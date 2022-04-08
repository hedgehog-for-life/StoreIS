using SautinSoft.Document;
using Store.Controllers;
using Store.DataBase.Context;
using Store.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.Windows.ForUser
{
    public partial class OrderWindow : Form
    {
        private Dictionary<Panel, Order> currOrders;
        private Dictionary<Panel, Order> archivedOrders;

        private stuff_shopContext db;

        private OrderController orderController;
        private OrderGoodController orderGoodController;

        private PersonController personController;

        private StreetController streetController;
        private RegionController regionController;

        private Person user;

        public OrderWindow(string userEmail)
        {
            InitializeComponent();
            personController = new PersonController();
            user = personController.FindPersonByEmail(userEmail);

            currOrders = new Dictionary<Panel, Order>();
            archivedOrders = new Dictionary<Panel, Order>();

            db = new stuff_shopContext();
            orderController = new OrderController(db);
            orderGoodController = new OrderGoodController(db);

            streetController = new StreetController(db);
            regionController = new RegionController(db);



            saveResumeFileDialog.DefaultExt = "pdf";
            saveResumeFileDialog.Filter = "Resume pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveResumeFileDialog.FilterIndex = 2;
            saveResumeFileDialog.FileName = "resume.pdf";
            saveResumeFileDialog.CheckFileExists = false;
            saveResumeFileDialog.CheckPathExists = true;
            saveResumeFileDialog.RestoreDirectory = true;
            saveResumeFileDialog.InitialDirectory = @"C:\\";




            RetrieveDataFromDB();
        }

        private void RetrieveDataFromDB()
        {
            List<Order> currentOrders = orderController.GetUserCurrentOrders(user);
            foreach (Order o in currentOrders)
                CreatePanelsForCurrentOrder(o);

            List<Order> archOrders = orderController.GetUserArchivedOrders(user);
            foreach (Order o in archOrders)
                CreatePanelsForArchivedOrder(o);
        }

        private void CreatePanelsForCurrentOrder(Order o)
        {
            Panel panelEl = new Panel();
            panelEl.Width = 505;
            panelEl.Height = 482;

            ListBox listBoxGoodsNames = new ListBox();
            listBoxGoodsNames.Height = 60;
            listBoxGoodsNames.Width = 194;
            listBoxGoodsNames.Location = new Point(10, 381);
            listBoxGoodsNames.Font = new Font("Cambria", 9.0f);

            ListBox listBoxGoodsPrices = new ListBox();
            listBoxGoodsPrices.Height = 60;
            listBoxGoodsPrices.Width = 77;
            listBoxGoodsPrices.Location = new Point(204, 381);
            listBoxGoodsPrices.Font = new Font("Cambria", 9.0f);

            ListBox listBoxGoodsPromotions = new ListBox();
            listBoxGoodsPromotions.Height = 60;
            listBoxGoodsPromotions.Width = 63;
            listBoxGoodsPromotions.Location = new Point(277, 381);
            listBoxGoodsPromotions.Font = new Font("Cambria", 9.0f);

            ListBox listBoxGoodsNumbers = new ListBox();
            listBoxGoodsNumbers.Width = 75;
            listBoxGoodsNumbers.Height = 60;
            listBoxGoodsNumbers.Location = new Point(340, 381);
            listBoxGoodsNumbers.Font = new Font("Cambria", 9.0f);

            ListBox listBoxGoodsFinalCount = new ListBox();
            listBoxGoodsFinalCount.Height = 60;
            listBoxGoodsFinalCount.Width = 78;
            listBoxGoodsFinalCount.Location = new Point(415, 381);
            listBoxGoodsFinalCount.Font = new Font("Cambria", 9.0f);

            int maxX = 0, maxY = 0;
            if (currOrders.Count > 0)
            {
                foreach (Panel p in currOrders.Keys)
                {
                    if (p.Location.Y == maxY)
                    {
                        maxY = p.Location.Y;
                        if (p.Location.X > maxX) maxX = p.Location.X;
                    }
                    else if (p.Location.Y > maxY)
                    {
                        maxY = p.Location.Y;
                        maxX = p.Location.X;
                    }
                }
            }
            if (maxX == 0) panelEl.Location = new Point(15, 13);
            else
            {
                if (maxX == 15) panelEl.Location = new Point(531, maxY);
                else panelEl.Location = new Point(15, maxY + 500);
            }

            panelEl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            listBoxGoodsNames.BorderStyle = listBoxGoodsPrices.BorderStyle = listBoxGoodsPromotions.BorderStyle = listBoxGoodsNumbers.BorderStyle = listBoxGoodsFinalCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            listBoxGoodsNames.BackColor = listBoxGoodsPrices.BackColor = listBoxGoodsPromotions.BackColor = listBoxGoodsNumbers.BackColor = listBoxGoodsFinalCount.BackColor = System.Drawing.Color.FromArgb(228, 223, 218);
            listBoxGoodsNames.HorizontalScrollbar = listBoxGoodsPrices.HorizontalScrollbar = listBoxGoodsPromotions.HorizontalScrollbar = listBoxGoodsNumbers.HorizontalScrollbar = listBoxGoodsFinalCount.HorizontalScrollbar = true;
            listBoxGoodsNames.Name = "OrderGoodsNames";
            listBoxGoodsPrices.Name = "OrderGoodsPrices";
            listBoxGoodsPromotions.Name = "OrderGoodsPromotions";
            listBoxGoodsNumbers.Name = "OrderGoodsNumbers";
            listBoxGoodsFinalCount.Name = "OrderGoodsFinalCount";

            tabPageCurrent.Controls.Add(panelEl);

            List<OrderGood> orderGoods = orderGoodController.GetOrderGoodsByOrder(o);
            foreach (OrderGood og in orderGoods)
            {
                listBoxGoodsNames.Items.Add(og.Good.Article + ", " + og.Good.GoodName);
                listBoxGoodsPrices.Items.Add(og.Good.Price);
                listBoxGoodsPromotions.Items.Add(og.Discount);
                int count = og.GoodNum + og.FreeGoodNum;
                listBoxGoodsNumbers.Items.Add(count);
                float discount = 1 - 0.01f * og.Discount;
                decimal finalCount = og.Good.Price * og.GoodNum * (decimal)discount;
                listBoxGoodsFinalCount.Items.Add(finalCount);
            }

            Label nameLabel = new Label();
            nameLabel.Text = "Заказ";
            nameLabel.Location = new Point(7, 8);
            nameLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            nameLabel.AutoSize = true;
            Label orderNumLabel = new Label();
            orderNumLabel.Text = o.OrderNumber;
            orderNumLabel.Location = new Point(55, 8);
            orderNumLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            orderNumLabel.AutoSize = true;
            orderNumLabel.Name = "OrderNumber";

            Label deliveryDateLabel = new Label();
            deliveryDateLabel.Text = "Дата доставки: ";
            deliveryDateLabel.Location = new Point(21, 299);
            deliveryDateLabel.Font = new Font("Cambria", 9.75f);
            deliveryDateLabel.AutoSize = true;
            Label deliveryDate = new Label();
            deliveryDate.Text = o.DeliveryDate.ToShortDateString();
            deliveryDate.Location = new Point(123, 299);
            deliveryDate.Font = new Font("Cambria", 9f);
            deliveryDate.Name = "DeliveryDate";
            Label statusLabel = new Label();
            statusLabel.Text = "Статус: ";
            statusLabel.Location = new Point(7, 33);
            statusLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            statusLabel.AutoSize = true;
            //ComboBox statusCB = new ComboBox();
            //if (o.DeliveryMethod == 0)
            //{
            //    statusCB.Items.Add("Выполняется поиск курьера");
            //    statusCB.Items.Add("Найден курьер");
            //}
            //statusCB.Items.Add("Подготавливается к отправке");
            //statusCB.Items.Add("В пути");
            //statusCB.Items.Add("Прибыл в город назначения");
            //if (o.DeliveryMethod == 1)
            //{
            //    statusCB.Items.Add("Прибыл в пункт самовывоза");
            //    statusCB.Items.Add("Получен и оплачен");

            //}
            //if (o.DeliveryMethod == 0)
            //{
            //    statusCB.Items.Add("Выполняется доставка по нужному адресу");
            //    statusCB.Items.Add("Доставлен и оплачен");
            //}
            //statusCB.Items.Add("Отменен");

            //statusCB.SelectedItem = statusCB.Items[o.OrderStatus];
            //statusCB.Font = new Font("Cambria", 9f);
            //statusCB.Location = new Point(69, 31);
            //statusCB.Width = 237;
            //statusCB.Height = 22;
            //statusCB.Name = "OrderStatus";
            //statusCB.SelectedIndexChanged += new EventHandler(StatusChanged);
            Label status = new Label();
            status.Location = new Point(69, 33);
            status.Font = new Font("Cambria", 9.75f);
            status.Name = "OrderStatus";
            status.AutoSize = true;

            Button cancelButton = new Button();
            cancelButton.Text = "Отменить";
            cancelButton.Click += new EventHandler(CancelOrder);
            cancelButton.Location = new Point(367, 8);
            cancelButton.Width = 128;
            cancelButton.Height = 29;

            if (o.DeliveryMethod == 0)
            {
                switch(o.OrderStatus)
                {
                    case 0:
                        status.Text = "Выполняется поиск курьера";
                        panelEl.Controls.Add(cancelButton);
                        break;
                    case 1:
                        status.Text = "Найден курьер";
                        panelEl.Controls.Add(cancelButton);
                        break;
                    case 2:
                        status.Text = "Подготавливается к отправке";
                        panelEl.Controls.Add(cancelButton);
                        break;
                    case 3:
                        status.Text = "В пути";
                        break;
                    case 4:
                        status.Text = "Прибыл в город назначения";
                        break;
                    case 5:
                        status.Text = "Выполняется доставка по нужному адресу";
                        break;
                    case 6:
                        status.Text = "Доставлен и оплачен";
                        break;
                    case 7:
                        status.Text = "Отменен";
                        break;
                }
            }
            else
            {
                switch (o.OrderStatus)
                {
                    case 0:
                        status.Text = "Подготавливается к отправке";
                        panelEl.Controls.Add(cancelButton);
                        break;
                    case 1:
                        status.Text = "В пути";
                        break;
                    case 2:
                        status.Text = "Прибыл в город назначения";
                        break;
                    case 3:
                        status.Text = "Прибыл в пункт самовывоза";
                        break;
                    case 4:
                        status.Text = "Получен и оплачен";
                        break;
                    case 5:
                        status.Text = "Отменен";
                        break;
                }
            }

            Label paymentMethodLabel = new Label();
            paymentMethodLabel.Text = "Способ оплаты: ";
            paymentMethodLabel.Location = new Point(7, 129);
            paymentMethodLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            paymentMethodLabel.AutoSize = true;
            Label paymentMethod = new Label();
            paymentMethod.Location = new Point(113, 129);
            paymentMethod.Font = new Font("Cambria", 9.75f);
            paymentMethod.AutoSize = true;
            if (o.PaymentMethod == 0)
                paymentMethod.Text = "Наличными при получении";
            else paymentMethod.Text = "Картой при получении";
            paymentMethod.Name = "PaymentMethod";

            Label deliveryLabel = new Label();
            deliveryLabel.Text = "Доставка";
            deliveryLabel.Location = new Point(7, 156);
            deliveryLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            deliveryLabel.AutoSize = true;

            Label goodsLabel = new Label();
            goodsLabel.Text = "Товары";
            goodsLabel.Location = new Point(7, 327);
            goodsLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            goodsLabel.AutoSize = true;
            Label articleLabel = new Label();

            articleLabel.Text = "Артикул, наименование";
            articleLabel.Location = new Point(21, 350);
            articleLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            articleLabel.AutoSize = true;
            Label costLabel = new Label();

            costLabel.Text = "Стоимость,\nруб";
            costLabel.Location = new Point(206, 350);
            costLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            costLabel.AutoSize = true;
            Label discountLabel = new Label();

            discountLabel.Text = "Скидка, %";
            discountLabel.Location = new Point(282, 350);
            discountLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            discountLabel.AutoSize = true;
            Label numbersLabel = new Label();

            numbersLabel.Text = "Количество,\nшт";
            numbersLabel.Location = new Point(346, 350);
            numbersLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            numbersLabel.AutoSize = true;
            Label totalLabel = new Label();

            totalLabel.Text = "Итого, руб";
            totalLabel.Location = new Point(425, 350);
            totalLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            totalLabel.AutoSize = true;

            Label deliveryMethodLabel = new Label();
            deliveryMethodLabel.Text = "Способ доставки: ";
            deliveryMethodLabel.Location = new Point(21, 182);
            deliveryMethodLabel.Font = new Font("Cambria", 9.75f);
            deliveryMethodLabel.AutoSize = true;
            Label deliveryMethodCB = new Label();
            //      deliveryMethodCB.Items.Add("Курьерская"); // 0
            //      deliveryMethodCB.Items.Add("Самовывоз"); // 1
            if (o.DeliveryMethod == 0)
                deliveryMethodCB.Text = "Курьерская";
            else deliveryMethodCB.Text = "Самовывоз";
            deliveryMethodCB.Font = new Font("Cambria", 9f);
            deliveryMethodCB.Location = new Point(136, 183);
            deliveryMethodCB.Name = "DeliveryMethod";

            Label buyerLabel = new Label();
            buyerLabel.Text = "Покупатель:";
            buyerLabel.Location = new Point(7, 102);
            buyerLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            buyerLabel.AutoSize = true;

            TextBox buyerTB = new TextBox();
            buyerTB.Text = o.User.PersonSurname + " " + o.User.PersonName + " " + o.User.PersonPatronymic + ", " + o.User.BirthDate.ToShortDateString() + ", +7" + o.User.Phone;
            buyerTB.Location = new Point(94, 103);
            buyerTB.Font = new Font("Cambria", 9f);
            buyerTB.Name = "Buyer";
            buyerTB.Width = 322;
            buyerTB.Height = 22;
            buyerTB.ReadOnly = true;
            buyerTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            buyerTB.BackColor = System.Drawing.Color.FromArgb(228, 223, 218);

            Label addressLabel = new Label();
            addressLabel.Text = "Адрес:";
            addressLabel.Location = new Point(21, 209);
            addressLabel.Font = new Font("Cambria", 9.75f);
            addressLabel.AutoSize = true;
            Label addressTB = new Label();
            Street street = streetController.GetStreet(o.Address.StreetId);
            DataBase.Entities.Region region = regionController.GetRegion(street.City.RegionId);
            addressTB.Text = o.Address.AddIndex + ", " + region.Country.CountryName + ", " + region.RegionName + ", " + street.City.CityName + ", " + street.StreetName + ", " + o.Address.House + ", " + o.Address.ApartmentNum;
            addressTB.Location = new Point(66, 210);
            addressTB.Font = new Font("Cambria", 9f);
            addressTB.Name = "DeliveryAddress";
            addressTB.AutoSize = true;

            Label delCostLabel = new Label();
            delCostLabel.Text = "Стоимость доставки, руб: ";
            delCostLabel.Location = new Point(21, 239);
            delCostLabel.Font = new Font("Cambria", 9.75f);
            delCostLabel.AutoSize = true;
            Label delCostTB = new Label();
            delCostTB.Text = o.DeliveryPrice.ToString();
            delCostTB.Location = new Point(187, 240);
            delCostTB.Font = new Font("Cambria", 9f);
            delCostTB.Name = "DeliveryCost";

            Label courierLabel = new Label();
            courierLabel.Text = "Курьер: ";
            courierLabel.Location = new Point(21, 269);
            courierLabel.Font = new Font("Cambria", 9.75f);
            courierLabel.AutoSize = true;
            Label courierTB = new Label();
            if (o.Courier != null)
                courierTB.Text = o.Courier.PersonSurname + " " + o.Courier.PersonName + " " + o.Courier.PersonPatronymic;
            courierTB.Location = new Point(79, 270);
            courierTB.Font = new Font("Cambria", 9f);
            courierTB.Name = "Courier";
            courierTB.AutoSize = true;

            Label isPaidLabel = new Label();
            isPaidLabel.Text = "Подтвердить получение и оплату ";
            isPaidLabel.Location = new Point(7, 60);
            isPaidLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            isPaidLabel.AutoSize = true;
            CheckBox isPaidCB = new CheckBox();
            isPaidCB.Checked = o.Verified;
            isPaidCB.Name = "IsPaidOrder";
            isPaidCB.Location = new Point(220, 57);
            isPaidCB.CheckedChanged += new EventHandler(Verified);
            if (o.OrderStatus == 6 && o.DeliveryMethod == 0 || o.OrderStatus == 4 && o.DeliveryMethod == 1)
                isPaidCB.Enabled = true;
            else isPaidCB.Enabled = false;


            Label finalCostLabel = new Label();
            finalCostLabel.Text = "ИТОГО, руб ";
            finalCostLabel.Location = new Point(7, 453);
            finalCostLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            finalCostLabel.AutoSize = true;
            Label finalCostTB = new Label();
            finalCostTB.Text = o.TotalCost.ToString();
            finalCostTB.Location = new Point(400, 453);
            finalCostTB.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            finalCostTB.Name = "FinalCost";
            finalCostTB.Width = 80;
            finalCostTB.Height = 22;

     //       PictureBox pdfPB = new PictureBox();
     //       pdfPB.Height = pdfPB.Width = 20;
            //Bitmap imageE = new Bitmap(Properties.Resources.pdf, 20, 20);
            //pdfPB.Location = new Point(487, 33);
            //pdfPB.Image = imageE;
            //pdfPB.Click += new EventHandler(generatePDFButton_Click);


            panelEl.Controls.Add(finalCostLabel);
            panelEl.Controls.Add(finalCostTB);
            panelEl.Controls.Add(isPaidCB);
            panelEl.Controls.Add(isPaidLabel);
            panelEl.Controls.Add(addressLabel);
            panelEl.Controls.Add(addressTB);
            panelEl.Controls.Add(delCostLabel);
            panelEl.Controls.Add(delCostTB);
            panelEl.Controls.Add(courierTB);
            panelEl.Controls.Add(courierLabel);
            panelEl.Controls.Add(buyerLabel);
            panelEl.Controls.Add(buyerTB);
            panelEl.Controls.Add(deliveryMethodLabel);
            panelEl.Controls.Add(deliveryMethodCB);
            panelEl.Controls.Add(totalLabel);
            panelEl.Controls.Add(numbersLabel);
            panelEl.Controls.Add(discountLabel);
            panelEl.Controls.Add(costLabel);
            panelEl.Controls.Add(articleLabel);
            panelEl.Controls.Add(goodsLabel);
            panelEl.Controls.Add(deliveryLabel);
            panelEl.Controls.Add(status);
            panelEl.Controls.Add(statusLabel);
            panelEl.Controls.Add(paymentMethodLabel);
            panelEl.Controls.Add(paymentMethod);
            panelEl.Controls.Add(deliveryDateLabel);
            panelEl.Controls.Add(deliveryDate);
            panelEl.Controls.Add(nameLabel);
            panelEl.Controls.Add(orderNumLabel);

        //    panelEl.Controls.Add(pdfPB);
            panelEl.Controls.Add(listBoxGoodsNames);
            panelEl.Controls.Add(listBoxGoodsPrices);
            panelEl.Controls.Add(listBoxGoodsPromotions);
            panelEl.Controls.Add(listBoxGoodsNumbers);
            panelEl.Controls.Add(listBoxGoodsFinalCount);

            currOrders.Add(panelEl, o);
        }

        private void CreatePanelsForArchivedOrder(Order o)
        {
            Panel panelEl = new Panel();
            panelEl.Width = 505;
            panelEl.Height = 482;

            ListBox listBoxGoodsNames = new ListBox();
            listBoxGoodsNames.Height = 60;
            listBoxGoodsNames.Width = 194;
            listBoxGoodsNames.Location = new Point(10, 381);
            listBoxGoodsNames.Font = new Font("Cambria", 9.0f);

            ListBox listBoxGoodsPrices = new ListBox();
            listBoxGoodsPrices.Height = 60;
            listBoxGoodsPrices.Width = 77;
            listBoxGoodsPrices.Location = new Point(204, 381);
            listBoxGoodsPrices.Font = new Font("Cambria", 9.0f);

            ListBox listBoxGoodsPromotions = new ListBox();
            listBoxGoodsPromotions.Height = 60;
            listBoxGoodsPromotions.Width = 63;
            listBoxGoodsPromotions.Location = new Point(277, 381);
            listBoxGoodsPromotions.Font = new Font("Cambria", 9.0f);

            ListBox listBoxGoodsNumbers = new ListBox();
            listBoxGoodsNumbers.Width = 75;
            listBoxGoodsNumbers.Height = 60;
            listBoxGoodsNumbers.Location = new Point(340, 381);
            listBoxGoodsNumbers.Font = new Font("Cambria", 9.0f);

            ListBox listBoxGoodsFinalCount = new ListBox();
            listBoxGoodsFinalCount.Height = 60;
            listBoxGoodsFinalCount.Width = 78;
            listBoxGoodsFinalCount.Location = new Point(415, 381);
            listBoxGoodsFinalCount.Font = new Font("Cambria", 9.0f);

            int maxX = 0, maxY = 0;
            if (archivedOrders.Count > 0)
            {
                foreach (Panel p in archivedOrders.Keys)
                {
                    if (p.Location.Y == maxY)
                    {
                        maxY = p.Location.Y;
                        if (p.Location.X > maxX) maxX = p.Location.X;
                    }
                    else if (p.Location.Y > maxY)
                    {
                        maxY = p.Location.Y;
                        maxX = p.Location.X;
                    }
                }
            }
            if (maxX == 0) panelEl.Location = new Point(15, 13);
            else
            {
                if (maxX == 15) panelEl.Location = new Point(531, maxY);
                else panelEl.Location = new Point(15, maxY + 500);
            }

            panelEl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            listBoxGoodsNames.BorderStyle = listBoxGoodsPrices.BorderStyle = listBoxGoodsPromotions.BorderStyle = listBoxGoodsNumbers.BorderStyle = listBoxGoodsFinalCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            listBoxGoodsNames.BackColor = listBoxGoodsPrices.BackColor = listBoxGoodsPromotions.BackColor = listBoxGoodsNumbers.BackColor = listBoxGoodsFinalCount.BackColor = System.Drawing.Color.FromArgb(228, 223, 218);
            listBoxGoodsNames.HorizontalScrollbar = listBoxGoodsPrices.HorizontalScrollbar = listBoxGoodsPromotions.HorizontalScrollbar = listBoxGoodsNumbers.HorizontalScrollbar = listBoxGoodsFinalCount.HorizontalScrollbar = true;
            listBoxGoodsNames.Name = "OrderGoodsNames";
            listBoxGoodsPrices.Name = "OrderGoodsPrices";
            listBoxGoodsPromotions.Name = "OrderGoodsPromotions";
            listBoxGoodsNumbers.Name = "OrderGoodsNumbers";
            listBoxGoodsFinalCount.Name = "OrderGoodsFinalCount";

            tabPageArchived.Controls.Add(panelEl);

            List<OrderGood> orderGoods = orderGoodController.GetOrderGoodsByOrder(o);
            foreach (OrderGood og in orderGoods)
            {
                listBoxGoodsNames.Items.Add(og.Good.Article + ", " + og.Good.GoodName);
                listBoxGoodsPrices.Items.Add(og.Good.Price);
                listBoxGoodsPromotions.Items.Add(og.Discount);
                int count = og.GoodNum + og.FreeGoodNum;
                listBoxGoodsNumbers.Items.Add(count);
                float discount = 1 - 0.01f * og.Discount;
                decimal finalCount = og.Good.Price * og.GoodNum * (decimal)discount;
                listBoxGoodsFinalCount.Items.Add(finalCount);
            }

            Label nameLabel = new Label();
            nameLabel.Text = "Заказ";
            nameLabel.Location = new Point(7, 8);
            nameLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            nameLabel.AutoSize = true;
            Label orderNumLabel = new Label();
            orderNumLabel.Text = o.OrderNumber;
            orderNumLabel.Location = new Point(55, 8);
            orderNumLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            orderNumLabel.AutoSize = true;
            orderNumLabel.Name = "OrderNumber";

            Label deliveryDateLabel = new Label();
            deliveryDateLabel.Text = "Дата доставки: ";
            deliveryDateLabel.Location = new Point(21, 299);
            deliveryDateLabel.Font = new Font("Cambria", 9.75f);
            deliveryDateLabel.AutoSize = true;
            Label deliveryDate = new Label();
            deliveryDate.Text = o.DeliveryDate.ToShortDateString();
            deliveryDate.Location = new Point(123, 299);
            deliveryDate.Font = new Font("Cambria", 9f);
            deliveryDate.Name = "DeliveryDate";
            Label statusLabel = new Label();
            statusLabel.Text = "Статус: ";
            statusLabel.Location = new Point(7, 33);
            statusLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            statusLabel.AutoSize = true;
            //ComboBox statusCB = new ComboBox();
            //if (o.DeliveryMethod == 0)
            //{
            //    statusCB.Items.Add("Выполняется поиск курьера");
            //    statusCB.Items.Add("Найден курьер");
            //}
            //statusCB.Items.Add("Подготавливается к отправке");
            //statusCB.Items.Add("В пути");
            //statusCB.Items.Add("Прибыл в город назначения");
            //if (o.DeliveryMethod == 1)
            //{
            //    statusCB.Items.Add("Прибыл в пункт самовывоза");
            //    statusCB.Items.Add("Получен и оплачен");

            //}
            //if (o.DeliveryMethod == 0)
            //{
            //    statusCB.Items.Add("Выполняется доставка по нужному адресу");
            //    statusCB.Items.Add("Доставлен и оплачен");
            //}
            //statusCB.Items.Add("Отменен");

            //statusCB.SelectedItem = statusCB.Items[o.OrderStatus];
            //statusCB.Font = new Font("Cambria", 9f);
            //statusCB.Location = new Point(69, 31);
            //statusCB.Width = 237;
            //statusCB.Height = 22;
            //statusCB.Name = "OrderStatus";
            //statusCB.SelectedIndexChanged += new EventHandler(StatusChanged);
            Label status = new Label();
            status.Location = new Point(69, 33);
            status.Font = new Font("Cambria", 9.75f);
            status.Name = "OrderStatus";
            status.AutoSize = true;

            if (o.DeliveryMethod == 0)
            {
                switch (o.OrderStatus)
                {
                    case 0:
                        status.Text = "Выполняется поиск курьера";
                        break;
                    case 1:
                        status.Text = "Найден курьер";
                        break;
                    case 2:
                        status.Text = "Подготавливается к отправке";
                        break;
                    case 3:
                        status.Text = "В пути";
                        break;
                    case 4:
                        status.Text = "Прибыл в город назначения";
                        break;
                    case 5:
                        status.Text = "Выполняется доставка по нужному адресу";
                        break;
                    case 6:
                        status.Text = "Доставлен и оплачен";
                        break;
                    case 7:
                        status.Text = "Отменен";
                        break;
                }
            }
            else
            {
                switch (o.OrderStatus)
                {
                    case 0:
                        status.Text = "Подготавливается к отправке";
                        break;
                    case 1:
                        status.Text = "В пути";
                        break;
                    case 2:
                        status.Text = "Прибыл в город назначения";
                        break;
                    case 3:
                        status.Text = "Прибыл в пункт самовывоза";
                        break;
                    case 4:
                        status.Text = "Получен и оплачен";
                        break;
                    case 5:
                        status.Text = "Отменен";
                        break;
                }
            }

            Label paymentMethodLabel = new Label();
            paymentMethodLabel.Text = "Способ оплаты: ";
            paymentMethodLabel.Location = new Point(7, 129);
            paymentMethodLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            paymentMethodLabel.AutoSize = true;
            Label paymentMethod = new Label();
            paymentMethod.Location = new Point(113, 129);
            paymentMethod.Font = new Font("Cambria", 9.75f);
            paymentMethod.AutoSize = true;
            if (o.PaymentMethod == 0)
                paymentMethod.Text = "Наличными при получении";
            else paymentMethod.Text = "Картой при получении";
            paymentMethod.Name = "PaymentMethod";
            //ComboBox paymentMethodCB = new ComboBox();
            //paymentMethodCB.Items.Add("Наличными при получении"); // 0
            //paymentMethodCB.Items.Add("Картой при получении"); // 1
            //paymentMethodCB.SelectedItem = paymentMethodCB.Items[order.PaymentMethod];
            //paymentMethodCB.Font = new Font("Cambria", 9f);
            //paymentMethodCB.Location = new Point(113, 85);
            //paymentMethodCB.Width = 182;
            //paymentMethodCB.Height = 22;
            //paymentMethodCB.Name = "PaymentMethod";
            //paymentMethodCB.SelectedIndexChanged += new EventHandler(PaymentMethodChanged);

            Label deliveryLabel = new Label();
            deliveryLabel.Text = "Доставка";
            deliveryLabel.Location = new Point(7, 156);
            deliveryLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            deliveryLabel.AutoSize = true;

            Label goodsLabel = new Label();
            goodsLabel.Text = "Товары";
            goodsLabel.Location = new Point(7, 327);
            goodsLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            goodsLabel.AutoSize = true;
            Label articleLabel = new Label();

            articleLabel.Text = "Артикул, наименование";
            articleLabel.Location = new Point(21, 350);
            articleLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            articleLabel.AutoSize = true;
            Label costLabel = new Label();

            costLabel.Text = "Стоимость,\nруб";
            costLabel.Location = new Point(206, 350);
            costLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            costLabel.AutoSize = true;
            Label discountLabel = new Label();

            discountLabel.Text = "Скидка, %";
            discountLabel.Location = new Point(282, 350);
            discountLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            discountLabel.AutoSize = true;
            Label numbersLabel = new Label();

            numbersLabel.Text = "Количество,\nшт";
            numbersLabel.Location = new Point(346, 350);
            numbersLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            numbersLabel.AutoSize = true;
            Label totalLabel = new Label();

            totalLabel.Text = "Итого, руб";
            totalLabel.Location = new Point(425, 350);
            totalLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            totalLabel.AutoSize = true;

            Label deliveryMethodLabel = new Label();
            deliveryMethodLabel.Text = "Способ доставки: ";
            deliveryMethodLabel.Location = new Point(21, 182);
            deliveryMethodLabel.Font = new Font("Cambria", 9.75f);
            deliveryMethodLabel.AutoSize = true;
            Label deliveryMethodCB = new Label();
            //      deliveryMethodCB.Items.Add("Курьерская"); // 0
            //      deliveryMethodCB.Items.Add("Самовывоз"); // 1
            if (o.DeliveryMethod == 0)
                deliveryMethodCB.Text = "Курьерская";
            else deliveryMethodCB.Text = "Самовывоз";
            deliveryMethodCB.Font = new Font("Cambria", 9f);
            deliveryMethodCB.Location = new Point(136, 183);
            deliveryMethodCB.Name = "DeliveryMethod";

            Label buyerLabel = new Label();
            buyerLabel.Text = "Покупатель:";
            buyerLabel.Location = new Point(7, 102);
            buyerLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            buyerLabel.AutoSize = true;

            TextBox buyerTB = new TextBox();
            buyerTB.Text = o.User.PersonSurname + " " + o.User.PersonName + " " + o.User.PersonPatronymic + ", " + o.User.BirthDate.ToShortDateString() + ", +7" + o.User.Phone;
            buyerTB.Location = new Point(94, 103);
            buyerTB.Font = new Font("Cambria", 9f);
            buyerTB.Name = "Buyer";
            buyerTB.Width = 322;
            buyerTB.Height = 22;
            buyerTB.ReadOnly = true;
            buyerTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            buyerTB.BackColor = System.Drawing.Color.FromArgb(228, 223, 218);

            Label addressLabel = new Label();
            addressLabel.Text = "Адрес:";
            addressLabel.Location = new Point(21, 209);
            addressLabel.Font = new Font("Cambria", 9.75f);
            addressLabel.AutoSize = true;
            Label addressTB = new Label();
            Street street = streetController.GetStreet(o.Address.StreetId);
            DataBase.Entities.Region region = regionController.GetRegion(street.City.RegionId);
            addressTB.Text = o.Address.AddIndex + ", " + region.Country.CountryName + ", " + region.RegionName + ", " + street.City.CityName + ", " + street.StreetName + ", " + o.Address.House + ", " + o.Address.ApartmentNum;
            addressTB.Location = new Point(66, 210);
            addressTB.Font = new Font("Cambria", 9f);
            addressTB.Name = "DeliveryAddress";
            addressTB.AutoSize = true;

            Label delCostLabel = new Label();
            delCostLabel.Text = "Стоимость доставки, руб: ";
            delCostLabel.Location = new Point(21, 239);
            delCostLabel.Font = new Font("Cambria", 9.75f);
            delCostLabel.AutoSize = true;
            Label delCostTB = new Label();
            delCostTB.Text = o.DeliveryPrice.ToString();
            delCostTB.Location = new Point(187, 240);
            delCostTB.Font = new Font("Cambria", 9f);
            delCostTB.Name = "DeliveryCost";

            Label courierLabel = new Label();
            courierLabel.Text = "Курьер: ";
            courierLabel.Location = new Point(21, 269);
            courierLabel.Font = new Font("Cambria", 9.75f);
            courierLabel.AutoSize = true;
            Label courierTB = new Label();
            if (o.Courier != null)
                courierTB.Text = o.Courier.PersonSurname + " " + o.Courier.PersonName + " " + o.Courier.PersonPatronymic;
            courierTB.Location = new Point(79, 270);
            courierTB.Font = new Font("Cambria", 9f);
            courierTB.Name = "Courier";
            courierTB.AutoSize = true;

            Label isPaidLabel = new Label();
            isPaidLabel.Text = "Получение и оплата подтверждены? ";
            isPaidLabel.Location = new Point(7, 60);
            isPaidLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            isPaidLabel.AutoSize = true;
            CheckBox isPaidCB = new CheckBox();
            isPaidCB.Checked = o.Verified;
            isPaidCB.Name = "IsPaidOrder";
            isPaidCB.Location = new Point(220, 57);
            isPaidCB.Enabled = false;


            Label finalCostLabel = new Label();
            finalCostLabel.Text = "ИТОГО, руб ";
            finalCostLabel.Location = new Point(7, 453);
            finalCostLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            finalCostLabel.AutoSize = true;
            Label finalCostTB = new Label();
            finalCostTB.Text = o.TotalCost.ToString();
            finalCostTB.Location = new Point(400, 453);
            finalCostTB.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            finalCostTB.Name = "FinalCost";
            finalCostTB.Width = 80;
            finalCostTB.Height = 22;

            PictureBox pdfPB = new PictureBox();
            pdfPB.Height = pdfPB.Width = 20;
            Bitmap imageE = new Bitmap(Properties.Resources.pdf, 20, 20);
            pdfPB.Location = new Point(473, 8);
            pdfPB.Image = imageE;
            pdfPB.Click += new EventHandler(GeneratePDFButton_Click);


            panelEl.Controls.Add(finalCostLabel);
            panelEl.Controls.Add(finalCostTB);
            panelEl.Controls.Add(isPaidCB);
            panelEl.Controls.Add(isPaidLabel);
            panelEl.Controls.Add(addressLabel);
            panelEl.Controls.Add(addressTB);
            panelEl.Controls.Add(delCostLabel);
            panelEl.Controls.Add(delCostTB);
            panelEl.Controls.Add(courierTB);
            panelEl.Controls.Add(courierLabel);
            panelEl.Controls.Add(buyerLabel);
            panelEl.Controls.Add(buyerTB);
            panelEl.Controls.Add(deliveryMethodLabel);
            panelEl.Controls.Add(deliveryMethodCB);
            panelEl.Controls.Add(totalLabel);
            panelEl.Controls.Add(numbersLabel);
            panelEl.Controls.Add(discountLabel);
            panelEl.Controls.Add(costLabel);
            panelEl.Controls.Add(articleLabel);
            panelEl.Controls.Add(goodsLabel);
            panelEl.Controls.Add(deliveryLabel);
            panelEl.Controls.Add(status);
            panelEl.Controls.Add(statusLabel);
            panelEl.Controls.Add(paymentMethodLabel);
            panelEl.Controls.Add(paymentMethod);
            panelEl.Controls.Add(deliveryDateLabel);
            panelEl.Controls.Add(deliveryDate);
            panelEl.Controls.Add(nameLabel);
            panelEl.Controls.Add(orderNumLabel);

                panelEl.Controls.Add(pdfPB);
            panelEl.Controls.Add(listBoxGoodsNames);
            panelEl.Controls.Add(listBoxGoodsPrices);
            panelEl.Controls.Add(listBoxGoodsPromotions);
            panelEl.Controls.Add(listBoxGoodsNumbers);
            panelEl.Controls.Add(listBoxGoodsFinalCount);

            archivedOrders.Add(panelEl, o);
        }

        private void GeneratePDFButton_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                Control control = (Control)sender;
                Panel panel = (Panel)control.Parent;

                DocumentCore dc = new DocumentCore();
                DocumentBuilder db = new DocumentBuilder(dc);

                Section section = db.Document.Sections[0];
                section.PageSetup.PaperType = PaperType.A4;

                Control[] elsList = panel.Controls.Find("OrderNumber", true);
                Label orderLabel = (Label)elsList[0];

                saveResumeFileDialog.FileName = "Order" + orderLabel.Text + "Info.pdf";

                db.CharacterFormat.FontName = "Times New Roman";
                db.CharacterFormat.Size = 14;
                db.CharacterFormat.FontColor = SautinSoft.Document.Color.Black;
                db.CharacterFormat.Bold = true;
                db.Writeln("Заказ " + orderLabel.Text);
                db.CharacterFormat.Bold = false;

                db.CharacterFormat.Italic = true;
                db.Write("Статус: ");
                db.CharacterFormat.Italic = false;
                elsList = panel.Controls.Find("OrderStatus", true);
                Label orderCB = (Label)elsList[0];
                db.Writeln(orderCB.Text.ToString());

                db.CharacterFormat.Italic = true;
                db.Write("Покупатель: ");
                db.CharacterFormat.Italic = false;
                elsList = panel.Controls.Find("Buyer", true);
                Label orderTB;
                TextBox helpTB = (TextBox)elsList[0];
                db.Writeln(helpTB.Text);

                db.CharacterFormat.Italic = true;
                db.Write("Способ оплаты: ");
                db.CharacterFormat.Italic = false;
                elsList = panel.Controls.Find("PaymentMethod", true);
                orderCB = (Label)elsList[0];
                db.Writeln(orderCB.Text.ToString());

                db.CharacterFormat.Italic = true;
                db.Write("Доставка");
                db.CharacterFormat.Italic = false;
                elsList = panel.Controls.Find("DeliveryMethod", true);
                orderCB = (Label)elsList[0];
                db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                db.InsertSpecialCharacter(SpecialCharacterType.Tab);
                db.Write("Способ доставки: " + orderCB.Text.ToString());
                elsList = panel.Controls.Find("DeliveryAddress", true);
                orderTB = (Label)elsList[0];
                db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                db.InsertSpecialCharacter(SpecialCharacterType.Tab);
                db.Write("Адрес: " + orderTB.Text);
                elsList = panel.Controls.Find("DeliveryCost", true);
                orderTB = (Label)elsList[0];
                db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                db.InsertSpecialCharacter(SpecialCharacterType.Tab);
                db.Write("Стоимость доставки: " + orderTB.Text + " руб.");
                elsList = panel.Controls.Find("Courier", true);
                orderTB = (Label)elsList[0];
                db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                db.InsertSpecialCharacter(SpecialCharacterType.Tab);
                db.Write("Курьер: " + orderTB.Text);           
                elsList = panel.Controls.Find("DeliveryDate", true);
               Label orderDateTime = (Label)elsList[0];
                db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                db.InsertSpecialCharacter(SpecialCharacterType.Tab);
                db.Writeln("Дата доставки: " + orderDateTime.Text);
                db.CharacterFormat.Italic = true;
                db.Write("Товары");
                db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                elsList = panel.Controls.Find("OrderGoodsNames", true);
                ListBox orderLBNames = (ListBox)elsList[0];
                elsList = panel.Controls.Find("OrderGoodsPrices", true);
                ListBox orderLBPrices = (ListBox)elsList[0];
                elsList = panel.Controls.Find("OrderGoodsPromotions", true);
                ListBox orderLBDiscounts = (ListBox)elsList[0];
                elsList = panel.Controls.Find("OrderGoodsNumbers", true);
                ListBox orderLBNumbers = (ListBox)elsList[0];
                elsList = panel.Controls.Find("OrderGoodsFinalCount", true);
                ListBox orderLBFinalCounts = (ListBox)elsList[0];
                for (int i = 0; i < orderLBNames.Items.Count; i++)
                {
                    db.CharacterFormat.Italic = false;
                    db.Write((i + 1) + ". " + orderLBNames.Items[i]);
                    db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                    db.InsertSpecialCharacter(SpecialCharacterType.Tab);
                    db.CharacterFormat.Italic = true;
                    db.Write("Стоимость товара (без учета скидок), руб.: ");
                    db.CharacterFormat.Italic = false;
                    db.Write(orderLBPrices.Items[i].ToString());
                    db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                    db.InsertSpecialCharacter(SpecialCharacterType.Tab);
                    db.CharacterFormat.Italic = true;
                    db.Write("Скидка на товар, %: ");
                    db.CharacterFormat.Italic = false;
                    db.Write(orderLBDiscounts.Items[i].ToString());
                    db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                    db.InsertSpecialCharacter(SpecialCharacterType.Tab);
                    db.CharacterFormat.Italic = true;
                    db.Write("Количество доставляемого товара, шт.: ");
                    db.CharacterFormat.Italic = false;
                    db.Write(orderLBNumbers.Items[i].ToString());
                    db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                    db.InsertSpecialCharacter(SpecialCharacterType.Tab);
                    db.CharacterFormat.Italic = true;
                    db.Write("Итоговая стоимость в заказе, руб.: ");
                    db.CharacterFormat.Italic = false;
                    if (i < orderLBNames.Items.Count - 1)
                    {
                        db.Write(orderLBFinalCounts.Items[i].ToString());
                        db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                    }
                    else db.Writeln(orderLBFinalCounts.Items[i].ToString());
                }
                db.CharacterFormat.Italic = true;
                db.Write("Подтвержден: ");
                db.CharacterFormat.Italic = false;
                elsList = panel.Controls.Find("IsPaidOrder", true);
                CheckBox orderCheckBox = (CheckBox)elsList[0];
                if (orderCheckBox.Checked) db.Writeln("да");
                else db.Writeln("нет");
                elsList = panel.Controls.Find("FinalCost", true);
                orderTB = (Label)elsList[0];
                db.CharacterFormat.Bold = true;
                db.Write("ИТОГО, руб. " + orderTB.Text);
                //dc.Save(@"OrderInfo.pdf", new PdfSaveOptions()
                //{ Compliance = PdfCompliance.PDF_A1a });
                //System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(@"OrderInfo.pdf") { UseShellExecute = true });
               

                if (saveResumeFileDialog.ShowDialog() == DialogResult.OK)
                {
                //    File.WriteAllBytes(saveResumeFileDialog.FileName, newEmpApp.Resume);
                    dc.Save(saveResumeFileDialog.FileName, new PdfSaveOptions()
                    { Compliance = PdfCompliance.PDF_A1a });
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(saveResumeFileDialog.FileName) { UseShellExecute = true });
                }

            }
        }

        private void CancelOrder(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Panel panel = (Panel)button.Parent;

            Order order;
            if (currOrders.TryGetValue(panel, out order))
            {
                if (order.DeliveryMethod == 0)
                    order.OrderStatus = 7;
                else order.OrderStatus = 5;

                orderController.UpdateOrder(order);

                SuccessWindow successWindow = new SuccessWindow("Заказ успешно отменен");

                currOrders.Clear();
                tabPageCurrent.Controls.Clear();
                List<Order> currentOrders = orderController.GetUserCurrentOrders(user);
                foreach (Order o in currentOrders)
                    CreatePanelsForCurrentOrder(o);
            }
        }

        private void Verified(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            Panel panel = (Panel)checkBox.Parent;
            if(checkBox.Checked)
            {
                Order order;
                if(currOrders.TryGetValue(panel, out order)) {
                    order.Verified = true;
                    checkBox.Enabled = false;

                    orderController.UpdateOrder(order);

                    currOrders.Clear();
                    tabPageCurrent.Controls.Clear();
                    List<Order> currentOrders = orderController.GetUserCurrentOrders(user);
                    foreach (Order o in currentOrders)
                        CreatePanelsForCurrentOrder(o);
                    archivedOrders.Clear();
                    List<Order> orders = orderController.GetUserArchivedOrders(user);
                    foreach (Order o in orders)
                        CreatePanelsForArchivedOrder(o);
                }
            }
        }


        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxLogOut_Click(object sender, EventArgs e)
        {
            LoginForm loginWindow = new LoginForm();
            loginWindow.Show();
            this.Hide();
        }

        private void buttonWatchThroughItems_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow(user.Email);
            mainWindow.Show();
            this.Hide();
        }

        private void buttonWork_Click(object sender, EventArgs e)
        {
            JobAppWindow jobAppWindow = new JobAppWindow(user.Email);
            jobAppWindow.Show();
            this.Hide();
        }

        private void buttonQuestion_Click(object sender, EventArgs e)
        {
            QuestionWindow questionWindow = new QuestionWindow(user.Email);
            questionWindow.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShoppingCartWindow shoppingCartWindow = new ShoppingCartWindow(user.Email);
            shoppingCartWindow.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchResultWindow searchResultWindow = new SearchResultWindow(this, textBoxValue.Text, checkBoxHavePromotions.Checked, user.Email);
            searchResultWindow.Show();
            this.Hide();
        }
    }
}
