using MySql.Data.MySqlClient;
using Store.Controllers;
using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SautinSoft.Document;
using Region = Store.DataBase.Entities.Region;
using System.Globalization;

namespace Store.Windows.ForAdmin
{
    public partial class GoodInfoWindow : Form
    {
        private GoodController goodController;
        private CategoryController categoryController;
        private CollectionController collectionController;
        private GoodCollectionController goodColController;
        private WriteOffController writeOffController;
        private WriteOffReasonController writeOffReasonController;
        private PromotionController promotionController;
        private GoodPromotionController goodPromotionController;
        private OrderController orderController;
        private OrderGoodController orderGoodController;
        private StreetController streetController;
        private RegionController regionController;
        private AddressController addressController;
        private CityController cityController;
        private CountryController countryController;
        private PersonController personController;
        private ReviewController reviewController;

        private List<int> elsIdForDeleting;
        private List<int> goodsToColsToDelete, goodsToColsToAdd; 
        private Dictionary<int, Good> elsForAdding;
        private Dictionary<int, Good> elsForUpdating;
        private Dictionary<Panel, Category> cPanels;
        private Dictionary<Panel, Collection> colPanels;
        private Dictionary<Panel, Promotion> promPanels;
        private Dictionary<Panel, Order> orderPanels;
        private Dictionary<Panel, Address> addressPanels;
        private BindingList<Good> goods;
        private BindingList<Review> reviews;
        private StringValidator validator;
        private InputValidator iValidator;
        private DateTimeValidator dtValidator;
        private DigitClassesValidator dValidator;
        private int currentRow;
        private string userEmail;
        private int locX, locY, locXcol, locYcol, columnNum, columnPromNum, promFieldsNum, locXprom, locYprom;
        private int locXorder, locYorder;
        private Category currentCategory;
        private Collection currentCollection;
        private Promotion currentPromotion;
        private Address currentAddress;
        private List<GoodCollection> tracked;
        private DataGridViewRow previous = null, previousRowReasons = null;
        private int correctPromInputs = 0;

        private CultureInfo provider = CultureInfo.InvariantCulture;

        private Dictionary<DataGridViewRow, List<int>> newRows;

        private stuff_shopContext db, db1;

        public GoodInfoWindow()
        {
            StartingActions();


        }

        public GoodInfoWindow(string userEmail)
        {
            this.userEmail = userEmail;
            StartingActions();


        }

        private void StartingActions()
        {
            InitializeComponent();
            db = new stuff_shopContext();
            db1 = new stuff_shopContext();
            

            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "Resume pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.FileName = "order_info.pdf";
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.InitialDirectory = @"C:\\";
            // dataGridViewGood.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(DataGridView1_DataError);

            validator = new StringValidator();
            dtValidator = new DateTimeValidator();
            iValidator = new InputValidator();
            dValidator = new DigitClassesValidator();

            nColNameTB.KeyPress += new KeyPressEventHandler(nCategoryNameTB_KeyPress);
            goodPromNumTB.KeyPress += new KeyPressEventHandler(promDiscountTB_KeyPress);
            freeGoodPromNumTB.KeyPress += new KeyPressEventHandler(promDiscountTB_KeyPress);

            addButton.Enabled = false;
            //   addColBtn.Enabled = false;
            buttonAddCol.Enabled = false;

            elsIdForDeleting = new List<int>();
            elsForAdding = new Dictionary<int, Good>();
            elsForUpdating = new Dictionary<int, Good>();
            cPanels = new Dictionary<Panel, Category>();
            colPanels = new Dictionary<Panel, Collection>();
            promPanels = new Dictionary<Panel, Promotion>();
            goodsToColsToDelete = new List<int>();
            goodsToColsToAdd = new List<int>();
            newRows = new Dictionary<DataGridViewRow, List<int>>();
            orderPanels = new Dictionary<Panel, Order>();
            addressPanels = new Dictionary<Panel, Address>();

              nColStatusCB.SelectedItem = nColStatusCB.Items[0];

            categoryController = new CategoryController(db);
            collectionController = new CollectionController(db);
            goodController = new GoodController(db);
            goodColController = new GoodCollectionController(db);
            writeOffController = new WriteOffController(db);
            writeOffReasonController = new WriteOffReasonController(db1);
            promotionController = new PromotionController(db1);
            goodPromotionController = new GoodPromotionController(db);
            orderController = new OrderController(db);
            orderGoodController = new OrderGoodController(db);
            streetController = new StreetController(db);
            regionController = new RegionController(db);
            addressController = new AddressController(db1);
            cityController = new CityController(db1);
            countryController = new CountryController(db1);
            personController = new PersonController();
            reviewController = new ReviewController(db1);
            RetrieveDataFromDB();

            Bitmap sizedImage = new Bitmap(pictureBoxIcon.Image, new Size(pictureBoxIcon.Width, pictureBoxIcon.Height));
            pictureBoxIcon.Image = sizedImage;

            sizedImage = new Bitmap(pictureBoxAvatar.Image, new Size(pictureBoxAvatar.Width, pictureBoxAvatar.Height));
            pictureBoxAvatar.Image = sizedImage;

            sizedImage = new Bitmap(pictureBoxExit.Image, new Size(pictureBoxExit.Width, pictureBoxExit.Height));
            pictureBoxExit.Image = sizedImage;

            sizedImage = new Bitmap(pictureBoxLogOut.Image, new Size(pictureBoxLogOut.Width, pictureBoxLogOut.Height));
            pictureBoxLogOut.Image = sizedImage;

            sizedImage = new Bitmap(PBSearchGoodForOrder.Image, new Size(PBSearchGoodForOrder.Width, PBSearchGoodForOrder.Height));
            PBSearchGoodForOrder.Image = sizedImage;

            panelGoodsOrderPicker.Visible = false;
        }

        // Работа с получением больших объемов данных из БД
        private void RetrieveDataFromDB()
        {
            goods = new BindingList<Good>(goodController.GetGoods());
            //      dataGridViewGood.DataSource = goods;

            dataGridViewGoodInfo.DataSource = goods;
            dataGridViewGoodInfo.Focus();

            ColumnGoodReleaseDate.DefaultCellStyle.Format = "dd.MM.yyyy";

            BindingList<WriteOff> writeOffs = new BindingList<WriteOff>(writeOffController.GetWriteOffs());
            dataGridViewWriteOffs.DataSource = writeOffs;

            BindingList<WriteOffReason> reasons = new BindingList<WriteOffReason>(writeOffReasonController.GetWriteOffReasons());
            dataGridViewWriteOffReasons.DataSource = reasons;

            List<Collection> collections;

            locX = 378;
            locY = 18;

            locXcol = 308;
            locYcol = 18;
            columnNum = 0;

            locXorder = 5;
            locYorder = 5;

            foreach (WriteOffReason r in reasons)
            {
                ColumnReason.Items.Add(r.ReasonName);
            } 
            ColumnWriteOffStatus.Items.Add("Составляется необх. документация"); // 0
            ColumnWriteOffStatus.Items.Add("Составлена необх. документация"); // 1
            ColumnWriteOffStatus.Items.Add("Проведена проверка комиссией"); // 2
            ColumnWriteOffStatus.Items.Add("Подписаны документы"); // 3
            ColumnWriteOffStatus.Items.Add("Товар списан"); // 4

            List<Category> categories = categoryController.GetCategories();
            foreach (Category c in categories)
            {
                c.Good = goodController.GetGoodsByCategory(c);
            //    AddElToCategoryCB(c.CName);

                ColumnGoodCategory.Items.Add(c.CName);

                CreatePanelForCategory(c);


            }

            collections = collectionController.GetAllCollections();
            foreach(Collection c in collections)
            {
                CreatePanelForCollection(c);
            }

            List<Promotion> promotions = promotionController.GetPromotions();
            locXprom = 325;
            locYprom = 20;
            columnPromNum = 0;
            promFieldsNum = 0;

            buttonAddProm.Enabled = false;
            foreach (Promotion p in promotions)
            {
                CreatePanelForPromotion(p);

            }
            foreach (Good g in goods)
                goodsPromCLB.Items.Add(g.Article + ", " + g.GoodName);
            dateTimePickerPromStart.Value = DateTime.Now;
            dateTimePickerPromEnd.Value = DateTime.Now;

            List<Order> orders = orderController.GetOrders();
            foreach (Order o in orders)
            {
                CreatePanelForOrder(o);
            }

            List<Address> addresses = addressController.GetAllAddresses();
            foreach (Address a in addresses)
            {
                CreatePanelForAddress(a);
            }
            comboBoxAddress.Items.Add("Действующий пункт самовывоза");
            comboBoxAddress.Items.Add("Неактивный пункт самовывоза");
            comboBoxAddress.SelectedItem = comboBoxAddress.Items[0];

            reviews = new BindingList<Review>(reviewController.GetAllReviews());
            dataGridViewReviews.DataSource = reviews;
        }

        private void CreatePanelForAddress(Address address)
        {
            Panel panelEl = new Panel();
            panelEl.Height = 231;
            panelEl.Width = 329;

            Street street = address.Street;
            City city = cityController.GetCity(street.CityId);
            DataBase.Entities.Region region = city.Region;
            Country country = countryController.GetCountry(region.CountryId);


            int maxX = 0, maxY = 0;
            if (colPanels.Count > 0)
            {
                foreach (Panel a in addressPanels.Keys)
                {
                    if (a.Location.Y == maxY)
                    {
                        maxY = a.Location.Y;
                        if (a.Location.X > maxX) maxX = a.Location.X;
                    }
                    else if (a.Location.Y > maxY)
                    {
                        maxY = a.Location.Y;
                        maxX = a.Location.X;
                    }
                }
            }
            if (maxX == 0) panelEl.Location = new Point(297, 34);
            else
            {
                if (maxX == 297) panelEl.Location = new Point(674, maxY);
                else panelEl.Location = new Point(297, maxY + 270);
            }

            panelEl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tabPageAddresses.Controls.Add(panelEl);

            Label indexLabel = new Label();
            indexLabel.Text = "Индекс";
            indexLabel.Location = new Point(7, 38);
            indexLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            indexLabel.AutoSize = true;
            Label countryLabel = new Label();
            countryLabel.Text = "Страна";
            countryLabel.Location = new Point(7, 63);
            countryLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            countryLabel.AutoSize = true;
            Label regionLabel = new Label();
            regionLabel.Text = "Регион";
            regionLabel.Location = new Point(7, 88);
            regionLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            regionLabel.AutoSize = true;
            Label cityLabel = new Label();
            cityLabel.Text = "Город";
            cityLabel.Location = new Point(7, 115);
            cityLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            cityLabel.AutoSize = true;
            Label streetLabel = new Label();
            streetLabel.Text = "Улица";
            streetLabel.Location = new Point(7, 144);
            streetLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            streetLabel.AutoSize = true;
            Label houseLabel = new Label();
            houseLabel.Text = "Дом";
            houseLabel.Location = new Point(7, 174);
            houseLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            houseLabel.AutoSize = true;
            Label appartmentLabel = new Label();
            appartmentLabel.Text = "Квартира";
            appartmentLabel.Location = new Point(7, 202);
            appartmentLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            appartmentLabel.AutoSize = true;

            Label indexValLabel = new Label();
            indexValLabel.Text = address.AddIndex;
            indexValLabel.Location = new Point(88, 38);
            indexValLabel.Font = new Font("Cambria", 9.75f);
            indexValLabel.Name = "Index";
            indexValLabel.AutoSize = true;
            indexValLabel.Width = 226;
            indexValLabel.Height = 15;
            indexValLabel.TextAlign = ContentAlignment.MiddleRight;
            Label countryValLabel = new Label();
            countryValLabel.Text = country.CountryName;
            countryValLabel.Location = new Point(88, 63);
            countryValLabel.Font = new Font("Cambria", 9.75f);
            countryValLabel.Name = "Country";
            countryValLabel.AutoSize = true;
            countryValLabel.Width = 226;
            countryValLabel.Height = 15;
            countryValLabel.TextAlign = ContentAlignment.MiddleRight;
            Label regionValLabel = new Label();
            regionValLabel.Text = region.RegionName;
            regionValLabel.Location = new Point(88, 88);
            regionValLabel.Font = new Font("Cambria", 9.75f);
            regionValLabel.Name = "Region";
            regionValLabel.AutoSize = true;
            regionValLabel.Width = 226;
            regionValLabel.Height = 15;
            regionValLabel.TextAlign = ContentAlignment.MiddleRight;
            Label cityValLabel = new Label();
            cityValLabel.Text = city.CityName;
            cityValLabel.Location = new Point(88, 115);
            cityValLabel.Font = new Font("Cambria", 9.75f);
            cityValLabel.Name = "City";
            cityValLabel.AutoSize = true;
            cityValLabel.Width = 226;
            cityValLabel.Height = 15;
            cityValLabel.TextAlign = ContentAlignment.MiddleRight;
            Label streetValLabel = new Label();
            streetValLabel.Text = street.StreetName;
            streetValLabel.Location = new Point(88, 144);
            streetValLabel.Font = new Font("Cambria", 9.75f);
            streetValLabel.Name = "Street";
            streetValLabel.AutoSize = true;
            streetValLabel.Width = 226;
            streetValLabel.Height = 15;
            streetValLabel.TextAlign = ContentAlignment.MiddleRight;
            Label houseValLabel = new Label();
            houseValLabel.Text = address.House;
            houseValLabel.Location = new Point(88, 174);
            houseValLabel.Font = new Font("Cambria", 9.75f);
            houseValLabel.Name = "House";
            houseValLabel.AutoSize = true;
            houseValLabel.Width = 226;
            houseValLabel.Height = 15;
            houseValLabel.TextAlign = ContentAlignment.MiddleRight;
            Label appartmentValLabel = new Label();
            appartmentValLabel.Text = address.ApartmentNum;
            appartmentValLabel.Location = new Point(88, 202);
            appartmentValLabel.Font = new Font("Cambria", 9.75f);
            appartmentValLabel.Name = "Appartment";
            appartmentValLabel.AutoSize = true;
            appartmentValLabel.Width = 226;
            appartmentValLabel.Height = 15;
            appartmentValLabel.TextAlign = ContentAlignment.MiddleRight;

            Label typeLabel = new Label();
            typeLabel.AutoSize = true;
            switch (address.AddType)
            {
                case 0:
                    typeLabel.Text = "Действующий пункт самовывоза";
                    break;
                case 1:
                    typeLabel.Text = "Неактивный пункт самовывоза";
                    break;
            }
            typeLabel.Location = new Point(7, 8);
            typeLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            typeLabel.Name = "Type";

            PictureBox editPB = new PictureBox();
            PictureBox removePB = new PictureBox();
            editPB.Height = editPB.Width = removePB.Height = removePB.Width = 15;
            Bitmap imageE = new Bitmap(Properties.Resources.edit, 15, 15);
            editPB.Location = new Point(280, 8);
            editPB.Image = imageE;
            editPB.Click += new EventHandler(editAddress_Click);
            imageE = new Bitmap(Properties.Resources.delete, 15, 15);
            removePB.Location = new Point(299, 8);
            removePB.Image = imageE;
            removePB.Click += new EventHandler(removeAddressButton_Click);

            panelEl.Controls.Add(indexLabel);
            panelEl.Controls.Add(indexValLabel);
            panelEl.Controls.Add(countryLabel);
            panelEl.Controls.Add(countryValLabel);
            panelEl.Controls.Add(regionLabel);
            panelEl.Controls.Add(regionValLabel);
            panelEl.Controls.Add(cityLabel);
            panelEl.Controls.Add(cityValLabel);
            panelEl.Controls.Add(streetLabel);
            panelEl.Controls.Add(streetValLabel);
            panelEl.Controls.Add(houseLabel);
            panelEl.Controls.Add(houseValLabel);
            panelEl.Controls.Add(appartmentLabel);
            panelEl.Controls.Add(appartmentValLabel);

            panelEl.Controls.Add(typeLabel);
            panelEl.Controls.Add(editPB);
            panelEl.Controls.Add(removePB);

            addressPanels.Add(panelEl, address);
        }

        private void editAddress_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                Control control = (Control)sender;
                Panel panel = (Panel)control.Parent;
                
                Control[] elsList = panel.Controls.Find("Type", true);
                Label addressLabel = (Label)elsList[0];
                comboBoxAddress.SelectedItem = addressLabel.Text;

                elsList = panel.Controls.Find("Index", true);
                addressLabel = (Label)elsList[0];
                textBox12.Text = addressLabel.Text;

                elsList = panel.Controls.Find("Country", true);
                addressLabel = (Label)elsList[0];
                textBoxCountry.Text = addressLabel.Text;

                elsList = panel.Controls.Find("Region", true);
                addressLabel = (Label)elsList[0];
                textBoxRegion.Text = addressLabel.Text;

                elsList = panel.Controls.Find("City", true);
                addressLabel = (Label)elsList[0];
                textBoxCity.Text = addressLabel.Text;

                elsList = panel.Controls.Find("Street", true);
                addressLabel = (Label)elsList[0];
                textBoxStreetName.Text = addressLabel.Text;

                elsList = panel.Controls.Find("House", true);
                addressLabel = (Label)elsList[0];
                textBoxHouse.Text = addressLabel.Text;

                elsList = panel.Controls.Find("Appartment", true);
                addressLabel = (Label)elsList[0];
                textBoxAppartment.Text = addressLabel.Text;

                buttonUpdateAddress.Visible = true;
                buttonCancelUpdateAddress.Visible = true;
                buttonAddAddress.Visible = false;

