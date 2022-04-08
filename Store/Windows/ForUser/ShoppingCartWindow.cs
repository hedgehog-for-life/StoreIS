using Store.Controllers;
using Store.DataBase.Context;
using Store.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.Windows.ForUser
{
    public partial class ShoppingCartWindow : Form
    {
        private GoodController goodController;
        private GoodPromotionController goodPromotionController;
        private PromotionController promotionController;
        private ShoppingCartController shoppingCartController;
        private PersonController personController;

        private Dictionary<Panel, ShoppingCart> scPanels;
        private List<ShoppingCart> items;

        private Person user;

        private stuff_shopContext db;

        public ShoppingCartWindow(string userEmail)
        {
            InitializeComponent();
            personController = new PersonController();
            user = personController.FindPersonByEmail(userEmail);

            db = new stuff_shopContext();

            goodController = new GoodController(db);
            goodPromotionController = new GoodPromotionController(db);
            promotionController = new PromotionController(db);
            shoppingCartController = new ShoppingCartController(db);

            scPanels = new Dictionary<Panel, ShoppingCart>();

            RetrieveDataFromDB();
        }

        private void RetrieveDataFromDB()
        {
            items = shoppingCartController.GetShoppingCarts(user);
            foreach(ShoppingCart item in items)
            {
                AddPanelForItem(item);
            }
        }

        private void AddPanelForItem(ShoppingCart item)
        {
            Panel panelEl = new Panel();
            panelEl.Height = 229;
            panelEl.Width = 435; 

            panelEl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(panelEl);

            Label goodNameLabel = new Label();
            goodNameLabel.Text = item.Good.GoodName;
            goodNameLabel.Location = new Point(13, 15);
            goodNameLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            goodNameLabel.Name = "Name";
            goodNameLabel.AutoSize = true;

            Label goodArticleLabel = new Label();
            goodArticleLabel.Text = item.Good.Article;
            goodArticleLabel.Location = new Point(13, 38);
            goodArticleLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            goodArticleLabel.Name = "Article";
            goodArticleLabel.AutoSize = true;

            PictureBox itemImage = new PictureBox();
            itemImage.Width = 100;
            itemImage.Height = 146;
            MemoryStream ms = new MemoryStream(item.Good.Image);
            Bitmap image = new Bitmap(ms);
            itemImage.Image = image;
            itemImage.Location = new Point(15, 66);
            itemImage.SizeMode = PictureBoxSizeMode.Zoom;

            Label numberTextLabel = new Label();
            numberTextLabel.Text = "Количество";
            numberTextLabel.Location = new Point(127, 66);
            numberTextLabel.Font = new Font("Cambria", 9f, FontStyle.Bold);
            numberTextLabel.AutoSize = true;

            Label discountTextLabel = new Label();
            discountTextLabel.Text = "Скидка";
            discountTextLabel.Location = new Point(127, 90);
            discountTextLabel.Font = new Font("Cambria", 9f, FontStyle.Bold);
            discountTextLabel.AutoSize = true;

            Label freeGoodsTextLabel = new Label();
            freeGoodsTextLabel.Text = "Товаров в подарок";
            freeGoodsTextLabel.Location = new Point(127, 116);
            freeGoodsTextLabel.Font = new Font("Cambria", 9f, FontStyle.Bold);
            freeGoodsTextLabel.AutoSize = true;

            Label costTextLabel = new Label();
            costTextLabel.Text = "Стоимость";
            costTextLabel.Location = new Point(127, 171);
            costTextLabel.Font = new Font("Cambria", 9f, FontStyle.Bold);
            costTextLabel.AutoSize = true;

            if(item.Characteristic != null)
            {
                Label characteristicTextLabel = new Label();
                string[] characteristicName = item.Good.Characteristic.Split('_');
                characteristicTextLabel.Text = characteristicName[0];
                characteristicTextLabel.Location = new Point(127, 144);
                characteristicTextLabel.Font = new Font("Cambria", 9f, FontStyle.Bold);
                characteristicTextLabel.AutoSize = true;

                TextBox characteristicTextBox = new TextBox();
                characteristicTextBox.Text = item.Characteristic;
                characteristicTextBox.Location = new Point(328, 142);
                characteristicTextBox.Width = 82;
                characteristicTextBox.Height = 22;
                characteristicTextBox.TextChanged += new EventHandler(CharacteristicChanged);
                characteristicTextBox.Name = "Characteristic";
                characteristicTextBox.TextAlign = HorizontalAlignment.Right;
                characteristicTextLabel.Font = new Font("Cambria", 9f, FontStyle.Bold);

                panelEl.Controls.Add(characteristicTextLabel);
                panelEl.Controls.Add(characteristicTextBox);
            }

            Label costWDTextLabel = new Label();
            costWDTextLabel.Text = "Стоимость со скидкой";
            costWDTextLabel.Location = new Point(127, 196);
            costWDTextLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            costWDTextLabel.AutoSize = true;

            Label costWDLabel = new Label();
            costWDLabel.Text = item.Cost.ToString();
            costWDLabel.Location = new Point(291, 196);
            costWDLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            costWDLabel.AutoSize = false;
            costWDLabel.Width = 117;
            costWDLabel.Height = 15;
            costWDLabel.Name = "Cost";
            costWDLabel.TextAlign = ContentAlignment.MiddleRight;

            Label costLabel = new Label();
            costLabel.Text = item.Good.Price.ToString();
            costLabel.Location = new Point(291, 171);
            costLabel.Font = new Font("Cambria", 9f);
            costLabel.AutoSize = false;
            costLabel.Width = 117;
            costLabel.Height = 15;
            costLabel.Name = "Price";
            costLabel.TextAlign = ContentAlignment.MiddleRight;

            Label freeGoodsLabel = new Label();
            freeGoodsLabel.Text = item.FreeGoods.ToString();
            freeGoodsLabel.Location = new Point(291, 115);
            freeGoodsLabel.Font = new Font("Cambria", 9f);
            freeGoodsLabel.AutoSize = false;
            freeGoodsLabel.Width = 117;
            freeGoodsLabel.Height = 15;
            freeGoodsLabel.Name = "FreeGoods";
            freeGoodsLabel.TextAlign = ContentAlignment.MiddleRight;

            Label discountLabel = new Label();
            discountLabel.Text = item.Discount.ToString();
            discountLabel.Location = new Point(294, 90);
            discountLabel.Font = new Font("Cambria", 9f);
            discountLabel.AutoSize = false;
            discountLabel.Width = 117;
            discountLabel.Height = 15;
            discountLabel.Name = "Discount";
            discountLabel.TextAlign = ContentAlignment.MiddleRight;

            PictureBox removePB = new PictureBox();
            removePB.Height = removePB.Width = 15;
            Bitmap imageE = new Bitmap(Properties.Resources.delete, 15, 15);
            removePB.Location = new Point(394, 18);
            removePB.Image = imageE;
            removePB.Click += new EventHandler(RemoveButton_Click);

            PictureBox morePB = new PictureBox();
            morePB.Height = morePB.Width = 13;
            imageE = new Bitmap(Properties.Resources.add, 13, 13);
            morePB.Location = new Point(395, 66);
            morePB.Image = imageE;
            morePB.Click += new EventHandler(AddGoodNum_Click);

            PictureBox lessPB = new PictureBox();
            lessPB.Height = lessPB.Width = 13;
            imageE = new Bitmap(Properties.Resources.remove, 13, 13);
            lessPB.Location = new Point(328, 66);
            lessPB.Image = imageE;
            lessPB.Click += new EventHandler(LessGoodNum_Click);

            TextBox numberTextBox = new TextBox();
            numberTextBox.Text = item.GoodNum.ToString();
            numberTextBox.Location = new Point(352, 64);
            numberTextBox.Width = 35;
            numberTextBox.Height = 22;
            numberTextBox.ReadOnly = true;
            numberTextBox.Name = "Number";
            numberTextBox.TextAlign = HorizontalAlignment.Right;
            numberTextBox.Font = new Font("Cambria", 9f);

            panelEl.Controls.Add(lessPB);
            panelEl.Controls.Add(morePB);
            panelEl.Controls.Add(removePB);
            panelEl.Controls.Add(itemImage);

            panelEl.Controls.Add(goodArticleLabel);
            panelEl.Controls.Add(goodNameLabel);

            panelEl.Controls.Add(numberTextBox);
            panelEl.Controls.Add(discountLabel);
            panelEl.Controls.Add(discountTextLabel);
            panelEl.Controls.Add(freeGoodsLabel);
            panelEl.Controls.Add(freeGoodsTextLabel);
            panelEl.Controls.Add(costLabel);
            panelEl.Controls.Add(costTextLabel);
            panelEl.Controls.Add(costWDLabel);
            panelEl.Controls.Add(costWDTextLabel);
            panelEl.Controls.Add(numberTextLabel);

            int maxY = 0;
            if (scPanels.Count > 0)
            {
                foreach (Panel p in scPanels.Keys)
                {
                    if (p.Location.Y > maxY)
                    {
                        maxY = p.Location.Y;
                    }
                }
            }
            if (maxY == 0) panelEl.Location = new Point(220, 177);
            else
            {
                panelEl.Location = new Point(220, maxY + 251);
            }
            scPanels.Add(panelEl, item);
        }

        async private void CharacteristicChanged(object sender, EventArgs e)
        {
            TextBox characteristicText = (TextBox)sender;
            Panel panel = (Panel)characteristicText.Parent;
            ShoppingCart item;
            if (scPanels.TryGetValue(panel, out item))
            {
                item.Characteristic = characteristicText.Text;
                await shoppingCartController.UpdateItemAsync(item);
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

        async private void FindBestPrice(Panel panel)
        { 
            ShoppingCart item;
            if(scPanels.TryGetValue(panel, out item))
            {
                Control[] elsList = panel.Controls.Find("Cost", true);
                Label cost = (Label)elsList[0];
                elsList = panel.Controls.Find("FreeGoods", true);
                Label fg = (Label)elsList[0];
                elsList = panel.Controls.Find("Discount", true);
                Label disc = (Label)elsList[0];
                elsList = panel.Controls.Find("Number", true);
                TextBox num = (TextBox)elsList[0];

                List<Promotion> promotions = goodPromotionController.GetPromotions(item.Good);
                int currDiscount = Convert.ToInt32(disc.Text);
                float discount = 1 - 0.01f * currDiscount;
                int freeGoods = 0;
                int freeGoodsWOD = 0;
                decimal currPrice = item.Good.Price * Convert.ToInt32(num.Text) * (decimal)discount;
                foreach (Promotion p in promotions)
                {
                    if (Convert.ToInt32(num.Text) >= p.GoodNum)
                    {
                        float lower = 1 - 0.01f * p.Discount;
                        decimal price = item.Good.Price * Convert.ToInt32(num.Text) * (decimal)lower;
                        if (price < currPrice)
                        {
                            currPrice = price;
                            currDiscount = p.Discount;
                            freeGoods = p.FreeGoodNum;
                            discount = 1 - 0.01f * currDiscount;
                        }
                        if (p.Discount == 0 && p.FreeGoodNum > freeGoodsWOD) freeGoodsWOD = p.FreeGoodNum;
                    }
                }
                if (currDiscount > 0)
                {
                    disc.Text = currDiscount.ToString();
                    fg.Text = freeGoods.ToString();

                    item.Discount = Convert.ToInt16(currDiscount);
                    item.FreeGoods = Convert.ToInt16(freeGoods);
                }
                else
                {
                    disc.Text = "0";
                    fg.Text = freeGoodsWOD.ToString();

                    item.Discount = 0;
                    item.FreeGoods = Convert.ToInt16(freeGoodsWOD);
                }
                cost.Text = currPrice.ToString();
                item.Cost = currPrice;

                await shoppingCartController.UpdateItemAsync(item);
            }

        }

        async private void LessGoodNum_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Panel panel = (Panel)control.Parent;
            Control[] elsList = panel.Controls.Find("Number", true);
            TextBox num = (TextBox)elsList[0];

            ShoppingCart item;
            if (scPanels.TryGetValue(panel, out item))
            {
                int val = Convert.ToInt32(num.Text);
                if (val <= 1) val = 1;
                else val -= 1;
                num.Text = val.ToString();
                FindBestPrice(panel);

                item.GoodNum = val;
                await shoppingCartController.UpdateItemAsync(item);
            }
        }

        async private void AddGoodNum_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Panel panel = (Panel)control.Parent;
            Control[] elsList = panel.Controls.Find("Number", true);
            TextBox num = (TextBox)elsList[0];

            ShoppingCart item;
            if (scPanels.TryGetValue(panel, out item))
            {
                int val = Convert.ToInt32(num.Text);
                if (val >= item.Good.GoodNum)
                {
                    val = item.Good.GoodNum;
                }
                else val += 1;
                num.Text = val.ToString();
                FindBestPrice(panel);

                item.GoodNum = val;
                await shoppingCartController.UpdateItemAsync(item);
            }

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Panel panel = (Panel)control.Parent;
            ShoppingCart item = null;
            
            bool canRemove = false;

           int maxY = panel.Location.Y;
           foreach (Panel p in scPanels.Keys)
                {
                    if (p == panel)
                    {
                        if (scPanels.TryGetValue(p, out item))
                    {
                            this.Controls.Remove(panel);
                            canRemove = true;
                            panel.Hide();
                        }
                    }
                    if (p.Location.Y > maxY)
                    {
                        p.Location = new Point(p.Location.X, p.Location.Y - 251);
                    }

                }
            if (canRemove)
            {
                scPanels.Remove(panel);
                items.Remove(item);
                shoppingCartController.RemoveItem(item.Id);
            }
        }

        async private void textBoxCharacteristic_Validated(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Panel panel = (Panel)control.Parent;
            Control[] elsList = panel.Controls.Find("Characteristic", true);
            TextBox characteristic = (TextBox)elsList[0];

            ShoppingCart item;
            if (scPanels.TryGetValue(panel, out item))
            {
                item.Characteristic = characteristic.Text;

                await shoppingCartController.UpdateItemAsync(item);
            }
        }

        private void buttonAddToSC_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.User = user;
            order.TotalCost = 0;
            foreach(ShoppingCart sc in scPanels.Values)
            {
                OrderGood orderGood = new OrderGood();
                orderGood.Order = order;
                orderGood.Good = sc.Good;
                orderGood.GoodNum = sc.GoodNum;
                orderGood.Characteristic = sc.Characteristic;
                orderGood.Discount = sc.Discount;
                orderGood.FreeGoodNum = sc.FreeGoods;

                order.TotalCost += sc.Cost;
                order.OrderGood.Add(orderGood);
            }

            OrderFormWindow orderFormWindow = new OrderFormWindow(user.Email, order);
            orderFormWindow.Show();
            this.Hide();
        }

        private void buttonWatchThroughItems_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow(user.Email);
            mainWindow.Show();
            this.Hide();
        }

        private void buttonUserOrders_Click(object sender, EventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow(user.Email);
            orderWindow.Show();
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
            QuestionWindow window = new QuestionWindow(user.Email);
            window.Show();
            this.Hide();
        }
    }
}
