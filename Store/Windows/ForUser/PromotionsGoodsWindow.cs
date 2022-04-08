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
    public partial class PromotionsGoodsWindow : Form
    {
        private PromotionController promotionController;
        private GoodPromotionController goodPromotionController;

        private Dictionary<Panel, Good> panelGoods;

        private stuff_shopContext db;

        private string userEmail;

        public PromotionsGoodsWindow(int id, string userEmail)
        {
            InitializeComponent();

            db = new stuff_shopContext();

            promotionController = new PromotionController(db);
            goodPromotionController = new GoodPromotionController(db);

            this.userEmail = userEmail;
            panelGoods = new Dictionary<Panel, Good>();

            Promotion promotion = promotionController.GetPromotion(id);
            List<Good> goods = goodPromotionController.GetGoods(promotion);

            labelActivationNum.Text = promotion.GoodNum.ToString();
            labelFreeNum.Text = promotion.FreeGoodNum.ToString();
            labelDiscount.Text = promotion.Discount.ToString();

            foreach (Good g in goods)
            {
                CreateItemForm(316, 220, 458, 698, g);
            }
        }

        private void CreateItemForm(int y0, int x0, int x1, int x2, Good g)
        {
            Panel panelEl = new Panel();
            this.Controls.Add(panelEl);

            panelEl.Height = 243;
            panelEl.Width = 196;

            int maxX = 0, maxY = 0;
            if (panelGoods.Count > 0)
            {
                    foreach (Panel p in panelGoods.Keys)
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
            if (maxX == 0) panelEl.Location = new Point(x0, y0);
            else
            {
                if (maxX == x0) panelEl.Location = new Point(x1, maxY);
                else if (maxX == x1) panelEl.Location = new Point(x2, maxY);
                else panelEl.Location = new Point(x0, maxY + 279);
            }

            Label goodName = new Label();
            goodName.Location = new Point(3, 6);
            goodName.Text = g.GoodName;
            goodName.Font = new Font("Cambria", 9.0f, FontStyle.Bold);
            goodName.Width = 190;
            goodName.Height = 14;

            Label rubsLabel = new Label();
            rubsLabel.Location = new Point(154, 219);
            rubsLabel.Text = "РУБ.";
            rubsLabel.Font = new Font("Cambria", 9.0f);
            rubsLabel.Width = 30;
            rubsLabel.Height = 14;

            Label priceLabel = new Label();
            priceLabel.Location = new Point(11, 219);
            priceLabel.Font = new Font("Cambria", 9.0f);
            priceLabel.Width = 136;
            priceLabel.Height = 14;
            int maxDiscount = 0;
            List<Promotion> proms = goodPromotionController.GetPromotions(g);
            foreach (Promotion p in proms) if (p.Discount > maxDiscount) maxDiscount = p.Discount;
            decimal price = g.Price * (decimal)(1 - (float)maxDiscount * 0.01f);
            priceLabel.Text = price.ToString() + " (-" + maxDiscount + "%)";

            PictureBox goodImage = new PictureBox();
            MemoryStream ms = new MemoryStream(g.Image);
            Bitmap image = new Bitmap(ms);
            goodImage.Width = 125;
            goodImage.Height = 182;
            goodImage.SizeMode = PictureBoxSizeMode.Zoom;
            goodImage.Image = image;
            goodImage.Name = "good_" + g.Id;
            goodImage.Location = new Point(34, 27);
            goodImage.Click += new EventHandler(OpenItemInfo);

            panelEl.Controls.Add(goodImage);
            panelEl.Controls.Add(goodName);
            panelEl.Controls.Add(priceLabel);
            panelEl.Controls.Add(rubsLabel);

            panelGoods.Add(panelEl, g);
        }

        private void OpenItemInfo(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            string[] goodInfo = control.Name.Split('_');

            ItemWindow itemWindow = new ItemWindow(userEmail, this, Convert.ToInt32(goodInfo[1]));
            itemWindow.Show();
            this.Hide();
        }

        private void buttonQuestion_Click(object sender, EventArgs e)
        {
            QuestionWindow window = new QuestionWindow(userEmail);
            window.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow(userEmail);
            mainWindow.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShoppingCartWindow shoppingCartWindow = new ShoppingCartWindow(userEmail);
            shoppingCartWindow.Show();
            this.Hide();
        }

        private void buttonUserOrders_Click(object sender, EventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow(userEmail);
            orderWindow.Show();
            this.Hide();
        }

        private void buttonWork_Click(object sender, EventArgs e)
        {
            JobAppWindow jobAppWindow = new JobAppWindow(userEmail);
            jobAppWindow.Show();
            this.Hide();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchResultWindow searchResultWindow = new SearchResultWindow(this, textBox1.Text, checkBox1.Checked, userEmail);
            searchResultWindow.Show();
            this.Hide();
        }
    }
}
