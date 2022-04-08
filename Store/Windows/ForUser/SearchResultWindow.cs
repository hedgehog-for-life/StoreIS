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
    public partial class SearchResultWindow : Form
    {
        private CategoryController categoryController;
        private CollectionController collectionController;
        private GoodPromotionController goodPromotionController;
        private GoodController goodController;
        private GoodCollectionController goodCollectionController;

        private Form previousWindow;

        private Dictionary<Panel, Good> resultGoods;

        private stuff_shopContext db;

        private string userEmail;
        private string value;

        private bool promotionsNeed;

        public SearchResultWindow(Form previousWindow, string value, bool promotionsNeed, string userEmail)
        {
            InitializeComponent();
            db = new stuff_shopContext();
            categoryController = new CategoryController(db);
            collectionController = new CollectionController(db);
            goodPromotionController = new GoodPromotionController(db);
            goodController = new GoodController(db);
            goodCollectionController = new GoodCollectionController(db);

            labelWProms.Text = promotionsNeed ? "Да" : "Нет";

            this.userEmail = userEmail;

            FillInCategories();
            FillInCollections();
            List<Good> goodsByName = goodController.SearchByName(value);
            List<Good> goodsByArticle = goodController.SearchByArticle(value);
            resultGoods = new Dictionary<Panel, Good>();
            foreach(Good g in goodsByName)
            {
                if (promotionsNeed)
                {
                    List<Promotion> promotions = goodPromotionController.GetPromotions(g);
                    if (!resultGoods.ContainsValue(g) && promotions.Count > 0)
                        CreatePanelForGood(g, promotionsNeed);
                }
                else
                {
                    if (!resultGoods.ContainsValue(g))
                        CreatePanelForGood(g, promotionsNeed);
                }
            }
            foreach (Good g in goodsByArticle)
            {
                if (promotionsNeed)
                {
                    if (!resultGoods.ContainsValue(g) && goodPromotionController.GetPromotions(g).Count > 0)
                        CreatePanelForGood(g, promotionsNeed);
                }
                else
                {
                    if (!resultGoods.ContainsValue(g))
                        CreatePanelForGood(g, promotionsNeed);
                }
            }

            this.value = value;

            this.promotionsNeed = promotionsNeed;

            this.previousWindow = previousWindow;
        }

        private void FillInCategories()
        {
            List<Category> categories = categoryController.GetCategories();
            foreach(Category c in categories)
            {
                checkedListBoxCategories.Items.Add(c.CName);
            }
            for(int i = 0; i < checkedListBoxCategories.Items.Count; i++)
            {
                checkedListBoxCategories.SetItemChecked(i, true);
            }
        }
        private void FillInCollections()
        {
            List<Collection> collections = collectionController.GetActiveCollections();
            foreach (Collection c in collections)
            {
                checkedListBoxCollections.Items.Add(c.ColName);
            }
            for (int i = 0; i < checkedListBoxCollections.Items.Count; i++)
            {
                checkedListBoxCollections.SetItemChecked(i, true);
            }
        }
        //private void FillInCategories(string name)
        //{
        //    List<Category> categories = categoryController.GetCategoriesLikeName(name);
        //    int X = 8, Y = 9;
        //    foreach (Category c in categories)
        //    {
        //        Label label = new Label();
        //        label.Name = "category_" + c.Id;
        //        label.Location = new Point(X, Y);
        //        label.AutoSize = true;
        //        Y += 24;
        //        label.Text = c.CName;
        //        label.Font = new Font("Cambria", 9f);
        //        label.Click += new EventHandler(OpenCategoryWindow);

        //        panelAllCategories.Controls.Add(label);
        //    }
        //}

        //private void FillInCollections(string name)
        //{
        //    List<Collection> collections = collectionController.GetCollectionsLikeName(name);
        //    int X = 8, Y = 9;
        //    foreach (Collection c in collections)
        //    {
        //        Label label = new Label();
        //        label.Name = "collection_" + c.Id;
        //        label.Location = new Point(X, Y);
        //        label.AutoSize = true;
        //        Y += 24;
        //        label.Text = c.ColName;
        //        label.Font = new Font("Cambria", 9f);
        //        label.Click += new EventHandler(OpenCollectionWindow);

        //        panelAllCollections.Controls.Add(label);
        //    }
        //}


        private void OpenCategoryWindow(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            string[] categoryInfo = control.Name.Split('_');

            CategoriesCollectionsGoodsWindow categoryWindow = new CategoriesCollectionsGoodsWindow(Convert.ToInt32(categoryInfo[1]), 0, userEmail);
            categoryWindow.Show();
            this.Hide();
        }

        private void OpenCollectionWindow(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            string[] collectionInfo = control.Name.Split('_');

            CategoriesCollectionsGoodsWindow categoryWindow = new CategoriesCollectionsGoodsWindow(Convert.ToInt32(collectionInfo[1]), 1, userEmail);
            categoryWindow.Show();
            this.Hide();
        }

        private void OpenItemInfo(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Panel panel = (Panel)control.Parent;
            string[] goodInfo = control.Name.Split('_');

            ItemWindow itemWindow = new ItemWindow(userEmail, this, Convert.ToInt32(goodInfo[1]));
            itemWindow.Show();
            this.Hide();
        }

        private void CreatePanelForGood(Good g, bool promotionsRequired)
        {
         //   int discount = FindBestPrice(g);
           // decimal price = (decimal)((1 - 0.01f * (float)discount)) * g.Price;

            Panel panelEl = new Panel();
            int maxY = 0;
            if (resultGoods.Count > 0)
            {
                foreach (Panel p in resultGoods.Keys)
                {
                    if (p.Location.Y > maxY)
                    {
                        maxY = p.Location.Y;
                    }
                }
            }
            if (maxY == 0) panelEl.Location = new Point(207, 436);
            else
            {
                panelEl.Location = new Point(207, maxY + 112);
            }
            panelEl.Width = 434;
            panelEl.Height = 94;
            panelEl.AutoScroll = true;

            panelEl.BackColor = Color.FromArgb(228, 223, 218);
            panelEl.BorderStyle = BorderStyle.FixedSingle;

            PictureBox goodImage = new PictureBox();
            MemoryStream ms = new MemoryStream(g.Image);
            Bitmap image = new Bitmap(ms);
            goodImage.Width = 60;
            goodImage.Height = 88;
            goodImage.SizeMode = PictureBoxSizeMode.Zoom;
            goodImage.Image = image;
            goodImage.Name = "good_" + g.Id;
            goodImage.Location = new Point(0, 3);
            goodImage.Click += new EventHandler(OpenItemInfo);


            Label goodName = new Label();
            goodName.Text = g.GoodName;
            goodName.Location = new Point(65, 9);
            goodName.Font = new Font("Cambria", 9f, FontStyle.Bold);
            goodName.Name = "good_" + g.Id;
            goodName.AutoSize = true;
            goodName.Click += new EventHandler(OpenItemInfo);

            RichTextBox description = new RichTextBox();
            description.BackColor =  Color.FromArgb(228, 223, 218);
            description.BorderStyle = BorderStyle.None;
            description.Width = 356;
            description.Height = 39;
            description.Location = new Point(68, 26);
            description.Font = new Font("Cambria", 8.5f);
            description.Text = g.GoodDescription;
            description.Click += new EventHandler(OpenItemInfo);
            description.Name = "good_" + g.Id;

            TextBox goodCost = new TextBox();
            goodCost.Width = 103; 
            goodCost.Height = 15;
            goodCost.Location = new Point(321, 68);
            goodCost.TextAlign = HorizontalAlignment.Right;
            goodCost.Font = new Font("Cambria", 9f, FontStyle.Bold);
            goodCost.BackColor = Color.FromArgb(228, 223, 218);
            goodCost.BorderStyle = BorderStyle.None;

            Label costLabel = new Label();
            costLabel.Location = new Point(65, 68);
            costLabel.Font = new Font("Cambria", 9f, FontStyle.Bold);
            costLabel.AutoSize = true;

            if (promotionsRequired)
            {
                int maxDiscount = 0;
                List<Promotion> proms = goodPromotionController.GetPromotions(g);
                foreach (Promotion p in proms) if (p.Discount > maxDiscount) maxDiscount = p.Discount;
                decimal price = g.Price * (decimal)(1 - (float)maxDiscount * 0.01f);
                goodCost.Text = price.ToString(); ;
                costLabel.Text = "Цена (скидка - " + maxDiscount + "%)";
            }
            else {
                goodCost.Text = g.Price.ToString();
                costLabel.Text = "Цена";
                    }

            this.Controls.Add(panelEl);
            panelEl.Controls.Add(goodImage);
            panelEl.Controls.Add(goodName);
            panelEl.Controls.Add(description);
            panelEl.Controls.Add(costLabel);
            panelEl.Controls.Add(goodCost);
            resultGoods.Add(panelEl, g);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            previousWindow.Show();
            this.Hide();
        }

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

        private void pictureBoxCart_Click(object sender, EventArgs e)
        {
            ShoppingCartWindow shoppingCartWindow = new ShoppingCartWindow(userEmail);
            shoppingCartWindow.Show();
            this.Hide();
        }

        private void buttonAddFilter_Click(object sender, EventArgs e)
        {
            foreach(Panel p in resultGoods.Keys)
            {
                this.Controls.Remove(p);
            }
            resultGoods.Clear();

            foreach(string categoryName in checkedListBoxCategories.CheckedItems)
            {
                Category category = categoryController.GetCategoryByName(categoryName);
                
            }
            List<Good> goodsByName = goodController.SearchByName(value);
            List<Good> goodsByArticle = goodController.SearchByArticle(value);

            List<Good> resultListOfGoods = new List<Good>();
            foreach(Good g in goodsByName)
            {
                bool categoryCheck = false;
                bool collectionCheck = false;
                if(!resultListOfGoods.Contains(g))
                {
                    foreach (string categoryName in checkedListBoxCategories.CheckedItems)
                    {
                        Category category = categoryController.GetCategoryByName(categoryName);
                        if (g.Category.Id == category.Id) { categoryCheck = true; break; }
                    }
                    foreach (string collectionName in checkedListBoxCollections.CheckedItems)
                    {
                        Collection collection = collectionController.GetCollectionByName(collectionName);
                        if(goodCollectionController.GetGoods(collection).Contains(g)) { collectionCheck = true; break; }
                    }
                    if(collectionCheck && categoryCheck)
                    {
                        resultListOfGoods.Add(g);
                    }
                }
            }
            foreach (Good g in goodsByArticle)
            {
                bool categoryCheck = false;
                bool collectionCheck = false;
                if (!resultListOfGoods.Contains(g))
                {
                    foreach (string categoryName in checkedListBoxCategories.CheckedItems)
                    {
                        Category category = categoryController.GetCategoryByName(categoryName);
                        if (g.Category.Id == category.Id) { categoryCheck = true; break; }
                    }
                    foreach (string collectionName in checkedListBoxCollections.CheckedItems)
                    {
                        Collection collection = collectionController.GetCollectionByName(collectionName);
                        if (goodCollectionController.GetGoods(collection).Contains(g)) { collectionCheck = true; break; }
                    }
                    if (collectionCheck && categoryCheck)
                    {
                        resultListOfGoods.Add(g);
                    }
                }
            }
            foreach(Good g in resultListOfGoods)
            {
                if(promotionsNeed)
                {
                    if (goodPromotionController.GetPromotions(g).Count > 0)
                        CreatePanelForGood(g, promotionsNeed);
                }
                else CreatePanelForGood(g, promotionsNeed);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchResultWindow searchResultWindow = new SearchResultWindow(this, textBoxValue.Text, checkBoxHavePromotions.Checked, userEmail);
            searchResultWindow.Show();
            this.Hide();
        }

        public void SetUserEmail(string userEmail)
        {
            this.userEmail = userEmail;
        }

        private void buttonWatchThroughItems_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow(userEmail);
            mainWindow.Show();
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

        private void buttonQuestion_Click(object sender, EventArgs e)
        {
            QuestionWindow window = new QuestionWindow(userEmail);
            window.Show();
            this.Hide();
        }
    }
}
