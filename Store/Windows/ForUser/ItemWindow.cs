using Store.Controllers;
using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.Validators;
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
    public partial class ItemWindow : Form
    {
        private Form previoslyOpened;
        private Good good;

        private Person user;

        private GoodController goodController;
        private GoodPromotionController goodPromotionController;
        private PromotionController promotionController;
        private ShoppingCartController shoppingCartController;
        private PersonController personController;
        private ReviewController reviewController;

        private StringValidator validator;
        private InputValidator iValidator;

        private Dictionary<Panel, Review> rPanels;

        private stuff_shopContext db;

        public ItemWindow(string userEmail, Form previoslyOpened, int goodId) 
        {
            InitializeComponent();
            this.previoslyOpened = previoslyOpened;
            personController = new PersonController();
            user = personController.FindPersonByEmail(userEmail);

            validator = new StringValidator();
            iValidator = new InputValidator();

            rPanels = new Dictionary<Panel, Review>();

            db = new stuff_shopContext();

            goodController = new GoodController(db);

            good = goodController.GetGood(goodId);
            goodPromotionController = new GoodPromotionController(db);
            promotionController = new PromotionController(db);
            shoppingCartController = new ShoppingCartController(db);
            reviewController = new ReviewController(db);

            SetUpData();
        }

        public void SetUpData()
        {
            labelDiscount.Text = "0";
            labelFreeGoods.Text = "0";
            MemoryStream ms = new MemoryStream(good.Image);
            Bitmap image = new Bitmap(ms);
            pictureBoxGoodImage.Image = image;
            labelGoodName.Text = good.GoodName;
            labelGoodArticle.Text = good.Article;
            labelGoodDate.Text = "Дата выпуска: " + good.ReleaseDate.ToShortDateString();
            richTextBoxDescription.Text = good.GoodDescription;
            labelNumber.Text = good.GoodNum.ToString();
            if (good.Characteristic != null)
            {
                string[] characteristicValue = good.Characteristic.Split('_');
                labelCharacteristic.Text = characteristicValue[1];
                characteristicL.Text = characteristicValue[0];
                labelCharacteristicL.Text = characteristicValue[0];
            }
            else
            {
                labelCharacteristic.Visible = false;
                characteristicL.Visible = false;
            }
            if (shoppingCartController.GetBYUserAndGood(user.Id, good.Id) != null)
                buttonAddToSC.Enabled = false;

            FindBestPrice();
        }

        public void RetrieveDataFromDB()
        {
            List<Review> reviews = reviewController.GetReviewsForGood(good);
            foreach (Review r in reviews)
                CreatePanelForReview(r);
        }

        private void CreatePanelForReview(Review r)
        {
            Panel panelEl = new Panel();
            panelEl.Width = 238; 
            panelEl.Height = 180;

            panelReviewContainer.Controls.Add(panelEl);

            Label authorLabel = new Label();
            authorLabel.Text = r.User.PersonSurname + " " + r.User.PersonName + " " + r.User.PersonPatronymic;
            authorLabel.AutoSize = true;
            authorLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            authorLabel.Location = new Point(4, 5);

            Label assessmentLabel = new Label();
            assessmentLabel.Text = r.Assessment.ToString();
            assessmentLabel.AutoSize = true;
            assessmentLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            assessmentLabel.Location = new Point(4, 28);

            RichTextBox reviewTB = new RichTextBox();
            reviewTB.Text = r.ReviewText;
            reviewTB.Font = new Font("Cambria", 9f);
            reviewTB.Location = new Point(7,52);
            reviewTB.Width = 222;
            reviewTB.Height = 96;

            Label publishDateLabel = new Label();
            publishDateLabel.Text = r.PublishDate.ToShortDateString();
            publishDateLabel.AutoSize = true;
            publishDateLabel.Font = new Font("Cambria", 9.75f);
            publishDateLabel.Location = new Point(4, 155);

            panelEl.Controls.Add(publishDateLabel);
            panelEl.Controls.Add(reviewTB);
            panelEl.Controls.Add(authorLabel);
            panelEl.Controls.Add(assessmentLabel);

            if (rPanels.Count > 0)
            {
                foreach (Panel p in rPanels.Keys)
                {
                    p.Location = new Point(p.Location.X, p.Location.Y + 199);
                }
            }
            panelEl.Location = new Point(0, 0);
        }

        private void FindBestPrice()
        {
            List<Promotion> promotions = goodPromotionController.GetPromotions(good);
            int currDiscount = Convert.ToInt32(labelDiscount.Text);
            float discount = 1 - 0.01f * currDiscount;
            int freeGoods = 0;
            int freeGoodsWOD = 0;
            decimal currPrice = good.Price * Convert.ToInt32(textBoxGoodsNumber.Text) * (decimal)discount;
            foreach (Promotion p in promotions)
            {
                if (Convert.ToInt32(textBoxGoodsNumber.Text) >= p.GoodNum)
                {
                    float lower = 1 - 0.01f * p.Discount;
                    decimal price = good.Price * Convert.ToInt32(textBoxGoodsNumber.Text) * (decimal)lower;
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
                labelDiscount.Text = currDiscount.ToString();
                labelFreeGoods.Text = freeGoods.ToString();
            }
            else
            {
                labelDiscount.Text = "0";
                labelFreeGoods.Text = freeGoodsWOD.ToString();
            }
            labelCost.Text = currPrice.ToString();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            previoslyOpened.Show();
            this.Hide();
        }

        private void pictureBoxMore_Click(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(textBoxGoodsNumber.Text);
            if (val >= good.GoodNum)
            {
                val = good.GoodNum;
            }
            else val += 1;
            textBoxGoodsNumber.Text = val.ToString();
            FindBestPrice();
        }

        private void pictureBoxLess_Click(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(textBoxGoodsNumber.Text);
            if (val <= 1) val = 1;
            else val -= 1;
            textBoxGoodsNumber.Text = val.ToString();
            FindBestPrice();
        }

        async private void buttonAddToSC_Click(object sender, EventArgs e)
        {
            buttonAddToSC.Enabled = false;
            ShoppingCart item = new ShoppingCart();
            item.Good = good;
            item.User = user;
            item.Characteristic = textBoxCharacteristic.Text;
            item.GoodNum = Convert.ToInt32(textBoxGoodsNumber.Text);
            item.Discount = Convert.ToInt16(labelDiscount.Text);
            item.FreeGoods = Convert.ToInt16(labelFreeGoods.Text);
            item.Cost = Convert.ToDecimal(labelCost.Text);

            await shoppingCartController.AddItemAsync(item);
        }

        private void pictureBoxCart_Click(object sender, EventArgs e)
        {
            ShoppingCartWindow shoppingCartWindow = new ShoppingCartWindow(user.Email);
            shoppingCartWindow.Show();
            this.Hide();
        }

        private void buttonAddRewiew_Click(object sender, EventArgs e)
        {
            if(validator.IsLengthCorrectMin(richTextBoxReviewText.Text, 1) || string.IsNullOrEmpty(textBoxAssas.Text))
            {
                try
                {
                    Review review = new Review();
                    review.Assessment = Convert.ToSingle(textBoxAssas.Text);
                    review.ReviewText = richTextBoxReviewText.Text;
                    review.User = user;
                    review.Good = good;
                    review.PublishDate = DateTime.Now;

                    reviewController.AddReview(review);
                    CreatePanelForReview(review);

                    richTextBoxReviewText.Text = "";
                    textBoxAssas.Text = "";
                }
                catch(Exception)
                {
                    ErrorWindow errorWindow = new ErrorWindow("Ваша оценка имеет некорректный формат");
                    errorWindow.Show();
                }
            }
            else
            {
                ErrorWindow errorWindow = new ErrorWindow("Отзыв/оценка не могцт быть пустыми строками");
                errorWindow.Show();
            }
                
        }

        private void textBoxAssas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!iValidator.IdFloatSymbol(e.KeyChar))
                e.Handled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchResultWindow searchResultWindow = new SearchResultWindow(this, textBoxValue.Text, checkBoxHavePromotions.Checked, user.Email);
            searchResultWindow.Show();
            this.Hide();
        }

        private void pictureBoxLogOut_Click_1(object sender, EventArgs e)
        {
            LoginForm loginWindow = new LoginForm();
            loginWindow.Show();
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
