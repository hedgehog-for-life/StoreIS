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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.Windows.ForUser
{
    public partial class QuestionWindow : Form
    {
        private string userEmail;
        private Person user;

        private PersonController personController;
        private QuestionController questionController;
        private QThemeController qThemeController;

        private List<Question> questions;

        private StringValidator stringValidator;

        private stuff_shopContext db;

        private Dictionary<Panel, Question> qPanelsU;
        private Dictionary<Panel, Question> qPanelsA;

        public QuestionWindow(string userEmail)
        {
            InitializeComponent();

            db = new stuff_shopContext();

            personController = new PersonController();
            questionController = new QuestionController(db);
            qThemeController = new QThemeController(db);

            questions = new List<Question>();

            user = personController.FindPersonByEmail(userEmail);

            stringValidator = new StringValidator();

            qPanelsU = new Dictionary<Panel, Question>();
            qPanelsA = new Dictionary<Panel, Question>();

            List<QTheme> themes = qThemeController.GetThemes();
            foreach(QTheme qt in themes)
            {
                comboBoxQThemes.Items.Add(qt.ThemeName);
            }
            comboBoxQThemes.SelectedItem = comboBoxQThemes.Items[0];

            RetrieveDataFromDB();
        }

        public void RetrieveDataFromDB()
        {
            questions = questionController.GetQuestionsForUser(user);

            List<Question> unansweredQuestions = new List<Question>();
            List<Question> answeredQuestions = new List<Question>();

            foreach(Question q in questions)
            {
                if (q.QStatus == 0 || q.QStatus == 1) unansweredQuestions.Add(q);
                else answeredQuestions.Add(q);
            }

            foreach(Question q in answeredQuestions)
            {
                AddAnsweredQuestionsPanel(q);
            }
            foreach (Question q in unansweredQuestions)
            {
                AddUnansweredQuestionPanel(q);
            }

        }

        private void richTextBoxQuestion_Validating(object sender, CancelEventArgs e)
        {
            string text = richTextBoxQuestion.Text;
            if (!stringValidator.IsLengthCorrectMax(text, 500) || !stringValidator.IsLengthCorrectMin(text, 10))
            {
                e.Cancel = true;
                richTextBoxQuestion.Select(0, richTextBoxQuestion.Text.Length);

                buttonAddQuestion.Enabled = false;

                this.errorProvider1.SetError(richTextBoxQuestion, "Длина текста вопроса должна быть в интервале от 10 до 500 символов.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(richTextBoxQuestion, "");
                buttonAddQuestion.Enabled = true;
            }
        }

        private void richTextBoxQuestion_Validated(object sender, EventArgs e)
        {
            buttonAddQuestion.Enabled = true;
            errorProvider1.SetError(richTextBoxQuestion, "");
        }

        private void AddUnansweredQuestionPanel(Question question) 
        {
            Panel panelEl = new Panel();
            panelEl.Height = 179;
            panelEl.Width = 379;
            panelEl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(panelEl);

            Label qLabel = new Label();
            qLabel.Text = "Вопрос от " + question.PublishQDate.ToShortDateString();
            qLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            qLabel.AutoSize = true;
            qLabel.Location = new Point(4, 4);

            Label themeLabel = new Label();
            themeLabel.Text = "Тема вопроса";
            themeLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            themeLabel.AutoSize = true;
            themeLabel.Location = new Point(4, 35);

            Label questionLabel = new Label();
            questionLabel.Text = "Вопрос";
            questionLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            questionLabel.AutoSize = true;
            questionLabel.Location = new Point(4, 89);

            RichTextBox themeRTB = new RichTextBox();
            themeRTB.ReadOnly = true;
            themeRTB.BorderStyle = BorderStyle.None;
            themeRTB.BackColor = Color.FromArgb(228, 223, 218);
            themeRTB.Text = question.Theme.ThemeName;
            themeRTB.Font = new Font("Cambria", 9f);
            themeRTB.Width = 365;
            themeRTB.Height = 19;
            themeRTB.Location = new Point(7, 61);

            RichTextBox questionRTB = new RichTextBox();
            questionRTB.ReadOnly = true;
            questionRTB.BorderStyle = BorderStyle.None;
            questionRTB.BackColor = Color.FromArgb(228, 223, 218);
            questionRTB.Text = question.QText;
            questionRTB.Font = new Font("Cambria", 9f);
            questionRTB.Width = 365;
            questionRTB.Height = 55;
            questionRTB.Location = new Point(7, 115);

            if (qPanelsU.Count > 0)
            {
                foreach (Panel p in qPanelsU.Keys)
                {
                    p.Location = new Point(p.Location.X, p.Location.Y + 215);
                }
            }
            panelEl.Location = new Point(181, 456);

            panelEl.Controls.Add(qLabel);
            panelEl.Controls.Add(themeLabel);
            panelEl.Controls.Add(questionLabel);
            panelEl.Controls.Add(themeRTB);
            panelEl.Controls.Add(questionRTB);

            qPanelsU.Add(panelEl, question);
        }

        private void AddAnsweredQuestionsPanel(Question question)
        {
            Panel panelEl = new Panel();
            panelEl.Height = 307;
            panelEl.Width = 379;
            panelEl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(panelEl);

            Label qLabel = new Label();
            qLabel.Text = "Вопрос от " + question.PublishQDate.ToShortDateString();
            qLabel.Font = new Font("Cambria", 9.75f, FontStyle.Bold);
            qLabel.AutoSize = true;
            qLabel.Location = new Point(4, 4);

            Label themeLabel = new Label();
            themeLabel.Text = "Тема вопроса";
            themeLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            themeLabel.AutoSize = true;
            themeLabel.Location = new Point(4, 35);

            Label questionLabel = new Label();
            questionLabel.Text = "Вопрос";
            questionLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            questionLabel.AutoSize = true;
            questionLabel.Location = new Point(4, 89);

            Label answerLabel = new Label();
            answerLabel.Text = "Ответ";
            answerLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            answerLabel.AutoSize = true;
            answerLabel.Location = new Point(4, 214);

            Label aDateLabel = new Label();
            aDateLabel.Text = Convert.ToDateTime(question.PublishADate).ToShortDateString();
            aDateLabel.Font = new Font("Cambria", 9f, FontStyle.Italic);
            aDateLabel.AutoSize = true;
            aDateLabel.Location = new Point(313, 214);

            RichTextBox themeRTB = new RichTextBox();
            themeRTB.Text = question.Theme.ThemeName;
            themeRTB.Font = new Font("Cambria", 9f);
            themeRTB.Width = 365;
            themeRTB.Height = 19;
            themeRTB.Location = new Point(7, 61);
            themeRTB.ReadOnly = true;
            themeRTB.BorderStyle = BorderStyle.None;
            themeRTB.BackColor = Color.FromArgb(228, 223, 218);

            RichTextBox questionRTB = new RichTextBox();
            questionRTB.Text = question.QText;
            questionRTB.Font = new Font("Cambria", 9f); 
            questionRTB.ReadOnly = true;
            questionRTB.BorderStyle = BorderStyle.None;
            questionRTB.BackColor = Color.FromArgb(228, 223, 218);
            questionRTB.Width = 365;
            questionRTB.Height = 55;
            questionRTB.Location = new Point(7, 115);

            RichTextBox answerRTB = new RichTextBox();
            answerRTB.Text = question.AText;
            answerRTB.Font = new Font("Cambria", 9f);
            answerRTB.Width = 365;
            answerRTB.Height = 55;
            answerRTB.Location = new Point(7, 240);
            answerRTB.ReadOnly = true;
            answerRTB.BorderStyle = BorderStyle.None;
            answerRTB.BackColor = Color.FromArgb(228, 223, 218);

            Label consultantLabel = new Label();
            consultantLabel.Text = question.Consultant.PersonSurname + " " + question.Consultant.PersonName + " " + question.Consultant.PersonPatronymic;
            consultantLabel.Font = new Font("Cambria", 9f, FontStyle.Bold);
            consultantLabel.AutoSize = true;
            consultantLabel.Location = new Point(4, 182);

            if (qPanelsA.Count > 0)
            {
                foreach (Panel p in qPanelsA.Keys)
                {
                    p.Location = new Point(p.Location.X, p.Location.Y + 343);
                }
            }
            panelEl.Location = new Point(588, 116);

            panelEl.Controls.Add(qLabel);
            panelEl.Controls.Add(themeLabel);
            panelEl.Controls.Add(questionLabel);
            panelEl.Controls.Add(answerLabel);
            panelEl.Controls.Add(aDateLabel);
            panelEl.Controls.Add(themeRTB);
            panelEl.Controls.Add(questionRTB);
            panelEl.Controls.Add(answerRTB);
            panelEl.Controls.Add(consultantLabel);

            qPanelsA.Add(panelEl, question);
        }

        private void buttonAddQuestion_Click(object sender, EventArgs e)
        {
            Question question = new Question();
            question.User = user;
            question.QStatus = 0;
            question.PublishQDate = DateTime.Now;
            QTheme theme = qThemeController.GetQTheme(comboBoxQThemes.SelectedItem.ToString());
            question.Theme = theme;
            question.QText = richTextBoxQuestion.Text;

            questionController.AddQuestion(question);
            AddUnansweredQuestionPanel(question);
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
            MainWindow window = new MainWindow(user.Email);
            window.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShoppingCartWindow shoppingCartWindow = new ShoppingCartWindow(user.Email);
            shoppingCartWindow.Show();
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
    }
}