                Address address;
                if (addressPanels.TryGetValue(panel, out address))
                    currentAddress = address;
                else currentAddress = null;
            }
        }

        private void removeAddressButton_Click(object sender, EventArgs e)
        {
         //   UpdateAddressesData();
            if (sender != null)
            {
                Control control = (Control)sender;
                Panel panel = (Panel)control.Parent;

                int maxY = panel.Location.Y, maxX = panel.Location.X;
                foreach (Panel p in addressPanels.Keys)
                {
                    if (p.Location.Y == maxY)
                    {
                        if (p.Location.X > maxX)
                        {
                            if (p.Location.X == 674)
                            {
                                p.Location = new Point(297, p.Location.Y);
                            }
                            else
                            {
                                p.Location = new Point(674, p.Location.Y - 270);
                            }
                        }
                    }
                    else if (p.Location.Y > maxY)
                    {
                        if (p.Location.X == 674)
                        {
                            p.Location = new Point(297, p.Location.Y);
                        }
                        else
                        {
                            p.Location = new Point(674, p.Location.Y - 270);
                        }
                    }
                }

                Address address;
                if (addressPanels.TryGetValue(panel, out address))
                {
                    addressPanels.Remove(panel);
                    tabPageAddresses.Controls.Remove(panel);
                    panel.Hide();
                    if (address != null)
                        addressController.RemoveAddress(address.Id);
                }
            }
        }

        private void removeOrderButton_Click(object sender, EventArgs e)
        {
         //   UpdateCollectionData();
            if (sender != null)
            {
                Control control = (Control)sender;
                Panel panel = (Panel)control.Parent;

                int maxY = panel.Location.Y, maxX = panel.Location.X;
                foreach (Panel p in orderPanels.Keys)
                {
                    if (p.Location.Y == maxY)
                    {
                        if (p.Location.X > maxX)
                        {
                            if (p.Location.X == 530)
                            {
                                p.Location = new Point(5, p.Location.Y);
                                columnPromNum = 1;
                            }
                            else
                            {
                                p.Location = new Point(530, p.Location.Y - 545);
                                columnPromNum = 0;
                            }
                        }
                    }
                    else if (p.Location.Y > maxY)
                    {
                        if (p.Location.X == 530)
                        {
                            p.Location = new Point(5, p.Location.Y);
                            columnPromNum = 1;
                        }
                        else
                        {
                            p.Location = new Point(530, p.Location.Y - 545);
                            columnPromNum = 0;
                        }
                    }
                }

                Order order;
                if (orderPanels.TryGetValue(panel, out order))
                {
                    orderPanels.Remove(panel);
                    tabPageOrders.Controls.Remove(panel);
                    panel.Hide();
                    if (order != null)
                        orderController.RemoveOrder(order.Id);
                }
            }
        }

        async private void LeaveAddressInfoTB(object sender, EventArgs e)
        {
            TextBox address = (TextBox)sender;
            Panel panel = (Panel)address.Parent;

            Order order;
            if (orderPanels.TryGetValue(panel, out order))
            {
                string[] addressInfo = address.Text.ToString().Split(',');

                Country country = countryController.GetCountry(addressInfo[1]);
                if(country == null )
                {
                    address.Text = order.Address.AddIndex + "," + order.Address.Street.City.Region.Country.CountryName + "," + order.Address.Street.City.Region.RegionName + "," + order.Address.Street.City.CityName + "," + order.Address.Street.StreetName + "," + order.Address.House + "," + order.Address.ApartmentNum;
                    return;
                }
                Region region = regionController.GetRegion(addressInfo[2], country);
                if(region == null)
                {
                    address.Text = order.Address.AddIndex + "," + order.Address.Street.City.Region.Country.CountryName + "," + order.Address.Street.City.Region.RegionName + "," + order.Address.Street.City.CityName + "," + order.Address.Street.StreetName + "," + order.Address.House + "," + order.Address.ApartmentNum;
                    return;
                }
                City city = cityController.GetCity(addressInfo[3], region);
                if(city == null)
                {
                    address.Text = order.Address.AddIndex + "," + order.Address.Street.City.Region.Country.CountryName + "," + order.Address.Street.City.Region.RegionName + "," + order.Address.Street.City.CityName + "," + order.Address.Street.StreetName + "," + order.Address.House + "," + order.Address.ApartmentNum;
                    return;
                }
                Street street = streetController.GetStreet(addressInfo[4], city);
                    if (street == null)
                    {
                        street = NewStreet(addressInfo[4], city);
                    }address.Text = order.Address.AddIndex + "," + region.Country.CountryName + "," + region.RegionName + "," + street.City.CityName + "," + street.StreetName + "," + order.Address.House + "," + order.Address.ApartmentNum;

                Address testAddress1 = addressController.GetByAll(street, addressInfo[0], 0, addressInfo[5], addressInfo[6]);
                if (order.Address.AddType == 0 && testAddress1 != null && testAddress1.Id == order.Address.Id)
                {
                    address.Text = order.Address.AddIndex + "," + region.Country.CountryName + "," + region.RegionName + "," + street.City.CityName + "," + street.StreetName + "," + order.Address.House + "," + order.Address.ApartmentNum;
                    return;
                }
                Address testAddress2 = addressController.GetByAll(street,addressInfo[0], 1, addressInfo[5], addressInfo[6]);
                Address testAddress3 = addressController.GetByAll(street, addressInfo[0], 2, addressInfo[5], addressInfo[6]);
                if(order.Address.AddType == 0 || order.Address.AddType == 1)
                {
                    if(testAddress2 != null && order.Address.Id != testAddress2.Id)
                    {
                        order.Address = testAddress2;
                        await orderController.UpdateOrderAsync(order);
                    }

                }
                else if(order.Address.AddType == 2)
                {
                    if (testAddress3 != null && order.Address.Id != testAddress3.Id)
                    {
                        order.Address = testAddress3;
                        orderController.UpdateOrder(order);
                    }
                    else if(testAddress3 == null)
                    {
                        Address newAddress = new Address();
                        newAddress.AddType = 2;
                        newAddress.AddIndex = addressInfo[0];
                        newAddress.ApartmentNum = addressInfo[6];
                        newAddress.House = addressInfo[5];
                        newAddress.Street = street;
                        addressController.AddAddress(newAddress);
                        order.Address = newAddress;
                        orderController.UpdateOrder(order);
                    }
                }
                Region regionFinal = regionController.GetRegion(order.Address.Street.City.RegionId);
                address.Text = order.Address.AddIndex + "," + regionFinal.Country.CountryName + "," + regionFinal.RegionName + "," + order.Address.Street.City.CityName + "," + order.Address.Street.StreetName + "," + order.Address.House;
            }
            
        }

       private void LeaveCourierInfoTB(object sender, EventArgs e)
        {
            TextBox courierInfoTB = (TextBox)sender;
            Panel panel = (Panel)courierInfoTB.Parent;

            Order order;
            if (orderPanels.TryGetValue(panel, out order))
            {
                if (courierInfoTB.Text.ToString() != "")
                {
                    string[] courierInfo = courierInfoTB.Text.ToString().Split(' ');
                    //Person courier = personController.FindPersonByEmail(courierInfo[3]);
                    //if (courier != null && courier.Id != order.Courier.Id)
                    //{
                    //    order.Courier = courier;

                    //   orderController.UpdateOrder(order);
                    //}
                    order.Courier = personController.FindPersonByEmail(courierInfo[3]);
                    orderController.UpdateOrder(order);
                    courierInfoTB.Text = order.Courier.PersonSurname + " " + order.Courier.PersonName + " " + order.Courier.PersonPatronymic + " " + order.Courier.Email;
                }
            }
        }

        async private void LeaveTotalCostInfoTB(object sender, EventArgs e)
        {
            TextBox costInfoTB = (TextBox)sender;
            Panel panel = (Panel)costInfoTB.Parent;

            Order order;
            if (orderPanels.TryGetValue(panel, out order))
            {
                order.TotalCost = Convert.ToDecimal(costInfoTB.Text);
                await orderController.UpdateOrderAsync(order);
            }
        }

        async private void LeaveDeliveryCostInfoTB(object sender, EventArgs e)
        {
            TextBox deliveryCostTB = (TextBox)sender;
            Panel panel = (Panel)deliveryCostTB.Parent;

            Order order;
            if (orderPanels.TryGetValue(panel, out order))
            {
                order.TotalCost -= order.DeliveryPrice;
                order.TotalCost += Convert.ToDecimal(deliveryCostTB.Text);
                order.DeliveryPrice = Convert.ToDecimal(deliveryCostTB.Text);

                await orderController.UpdateOrderAsync(order);

                Control[] elsList = panel.Controls.Find("FinalCost", true);
                TextBox finalCost = (TextBox)elsList[0];
                finalCost.Text = order.TotalCost.ToString();
            }
        }

        private void CreatePanelForOrder(Order order)
        {
            Panel panelEl = new Panel();
            panelEl.Width = 522;
            panelEl.Height = 482;

            ListBox listBoxGoodsNames = new ListBox();
            listBoxGoodsNames.Height = 102;
            listBoxGoodsNames.Width = 198;
            listBoxGoodsNames.Location = new Point(24, 339);
            listBoxGoodsNames.Font = new Font("Cambria", 9.0f);

            ListBox listBoxGoodsPrices = new ListBox();
            listBoxGoodsPrices.Height = 102;
            listBoxGoodsPrices.Width = 73;
            listBoxGoodsPrices.Location = new Point(222, 339);
            listBoxGoodsPrices.Font = new Font("Cambria", 9.0f);

            ListBox listBoxGoodsPromotions = new ListBox();
            listBoxGoodsPromotions.Height = 102;
            listBoxGoodsPromotions.Width = 64;
            listBoxGoodsPromotions.Location = new Point(295, 339);
            listBoxGoodsPromotions.Font = new Font("Cambria", 9.0f);

            ListBox listBoxGoodsNumbers = new ListBox();
            listBoxGoodsNumbers.Width = 74;
            listBoxGoodsNumbers.Height = 102;
            listBoxGoodsNumbers.Location = new Point(359, 339);
            listBoxGoodsNumbers.Font = new Font("Cambria", 9.0f);

            ListBox listBoxGoodsFinalCount = new ListBox();
            listBoxGoodsFinalCount.Height = 102;
            listBoxGoodsFinalCount.Width = 74;
            listBoxGoodsFinalCount.Location = new Point(433, 339);
            listBoxGoodsFinalCount.Font = new Font("Cambria", 9.0f);

            int maxX = 0, maxY = 0;
            if (orderPanels.Count > 0)
            {
                foreach (Panel p in orderPanels.Keys)
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
            if (maxX == 0) panelEl.Location = new Point(5, 5);
            else
            {
                if (maxX == 5) panelEl.Location = new Point(530, maxY);
                else panelEl.Location = new Point(5, maxY + 545);
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

            tabPageOrders.Controls.Add(panelEl);


            List<OrderGood> orderGoods = orderGoodController.GetOrderGoodsByOrder(order);
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
            orderNumLabel.Text = order.OrderNumber;
            orderNumLabel.Location = new Point(55, 8);
            nameLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            nameLabel.AutoSize = true;
            orderNumLabel.Name = "OrderNumber";

            Label deliveryDateLabel = new Label();
            deliveryDateLabel.Text = "Дата доставки: ";
            deliveryDateLabel.Location = new Point(21, 258);
            deliveryDateLabel.Font = new Font("Cambria", 9.75f);
            deliveryDateLabel.AutoSize = true;
            DateTimePicker deliveryDate = new DateTimePicker();
            deliveryDate.Value = order.DeliveryDate;
            deliveryDate.Location = new Point(123, 253);
            deliveryDate.Font = new Font("Cambria", 9f);
            deliveryDate.Name = "DeliveryDate";
            deliveryDate.Width = 200;
            deliveryDate.Height = 22;
            deliveryDate.ValueChanged += new EventHandler(DeliveryDateValueChanged);
            Label statusLabel = new Label();
            statusLabel.Text = "Статус: ";
            statusLabel.Location = new Point(7, 33);
            statusLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            statusLabel.AutoSize = true;
            ComboBox statusCB = new ComboBox();
            if (order.DeliveryMethod == 0)
            {
                statusCB.Items.Add("Выполняется поиск курьера");
                statusCB.Items.Add("Найден курьер");
            }
            statusCB.Items.Add("Подготавливается к отправке"); 
            statusCB.Items.Add("В пути"); 
            statusCB.Items.Add("Прибыл в город назначения"); 
            if (order.DeliveryMethod == 1)
            {
                statusCB.Items.Add("Прибыл в пункт самовывоза");
                statusCB.Items.Add("Получен и оплачен");
                
            }
            if (order.DeliveryMethod == 0)
            {
                statusCB.Items.Add("Выполняется доставка по нужному адресу");
                statusCB.Items.Add("Доставлен и оплачен");
            }
            statusCB.Items.Add("Отменен"); 

            statusCB.SelectedItem = statusCB.Items[order.OrderStatus];
            statusCB.Font = new Font("Cambria", 9f);
            statusCB.Location = new Point(69, 31);
            statusCB.Width = 237;
            statusCB.Height = 22;
            statusCB.Name = "OrderStatus";
            statusCB.SelectedIndexChanged += new EventHandler(StatusChanged);

            Label paymentMethodLabel = new Label();
            paymentMethodLabel.Text = "Способ оплаты: ";
            paymentMethodLabel.Location = new Point(7, 87);
            paymentMethodLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            paymentMethodLabel.AutoSize = true;
            ComboBox paymentMethodCB = new ComboBox();
            paymentMethodCB.Items.Add("Наличными при получении"); // 0
            paymentMethodCB.Items.Add("Картой при получении"); // 1
            paymentMethodCB.SelectedItem = paymentMethodCB.Items[order.PaymentMethod];
            paymentMethodCB.Font = new Font("Cambria", 9f);
            paymentMethodCB.Location = new Point(113, 85);
            paymentMethodCB.Width = 182;
            paymentMethodCB.Height = 22;
            paymentMethodCB.Name = "PaymentMethod";
            paymentMethodCB.SelectedIndexChanged += new EventHandler(PaymentMethodChanged);

            Label deliveryLabel = new Label();
            deliveryLabel.Text = "Доставка";
            deliveryLabel.Location = new Point(7, 114);
            deliveryLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            deliveryLabel.AutoSize = true;
            Label goodsLabel = new Label();
            goodsLabel.Text = "Товары";
            goodsLabel.Location = new Point(7, 286);
            goodsLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            goodsLabel.AutoSize = true;
            Label articleLabel = new Label();
            articleLabel.Text = "Артикул, наименование";
            articleLabel.Location = new Point(21, 308);
            articleLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            articleLabel.AutoSize = true;
            Label costLabel = new Label();
            costLabel.Text = "Стоимость,\nруб";
            costLabel.Location = new Point(215, 308);
            costLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            costLabel.AutoSize = true;
            Label discountLabel = new Label();
            discountLabel.Text = "Скидка, %";
            discountLabel.Location = new Point(288, 308);
            discountLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            discountLabel.AutoSize = true;
            Label numbersLabel = new Label();
            numbersLabel.Text = "Количество,\nшт";
            numbersLabel.Location = new Point(352, 308);
            numbersLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            numbersLabel.AutoSize = true;
            Label totalLabel = new Label();
            totalLabel.Text = "Итого, руб";
            totalLabel.Location = new Point(428, 308);
            totalLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            totalLabel.AutoSize = true;

            Label deliveryMethodLabel = new Label();
            deliveryMethodLabel.Text = "Способ доставки: ";
            deliveryMethodLabel.Location = new Point(21, 140);
            deliveryMethodLabel.Font = new Font("Cambria", 9.75f);
            deliveryMethodLabel.AutoSize = true;
           Label deliveryMethodCB = new Label();
            //      deliveryMethodCB.Items.Add("Курьерская"); // 0
            //      deliveryMethodCB.Items.Add("Самовывоз"); // 1
            if (order.DeliveryMethod == 0)
                deliveryMethodCB.Text = "Курьерская";
            else deliveryMethodCB.Text = "Самовывоз";
            deliveryMethodCB.Font = new Font("Cambria", 9f);
            deliveryMethodCB.Location = new Point(136, 138);
            deliveryMethodCB.Width = 91;
            deliveryMethodCB.Height = 22;
            deliveryMethodCB.Name = "DeliveryMethod";

            Label buyerLabel = new Label();
            buyerLabel.Text = "Покупатель:";
            buyerLabel.Location = new Point(7, 60);
            buyerLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            buyerLabel.AutoSize = true;
            TextBox buyerTB = new TextBox();
            buyerTB.Text = order.User.PersonSurname + " " + order.User.PersonName + " " + order.User.PersonPatronymic + ", " + order.User.BirthDate.ToShortDateString() + ", +7" + order.User.Phone;
            buyerTB.Location = new Point(90, 58);
            buyerTB.Font = new Font("Cambria", 9f);
            buyerTB.Name = "Buyer";
            buyerTB.Width = 322;
            buyerTB.Height = 22;
            buyerTB.ReadOnly = true;
            buyerTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            buyerTB.BackColor = System.Drawing.Color.FromArgb(228, 223, 218);

            Label addressLabel = new Label();
            addressLabel.Text = "Адрес:";
            addressLabel.Location = new Point(21, 167);
            addressLabel.Font = new Font("Cambria", 9.75f);
            addressLabel.AutoSize = true;
            TextBox addressTB = new TextBox();
            Street street = streetController.GetStreet(order.Address.StreetId);
            DataBase.Entities.Region region = regionController.GetRegion(street.City.RegionId);
            addressTB.Text = order.Address.AddIndex + "," + region.Country.CountryName + "," + region.RegionName + "," + street.City.CityName + "," + street.StreetName + "," + order.Address.House + "," + order.Address.ApartmentNum;
            addressTB.Location = new Point(66, 165);
            addressTB.Font = new Font("Cambria", 9f);
            addressTB.Name = "DeliveryAddress";
            addressTB.Width = 441;
            addressTB.Height = 22;
            addressTB.Leave += new EventHandler(LeaveAddressInfoTB);
            Label delCostLabel = new Label();
            delCostLabel.Text = "Стоимость доставки, руб: ";
            delCostLabel.Location = new Point(21, 197);
            delCostLabel.Font = new Font("Cambria", 9.75f);
            delCostLabel.AutoSize = true;
            TextBox delCostTB = new TextBox();
            delCostTB.Text = order.DeliveryPrice.ToString();
            delCostTB.Location = new Point(187, 195);
            delCostTB.Font = new Font("Cambria", 9f);
            delCostTB.Name = "DeliveryCost";
            delCostTB.Width = 40;
            delCostTB.Height = 22;
            delCostTB.Leave += new EventHandler(LeaveDeliveryCostInfoTB);
            Label courierLabel = new Label();
            courierLabel.Text = "Курьер: ";
            courierLabel.Location = new Point(21, 227);
            courierLabel.Font = new Font("Cambria", 9.75f);
            courierLabel.AutoSize = true;
            TextBox courierTB = new TextBox();
            if(order.Courier != null)
            courierTB.Text = order.Courier.PersonSurname + " " + order.Courier.PersonName + " " + order.Courier.PersonPatronymic + " " + order.Courier.Email;
            courierTB.Location = new Point(79, 225);
            courierTB.Font = new Font("Cambria", 9f);
            courierTB.Name = "Courier";
            courierTB.Width = 160;
            courierTB.Height = 22;
            courierTB.Leave += new EventHandler(LeaveCourierInfoTB);

            Label isPaidLabel = new Label();
            isPaidLabel.Text = "Оплачено: ";
            isPaidLabel.Location = new Point(7, 453);
            isPaidLabel.Font = new Font("Cambria", 9.75f, FontStyle.Italic);
            isPaidLabel.AutoSize = true;
            CheckBox isPaidCB = new CheckBox();
            isPaidCB.Checked = order.Verified;
            isPaidCB.Name = "IsPaidOrder";
            isPaidCB.Location = new Point(79, 452);
            isPaidCB.Enabled = false;

            Label finalCostLabel = new Label();
            finalCostLabel.Text = "ИТОГО, руб ";
            finalCostLabel.Location = new Point(360, 453);
            finalCostLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            finalCostLabel.AutoSize = true;
            TextBox finalCostTB = new TextBox();
            finalCostTB.Text = order.TotalCost.ToString();
            finalCostTB.Location = new Point(454, 451);
            finalCostTB.Font = new Font("Cambria", 9f, FontStyle.Bold);
            finalCostTB.Name = "FinalCost";
            finalCostTB.Width = 53;
            finalCostTB.Height = 22;
            finalCostTB.Leave += new EventHandler(LeaveTotalCostInfoTB);

            PictureBox pdfPB = new PictureBox();
            PictureBox removePB = new PictureBox();
            PictureBox editGoodsPB = new PictureBox();
            pdfPB.Height = pdfPB.Width = removePB.Height = removePB.Width = 20;
            Bitmap imageE = new Bitmap(Properties.Resources.pdf, 20, 20);
            pdfPB.Location = new Point(487, 33);
            pdfPB.Image = imageE;
            pdfPB.Click += new EventHandler(generatePDFButton_Click);

            imageE = new Bitmap(Properties.Resources.add, 15, 15);

            imageE = new Bitmap(Properties.Resources.delete, 20, 20);
            removePB.Location = new Point(487, 8);
            removePB.Image = imageE;
            removePB.Click += new EventHandler(removeOrderButton_Click);

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
            panelEl.Controls.Add(statusCB);
            panelEl.Controls.Add(statusLabel);
            panelEl.Controls.Add(paymentMethodLabel);
            panelEl.Controls.Add(paymentMethodCB);
            panelEl.Controls.Add(deliveryDateLabel);
            panelEl.Controls.Add(deliveryDate);
            panelEl.Controls.Add(nameLabel);
            panelEl.Controls.Add(orderNumLabel);

            panelEl.Controls.Add(pdfPB);
            panelEl.Controls.Add(removePB);

            panelEl.Controls.Add(listBoxGoodsNames);
            panelEl.Controls.Add(listBoxGoodsPrices);
            panelEl.Controls.Add(listBoxGoodsPromotions);
            panelEl.Controls.Add(listBoxGoodsNumbers);
            panelEl.Controls.Add(listBoxGoodsFinalCount);

            orderPanels.Add(panelEl, order);
        }

        private void addOrderGoodButton_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Panel panel = (Panel)control.Parent;
            panelGoodsOrderPicker.Visible = true;

            Control[] elsList = panel.Controls.Find("OrderNumber", true);
            Label orderLabel = (Label)elsList[0];
            orderNumLabel.Text = orderLabel.Text;

            textBoxGoodsNumber.Text = "1";
            TBGoodsForFree.Text = TBDiscount.Text = "0";
            textBox19.Text = "";
            goodArticleLabel.Text = "";
            labelResultPriceForGood.Text = "Итого: ";
        }

        async private void StatusChanged(object sender, EventArgs e)
        {
            ComboBox cbStatus = (ComboBox)sender;
            Panel panel = (Panel)cbStatus.Parent;

            Order order;
            if(orderPanels.TryGetValue(panel, out order))
            {
                order.OrderStatus = Convert.ToInt16(cbStatus.SelectedIndex);

                await orderController.UpdateOrderAsync(order);
            }
        }

        async private void DeliveryDateValueChanged(object sender, EventArgs e)
        {
            DateTimePicker date = (DateTimePicker)sender;
            Panel panel = (Panel)date.Parent;

            Order order;
            if (orderPanels.TryGetValue(panel, out order))
            {
                order.DeliveryDate = date.Value;

                await orderController.UpdateOrderAsync(order);
            }
        }


        async private void PaymentMethodChanged(object sender, EventArgs e)
        {
            ComboBox paymentMethod = (ComboBox)sender;
            Panel panel = (Panel)paymentMethod.Parent;

            Order order;
            if (orderPanels.TryGetValue(panel, out order))
            {
                order.PaymentMethod = Convert.ToInt16(paymentMethod.SelectedIndex);

                await orderController.UpdateOrderAsync(order);
            }
        }

        async private void DeliveryMethodChanged(object sender, EventArgs e)
        {
            ComboBox deliveryMethod = (ComboBox)sender;
            Panel panel = (Panel)deliveryMethod.Parent;

            Order order;
            if (orderPanels.TryGetValue(panel, out order))
            {
                order.DeliveryMethod = Convert.ToInt16(deliveryMethod.SelectedIndex);

                await orderController.UpdateOrderAsync(order);
            }
        }


        private void generatePDFButton_Click(object sender, EventArgs e)
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

                saveFileDialog1.FileName = "Order" + orderLabel.Text + "Info.pdf";

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
                ComboBox orderCB = (ComboBox)elsList[0];
                db.Writeln(orderCB.SelectedItem.ToString());

                db.CharacterFormat.Italic = true;
                db.Write("Покупатель: ");
                db.CharacterFormat.Italic = false;
                elsList = panel.Controls.Find("Buyer", true);
                TextBox orderTB = (TextBox)elsList[0];
                db.Writeln(orderTB.Text);

                db.CharacterFormat.Italic = true;
                db.Write("Способ оплаты: ");
                db.CharacterFormat.Italic = false;
                elsList = panel.Controls.Find("PaymentMethod", true);
                orderCB = (ComboBox)elsList[0];
                db.Writeln(orderCB.SelectedItem.ToString());

                db.CharacterFormat.Italic = true;
                db.Write("Доставка");
                db.CharacterFormat.Italic = false;
                elsList = panel.Controls.Find("DeliveryMethod", true);
                Label orderLabel1 = (Label)elsList[0];
                db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                db.InsertSpecialCharacter(SpecialCharacterType.Tab);
                db.Write("Способ доставки: " + orderLabel1.Text);
                elsList = panel.Controls.Find("DeliveryAddress", true);
                orderTB = (TextBox)elsList[0];
                db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                db.InsertSpecialCharacter(SpecialCharacterType.Tab);
                db.Write("Адрес: " + orderTB.Text);
                elsList = panel.Controls.Find("DeliveryCost", true);
                orderTB = (TextBox)elsList[0];
                db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                db.InsertSpecialCharacter(SpecialCharacterType.Tab);
                db.Write("Стоимость доставки: " + orderTB.Text + " руб.");
                elsList = panel.Controls.Find("Courier", true);
                orderTB = (TextBox)elsList[0];
                db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                db.InsertSpecialCharacter(SpecialCharacterType.Tab);
                db.Write("Курьер: " + orderTB.Text);
                elsList = panel.Controls.Find("DeliveryDate", true);
                DateTimePicker orderDateTime = (DateTimePicker)elsList[0];
                db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
                db.InsertSpecialCharacter(SpecialCharacterType.Tab);
                db.Writeln("Дата доставки: " + orderDateTime.Value.ToShortDateString());
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
                for(int i = 0; i < orderLBNames.Items.Count; i++)
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
                orderTB = (TextBox)elsList[0];
                db.CharacterFormat.Bold = true;
                db.Write("ИТОГО, руб. " + orderTB.Text);
                //   dc.Save(@"OrderInfo.pdf", new PdfSaveOptions()
                //   { Compliance = PdfCompliance.PDF_A1a });
                //   System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(@"OrderInfo.pdf") { UseShellExecute = true });
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //    File.WriteAllBytes(saveResumeFileDialog.FileName, newEmpApp.Resume);
                    dc.Save(saveFileDialog1.FileName, new PdfSaveOptions()
                    { Compliance = PdfCompliance.PDF_A1a });
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(saveFileDialog1.FileName) { UseShellExecute = true });
                }
            }
        }


        private void UpdateCollectionData()
        {
            List<Collection> collections = collectionController.GetAllCollections();
            List<Panel> removeList = new List<Panel>();
            int i = 0;
            foreach (Collection c in colPanels.Values)
            {
                Panel panel = colPanels.FirstOrDefault(x => x.Value == c).Key;
                if (c.Id == collections[i].Id)
                {
                    if (c.ColName != collections[i].ColName)
                    {
                        c.ColName = collections[i].ColName;
                        SetText(panel, "Name", c.ColName);
                    }
                    if (c.ColStatus != collections[i].ColStatus)
                    {
                        c.ColStatus = collections[i].ColStatus;
                        SetCBValue(panel, c.ColStatus);
                    }
                    List<Good> goods = goodColController.GetGoods(c);
                    Control[] elsList = panel.Controls.Find("ColGoods", true);
                    ListBox lb = (ListBox)elsList[0];
                    lb.Items.Clear();
                    foreach (Good g in goods)
                    {
                        lb.Items.Add(g.Article + ", " + g.GoodName);
                    }
                    i++;
                }
                else removeList.Add(panel);
            }
        }

        public void UpdatePromotionData()
        {
            List<Promotion> promotions = promotionController.GetPromotions();
            int i = 0;
            foreach (Promotion p in promPanels.Values)
            {
                Panel panel = promPanels.FirstOrDefault(x => x.Value == p).Key;
                if (p.Id == promotions[i].Id)
                {
                    List<Good> goods = goodPromotionController.GetGoods(p);
                    Control[] elsList = panel.Controls.Find("PromGoods", true);
                    ListBox lb = (ListBox)elsList[0];
                    lb.Items.Clear();
                    foreach (Good g in goods)
                    {
                        lb.Items.Add(g.Article + ", " + g.GoodName);
                    }
                    if (p.PromotionName != promotions[i].PromotionName)
                    {
                        p.PromotionName = promotions[i].PromotionName;
                        SetText(panel, "Name", p.PromotionName);
                    }
                    if (p.Discount != promotions[i].Discount)
                    {
                        p.Discount = promotions[i].Discount;
                        SetText(panel, "Discount", p.Discount.ToString());
                    }
                    if (p.GoodNum != promotions[i].GoodNum)
                    {
                        p.GoodNum = promotions[i].GoodNum;
                        SetText(panel, "GoodNum", p.GoodNum.ToString());
                    }
                    if (p.FreeGoodNum != promotions[i].FreeGoodNum)
                    {
                        p.FreeGoodNum = promotions[i].FreeGoodNum;
                        SetText(panel, "FreeGoodNum", p.FreeGoodNum.ToString());
                    }
                    if (p.DateBegin != promotions[i].DateBegin || p.DateEnd != promotions[i].DateEnd)
                    {
                        p.DateBegin = promotions[i].DateBegin;
                        p.DateEnd = promotions[i].DateEnd;
                        elsList = panel.Controls.Find("Date", true);
                        Label date = (Label)elsList[0];
                        string promDateEnd = p.DateEnd == null ? "?" : p.DateEnd.Value.ToShortDateString();
                        date.Text = p.DateBegin.Date.ToShortDateString() + "-" + promDateEnd;
                    }
                    i++;
                }
            }
        }

        private void CreatePanelForCollection(Collection collection)
        {
            Panel panelEl = new Panel();
            panelEl.Height = 218;
            panelEl.Width = 278;

            ListBox listBoxGoods = new ListBox();
            listBoxGoods.Height = 130;
            listBoxGoods.Width = 265;
            listBoxGoods.Location = new Point(5, 82);
            listBoxGoods.Font = new Font("Cambria", 9.0f);

            int maxX = 0, maxY = 0;
            if (colPanels.Count > 0)
            {
                foreach (Panel p in colPanels.Keys)
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
            if (maxX == 0) panelEl.Location = new Point(308, 18);
            else
            {
                if (maxX == 308) panelEl.Location = new Point(611, maxY);
                else panelEl.Location = new Point(308, maxY + 236);
            }

            panelEl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            listBoxGoods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            listBoxGoods.BackColor = System.Drawing.Color.FromArgb(228, 223, 218);
            listBoxGoods.HorizontalScrollbar = true;
            listBoxGoods.Name = "ColGoods";
            tabPageCollection.Controls.Add(panelEl);

            List<Good> goods = goodColController.GetGoods(collection);
            foreach (Good g in goods) listBoxGoods.Items.Add(g.Article + ", " + g.GoodName);

            Label nameLabel = new Label();
            nameLabel.Text = collection.ColName;
            nameLabel.Location = new Point(7, 8);
            nameLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            nameLabel.Name = "Name";
            nameLabel.AutoSize = true;

            Label statusLabel = new Label();
            statusLabel.AutoSize = true;
            switch (collection.ColStatus)
            {
                case 0:
                    statusLabel.Text = "Неактивна";
                    break;
                case 1:
                    statusLabel.Text = "Активна";
                    break;
                case 2:
                    statusLabel.Text = "Коллекция главного окна";
                    break;
            }
            statusLabel.Location = new Point(17, 33);
            statusLabel.Font = new Font("Cambria", 9.0f, FontStyle.Italic);
            statusLabel.Name = "Status";

            Label goodsHeaderLabel = new Label();
            goodsHeaderLabel.Text = "Товары";
            goodsHeaderLabel.Location = new Point(17, 57);
            goodsHeaderLabel.Font = new Font("Cambria", 9.0f, FontStyle.Italic);
            goodsHeaderLabel.SendToBack();

            PictureBox editPB = new PictureBox();
            PictureBox removePB = new PictureBox();
            editPB.Height = editPB.Width = removePB.Height = removePB.Width = 15;
            Bitmap imageE = new Bitmap(Properties.Resources.edit, 15, 15);
            editPB.Location = new Point(231, 8);
            editPB.Image = imageE;
            editPB.Click += new EventHandler(editColButton_Click);
            imageE = new Bitmap(Properties.Resources.delete, 15, 15);
            removePB.Location = new Point(250, 8);
            removePB.Image = imageE;
            removePB.Click += new EventHandler(removeColButton_Click);

            panelEl.Controls.Add(nameLabel);
            panelEl.Controls.Add(statusLabel);
            panelEl.Controls.Add(goodsHeaderLabel);
            panelEl.Controls.Add(editPB);
            panelEl.Controls.Add(removePB);

            panelEl.Controls.Add(listBoxGoods);

            colPanels.Add(panelEl, collection);
        }

        private void removeColButton_Click(object sender, EventArgs e)
        {
            UpdateCollectionData();
            if (sender != null)
            {
                Control control = (Control)sender;
                Panel panel = (Panel)control.Parent;

                int maxY = panel.Location.Y, maxX = panel.Location.X;
                foreach (Panel p in colPanels.Keys)
                {
                    if (p.Location.Y == maxY)
                    {
                        if (p.Location.X > maxX)
                        {
                            if (p.Location.X == locXcol + 303)
                            {
                                p.Location = new Point(p.Location.X - 303, p.Location.Y);
                                columnPromNum = 1;
                            }
                            else
                            {
                                p.Location = new Point(p.Location.X + 303, p.Location.Y - 236);
                                columnPromNum = 0;
                            }
                        }
                    }
                    else if (p.Location.Y > maxY)
                    {
                        if (p.Location.X == locXcol + 303)
                        {
                            p.Location = new Point(p.Location.X - 303, p.Location.Y);
                            columnPromNum = 1;
                        }
                        else
                        {
                            p.Location = new Point(p.Location.X + 303, p.Location.Y - 236);
                            columnPromNum = 0;
                        }
                    }
                }

                Collection collection;
                if(colPanels.TryGetValue(panel, out collection))
                {
                    colPanels.Remove(panel);
                    tabControlGood.Controls.Remove(panel);
                    panel.Hide();
                    if (collection != null) 
                        collectionController.RemoveCollection(collection.Id);
                }
            }
        }

        private void removePromotionButton_Click(object sender, EventArgs e)
        {
          //  UpdatePromotionData();
            if (sender != null)
            {
                Control control = (Control)sender;
                Panel panel = (Panel)control.Parent;

                int maxX = panel.Location.X, maxY = panel.Location.Y;
                foreach (Panel p in promPanels.Keys)
                {
                    if (p.Location.Y == maxY)
                    {
                        if (p.Location.X > maxX)
                        {
                            if (p.Location.X == locXprom + 243)
                            {
                                p.Location = new Point(p.Location.X - 243, p.Location.Y);
                                columnPromNum = 1;
                            }
                            else if (p.Location.X == locXprom + 486)
                            {
                                p.Location = new Point(p.Location.X - 243, p.Location.Y);
                                columnPromNum = 2;
                            }
                            else
                            {
                                p.Location = new Point(p.Location.X + 486, p.Location.Y - 382);
                                columnPromNum = 0;
                            }
                        }
                    }
                    else if (p.Location.Y > maxY)
                    {
                        if (p.Location.X == locXprom + 243)
                        {
                            p.Location = new Point(p.Location.X - 243, p.Location.Y);
                            columnPromNum = 1;
                        }
                        else if (p.Location.X == locXprom + 486)
                        {
                            p.Location = new Point(p.Location.X - 243, p.Location.Y);
                            columnPromNum = 2;
                        }
                        else
                        {
                            p.Location = new Point(p.Location.X + 486, p.Location.Y - 382);
                            columnPromNum = 0;
                        }
                    }
                }

                Promotion promotion;
                if (promPanels.TryGetValue(panel, out promotion))
                {
                    promPanels.Remove(panel);
                    tabPagePromotions.Controls.Remove(panel);
                    panel.Hide();
                    if (promotion != null)
                        promotionController.RemovePromotion(promotion.Id);
                }
            }
        }

        private void editPromotionButton_Click(object sender, EventArgs e)
        {
            UpdatePromotionData();
            if (sender != null)
            {
                Control control = (Control)sender;
                Panel panel = (Panel)control.Parent;

                buttonAddProm.Visible = false;
                buttonUpdateProm.Visible = true;
                buttonCancelUpdateProm.Visible = true;

                Control[] labelsList = panel.Controls.Find("Name", true);
                Label promLabel = (Label)labelsList[0];
                promNameTB.Text = promLabel.Text;

                labelsList = panel.Controls.Find("Discount", true);
                promLabel = (Label)labelsList[0];
                promDiscountTB.Text = promLabel.Text;

                labelsList = panel.Controls.Find("GoodNum", true);
                promLabel = (Label)labelsList[0];
                goodPromNumTB.Text = promLabel.Text;

                labelsList = panel.Controls.Find("FreeGoodNum", true);
                promLabel = (Label)labelsList[0];
                freeGoodPromNumTB.Text = promLabel.Text;

                labelsList = panel.Controls.Find("Date", true);
                promLabel = (Label)labelsList[0];
                string text = promLabel.Text;
                string[] dates = text.Split('-');
                dateTimePickerPromStart.Value = Convert.ToDateTime(dates[0]);
                try
                {
                    dateTimePickerPromEnd.Value = Convert.ToDateTime(dates[1]);
                }
                catch(Exception)
                {
                    dateTimePickerPromEnd.Value = DateTime.Now;
                }

                Promotion promotion;
                if (promPanels.TryGetValue(panel, out promotion))
                {
                    currentPromotion = promotion;
                    goodsPromCLB.Items.Clear();
                    List<Good> allGoods = goodController.GetAllGoods();
                    foreach (Good g in allGoods)
                    {
                        goodsPromCLB.Items.Add(g.Article + ", " + g.GoodName);
                        if (goodPromotionController.GetGoodPromotion(g.Id, currentPromotion.Id) != null)
                            goodsPromCLB.SetItemChecked(goodsPromCLB.Items.Count - 1, true);
                    }
                }
                else currentPromotion = null;
            }
        }

        private void editColButton_Click(object sender, EventArgs e)
        {
            UpdateCollectionData();
            if (sender != null)
            {
                Control control = (Control)sender;
                Panel panel = (Panel)control.Parent;

                colNameTB.Visible = true;
                colStatusCB.Visible = true;
             //   labelChooseGoods.Visible = true;
                goodsCLB.Visible = true;
                updateColBtn.Visible = true;
                cancelColChangesBtn.Visible = true;

                Control[] labelsList = panel.Controls.Find("Name", true);
                Label collectionLabel = (Label)labelsList[0];
                colNameTB.Text = collectionLabel.Text;

                labelsList = panel.Controls.Find("Status", true);
                Label collectionTB = (Label)labelsList[0];
                colStatusCB.SelectedItem = collectionTB.Text;

                goodsCLB.Items.Clear();
                List<Good> allGoods = goodController.GetAllGoods();
                foreach (Good g in allGoods)
                {
                    goodsCLB.Items.Add(g.Article + ", " + g.GoodName);
                    currentCollection = collectionController.GetCollectionByName(colNameTB.Text);
                    if (goodColController.GetGoodCollection(g.Id, currentCollection.Id) != null)
                        goodsCLB.SetItemChecked(goodsCLB.Items.Count - 1, true);
                }

                Category category;
                if (cPanels.TryGetValue(panel, out category))
                    currentCategory = category;
                else currentCategory = null;
            }

        }

        private void UpdateCategoryData()
        {
            List<Category> categories = categoryController.GetCategories();
            List<Panel> removeList = new List<Panel>();
            int i = 0;
            foreach (Category c in categories)
            {
                c.Good = goodController.GetGoodsByCategory(c);
            }
            foreach (Category c in cPanels.Values)
            {
                Panel panel = cPanels.FirstOrDefault(x => x.Value == c).Key;
                if (c.Id == categories[i].Id)
                {
                    if (c.CName != categories[i].CName)
                    {
                        c.CName = categories[i].CName;
                        SetText(panel, "Name", c.CName);
                    }
                    if (c.CDescription != categories[i].CDescription)
                    {
                        c.CDescription = categories[i].CDescription;
                        SetText(panel, "Description", c.CName);
                    }
                    if (c.Good != categories[i].Good)
                    {
                        c.Good = categories[i].Good;
                    }
                    i++;
                }
                else removeList.Add(panel);
            }
            bool movePanel = false;
        }

        // TabControl (бок. панель) - общее
        private void tabControlGood_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            TabPage _tabPage = tabControlGood.TabPages[e.Index];

            Rectangle _tabBounds = tabControlGood.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                _textBrush = new SolidBrush(System.Drawing.Color.Black);
                g.FillRectangle(Brushes.MediumAquamarine, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            Font _tabFont = new Font("Cambria", 11.0f, FontStyle.Regular, GraphicsUnit.Pixel);

            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        // Товары - информация
        //private void AddElToCategoryCB(string name)
        //{
        //    ColumnCategoryName.Items.Add(name);
        //}

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<int, Good> el in elsForUpdating)
            {
                goodController.UpdateGood(el.Value);
            }

            foreach (KeyValuePair<int, Good> el in elsForAdding)
            {
                goodController.AddGood(el.Value);
            }

            for (int i = 0; i < elsIdForDeleting.Count; i++)
            {
                goodController.DeleteGood(elsIdForDeleting[i]);
            }

            try
            {
                goods = new BindingList<Good>(goodController.GetAllGoods());
          //      dataGridViewGood.DataSource = null;
          //      dataGridViewGood.DataSource = goods;
            }
            catch(Exception) { }
           // dataGridViewGood.Refresh();


            elsForAdding.Clear();
            elsForUpdating.Clear();
            elsIdForDeleting.Clear();

            UpdateCollectionData();

        }

        private void dataGridViewGood_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridViewGood.Columns[e.ColumnIndex].HeaderText == "Изображение")
            //{
            //    using (OpenFileDialog dlg = new OpenFileDialog())
            //    {
            //        dlg.Title = "Выберете изображение";
            //        dlg.Filter = "png files (*.png)|*.png";

            //        if (dlg.ShowDialog() == DialogResult.OK)
            //        {
            //            Bitmap goodImage = new Bitmap(dlg.FileName);
            //            dataGridViewGood.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = goodImage;
            //            int index = (int)dataGridViewGood.Rows[e.RowIndex].Cells[ColumnId.Index].Value;
            //            ImageConverter imgConverter = new ImageConverter();
            //            if (index == 0)
            //                elsForAdding[e.RowIndex].Image = (byte[])imgConverter.ConvertTo(goodImage, typeof(byte[]));
            //            else
            //            {
            //                if (elsForUpdating.ContainsKey(index))
            //                    elsForUpdating[index].Image = (byte[])imgConverter.ConvertTo(goodImage, typeof(byte[]));
            //                else
            //                {
            //                    Good good = goodController.GetGood(index);
            //                    good.Image = (byte[])imgConverter.ConvertTo(goodImage, typeof(byte[]));
            //                    elsForUpdating.Add(index, good);
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void dataGridViewGood_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
        //    AddNewGoodToElsList(e.Row.Index);
        }

        private void AddNewGoodToElsList(int rowIndex)
        {
            //elsForAdding.Add(rowIndex - 1, new Good());
            //dataGridViewGood.Rows[rowIndex - 1].Cells[ColumnId.Index].Value = 0;
            //dataGridViewGood.Rows[rowIndex - 1].Cells[ColumnCategoryId.Index].Value = 1;
            //dataGridViewGood.Rows[rowIndex - 1].Cells[ColumnCategoryName.Index].Value = categoryController.GetCategories()[0].CName;
        }

        private void dataGridViewGood_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewColumn currentColumn = dataGridViewGood.Columns[e.ColumnIndex];
            //DataGridViewRow currentRow = dataGridViewGood.Rows[e.RowIndex];
            //DataGridViewCell currentCell = currentRow.Cells[e.ColumnIndex];
            //    int index = (int)dataGridViewGood.Rows[e.RowIndex].Cells[ColumnId.Index].Value;
            //    Good goodToChange;
            //if (index == 0)
            //{
            //    if (!elsForAdding.Keys.Contains(currentRow.Index))
            //        AddNewGoodToElsList(currentRow.Index);
            //    goodToChange = elsForAdding[currentRow.Index];
            //}
            //else goodToChange = goodController.GetGood(index);

            //if (currentColumn.HeaderText == "Название")
            //    goodToChange.GoodName = (string)currentCell.Value;
            //else if (currentColumn.HeaderText == "Имя категории")
            //{
            //    Category changedCategory = categoryController.GetCategoryByName(currentCell.EditedFormattedValue.ToString());
            //    currentRow.Cells[ColumnCategoryId.Index].Value = changedCategory.Id;
            //    goodToChange.Category = changedCategory;
            //}
            //else if (currentColumn.HeaderText == "Артикул")
            //    goodToChange.Article = (string)currentCell.EditedFormattedValue;
            //else if (currentColumn.HeaderText == "Количество")
            //    goodToChange.GoodNum = (int)currentCell.EditedFormattedValue;
            //else if (currentColumn.HeaderText == "Описание")
            //    goodToChange.GoodDescription = (string)currentCell.EditedFormattedValue;
            //else if (currentColumn.HeaderText == "Цена")
            //    goodToChange.Price = (decimal)currentCell.EditedFormattedValue;
            //else if (currentColumn.HeaderText == "Дата выпуска")
            //    goodToChange.ReleaseDate = Convert.ToDateTime(currentCell.EditedFormattedValue);
            //else if (currentColumn.HeaderText == "Характристика_значение")
            //    goodToChange.Characteristic = currentCell.EditedFormattedValue.ToString();

            //    if (index == 0)
            //        elsForAdding[currentRow.Index] = goodToChange;
            //    else
            //    {
            //        if (elsForUpdating.ContainsKey(index))
            //            elsForUpdating[index] = goodToChange;
            //        else elsForUpdating.Add(goodToChange.Id, goodToChange);
            //    }
        }

        private void dataGridViewGood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridViewGood_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //dataGridViewGood.Rows[e.RowIndex].ErrorText = "";
            //DataGridViewColumn currentColumn = dataGridViewGood.Columns[e.ColumnIndex];
            //DataGridViewRow currentRow = dataGridViewGood.Rows[e.RowIndex];
            //DataGridViewCell currentCell = currentRow.Cells[e.ColumnIndex];

            //if (currentColumn.HeaderText == "Название")
            //{
            //    if (!validator.IsCorrectInfo((string)e.FormattedValue) || !validator.IsLengthCorrectMax((string)e.FormattedValue, 255))
            //    {
            //        e.Cancel = true;
            //        dataGridViewGood.Rows[e.RowIndex].ErrorText = "Некорректная длина строки: допустимый интервал - 1-255 символов";
            //    }
            //}
            //else if (currentColumn.HeaderText == "Артикул")
            //{
            //    Good foundValue = goodController.GetGoodByArticle((string)e.FormattedValue);
            //    if (!(foundValue == null || foundValue.Id == (int)currentRow.Cells[ColumnId.Index].Value) || !validator.IsCorrectInfo((string)e.FormattedValue) || !validator.IsLengthCorrectRequired((string)e.FormattedValue, 14))
            //    {
            //        e.Cancel = true;
            //        dataGridViewGood.Rows[e.RowIndex].ErrorText = "Артикул должен быть уникальным и длиной 14 символов";
            //    }
            //}   
            //else if (currentColumn.HeaderText == "Дата выпуска")
            //{
            //    try
            //    {
            //        DateTime convertedData = Convert.ToDateTime(e.FormattedValue);
            //        if (!dtValidator.IsDataCorrect(convertedData))
            //        {
            //            e.Cancel = true;
            //            dataGridViewGood.Rows[e.RowIndex].ErrorText = "Товар не может быть произведен позднее сегодняшнего дня";
            //        }
            //    }
            //    catch(Exception)
            //    {
            //        e.Cancel = true;
            //        dataGridViewGood.Rows[e.RowIndex].ErrorText = "Некорректная дата";
            //    }
            //}
            //else if (currentColumn.HeaderText == "Категория")
            //{
            //    if(categoryController.GetCategoryByName(currentCell.Value.ToString()) == null)
            //    {
            //        e.Cancel = true;
            //        dataGridViewGood.Rows[e.RowIndex].ErrorText = "Такой категории не существует";
            //    }
            //}
        }

        private void dataGridViewGood_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //for(int i = 0; i < dataGridViewGood.Rows.Count; i++)
            //{
            //    string categoryName;
            //    if (elsForAdding.ContainsKey(i))
            //    {
            //        categoryName = (string)dataGridViewGood.Rows[i].Cells[ColumnCategoryName.Index].Value;
            //        if (categoryName == null) categoryName = (string)ColumnCategoryName.Items[0];
            //        Category category = categoryController.GetCategoryByName(categoryName);
            //        dataGridViewGood.Rows[i].Cells[ColumnCategoryId.Index].Value = category.Id;
            //        elsForAdding[i].Category = category;
            //    }
            //    else if (i < dataGridViewGood.Rows.Count - 1)
            //    {
            //        int index = (int)dataGridViewGood.Rows[i].Cells[ColumnId.Index].Value;
            //        categoryName = goodController.GetGood(index).Category.CName;

            //        try
            //        {
            //            Convert.ToDateTime(dataGridViewGood.Rows[i].Cells[ColumnReleaseDate.Index].Value);
            //        }
            //        catch(Exception)
            //        {
            //            dataGridViewGood.Rows[i].Cells[ColumnReleaseDate.Index].Value = DateTime.Now;
            //        }
            //    }
            //    else categoryName = (string)ColumnCategoryName.Items[0];
            //    dataGridViewGood.Rows[i].Cells[ColumnCategoryName.Index].Value = categoryName;

            //}
        }

        private void dataGridViewWriteOffs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int i = 0;

         //   List<WriteOffReason> reasonsCurr = writeOffReasonController.GetWriteOffReasons();
          //  List<string> names = new List<string>();
           // foreach (WriteOffReason r in reasonsCurr)
            //{
            //    if (!columnreason.items.contains(r.reasonname)) columnreason.items.add(r.reasonname);
            //    names.add(r.reasonname);
            //}
            //if (columnreason.items.count != reasonscurr.count)
            //    while (i < columnreason.items.count)
            //    {
            //        if (!names.contains(columnreason.items[i]))
            //        {
            //            columnreason.items.remove(columnreason.items[i]);
            //            i--;
            //        }
            //        i++;
            //    }

            for (i = 0; i < dataGridViewWriteOffs.Rows.Count; i++)
            {
                if (i < dataGridViewWriteOffs.Rows.Count - 1)
                {

                    if ((int)dataGridViewWriteOffs.Rows[i].Cells[ColumnGoodIdWriteOff.Index].Value > 0)
                        dataGridViewWriteOffs.Rows[i].Cells[ColumnGoodInfo.Index].Value = goodController.GetGood((int)dataGridViewWriteOffs.Rows[i].Cells[ColumnGoodIdWriteOff.Index].Value).Article;
                    dataGridViewWriteOffs.Rows[i].Cells[ColumnReason.Index].Value = writeOffReasonController.GetReason((int)dataGridViewWriteOffs.Rows[i].Cells[ColumnReasonId.Index].Value).ReasonName;
                    dataGridViewWriteOffs.Rows[i].Cells[ColumnWriteOffStatus.Index].Value = ColumnWriteOffStatus.Items[(short)dataGridViewWriteOffs.Rows[i].Cells[ColumnWriteOffStatusNum.Index].Value];
                }
                else
                {
                    dataGridViewWriteOffs.Rows[i].Cells[ColumnReason.Index].Value = (string)ColumnReason.Items[0];
                    WriteOffReason reason = writeOffReasonController.GetReasonByName((string)ColumnReason.Items[0]);
                    dataGridViewWriteOffs.Rows[i].Cells[ColumnReasonId.Index].Value = reason.Id;
                    dataGridViewWriteOffs.Rows[i].Cells[ColumnWriteOffStatus.Index].Value = (string)ColumnWriteOffStatus.Items[0];
                    dataGridViewWriteOffs.Rows[i].Cells[ColumnWriteOffStatusNum.Index].Value = 0;
                }
            }
        }

        private void dataGridViewGood_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
          //  dataGridViewGood.Rows[e.RowIndex].ErrorText = null;
        }

        private void dataGridViewGood_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
        //    int index = (int)dataGridViewGood.Rows[e.Row.Index].Cells[ColumnId.Index].Value;
        //    if (index == 0)
        //        elsForAdding.Remove(e.Row.Index);
        //    else
        //    {
        //        elsIdForDeleting.Add(index);
        //        if (elsForUpdating.ContainsKey(index))
        //            elsForUpdating.Remove(index);
        //        goods.Remove(goodController.GetGood(index));
        //    }
        }

        // Товары - категории
        private void CreatePanelForCategory(Category c)
        {
            Panel panelEl = new Panel();
            panelEl.Height = 85;
            panelEl.Width = 521;
            panelEl.AutoScroll = true;
            panelEl.Location = new Point(locX, locY);
            panelEl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tabPageCategories.Controls.Add(panelEl);

            Label nameLabel = new Label();
            nameLabel.Text = c.CName;
            nameLabel.Location = new Point(11, 12);
            nameLabel.Font = new Font("Cambria", 10.0f, FontStyle.Bold);
            nameLabel.Name = "Name";
            nameLabel.AutoSize = true;

            RichTextBox desc = new RichTextBox();
            desc.ReadOnly = true;
            desc.Font = new Font("Cambria", 8.0f);
            desc.Text = c.CDescription;
            desc.Location = new Point(25, 37);
            desc.Height = 35;
            desc.Width = 417;
            desc.Name = "Description";
            desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            PictureBox editPB = new PictureBox();
            PictureBox removePB = new PictureBox();
            editPB.Height = editPB.Width = removePB.Height = removePB.Width = 21;
            Bitmap imageE = new Bitmap(Properties.Resources.edit, 21, 21);
            editPB.Location = new Point(462, 7);
            editPB.Image = imageE;
            editPB.Click += new EventHandler(editButton_Click);
            editPB.BringToFront();
            imageE = new Bitmap(Properties.Resources.delete, 21, 21);
            removePB.Location = new Point(487, 7);
            removePB.Image = imageE;
            removePB.Click += new EventHandler(removeButton_Click);

            panelEl.Controls.Add(nameLabel);
            panelEl.Controls.Add(desc);
            panelEl.Controls.Add(editPB);
            panelEl.Controls.Add(removePB);

            int maxY = 0;
            if (cPanels.Count > 0)
            {
                foreach (Panel p in cPanels.Keys)
                {
                    if (p.Location.Y > maxY)
                    {
                        maxY = p.Location.Y;
                    }
                }
            }
            if (maxY == 0) panelEl.Location = new Point(378, 18);
            else
            {
                panelEl.Location = new Point(378, maxY + 103);
            }
            cPanels.Add(panelEl, c);
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Возникла ошибка вводимых данных: " + anError.Exception.ToString());
        }

        // Товары - категории - валидация
        private void nCategoryNameTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!iValidator.isNameSymbolsControl(e.KeyChar))
                e.Handled = true;
        }

        private void nCategoryNameTB_Validating(object sender, CancelEventArgs e)
        {
            string text = nCategoryNameTB.Text;
            if (!validator.IsCorrectName(text) || !validator.IsLengthCorrectMin(text, 1) || categoryController.GetCategoryByName(text) != null)
            {
                e.Cancel = true;
                nCategoryNameTB.Select(0, nCategoryNameTB.Text.Length);

                addButton.Enabled = false; 

                this.errorProvider1.SetError(nCategoryNameTB, "Некорректное имя. Проверьте длину, введенные символы или уникальность.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(nCategoryNameTB, "");
                addButton.Enabled = true;
            }
        }

        private void nCategoryNameTB_Enter(object sender, EventArgs e)
        {
            addButton.Enabled = false;
        }

        private void nCategoryNameTB_Validated(object sender, EventArgs e)
        {
            addButton.Enabled = true;

            errorProvider1.SetError(nCategoryNameTB, "");
        }

        private void categoryNameTB_Validating(object sender, CancelEventArgs e)
        {
            string text = categoryNameTB.Text;
            if (!validator.IsCorrectName(text) || !validator.IsLengthCorrectMin(text, 1) || categoryController.GetCategoryByName(text) != null)
            {
                e.Cancel = true;
                categoryNameTB.Select(0, categoryNameTB.Text.Length);

                updateButton.Enabled = false;

                this.errorProvider1.SetError(categoryNameTB, "Некорректное имя категории. Проверьте длину, введенные символы или уникальность.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(categoryNameTB, "");
                updateButton.Enabled = true;
            }
        }

        private void categoryNameTB_Validated(object sender, EventArgs e)
        {
            updateButton.Enabled = true;

            errorProvider1.SetError(categoryNameTB, "");
        }

        private void categoryNameTB_Enter(object sender, EventArgs e)
        {
            updateButton.Enabled = false;
        }

        private void categoryDescTB_Enter(object sender, EventArgs e)
        {
            if (categoryController.GetCategoryByName(categoryNameTB.Text) != null)
            {
                updateButton.Enabled = true;
            }
        }

        // Товары - категории - кнопки
        private void addButton_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CName = nCategoryNameTB.Text;
            category.CDescription = nCategoryDescTB.Text;

            categoryController.AddCategory(category);

            CreatePanelForCategory(category);

            nCategoryNameTB.Text = "";
            nCategoryDescTB.Text = "";
            addButton.Enabled = false;


            //AddElToCategoryCB(category.CName);
        }

        async private void updateButton_Click(object sender, EventArgs e)
        {
            if (currentCategory != null)
            {
                Panel currentPanel = cPanels.FirstOrDefault(x => x.Value == currentCategory).Key;
                if (currentPanel != null)
                {
                    //ColumnCategoryName.Items.Remove(currentCategory.CName);
                    currentCategory.CName = categoryNameTB.Text;
                    currentCategory.CDescription = categoryDescTB.Text;
                   // AddElToCategoryCB(currentCategory.CName);
                    SetText(currentPanel, "Name", currentCategory.CName);
                    SetText(currentPanel, "Description", currentCategory.CDescription);

                    await categoryController.aUpdateCategory(currentCategory);
                }
                currentCategory = null;

                categoryNameTB.Visible = false;
                categoryDescTB.Visible = false;
                buttonCancel.Visible = false;
                updateButton.Visible = false;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            UpdateCategoryData();
            if (sender != null)
            {
                Control control = (Control)sender;
                Panel panel = (Panel)control.Parent;

                categoryNameTB.Visible = true;
                categoryDescTB.Visible = true;
                buttonCancel.Visible = true;
                updateButton.Visible = true;
                updateButton.Enabled = false;

                Control[] labelsList = panel.Controls.Find("Name", true);
                Label categoryLabel = (Label)labelsList[0];
                categoryNameTB.Text = categoryLabel.Text;

                labelsList = panel.Controls.Find("Description", true);
                RichTextBox categoryTB = (RichTextBox)labelsList[0];
                categoryDescTB.Text = categoryTB.Text;

                Category category;
                if (cPanels.TryGetValue(panel, out category))
                    currentCategory = category;
                else currentCategory = null;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            categoryNameTB.Visible = false;
            categoryDescTB.Visible = false;
            buttonCancel.Visible = false;
            updateButton.Visible = false;
        }

        private void nColNameTB_Validated(object sender, EventArgs e)
        {
            //   addColBtn.Enabled = true;
            buttonAddCol.Enabled = true;

            errorProvider1.SetError(nColNameTB, "");
        }

        private void nColNameTB_Validating(object sender, CancelEventArgs e)
        {
            string text = nColNameTB.Text;
            if (!validator.IsCorrectName(text) || !validator.IsLengthCorrectMin(text, 1) || collectionController.GetCollectionByName(text) != null)
            {
                e.Cancel = true;
                nColNameTB.Select(0, nColNameTB.Text.Length);

                //    addColBtn.Enabled = false;
                buttonAddCol.Enabled = false;

                this.errorProvider1.SetError(nColNameTB, "Некорректное имя коллекции. Проверьте длину, введенные символы или уникальность.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(nColNameTB, "");
                buttonAddCol.Enabled = true;            }
        }

        private void buttonAddCol_Click(object sender, EventArgs e)
        {
            Collection collection = new Collection();
            collection.ColName = nColNameTB.Text;
            switch (nColStatusCB.SelectedItem)
            {
                case "Неактивна":
                    collection.ColStatus = 0;
                    break;
                case "Активна":
                    collection.ColStatus = 1;
                    break;
                default:
                    collection.ColStatus = 2;
                    break;
            }

            collectionController.AddCollection(collection);

            CreatePanelForCollection(collection);

            nColNameTB.Text = "";
            buttonAddCol.Enabled = false;
        }

        private void nColNameTB_Enter(object sender, EventArgs e)
        {
            buttonAddCol.Enabled = false; 
        }

        private void cancelColChangesBtn_Click(object sender, EventArgs e)
        {
            cancelColChangesBtn.Visible = false;
            updateColBtn.Visible = false;
            goodsCLB.Visible = false;
          //  labelChooseGoods.Visible = false;
            colStatusCB.Visible = false;
            colNameTB.Visible = false;
        }

        async private void updateColBtn_Click(object sender, EventArgs e)
        {
            if (currentCollection != null)
            {
                Panel panel = colPanels.FirstOrDefault(x => x.Value == currentCollection).Key;
                List<string> forRemove = new List<string>();

                Control[] elsList = panel.Controls.Find("ColGoods", true);

                if (elsList.Length > 0)
                {
                    ListBox goodsInfo = (ListBox)elsList[0];

                    foreach (string goodInfo in goodsInfo.Items)
                    {
                        if (!goodsCLB.CheckedItems.Contains(goodInfo))
                        {
                            forRemove.Add(goodInfo);
                            string[] article = goodInfo.Split(',');
                            Good good = goodController.GetGoodByArticle(article[0]);
                            goodsCLB.Items.Remove(goodInfo);
                            if (good != null)
                                await goodColController.RemoveGoodCollectionAsync(good, currentCollection);
                        }
                    }

                    for (int i = 0; i < forRemove.Count; i++)
                    {
                        goodsInfo.Items.Remove(forRemove[i]);
                    }

                    foreach (string s in goodsCLB.CheckedItems)
                    {
                        string[] goodInfo = s.Split(',');
                        if (!goodsInfo.Items.Contains(s))
                        {
                            goodsInfo.Items.Add(s);
                            Good good = goodController.GetGoodByArticle(goodInfo[0]);
                            if (good != null)
                                await goodColController.AddGoodCollectionAsync(good, currentCollection);
                        }

                    }
                }

                currentCollection.ColName = colNameTB.Text;
                elsList = panel.Controls.Find("Name", true);
                Label colName = (Label)elsList[0];
                colName.Text = colNameTB.Text;
                elsList = panel.Controls.Find("Status", true);
                Label colStatus = (Label)elsList[0];
                colStatus.Text = colStatusCB.SelectedItem.ToString();
                switch (colStatusCB.SelectedItem)
                {
                    case "Неактивна":
                        currentCollection.ColStatus = 0;
                        break;
                    case "Активна":
                        currentCollection.ColStatus = 1;
                        break;
                    default:
                        currentCollection.ColStatus = 2;
                        break;
                }

                await collectionController.UpdateCollectionAsync(currentCollection);
            }
            else
            {
                ErrorWindow errorWindow = new ErrorWindow("Что-то пошло не так при изменении данных. Попробуйте еще раз.");
                errorWindow.Show();
            }

            cancelColChangesBtn.Visible = false;
            updateColBtn.Visible = false;
            goodsCLB.Visible = false;
          //  labelChooseGoods.Visible = false;
            colStatusCB.Visible = false;
            colNameTB.Visible = false;
        }

        private void colNameTB_Enter(object sender, EventArgs e)
        {
            updateColBtn.Enabled = false;
        }

        private void colNameTB_Validating(object sender, CancelEventArgs e)
        {
            string text = colNameTB.Text;
            if (!validator.IsCorrectName(text) || !validator.IsLengthCorrectMin(text, 1) || collectionController.GetCollectionByName(text) != null)
            {
                e.Cancel = true;
                colNameTB.Select(0, colNameTB.Text.Length);

                updateColBtn.Enabled = false;

                this.errorProvider1.SetError(colNameTB, "Некорректное имя коллекции. Проверьте длину, введенные символы или уникальность.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(colNameTB, "");
                updateColBtn.Enabled = true;
            }
        }

        private void colNameTB_Validated(object sender, EventArgs e)
        {
            updateColBtn.Enabled = true;

            errorProvider1.SetError(nColNameTB, "");
        }

        private void dataGridViewWriteOffs_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string columnName = dataGridViewWriteOffs.Columns[e.ColumnIndex].Name;
            MessageBox.Show("Возникла ошибка вводимых данных: " + e.Exception.ToString() + " row: " + e.RowIndex + " " + columnName);
        }

        private void dataGridViewWriteOffs_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridViewWriteOffs.Rows[e.RowIndex].ErrorText = "";
            DataGridViewColumn currentColumn = dataGridViewWriteOffs.Columns[e.ColumnIndex];
            DataGridViewRow currentRow = dataGridViewWriteOffs.Rows[e.RowIndex];
            DataGridViewCell currentCell = currentRow.Cells[e.ColumnIndex];

            if (currentColumn.HeaderText == "Товар")
            {
                if(goodController.GetGoodByArticle(currentCell.EditedFormattedValue.ToString()) == null)
                {
                    e.Cancel = true;
                    dataGridViewWriteOffs.Rows[e.RowIndex].ErrorText = "Товара с таким артикулом не существует";
                }
            }
            else if (currentColumn.HeaderText == "Количество товара, шт")
            {
                try
                {
                    object article = currentRow.Cells[ColumnGoodInfo.Index].EditedFormattedValue;
                    Good good = goodController.GetGoodByArticle((string)article);
                    int num = Convert.ToInt32(currentCell.EditedFormattedValue);

                    if ((int)num <= 0 || good != null && (int)num > good.GoodNum)
                    {
                        e.Cancel = true;
                        dataGridViewWriteOffs.Rows[e.RowIndex].ErrorText = "Количество списываемого товара должно быть больше 0";
                    }
                    else
                    {
                        if (good != null)
                        {
                            good.GoodNum = good.GoodNum - Convert.ToInt32(e.FormattedValue) + Convert.ToInt32(currentCell.Value);
                            goodController.UpdateGood(good);
                        }
                    }
                }
                catch(Exception)
                {
                    e.Cancel = true;
                    dataGridViewWriteOffs.Rows[e.RowIndex].ErrorText = "Некорректное число";
                }
               
            }
            else if (currentColumn.HeaderText == "Дата списания")
            {
                try
                {
                    //      Convert.ToDateTime(e.FormattedValue);
                    DateTime.ParseExact(currentCell.EditedFormattedValue.ToString(), "dd.MM.yyyy", provider);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    dataGridViewWriteOffs.Rows[e.RowIndex].ErrorText = "Некорректная дата";
                }
            }
            else if(currentColumn.HeaderText == "Причина")
            {
                WriteOffReason reason = writeOffReasonController.GetReasonByName(currentCell.EditedFormattedValue.ToString());
                currentRow.Cells[ColumnReasonId.Index].Value = reason.Id;
            }
        }

        private void dataGridViewWriteOffs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn currentColumn = dataGridViewWriteOffs.Columns[e.ColumnIndex];
            DataGridViewRow currentRow = dataGridViewWriteOffs.Rows[e.RowIndex];
            DataGridViewCell currentCell = currentRow.Cells[e.ColumnIndex];

            int writeOffNum = (int)currentRow.Cells[ColumnWriteOffId.Index].Value;
            if (writeOffNum > 0)
            {
                WriteOff currWriteOff = writeOffController.GetWriteOff(writeOffNum);
                if(currWriteOff != null)
                {
                    if (currentColumn.HeaderText == "Товар")
                    {
                        Good good = goodController.GetGoodByArticle((string)currentCell.Value);
                        currentRow.Cells[ColumnGoodIdWriteOff.Index].Value = good.Id;
                        if (currentRow.Cells[ColumnGoodWriteOffNum.Index].Value != null && good.GoodNum < Convert.ToInt32(currentRow.Cells[ColumnGoodWriteOffNum.Index].Value))
                            currentRow.Cells[ColumnGoodWriteOffNum.Index].Value = good.GoodNum;
                        currWriteOff.Good = good;
                    }
                    else if (currentColumn.HeaderText == "Причина")
                    {
                        WriteOffReason reason = writeOffReasonController.GetReasonByName((string)currentCell.EditedFormattedValue);
                        currentRow.Cells[ColumnReasonId.Index].Value = reason.Id;
                        currWriteOff.Reason = reason;
                    }
                    else if (currentColumn.HeaderText == "Дата списания")
                    {
                        currWriteOff.WriteOffDate = Convert.ToDateTime(currentCell.Value);
                    }
                    else if (currentColumn.HeaderText == "Количество товара, шт")
                    {
                        
                        currWriteOff.GoodNum = Convert.ToInt32(currentCell.EditedFormattedValue);

                    }
                    else if (currentColumn.HeaderText == "Статус списания")
                    {
                        currentRow.Cells[ColumnWriteOffStatusNum.Index].Value = (short)ColumnWriteOffStatus.Items.IndexOf((string)currentCell.Value);
                        currWriteOff.WriteOffStatus = (short)ColumnWriteOffStatus.Items.IndexOf((string)currentCell.Value);
                    }

                    writeOffController.UpdateWriteOff(currWriteOff);
                }
            }
            else
            {
                if (currentColumn.HeaderText == "Товар")
                {
                    Good good = goodController.GetGoodByArticle((string)currentCell.Value);
                    currentRow.Cells[ColumnGoodIdWriteOff.Index].Value = good.Id;
                }
                else if (currentColumn.HeaderText == "Причина")
                {
                    WriteOffReason reason = writeOffReasonController.GetReasonByName((string)currentCell.Value);
                    currentRow.Cells[ColumnReasonId.Index].Value = reason.Id;
                }
                else if (currentColumn.HeaderText == "Статус списания")
                {
                    currentRow.Cells[ColumnWriteOffStatusNum.Index].Value = (short)ColumnWriteOffStatus.Items.IndexOf((string)currentCell.Value);
                }
            }
        }

        private void dataGridViewWriteOffs_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewWriteOffs.Rows[e.RowIndex].ErrorText = null;
        }

        private void dataGridViewWriteOffs_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            string message;
            DataGridViewRow row = dataGridViewWriteOffs.Rows[e.RowIndex];
            foreach (DataGridViewColumn c in dataGridViewWriteOffs.Columns)
            {
                message = DataGridViewWriteOffsValidatingCell(c, row.Cells[c.Index].Value, row);
                if (message != "")
                {
                    e.Cancel = true;
                    dataGridViewWriteOffs.Rows[e.RowIndex].ErrorText = message;

                    break;
                }
            }
        }

        private void dataGridViewWriteOffs_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
        }

        private string DataGridViewWriteOffsValidatingCell(DataGridViewColumn currentColumn, object value, DataGridViewRow row)
        {
            string errorMsg = "";
            if (currentColumn.HeaderText == "Товар")
            {
                if (goodController.GetGoodByArticle((string)value) == null)
                {
                    errorMsg = "Товара с таким артикулом не существует";
                }
            }
            else if (currentColumn.HeaderText == "Количество товара, шт")
            {
                try
                {
                    object article = row.Cells[ColumnGoodInfo.Index].EditedFormattedValue;
                    Good good = goodController.GetGoodByArticle((string)article);
                    int num = Convert.ToInt32(value);
                    if ((int)num <= 0 || (int)num > good.GoodNum)
                    {
                        errorMsg = "Количество списываемого товара должно быть больше 0 и не больше имеющегося кол-ва";
                    }
                }
                catch (Exception)
                {
                    errorMsg = "Некорректное число";
                }

            }
            else if (currentColumn.HeaderText == "Дата списания")
            {
                try
                {
                    Convert.ToDateTime(value);
                }
                catch (Exception)
                {
                    errorMsg = "Некорректная дата";
                }
            }
            return errorMsg;
        }

        private void dataGridViewWriteOffs_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewWriteOffs.Rows[e.RowIndex].ErrorText = null;
        }

        private void dataGridViewWriteOffs_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewWriteOffs.Rows[e.RowIndex];
            Console.WriteLine((int)currentRow.Cells[ColumnWriteOffId.Index].Value);
            if((int)currentRow.Cells[ColumnWriteOffId.Index].Value == 0)
            {
                try
                {
                    WriteOff writeOff = new WriteOff();
                    object value = currentRow.Cells[ColumnGoodInfo.Index].EditedFormattedValue;
                    Good good = goodController.GetGoodByArticle((string)value);
                    writeOff.Good = good;
                    value = currentRow.Cells[ColumnGoodWriteOffNum.Index].EditedFormattedValue;
                    writeOff.GoodNum = Convert.ToInt32((string)value);
                   
                    value = currentRow.Cells[ColumnReason.Index].EditedFormattedValue;
                    writeOff.Reason = writeOffReasonController.GetReasonByName((string)value);
                    value = currentRow.Cells[WriteOffDateColumn.Index].EditedFormattedValue;
                    writeOff.WriteOffDate = Convert.ToDateTime((string)value);
                    value = currentRow.Cells[ColumnWriteOffStatusNum.Index].EditedFormattedValue;
                    writeOff.WriteOffStatus = Convert.ToInt16((string)value);

                    if (previous == null || currentRow != previous)
                    {
                        if (writeOff.GoodNum <= 0) throw new Exception("Некорректное количество товароа");
                        else good.GoodNum -= writeOff.GoodNum;
                        goodController.UpdateGood(good);
                        writeOffController.AddWriteOff(writeOff);
                        
                    }
                    previous = currentRow;
                        

                    BindingList<WriteOff> writeOffs = new BindingList<WriteOff>(writeOffController.GetWriteOffs());
                    dataGridViewWriteOffs.DataSource = null;
                    dataGridViewWriteOffs.DataSource = writeOffs;

                }
                catch(Exception) { }
            }

        }

        async private void dataGridViewWriteOffs_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            await writeOffController.aDeleteWriteOff((int)e.Row.Cells[ColumnWriteOffId.Index].Value);
        }

      
        async private void removeButton_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Panel panel = (Panel)control.Parent;
            Category rCategory = null;

            UpdateCategoryData();
            bool canRemove = false;

            int maxY = panel.Location.Y;
            foreach (Panel p in cPanels.Keys)
            {
                if (p == panel)
                {
                    if (cPanels.TryGetValue(p, out rCategory))
                    {
                        if (rCategory.Good.Count > 0)
                        {
                            ErrorWindow err = new ErrorWindow("Данная категория не может быть удалена: к ней привязаны определенные товары.");
                            err.Show();
                            break;
                        }
                        locY -= 103;
                        await categoryController.aRemoveCategory(rCategory);
                        tabControlGood.Controls.Remove(panel);
                        canRemove = true;
                        panel.Hide();

                        //ColumnCategoryName.Items.Remove(rCategory.CName);
                    }
                }
                if (p.Location.Y > maxY)
                {
                    p.Location = new Point(p.Location.X, p.Location.Y - 103);
                }

            }
            if (canRemove) cPanels.Remove(panel);
        }

        private void SetText(Panel panel, string textContainerName, string text)
        {
            Control[] elsList = panel.Controls.Find(textContainerName, true);
            switch(textContainerName)
            {
                case "Name": 
                    Label categoryL = (Label)elsList[0];
                    categoryL.Text = text;
                    break;
                case "Discount":
                    Label discountL = (Label)elsList[0];
                    discountL.Text = text;
                    break;
                case "GoodNum":
                    Label goodNumL = (Label)elsList[0];
                    goodNumL.Text = text;
                    break;
                case "FreeGoodNum":
                    Label freeGoodNumL = (Label)elsList[0];
                    freeGoodNumL.Text = text;
                    break;
                default:
                    RichTextBox categoryTB = (RichTextBox)elsList[0];
                    categoryTB.Text = text;
                    break;
            }
        }

        private void SetCBValue(Panel panel, short statusCode)
        {
            Control[] elsList = panel.Controls.Find("Status", true);
            Label statusLabel = (Label)elsList[0];
            switch (statusCode)
            {
                case 0:
                    statusLabel.Text = "Неактивна";
                    break;
                case 1:
                    statusLabel.Text = "Активна";
                    break;
                case 2:
                    statusLabel.Text = "Коллекция главного окна";
                    break;
            }
        }

        // Header
        private void pictureBoxLogOut_Click(object sender, EventArgs e)
        {
            LoginForm loginWindow = new LoginForm();
            loginWindow.Show();
            this.Hide();
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void promNameTB_Validating(object sender, CancelEventArgs e)
        {
            string text = promNameTB.Text;
            if (!validator.IsCorrectName(text) || !validator.IsLengthCorrectMin(text, 1))
            {
                e.Cancel = true;
                promNameTB.Select(0,promNameTB.Text.Length);

               buttonAddProm.Enabled = false;
                promFieldsNum--;

                this.errorProvider1.SetError(promNameTB, "Некорректное имя для акции. Проверьте длину, введенные символы или уникальность.");
            }
        }

        private void promDiscountTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!iValidator.IsDigitOrControl(e.KeyChar))
                e.Handled = true;
        }

        private void promDiscountTB_Validating(object sender, CancelEventArgs e)
        {
            string text = promDiscountTB.Text;
            if (!validator.IsLengthCorrectMin(text, 1) || !dValidator.IsCorrectIntValMax(Convert.ToInt16(text), 100) || !dValidator.IsCorrectIntValMin(Convert.ToInt16(text), 0))
            {
                e.Cancel = true;
                promDiscountTB.Select(0, promDiscountTB.Text.Length);

                buttonAddProm.Enabled = false;
                promFieldsNum--;

                this.errorProvider1.SetError(promDiscountTB, "Проверьте, чтобы выбранный диапазон включал числа от 0 до 100");
            }
        }

        private void goodPromNumTB_Validating(object sender, CancelEventArgs e)
        {
            string text = goodPromNumTB.Text;
            if (!validator.IsLengthCorrectMin(text, 1) || !dValidator.IsCorrectIntValMin(Convert.ToInt16(text), 1))
            {
                e.Cancel = true;
                goodPromNumTB.Select(0, goodPromNumTB.Text.Length);

                buttonAddProm.Enabled = false;
                promFieldsNum--;

                this.errorProvider1.SetError(goodPromNumTB, "Число товаров не может быть меньше 1");
            }
        }

        private void freeGoodPromNumTB_Validating(object sender, CancelEventArgs e)
        {
            string text = freeGoodPromNumTB.Text;
            if (!validator.IsLengthCorrectMin(text, 1) || !dValidator.IsCorrectIntValMin(Convert.ToInt16(text), 0))
            {
                e.Cancel = true;
                freeGoodPromNumTB.Select(0, freeGoodPromNumTB.Text.Length);

                buttonAddProm.Enabled = false;
                promFieldsNum--;

                this.errorProvider1.SetError(freeGoodPromNumTB, "Число товаров не может быть меньше 0");
            }
        }

        private void promDiscountTB_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(promDiscountTB, "");
            promFieldsNum++;
            if (promFieldsNum == 4)
                buttonAddProm.Enabled = true;
        }

        private void goodPromNumTB_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(goodPromNumTB, "");
            promFieldsNum++;
            if (promFieldsNum == 4)
                buttonAddProm.Enabled = true;
        }

        private void freeGoodPromNumTB_Validated(object sender, EventArgs e)
        {

            errorProvider1.SetError(freeGoodPromNumTB, "");
            promFieldsNum++;
            if (promFieldsNum == 4)
                buttonAddProm.Enabled = true;
        }

        private void promNameTB_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(promNameTB, "");
            promFieldsNum++;
            if (promFieldsNum == 4)
                buttonAddProm.Enabled = true;
        }

        async private void buttonUpdateProm_Click(object sender, EventArgs e)
        {
            if (currentPromotion != null)
            {
                Panel panel = promPanels.FirstOrDefault(x => x.Value == currentPromotion).Key;
                List<string> forRemove = new List<string>();

                Control[] elsList = panel.Controls.Find("PromGoods", true);

                if (elsList.Length > 0)
                {
                    ListBox goodsInfo = (ListBox)elsList[0];

                    foreach (string goodInfo in goodsInfo.Items)
                    {
                        if (!goodsPromCLB.CheckedItems.Contains(goodInfo))
                        {
                            forRemove.Add(goodInfo);
                            string[] article = goodInfo.Split(',');
                            Good good = goodController.GetGoodByArticle(article[0]);
                            if (good != null)
                                await goodPromotionController.aRemoveGoodPromotion(good, currentPromotion);
                        }
                    }

                    for (int i = 0; i < forRemove.Count; i++)
                    {
                        goodsInfo.Items.Remove(forRemove[i]);
                    }

                    foreach (string s in goodsPromCLB.CheckedItems)
                    {
                        string[] goodInfo = s.Split(',');
                        if (!goodsInfo.Items.Contains(s))
                        {
                            goodsInfo.Items.Add(s);
                            Good good = goodController.GetGoodByArticle(goodInfo[0]);
                            if (good != null)
                            {
                                GoodPromotion goodPromotion = new GoodPromotion();
                                goodPromotion.Good = good;
                                goodPromotion.Promotion = currentPromotion;
                                await goodPromotionController.aAddGoodPromotion(goodPromotion);
                            }
                        }
                    }
                }

                currentPromotion.PromotionName = promNameTB.Text;
                elsList = panel.Controls.Find("Name", true);
                Label promLabel = (Label)elsList[0];
                promLabel.Text = promNameTB.Text;

                currentPromotion.Discount = Convert.ToInt16(promDiscountTB.Text);
                elsList = panel.Controls.Find("Discount", true);
                promLabel = (Label)elsList[0];
                promLabel.Text = promDiscountTB.Text;

                currentPromotion.GoodNum = Convert.ToInt16(goodPromNumTB.Text);
                elsList = panel.Controls.Find("GoodNum", true);
                promLabel = (Label)elsList[0];
                promLabel.Text = goodPromNumTB.Text;

                currentPromotion.FreeGoodNum = Convert.ToInt16(freeGoodPromNumTB.Text);
                elsList = panel.Controls.Find("FreeGoodNum", true);
                promLabel = (Label)elsList[0];
                promLabel.Text = freeGoodPromNumTB.Text;

                currentPromotion.DateBegin = dateTimePickerPromStart.Value;
                if (dtValidator.IsDateAcceptable(dateTimePickerPromEnd.Value, dateTimePickerPromStart.Value))
                    currentPromotion.DateEnd = dateTimePickerPromEnd.Value;
                else currentPromotion.DateEnd = null;
                elsList = panel.Controls.Find("Date", true);
                promLabel = (Label)elsList[0];
                string promDateEnd = currentPromotion.DateEnd == null ? "?" : currentPromotion.DateEnd.Value.ToShortDateString();

                promLabel.Text = currentPromotion.DateBegin.Date.ToShortDateString() + "-" + promDateEnd;

                await promotionController.aUpdatePromotion(currentPromotion);
            }
            else
            {
                ErrorWindow errorWindow = new ErrorWindow("Что-то пошло не так при изменении данных. Попробуйте еще раз.");
                errorWindow.Show();
            }
            int count = goodsPromCLB.Items.Count;
            for(int i = 0; i < count; i++)
            {
                if(goodsPromCLB.GetItemChecked(i))
                    goodsPromCLB.SetItemChecked(i, false);
            }
            buttonAddProm.Visible = true;
            buttonAddProm.Enabled = true;
            buttonCancelUpdateProm.Visible = false;
            buttonUpdateProm.Visible = false;

            promNameTB.Text = "";
            promDiscountTB.Text = "";
            goodPromNumTB.Text = "";
            freeGoodPromNumTB.Text = "";

            dateTimePickerPromStart.Value = dateTimePickerPromEnd.Value = DateTime.Now;
        }

        async private void buttonAddProm_Click(object sender, EventArgs e)
        {
            Promotion promotion = new Promotion();
            DateTime startDate = dateTimePickerPromStart.Value;
            promotion.DateBegin = startDate;
            DateTime finishDate = dateTimePickerPromEnd.Value;
            if (dtValidator.IsDateAcceptable(finishDate, startDate))
                promotion.DateEnd = finishDate;

            promotion.Discount = Convert.ToInt16(promDiscountTB.Text);
            promotion.GoodNum = Convert.ToInt16(goodPromNumTB.Text);
            promotion.FreeGoodNum = Convert.ToInt16(freeGoodPromNumTB.Text);
            promotion.PromotionName = promNameTB.Text;

            ListBox lb = CreatePanelForPromotion(promotion);

            promotionController.AddPromotion(promotion);
            foreach(string goodInfo in goodsPromCLB.CheckedItems)
            {
                
                string[] article = goodInfo.Split(',');
                Good good = goodController.GetGoodByArticle(article[0]);
                lb.Items.Add(goodInfo);
                GoodPromotion goodPromotion = new GoodPromotion();
                goodPromotion.Good = good;
                goodPromotion.Promotion = promotion;

                await goodPromotionController.aAddGoodPromotion(goodPromotion);
            }
            goodsPromCLB.Items.Clear();
            foreach (Good g in goodController.GetGoods())
                goodsPromCLB.Items.Add(g.Article + ", " + g.GoodName);

            promNameTB.Text = "";
            promDiscountTB.Text = "";
            goodPromNumTB.Text = "";
            freeGoodPromNumTB.Text = "";
            buttonAddProm.Enabled = false;
            promFieldsNum = 0;
        }

        private void textBox19_Validating(object sender, CancelEventArgs e)
        {
            string text = textBox19.Text;
            if (string.IsNullOrWhiteSpace(text) || !validator.IsLengthCorrectMin(text, 5))
            {
                e.Cancel = true;
                textBox19.Select(0, textBox19.Text.Length);

                this.errorProvider1.SetError(textBox19, "Введите хотя бы 5 символов");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox19, "");
                updateButton.Enabled = true;
            }
        }

        private void PBSearchGoodForOrder_Click(object sender, EventArgs e)
        {
            panelSearchResults.Controls.Clear();
            List<Good> articleSearchedGoods = goodController.SearchByArticle(textBox19.Text);
            List<Good> nameSearchedGoods = goodController.SearchByName(textBox19.Text);
            int X = 17;
            int Y = 21;
            foreach (Good g in articleSearchedGoods)
            {
                if (!nameSearchedGoods.Contains(g)) nameSearchedGoods.Add(g);
            }

            List<RadioButton> results = new List<RadioButton>();
            foreach (Good g in nameSearchedGoods)
            {
                RadioButton goodItem = new RadioButton();
                goodItem.Location = new Point(X, Y);
                goodItem.CheckedChanged += new EventHandler(goodRadioButton_Checked);
                goodItem.AutoSize = true;
                goodItem.Text = g.Article + ", " + g.GoodName + ", кол-во " + g.GoodNum + ", цена " + g.Price;
                results.Add(goodItem);
                Y += 39;
            }
            TBDiscount.Text = "0";
            TBGoodsForFree.Text = "0";
            textBoxGoodsNumber.Text = "1";

            for (int i = 0; i < results.Count; i++) 
            panelSearchResults.Controls.Add(results[i]);
        }

        async private void buttonGoodsOrderPicker_Click(object sender, EventArgs e)
        {
            panelGoodsOrderPicker.Visible = false;

            foreach (Order o in orderPanels.Values)
            {
                if(o.OrderNumber == orderNumLabel.Text)
                {
                    Panel panel = orderPanels.FirstOrDefault(x => x.Value == o).Key;
                    Control[] elsList = panel.Controls.Find("OrderGoodsNames", true);
                    ListBox listBoxGoodsNames = (ListBox)elsList[0];
                    elsList = panel.Controls.Find("OrderGoodsPrices", true);
                    ListBox listBoxGoodsPrices = (ListBox)elsList[0];
                    elsList = panel.Controls.Find("OrderGoodsPromotions", true);
                    ListBox listBoxGoodsPromotions = (ListBox)elsList[0];
                    elsList = panel.Controls.Find("OrderGoodsNumbers", true);
                    ListBox listBoxGoodsNumbers = (ListBox)elsList[0];
                    elsList = panel.Controls.Find("OrderGoodsFinalCount", true);
                    ListBox listBoxGoodsFinalCount = (ListBox)elsList[0];

                    elsList = panel.Controls.Find("FinalCost", true);
                    TextBox orderTB = (TextBox)elsList[0];

                    int count = Convert.ToInt32(textBoxGoodsNumber.Text) + Convert.ToInt32(TBGoodsForFree.Text);
                    Good good = goodController.GetGoodByArticle(goodArticleLabel.Text);
                    good.GoodNum -= count;
                    OrderGood orderGood = new OrderGood();
                    orderGood.Good = good;
                    orderGood.Order = o;

                    listBoxGoodsNames.Items.Add(good.Article + ", " + good.GoodName);
                    listBoxGoodsPrices.Items.Add(good.Price);
                    listBoxGoodsPromotions.Items.Add(TBDiscount.Text);
                    listBoxGoodsNumbers.Items.Add(count);
                    short discountVal = Convert.ToInt16(TBDiscount.Text);
                    orderGood.Discount = discountVal;
                    orderGood.GoodNum = Convert.ToInt32(textBoxGoodsNumber.Text);
                    orderGood.FreeGoodNum = Convert.ToInt16(TBGoodsForFree.Text);
                    float discount = 1 - 0.01f * discountVal;
                    decimal finalCount = good.Price * orderGood.GoodNum * (decimal)discount;
                    o.TotalCost += finalCount;
                    orderTB.Text = o.TotalCost.ToString();
                    listBoxGoodsFinalCount.Items.Add(finalCount);

                    await orderGoodController.AddGoodOrderAsync(orderGood);
                    await goodController.UpdateGoodAsync(good);
                    await orderController.UpdateOrderAsync(o);

                    panelSearchResults.Controls.Clear();

                    break;
                }
            }
        }

        private void textBoxGoodsNumber_TextChanged(object sender, EventArgs e)
        {
            if (textBoxGoodsNumber.Text != "")
            {
                short currDiscount = Convert.ToInt16(TBDiscount.Text);
                float discount = 1 - 0.01f * currDiscount;
                Good g = goodController.GetGoodByArticle(goodArticleLabel.Text);
                decimal currPrice = g.Price * Convert.ToInt32(textBoxGoodsNumber.Text) * (decimal)discount;

                labelResultPriceForGood.Text = "Итого: " + currPrice.ToString();
            }
        }

        private void TBDiscount_TextChanged(object sender, EventArgs e)
        {
            if (TBDiscount.Text != "")
            {
                short currDiscount = Convert.ToInt16(TBDiscount.Text);
                float discount = 1 - 0.01f * currDiscount;
                Good g = goodController.GetGoodByArticle(goodArticleLabel.Text);
                decimal currPrice = g.Price * Convert.ToInt32(textBoxGoodsNumber.Text) * (decimal)discount;

                labelResultPriceForGood.Text = "Итого: " + currPrice.ToString();
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!iValidator.IsAddressElement(e.KeyChar))
                e.Handled = true;
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!iValidator.IsCorrectIndex(e.KeyChar))
                e.Handled = true;
        }

        private void textBox12_Validating(object sender, CancelEventArgs e)
        {
            TextBox data = (TextBox)sender;
            if(!validator.IsCorrectName(data.Text))
            {
                e.Cancel = true;
                textBox19.Select(0, textBox19.Text.Length);

                this.errorProvider1.SetError(textBox19, "Поле должно быть заполнено");
            }
        }

        private void textBox12_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            errorProvider1.SetError(textBox, "");
        }

        async private void buttonAddAddress_Click(object sender, EventArgs e)
        {
            Address address = new Address();
            address.AddIndex = textBox12.Text;
            switch(comboBoxAddress.SelectedItem)
            {
                case "Действующий пункт самовывоза":
                    address.AddType = 0;
                    break;
                case "Неактивный пункт самовывоза":
                    address.AddType = 1;
                    break;
            }
            address.ApartmentNum = textBoxAppartment.Text;
            address.House = textBoxHouse.Text;
            string name = textBoxCountry.Text;
            Country country = countryController.GetCountry(name);
            if (country == null)
            {
                country = new Country();
                country.CountryName = name;
                countryController.AddCountry(country);
                country = countryController.GetCountry(name);
            }

            name = textBoxRegion.Text;
            Region region = regionController.GetRegion(name, country);
            if (region == null)
            {
                region = new Region();
                region.RegionName = name;
                region.Country = country;
                regionController.AddDetachedRegion(region);
                region = regionController.GetRegion(name, country);
            }

            name = textBoxCity.Text;
            City city = cityController.GetCity(name, region);
            if (city == null)
            {
                city = new City();
                city.CityName = name;
                city.Region = region;
                cityController.AddDetachedCity(city);
                city = cityController.GetCity(name, region);
            }

            name = textBoxStreetName.Text;
            Street street = streetController.GetStreet(name, city);
             if (street == null)
            {
                street = new Street();
                street.StreetName = name;
                street.City = city;
                streetController.AddDetachedStreet(street);
                street = streetController.GetStreet(name, city);
            }
            address.Street = street;
            //Country country = countryController.GetCountry(name);
            //Street street;
            //if(country == null)
            //{
            //    country = new Country();
            //    country.CountryName = name;
            //    countryController.AddCountry(country);
            //    country = countryController.GetCountry(name);

            //    name = textBoxRegion.Text;
            //    DataBase.Entities.Region region = NewRegion(name, country);

            //    name = textBoxCity.Text;
            //    City city = NewCity(name, region);

            //    name = textBoxStreetName.Text;
            //    street = NewStreet(name, city);
            //}
            //else
            //{
            //    name = textBoxRegion.Text;
            //    Region region = regionController.GetRegion(name, country);
            //    if(region == null)
            //    {
            //        region = NewRegion(name, country);

            //        name = textBoxCity.Text;
            //        City city = NewCity(name, region);

            //        name = textBoxStreetName.Text;
            //        street = NewStreet(name, city);
            //    }
            //    else
            //    {
            //        name = textBoxCity.Text;
            //        City city = cityController.GetCity(name, region);
            //        if (city == null)
            //        {
            //            city = NewCity(name, region);

            //            name = textBoxStreetName.Text;
            //            street = NewStreet(name, city);
            //        }
            //        else
            //        {
            //            name = textBoxStreetName.Text;
            //            street = streetController.GetStreet(name, city);
            //            if(street == null)
            //            {
            //                street = NewStreet(name, city);
            //            }
            //        }
            //    }
            //}
            if (addressController.GetByAll(address.Street, address.AddIndex, address.AddType, address.House, address.ApartmentNum) == null)
            {
                await addressController.aAddAddress(address);
                textBox12.Text = textBoxCountry.Text = textBoxRegion.Text = textBoxCity.Text = textBoxStreetName.Text = textBoxHouse.Text = textBoxAppartment.Text = "";
                comboBoxAddress.SelectedItem = comboBoxAddress.Items[0];

                CreatePanelForAddress(address);
            }
            else
            {
                ErrorWindow window = new ErrorWindow("Такой адрес уже есть в системе");
                window.Show();
            }
        }

        private Region NewRegion(string name, Country country)
        {
            DataBase.Entities.Region region = new DataBase.Entities.Region();
            region.RegionName = name;
            region.Country = country;
            regionController.AddRegion(region);
            return regionController.GetRegion(name, country);
        }

        private City NewCity(string name, Region region)
        {
            City city = new City();
            city.CityName = name;
            city.Region = region;
            cityController.AddCity(city);
            return cityController.GetCity(name, region);
        }

        private Street NewStreet(string name, City city)
        {
            Street street = new Street();
            street.StreetName = name;
            street.City = city;
            streetController.AddStreet(street);
            return  streetController.GetStreet(name, city);
        }

        private void buttonCancelUpdateAddress_Click(object sender, EventArgs e)
        {
            textBox12.Text = textBoxCountry.Text = textBoxRegion.Text = textBoxCity.Text = textBoxStreetName.Text = textBoxHouse.Text = textBoxAppartment.Text = "";
            comboBoxAddress.SelectedItem = comboBoxAddress.Items[0];
            buttonUpdateAddress.Visible = false;
            buttonCancelUpdateAddress.Visible = false;
            buttonAddAddress.Visible = true;
        }

        private void buttonUpdateAddress_Click(object sender, EventArgs e)
        {
            if(currentAddress != null)
            {
                Panel panel = addressPanels.FirstOrDefault(x => x.Value == currentAddress).Key;
                currentAddress.AddIndex = textBox12.Text;
                switch (comboBoxAddress.SelectedItem)
                {
                    case "Действующий пункт самовывоза":
                        currentAddress.AddType = 0;
                        break;
                    case "Неактивный пункт самовывоза":
                        currentAddress.AddType = 1;
                        break;
                }
                currentAddress.ApartmentNum = textBoxAppartment.Text;
                currentAddress.House = textBoxHouse.Text;
                string name = textBoxCountry.Text;
                Country country = countryController.GetCountry(name);
                if (country == null) {
                    country = new Country();
                    country.CountryName = name;
                    countryController.AddCountry(country);
                    country = countryController.GetCountry(name);
                }

                name = textBoxRegion.Text;
                Region region = regionController.GetRegion(name, country);
                if (region == null)
                {
                    region = new Region();
                    region.RegionName = name;
                    region.Country = country;
                    regionController.AddDetachedRegion(region);
                    region = regionController.GetRegion(name, country);
                }

                name = textBoxCity.Text;
                City city = cityController.GetCity(name, region);
                if (city == null)
                {
                    city = new City();
                    city.CityName = name;
                    city.Region = region;
                    cityController.AddDetachedCity(city);
                    city = cityController.GetCity(name, region);
                }

                name = textBoxStreetName.Text;
                Street street = streetController.GetStreet(name, city);
                if (street == null)
                {
                    street = new Street();
                    street.City = city;
                    street.StreetName = name;
                    streetController.AddDetachedStreet(street);
                    street = streetController.GetStreet(name, city);
                }

                currentAddress.Street = street;

                Address address = addressController.GetByAll(currentAddress.Street, currentAddress.AddIndex, currentAddress.AddType, currentAddress.House, currentAddress.ApartmentNum);
                if(address == null)
                {
                    

                    Control[] elsList = panel.Controls.Find("Type", true);
                    Label addressLabel = (Label)elsList[0];
                    addressLabel.Text = comboBoxAddress.SelectedItem.ToString();
                    elsList = panel.Controls.Find("Index", true);
                    addressLabel = (Label)elsList[0];
                    addressLabel.Text = currentAddress.AddIndex;
                    elsList = panel.Controls.Find("Country", true);
                    addressLabel = (Label)elsList[0];
                    addressLabel.Text = country.CountryName;
                    elsList = panel.Controls.Find("Region", true);
                    addressLabel = (Label)elsList[0];
                    addressLabel.Text = region.RegionName;
                    elsList = panel.Controls.Find("City", true);
                    addressLabel = (Label)elsList[0];
                    addressLabel.Text = city.CityName;
                    elsList = panel.Controls.Find("Street", true);
                    addressLabel = (Label)elsList[0];
                    addressLabel.Text = currentAddress.Street.StreetName;
                    elsList = panel.Controls.Find("House", true);
                    addressLabel = (Label)elsList[0];
                    addressLabel.Text = currentAddress.House;
                    elsList = panel.Controls.Find("Appartment", true);
                    addressLabel = (Label)elsList[0];
                    addressLabel.Text = currentAddress.ApartmentNum;

                    textBox12.Text = textBoxCountry.Text = textBoxRegion.Text = textBoxCity.Text = textBoxStreetName.Text = textBoxHouse.Text = textBoxAppartment.Text = "";
                    comboBoxAddress.SelectedItem = comboBoxAddress.Items[0];
                    addressController.UpdateAddress(currentAddress);
                }
                else
                {
                    ErrorWindow window;
                    if (address.Id == currentAddress.Id)
                    {
                        window = new ErrorWindow("Вы не внесли изменений");
                    }
                    else 
                        window = new ErrorWindow("Такой адрес уже есть в системе");
                    window.Show();      
                }

                currentAddress = null;

                buttonUpdateAddress.Visible = false;
                buttonCancelUpdateAddress.Visible = false;
                buttonAddAddress.Visible = true;
            }
        }

        private void dataGridViewReviews_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Review reviewToDelete = reviews.First(review => review.Id == Convert.ToInt32(e.Row.Cells[ColumnReviewId.Index].Value));
            reviewController.RemoveReview(reviewToDelete.Id);
         //   reviews.Remove(reviewToDelete);
        }

        async private void dataGridViewReviews_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Review reviewToUpdate = reviews.First(review => review.Id == Convert.ToInt32(dataGridViewReviews.Rows[e.RowIndex].Cells[ColumnReviewId.Index].Value));
            reviewToUpdate.ReviewText = dataGridViewReviews.Rows[e.RowIndex].Cells[ColumnReview.Index].Value.ToString();

            await reviewController.UpdateReviewAsync(reviewToUpdate);
        }

        private void dataGridViewReviews_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for(int i = 0; i < dataGridViewReviews.Rows.Count; i++)
            {
                Good good = goodController.GetGood(Convert.ToInt32(dataGridViewReviews.Rows[i].Cells[ColumnReviewGoodId.Index].Value));
                dataGridViewReviews.Rows[i].Cells[ColumnReviewGood.Index].Value = good.Article + ", " + good.GoodName;

                Person user = personController.GetUser(Convert.ToInt32(dataGridViewReviews.Rows[i].Cells[ColumnReviewUserId.Index].Value));
                dataGridViewReviews.Rows[i].Cells[ColumnReviewUser.Index].Value = user.PersonSurname + " " + user.PersonName + " " + user.PersonPatronymic;
            }
        }
        private void dataGridViewReviews_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewReviews.Rows[e.RowIndex].ErrorText = null;
        }

        private void dataGridViewReviews_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridViewReviews.Rows[e.RowIndex].ErrorText = "";
            DataGridViewColumn currentColumn = dataGridViewReviews.Columns[e.ColumnIndex];

            if (currentColumn.HeaderText == "Отзыв")
            {
                if (!validator.IsLengthCorrectMin((string)e.FormattedValue, 1))
                {
                    e.Cancel = true;
                    dataGridViewReviews.Rows[e.RowIndex].ErrorText = "Некорректная длина строки: минимальное значение = 1";
                }
            }
        }

        private void dataGridViewGoodInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn currentColumn = dataGridViewGoodInfo.Columns[e.ColumnIndex];
            DataGridViewRow currentRow = dataGridViewGoodInfo.Rows[e.RowIndex];
            DataGridViewCell currentCell = currentRow.Cells[e.ColumnIndex];

            if (currentColumn.HeaderText == "Категория")
            {
                Category category = categoryController.GetCategoryByName(currentCell.EditedFormattedValue.ToString());
                dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodCategoryId.Index].Value = category.Id;
            }

                if (dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodId.Index].EditedFormattedValue != null && Convert.ToInt32(dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodId.Index].EditedFormattedValue) > 0)
            {
                Good good = goods.First(g => g.Id == Convert.ToInt32(dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodId.Index].EditedFormattedValue));

                if (currentColumn.HeaderText == "Название")
                    good.GoodName = (string)currentCell.Value;
                else if (currentColumn.HeaderText == "Категория")
                {
                    Category changedCategory = categoryController.GetCategoryByName(currentCell.EditedFormattedValue.ToString());
                    currentRow.Cells[ColumnGoodCategoryId.Index].Value = changedCategory.Id;
                    good.Category = changedCategory;
                }
                else if (currentColumn.HeaderText == "Артикул")
                    good.Article = currentCell.EditedFormattedValue.ToString();
                else if (currentColumn.HeaderText == "Количество товаров")
                    good.GoodNum = Convert.ToInt32(currentCell.EditedFormattedValue);
                else if (currentColumn.HeaderText == "Описание")
                    good.GoodDescription = currentCell.EditedFormattedValue.ToString();
                else if (currentColumn.HeaderText == "Цена")
                    good.Price = Convert.ToDecimal(currentCell.EditedFormattedValue.ToString());
                else if (currentColumn.HeaderText == "Дата выпуска")
                    good.ReleaseDate = DateTime.ParseExact(currentCell.EditedFormattedValue.ToString(), "dd.MM.yyyy", provider);
              //  good.ReleaseDate = Convert.ToDateTime(currentCell.EditedFormattedValue);
                else if (currentColumn.HeaderText == "Характристика_значение")
                    good.Characteristic = currentCell.EditedFormattedValue.ToString();
                else if(currentColumn.HeaderText == "Изображение")
                {
                    ImageConverter imgConverter = new ImageConverter();
                    if (dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodImage.Index].EditedFormattedValue != null)
                        good.Image = (byte[])imgConverter.ConvertTo(dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodImage.Index].EditedFormattedValue, typeof(byte[]));
                }

                goodController.UpdateGood(good);
                goods = new BindingList<Good>(goodController.GetGoods());
                dataGridViewGoodInfo.Refresh();
            }
        }

        private void dataGridViewGoodInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = dataGridViewGoodInfo.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (Convert.ToInt32(dataGridViewGoodInfo.Rows[i].Cells[ColumnGoodCategoryId.Index].Value) > 0)
                {
                    dataGridViewGoodInfo.Rows[i].Cells[ColumnGoodCategory.Index].Value = categoryController.GetCategory(Convert.ToInt32(dataGridViewGoodInfo.Rows[i].Cells[ColumnGoodCategoryId.Index].Value)).CName;
                }
                else {
                    dataGridViewGoodInfo.Rows[i].Cells[ColumnGoodCategory.Index].Value = ColumnGoodCategory.Items[0];
                    dataGridViewGoodInfo.Rows[i].Cells[ColumnGoodCategoryId.Index].Value = categoryController.GetCategoryByName(ColumnGoodCategory.Items[0].ToString()).Id;
                }

            }
        }

        private void dataGridViewGoodInfo_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = null;
            
        }

        private void dataGridViewGoodInfo_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "";
            DataGridViewColumn currentColumn = dataGridViewGoodInfo.Columns[e.ColumnIndex];
            DataGridViewRow currentRow = dataGridViewGoodInfo.Rows[e.RowIndex];
            DataGridViewCell currentCell = currentRow.Cells[e.ColumnIndex];

            if (currentColumn.HeaderText == "Название")
            {
                if (!validator.IsCorrectInfo((string)e.FormattedValue) || !validator.IsLengthCorrectMax((string)e.FormattedValue, 255))
                {
                    e.Cancel = true;
                    dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Некорректная длина строки: допустимый интервал - 1-255 символов";
                }
            }
            else if (currentColumn.HeaderText == "Артикул")
            {
                Good foundValue = goods.FirstOrDefault(g => g.Article == (string)e.FormattedValue);
                if (!(foundValue == null || foundValue.Id == (int)currentRow.Cells[ColumnGoodId.Index].Value) || !validator.IsCorrectInfo((string)e.FormattedValue) || !validator.IsLengthCorrectRequired((string)e.FormattedValue, 14))
                {
                    e.Cancel = true;
                    dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Артикул должен быть уникальным и длиной 14 символов";
                }
            }
            else if (currentColumn.HeaderText == "Дата выпуска")
            {
                try
                {
                    //  DateTime convertedData = Convert.ToDateTime(e.FormattedValue);
                    DateTime convertedData = DateTime.ParseExact(currentCell.EditedFormattedValue.ToString(), "dd.MM.yyyy", provider);
                    if (!dtValidator.IsDataCorrect(convertedData))
                    {
                        e.Cancel = true;
                        dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Товар не может быть произведен позднее сегодняшнего дня";
                    }
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Некорректная дата";
                }
            }
            else if (currentColumn.HeaderText == "Количество товаров")
            {
                try
                {
                    if (e.FormattedValue == null || (string)e.FormattedValue == "" || Convert.ToInt32(e.FormattedValue) < 0)
                    {
                        e.Cancel = true;
                        dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Некорректное значение количества товаров";
                    }
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Некорректное значение количества товаров";
                }
            }
            else if (currentColumn.HeaderText == "Цена")
            {
                try
                {
                    if (e.FormattedValue == null || (string)e.FormattedValue == "" || Convert.ToDecimal(e.FormattedValue) <= 0)
                    {
                        e.Cancel = true;
                        dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Некорректное значение цены";
                    }
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Некорректное значение цены";
                }
            }
            else if (currentColumn.HeaderText == "Категория")
            {
                dataGridViewGoodInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = e.FormattedValue;
                dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodCategoryId.Index].Value = categoryController.GetCategoryByName(e.FormattedValue.ToString()).Id;
            }
        }

        private void dataGridViewGoodInfo_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = null;

            if (Convert.ToInt32(dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodId.Index].EditedFormattedValue) == 0) {
                Good good = new Good();
                good.GoodName = dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodName.Index].EditedFormattedValue.ToString();
                good.Article = dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodArticle.Index].EditedFormattedValue.ToString();
                good.GoodNum = Convert.ToInt32(dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodNum.Index].EditedFormattedValue);
                good.GoodDescription = dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodDescription.Index].EditedFormattedValue.ToString();
                //     good.ReleaseDate = Convert.ToDateTime(dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodReleaseDate.Index].EditedFormattedValue);
                good.ReleaseDate = DateTime.ParseExact(dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodReleaseDate.Index].EditedFormattedValue.ToString(), "dd.MM.yyyy", provider);
                good.Price = Convert.ToDecimal(dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodPrice.Index].EditedFormattedValue);
                good.Category = categoryController.GetCategory(Convert.ToInt32(dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodCategoryId.Index].EditedFormattedValue));

                ImageConverter imgConverter = new ImageConverter();
                if (dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodImage.Index].EditedFormattedValue != null)
                    good.Image = (byte[])imgConverter.ConvertTo(dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodImage.Index].EditedFormattedValue, typeof(byte[]));

                good.Characteristic = dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodCharacteristic.Index].EditedFormattedValue.ToString();

                goodController.AddGood(good);
                dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodId.Index].Value = goodController.GetGoodByArticle(good.Article).Id;

                goods = new BindingList<Good>(goodController.GetGoods());
                dataGridViewGoodInfo.Refresh();
                goodsPromCLB.Items.Clear();
                foreach (Good g in goods)
                {
                    goodsPromCLB.Items.Add(g.Article + ", " + g.GoodName);
                }
            }
            else {
                Good goodToUpdate = goodController.GetGood(Convert.ToInt32(dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodId.Index].EditedFormattedValue));
                ImageConverter imgConverter = new ImageConverter();
                if (dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodImage.Index].EditedFormattedValue != null && dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodImage.Index].EditedFormattedValue != dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodImage.Index].Value)
                {
                    goodToUpdate.Image = (byte[])imgConverter.ConvertTo(dataGridViewGoodInfo.Rows[e.RowIndex].Cells[ColumnGoodImage.Index].EditedFormattedValue, typeof(byte[]));
                    goodController.UpdateGood(goodToUpdate);
                }
            }

        }

        private void dataGridViewGoodInfo_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "";
            DataGridViewRow currentRow = dataGridViewGoodInfo.Rows[e.RowIndex];

           
                if (!validator.IsCorrectInfo((string)currentRow.Cells[ColumnGoodName.Index].EditedFormattedValue) || !validator.IsLengthCorrectMax((string)currentRow.Cells[ColumnGoodName.Index].EditedFormattedValue, 255))
                {
                    e.Cancel = true;
                    dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Некорректная длина строки: допустимый интервал - 1-255 символов";
                    
                    return;
                }

            if (currentRow.Cells[ColumnGoodArticle.Index].EditedFormattedValue != null)
            {
                Good foundValue;
                if (Convert.ToInt32(currentRow.Cells[ColumnGoodId.Index].EditedFormattedValue) > 0)
                    foundValue = goods.First(g => g.Article == (string)currentRow.Cells[ColumnGoodArticle.Index].EditedFormattedValue);
                else foundValue = null;
                if (!(foundValue == null || foundValue.Id == (int)currentRow.Cells[ColumnGoodId.Index].Value) || !validator.IsCorrectInfo((string)currentRow.Cells[ColumnGoodArticle.Index].EditedFormattedValue) || !validator.IsLengthCorrectRequired((string)currentRow.Cells[ColumnGoodArticle.Index].EditedFormattedValue, 14))
                {
                    e.Cancel = true;
                    dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Артикул должен быть уникальным и длиной 14 символов";

                    return;
                }
            }
            else
            {
                e.Cancel = true;
                dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Артикул должен быть уникальным и длиной 14 символов";
            }

                try
                {
               //     DateTime convertedData = Convert.ToDateTime(currentRow.Cells[ColumnGoodReleaseDate.Index].EditedFormattedValue);
               DateTime convertedData = DateTime.ParseExact(currentRow.Cells[ColumnGoodReleaseDate.Index].EditedFormattedValue.ToString(), "dd.MM.yyyy", provider);
                if (!dtValidator.IsDataCorrect(convertedData))
                    {
                        e.Cancel = true;
                        dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Товар не может быть произведен позднее сегодняшнего дня";
                        return;
                    }
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Некорректная дата";
                    return;
                }

            try
            {
                if (currentRow.Cells[ColumnGoodNum.Index].EditedFormattedValue == null || (string)currentRow.Cells[ColumnGoodNum.Index].EditedFormattedValue == "" || Convert.ToInt32(currentRow.Cells[ColumnGoodNum.Index].EditedFormattedValue) < 0)
                {
                    e.Cancel = true;
                    dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Некорректное значение количества товаров";

                    return;
                }
            }
            catch (Exception)
            {
                e.Cancel = true;
                dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Некорректное значение количества товаров";

                return;
            }

            try
            {
                if (currentRow.Cells[ColumnGoodPrice.Index].EditedFormattedValue == null || (string)currentRow.Cells[ColumnGoodPrice.Index].EditedFormattedValue == "" || Convert.ToDecimal(currentRow.Cells[ColumnGoodPrice.Index].EditedFormattedValue) <= 0)
                {
                    e.Cancel = true;
                    dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Некорректное значение цены";

                }
            }
            catch (Exception)
            {
                e.Cancel = true;
                dataGridViewGoodInfo.Rows[e.RowIndex].ErrorText = "Некорректное значение цены";
            }
        }

        private void dataGridViewGoodInfo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            List<Category> categories = categoryController.GetCategories();
            ColumnGoodCategory.Items.Clear();
            foreach (Category c in categories)
                ColumnGoodCategory.Items.Add(c.CName);
        }

        private void dataGridViewGoodInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewGoodInfo.Columns[e.ColumnIndex].HeaderText == "Изображение")
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Выберете изображение";
                    dlg.Filter = "png files (*.png)|*.png";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        Bitmap goodImage = new Bitmap(dlg.FileName);
                        dataGridViewGoodInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = goodImage;
                    }
                }
            }
        }

        private void dataGridViewGoodInfo_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Convert.ToInt32(e.Row.Cells[ColumnGoodId.Index].EditedFormattedValue) > 0)
            {
                goodController.DeleteGood(Convert.ToInt32(e.Row.Cells[ColumnGoodId.Index].EditedFormattedValue));
                goods = new BindingList<Good>(goodController.GetGoods());
            }
        }

        private void tabControlGood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FindBestPrice(Good g)
        {
            List<Promotion> promotions = goodPromotionController.GetPromotions(g);
            int currDiscount = 0;
            float discount = 1 - 0.01f * currDiscount;
            int freeGoods = 0;
            decimal currPrice = g.Price * Convert.ToInt32(textBoxGoodsNumber.Text) * (decimal)discount;
            foreach (Promotion p in promotions)
            {
                if (Convert.ToInt32(textBoxGoodsNumber.Text) >= p.GoodNum)
                {
                    float lower = 1 - 0.01f * p.Discount;
                    decimal price = g.Price * Convert.ToInt32(textBoxGoodsNumber.Text) * (decimal)lower;
                    if (price < currPrice)
                    {
                        currPrice = price;
                        currDiscount = p.Discount;
                        freeGoods = p.FreeGoodNum;
                        discount = 1 - 0.01f * currDiscount;
                    }
                }
            }
            TBDiscount.Text = currDiscount.ToString();
            TBGoodsForFree.Text = freeGoods.ToString();
            labelResultPriceForGood.Text = "Итого: " + currPrice.ToString();
        }

        private void goodRadioButton_Checked(object sender, EventArgs e)
        {
            RadioButton control = (RadioButton)sender;
            if (control.Checked)
            {
                string goodInfo = control.Text;

                string[] goodInfoSplited = goodInfo.Split(',');

                goodArticleLabel.Text = goodInfoSplited[0];

                Good good = goodController.GetGoodByArticle(goodInfoSplited[0]);
                FindBestPrice(good);
            }
        }

        private void dataGridViewWriteOffReasons_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn currentColumn = dataGridViewWriteOffReasons.Columns[e.ColumnIndex];
            DataGridViewRow currentRow = dataGridViewWriteOffReasons.Rows[e.RowIndex];
            DataGridViewCell currentCell = currentRow.Cells[e.ColumnIndex];

            int reasonId = (int)currentRow.Cells[ColumnWriteOffReasonId.Index].Value;
            if (reasonId > 0)
            {
                WriteOffReason currReason = writeOffReasonController.GetReason(reasonId);
                if (currReason != null)
                {
                    currReason.ReasonName = (string)currentCell.Value;
                    writeOffReasonController.UpdateReason(currReason);

                    List<WriteOffReason> reasonsCurr = writeOffReasonController.GetWriteOffReasons();
                    ColumnReason.Items.Clear();
                    foreach(WriteOffReason r in reasonsCurr)
                    {
                        ColumnReason.Items.Add(r.ReasonName);
                    }
                }
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           if(tabControlMain.SelectedIndex == 3)
            {
                
            }
        }

        private ListBox CreatePanelForPromotion(Promotion promotion)
        {
            Panel panelEl = new Panel();
            panelEl.Width = 228;
            panelEl.Height = 355;

            ListBox listBoxGoods = new ListBox();
            listBoxGoods.Height = 158;
            listBoxGoods.Width = 203;
            listBoxGoods.Location = new Point(10, 184);
            listBoxGoods.Font = new Font("Cambria", 9.0f);

            int maxX = 0, maxY = 0;
            if (promPanels.Count > 0)
            {
                foreach(Panel p in promPanels.Keys)
                {
                    if (p.Location.Y == maxY) {
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
            if (maxX == 0) panelEl.Location = new Point(325, 20);
            else
            {
                if(maxX == 325) panelEl.Location = new Point(568, maxY);
                else if(maxX == 568) panelEl.Location = new Point(811, maxY);
                else panelEl.Location = new Point(325, maxY + 382);
            }

            panelEl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            listBoxGoods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            listBoxGoods.BackColor = System.Drawing.Color.FromArgb(228, 223, 218);
            listBoxGoods.HorizontalScrollbar = true;
            listBoxGoods.Name = "PromGoods";
            tabPagePromotions.Controls.Add(panelEl);


            List<Good> goods = goodPromotionController.GetGoods(promotion);
            foreach (Good g in goods) listBoxGoods.Items.Add(g.Article + ", " + g.GoodName);

            Label nameLabel = new Label();
            nameLabel.Text = promotion.PromotionName;
            nameLabel.Location = new Point(7, 8);
            nameLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            nameLabel.Name = "Name";
            nameLabel.AutoSize = true;
            if (nameLabel.Text.Length > 20)
            {
                nameLabel.Font = new Font("Cambria", 7.0f, FontStyle.Bold);
            }

            Label dateLabel = new Label();
            
            string promDateEnd = promotion.DateEnd == null ? "?" : promotion.DateEnd.Value.ToShortDateString();
            dateLabel.Text = promotion.DateBegin.Date.ToShortDateString() + "-" + promDateEnd ;
            dateLabel.Location = new Point(7, 33);
            dateLabel.Font = new Font("Cambria", 9.75f);
            dateLabel.Name = "Date";
            dateLabel.AutoSize = true;

            Label discountLabel = new Label();
            discountLabel.Text = "Величина скидки, %";
            discountLabel.Location = new Point(7, 60);
            discountLabel.Font = new Font("Cambria", 9.0f);
            discountLabel.AutoSize = true;
            Label discountValLabel = new Label();
            discountValLabel.Text = promotion.Discount.ToString();
            discountValLabel.Location = new Point(192, 60);
            discountValLabel.Font = new Font("Cambria", 9.0f);
            discountValLabel.Name = "Discount";
            discountValLabel.AutoSize = true;
            discountValLabel.TextAlign = ContentAlignment.MiddleRight;

           Label activationNumLabel = new Label();
            activationNumLabel.Text = "Товаров для активации, шт.";
            activationNumLabel.Location = new Point(7, 85);
            activationNumLabel.Font = new Font("Cambria", 9.0f);
            activationNumLabel.AutoSize = true;
            Label activationNumValLabel = new Label();
            activationNumValLabel.Text = promotion.GoodNum.ToString();
            activationNumValLabel.Location = new Point(192, 85);
            activationNumValLabel.Font = new Font("Cambria", 9.0f);
            activationNumValLabel.Name = "GoodNum";
            activationNumValLabel.AutoSize = true;

            Label freeGoodNumLabel = new Label();
            freeGoodNumLabel.Text = "Товаров в подарок, шт.";
            freeGoodNumLabel.Location = new Point(7, 112);
            freeGoodNumLabel.Font = new Font("Cambria", 9.0f);
            freeGoodNumLabel.AutoSize = true;
            Label freeGoodNumValLabel = new Label();
            freeGoodNumValLabel.Text = promotion.FreeGoodNum.ToString();
            freeGoodNumValLabel.Location = new Point(192, 112);
            freeGoodNumValLabel.Font = new Font("Cambria", 9.0f);
            freeGoodNumValLabel.Name = "FreeGoodNum";
            freeGoodNumValLabel.AutoSize = true;

            Label goosHeaderLabel = new Label();
            goosHeaderLabel.Text = "Товары";
            goosHeaderLabel.Location = new Point(7, 154);
            goosHeaderLabel.Font = new Font("Cambria", 9.0f, FontStyle.Italic);
            goosHeaderLabel.AutoSize = true;

            PictureBox editPB = new PictureBox();
            PictureBox removePB = new PictureBox();
            editPB.Height = editPB.Width = removePB.Height = removePB.Width = 15;
            Bitmap imageE = new Bitmap(Properties.Resources.edit, 15, 15);
            editPB.Location = new Point(177, 8);
            editPB.Image = imageE;
            editPB.Click += new EventHandler(editPromotionButton_Click);
            imageE = new Bitmap(Properties.Resources.delete, 15, 15);
            removePB.Location = new Point(198, 8);
            removePB.Image = imageE;
            removePB.Click += new EventHandler(removePromotionButton_Click);

            panelEl.Controls.Add(nameLabel);
            panelEl.Controls.Add(dateLabel);
            panelEl.Controls.Add(discountLabel);
            panelEl.Controls.Add(discountValLabel);
            panelEl.Controls.Add(activationNumLabel);
            panelEl.Controls.Add(activationNumValLabel);
            panelEl.Controls.Add(freeGoodNumLabel);
            panelEl.Controls.Add(freeGoodNumValLabel);
            panelEl.Controls.Add(freeGoodNumLabel);


            panelEl.Controls.Add(editPB);
            panelEl.Controls.Add(removePB);

            panelEl.Controls.Add(listBoxGoods);

            promPanels.Add(panelEl, promotion);

            return listBoxGoods;
        }

        async private void dataGridViewWriteOffReasons_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            WriteOffReason currentReason = writeOffReasonController.GetReason((int)e.Row.Cells[ColumnWriteOffReasonId.Index].Value);
            List<WriteOff> writeOffs = writeOffController.GetByReason(currentReason);
            if (writeOffs.Count > 0)
            {
                ErrorWindow window = new ErrorWindow("Вы не можете удалить данную причину: есть списанные товары, относящиеся к ней");
                e.Cancel = true;
                window.Show();
            }
            else await writeOffReasonController.aDeleteReason(writeOffReasonController.GetReason(Convert.ToInt32(e.Row.Cells[ColumnWriteOffReasonId.Index].Value)));
        }

        private void dataGridViewWriteOffReasons_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            string message;
            DataGridViewRow row = dataGridViewWriteOffReasons.Rows[e.RowIndex];
            message = DataGridViewWriteOffReasonsValidatingCell(dataGridViewWriteOffReasons.Columns[ColumnWriteOffReason.Index], row.Cells[ColumnWriteOffReason.Index].Value);
            if (message != "")
            {
                e.Cancel = true;
                dataGridViewWriteOffReasons.Rows[e.RowIndex].ErrorText = message;
            }
        }

        private void dataGridViewWriteOffReasons_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewWriteOffReasons.Rows[e.RowIndex].ErrorText = null;
        }

        private string DataGridViewWriteOffReasonsValidatingCell(DataGridViewColumn currentColumn, object value)
        {
            string errorMsg = "";
            string text = (string)value;
            if (!validator.IsCorrectName(text) || !validator.IsLengthCorrectMin(text, 1))
                errorMsg = "Некорректное название причины. Проверьте длину, уникальность, вводимые символы";
            return errorMsg;
        }

        private void dataGridViewWriteOffReasons_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewWriteOffReasons.Rows[e.RowIndex];
            if ((int)currentRow.Cells[ColumnWriteOffReasonId.Index].Value == 0)
            {
                try
                {
                    WriteOffReason reason = new WriteOffReason();
                    object value = currentRow.Cells[ColumnWriteOffReason.Index].EditedFormattedValue;
                    reason.ReasonName = (string)value;

                    if (previousRowReasons == null || currentRow != previousRowReasons)
                    {
                        if(!writeOffReasonController.AddReason(reason))
                        {
                            ErrorWindow window = new ErrorWindow("Такая причина уже есть в базе.");
                            window.Show();
                        }
                       
                    }
                    previousRowReasons = currentRow;

                    BindingList<WriteOffReason> reasons = new BindingList<WriteOffReason>(writeOffReasonController.GetWriteOffReasons());
                    dataGridViewWriteOffReasons.DataSource = null;
                    dataGridViewWriteOffReasons.DataSource = reasons;

                    ColumnReason.Items.Clear();
                    foreach (WriteOffReason r in reasons)
                    {
                        ColumnReason.Items.Add(r.ReasonName);
                    }

                }
                catch (Exception) { }
            }
        }

        private void dataGridViewWriteOffReasons_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridViewWriteOffReasons.Rows[e.RowIndex].ErrorText = "";
            DataGridViewColumn currentColumn = dataGridViewWriteOffReasons.Columns[e.ColumnIndex];
            DataGridViewRow currentRow = dataGridViewWriteOffReasons.Rows[e.RowIndex];
            
            string msg = DataGridViewWriteOffReasonsValidatingCell(currentColumn, currentRow.Cells[ColumnWriteOffReason.Index].EditedFormattedValue);
            if (msg != "")
            {
                e.Cancel = true;
                dataGridViewWriteOffReasons.Rows[e.RowIndex].ErrorText = msg;

            }
        }

        private void dataGridViewWriteOffReasons_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewWriteOffReasons.Rows[e.RowIndex].ErrorText = null;
        }


    }
}