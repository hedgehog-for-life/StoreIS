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
    public partial class MainWindow : Form
    {
        private string userEmail;
        private List<Collection> collections;
        private List<Category> categories;
        private List<Promotion> promotions;

        private CollectionController collectionController;
        private GoodCollectionController goodCollectionController;
        private CategoryController categoryController;
        private PromotionController promotionController;
        private GoodPromotionController goodPromotionController;


        private stuff_shopContext db;

        public MainWindow(string userEmail)
        {
            InitializeComponent();

            db = new stuff_shopContext();

            collectionController = new CollectionController(db);
            categoryController = new CategoryController(db);
            promotionController = new PromotionController(db);
            goodPromotionController = new GoodPromotionController(db);
            goodCollectionController = new GoodCollectionController(db);

            RetrieveDataFromDB();

            this.userEmail = userEmail;
        }

        private void RetrieveDataFromDB()
        {
            collections = collectionController.GetActiveCollections();
            AddColLabelsToPanel(collections);

            List<Collection> mainCollections = new List<Collection>();
            foreach (Collection c in collections)
                if (c.ColStatus == 2)
                    mainCollections.Add(c);
            AddMWMainCollections(mainCollections);

            categories = categoryController.GetCategories();
            AddCategoryLabelsToPanel(categories);

            promotions = promotionController.GetCurrentPromotions();
            AddPromotionsLabelsToPanel(promotions);
        }

        private void OpenCollectionWindow(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            string[] collectionInfo = control.Name.Split('_');

            CategoriesCollectionsGoodsWindow categoryWindow = new CategoriesCollectionsGoodsWindow(Convert.ToInt32(collectionInfo[1]), 1, userEmail);
            categoryWindow.Show();
            this.Hide();
        }

        private void AddColLabelsToPanel(List<Collection> collections)
        {
            int X = 3, Y = 49;
            foreach(Collection c in collections)
            {
                Label label = new Label();
                label.Name = "collection_" + c.Id;
                label.Location = new Point(X, Y);
                label.AutoSize = true;
                Y += 31;
                label.Text = c.ColName;
                label.Font = new Font("Cambria", 9f);
                label.Click += new EventHandler(OpenCollectionWindow);

                panelAllCollections.Controls.Add(label);
            }
        }

        private void OpenCategoryWindow(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            string[] categoryInfo = control.Name.Split('_');

            CategoriesCollectionsGoodsWindow categoryWindow = new CategoriesCollectionsGoodsWindow(Convert.ToInt32(categoryInfo[1]), 0, userEmail);
            categoryWindow.Show();
            this.Hide();
        }

        private void AddCategoryLabelsToPanel(List<Category> categories)
        {
            int X = 3, Y = 49;
            foreach (Category c in categories)
            {
                Label label = new Label();
                label.Name = "category_" + c.Id;
                label.Location = new Point(X, Y);
                label.AutoSize = true;
                Y += 31;
                label.Text = c.CName;
                label.Font = new Font("Cambria", 9f);
                label.Click += new EventHandler(OpenCategoryWindow);

                panelAllCategories.Controls.Add(label);
            }
        }

        private void OpenPromotionWindow(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            string[] promotionInfo = control.Name.Split('_');

            PromotionsGoodsWindow promotionsGoodsWindow = new PromotionsGoodsWindow(Convert.ToInt32(promotionInfo[1]), userEmail);
            promotionsGoodsWindow.Show();
            this.Hide();
        }

        private void AddPromotionsLabelsToPanel(List<Promotion> promotions)
        {
            int X = 3, Y = 49;
            foreach (Promotion p in promotions)
            {
                Label label = new Label();
                label.Name = "promotion_" + p.Id;
                label.Location = new Point(X, Y);
                label.AutoSize = true;
                Y += 31;
                label.Text = p.PromotionName;
                label.Font = new Font("Cambria", 9f);
                label.Click += new EventHandler(OpenPromotionWindow);

                panelAllPromotions.Controls.Add(label);
            }
        }

        private void MoreInfo(object sender, EventArgs e)
        {
            Control element = (Control)sender;
            CategoriesCollectionsGoodsWindow collectionWindow = new CategoriesCollectionsGoodsWindow(Convert.ToInt32(element.Name), 1, userEmail);
            collectionWindow.Show();
            this.Hide();
        }

        private void AddMWMainCollections(List<Collection> collections)
        {
            int X = 170, Y = 130, Xsmall = 0, Ysmall = 48;
            foreach (Collection c in collections) 
            {
                Panel bigPanel = new Panel();
                bigPanel.Location = new Point(X, Y);
                bigPanel.Width = 544;
                bigPanel.Height = 303;
                Y += 318;
                bigPanel.Name = "mainCollection" + c.Id;
                Label name = new Label();
                name.AutoSize = true;
                name.Location = new Point(12, 15);
                name.Text = c.ColName;
                name.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
                Button moreInfoButton = new Button();
                moreInfoButton.Width = 88;
                moreInfoButton.Height = 30;
                moreInfoButton.Location = new Point(442, 8);
                moreInfoButton.BackColor = Color.FromArgb(212, 180, 131);
                moreInfoButton.Font = new Font("Cambria", 9f);
                moreInfoButton.Text = "Подробнее";
                moreInfoButton.Click += new EventHandler(MoreInfo);
                moreInfoButton.Name = c.Id.ToString();

                this.Controls.Add(bigPanel);

                Panel smallPanel = new Panel();
                smallPanel.Location = new Point(Xsmall, Ysmall);
                smallPanel.BorderStyle = BorderStyle.FixedSingle;
                smallPanel.Width = 542;
                smallPanel.Height = 254;
                List<Good> goods = goodCollectionController.GetGoods(c);

                bigPanel.Controls.Add(smallPanel);
                bigPanel.Controls.Add(name);
                bigPanel.Controls.Add(moreInfoButton);

                int XmCol = 25;
                for(int i = 0; i < 4; i++)
                {
                    if (i == goods.Count) break;
                    PictureBox goodImage = new PictureBox();
                    MemoryStream ms = new MemoryStream(goods[i].Image);
                    Bitmap image = new Bitmap(ms);
                    goodImage.Width = 100;
                    goodImage.Height = 146;
                    goodImage.SizeMode = PictureBoxSizeMode.Zoom;
                    goodImage.Image = image;
                    goodImage.Name = "good_" + goods[i].Id;
                    goodImage.Location = new Point(XmCol, 59);
                    goodImage.Click += new EventHandler(OpenItemInfo);

                    Label goodName = new Label();
                    goodName.Width = 103;
                    goodName.Height = 47;
                    goodName.Text = goods[i].GoodName;
                    goodName.Location = new Point(XmCol, 11);
                    goodName.Font = new Font("Cambria", 8.5f);

                    Label goodCost = new Label();
                    goodCost.Width = 103;
                    goodCost.Height = 17;
                    int maxDiscount = 0;
                    List<Promotion> proms = goodPromotionController.GetPromotions(goods[i]);
                    foreach (Promotion p in proms) if (p.Discount > maxDiscount) maxDiscount = p.Discount;
                    decimal price = goods[i].Price * (decimal)(1 - (float)maxDiscount * 0.01f);
                    goodCost.Text = price.ToString();
                    if (maxDiscount > 0) goodCost.Text = goodCost.Text + " (-" + maxDiscount + "%)";
                    goodCost.Location = new Point(XmCol, 213);
                    goodCost.Font = new Font("Cambria", 8.5f);

                    Label rubsLabel = new Label();
                    rubsLabel.Location = new Point(XmCol, 230);
                    rubsLabel.Font = new Font("Cambria", 8.5f);
                    rubsLabel.Text = "руб.";

                    XmCol += 127;

                    smallPanel.Controls.Add(goodImage);
                    smallPanel.Controls.Add(rubsLabel);
                    smallPanel.Controls.Add(goodCost);
                    smallPanel.Controls.Add(goodName);
                }
            }
        }

        private void OpenItemInfo(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            string[] goodInfo = control.Name.Split('_');

            ItemWindow itemWindow = new ItemWindow(userEmail, this, Convert.ToInt32(goodInfo[1]));
            itemWindow.Show();
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

        private void buttonQuestion_Click(object sender, EventArgs e)
        {
            QuestionWindow window = new QuestionWindow(userEmail);
            window.Show();
            this.Hide();
        }

        public void SetUserEmail(string userEmail)
        {
            this.userEmail = userEmail;
        }

        private void buttonWork_Click(object sender, EventArgs e)
        {
            JobAppWindow jobAppWindow = new JobAppWindow(userEmail);
            jobAppWindow.Show();
            this.Hide();
        }

        private void buttonUserOrders_Click(object sender, EventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow(userEmail);
            orderWindow.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShoppingCartWindow shoppingCartWindow = new ShoppingCartWindow(userEmail);
            shoppingCartWindow.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchResultWindow searchResultWindow = new SearchResultWindow(this, textBoxValue.Text, checkBoxHavePromotions.Checked, userEmail);
            searchResultWindow.Show();
            this.Hide();
        }
    }
}
