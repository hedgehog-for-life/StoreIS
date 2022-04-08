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

namespace Store.Windows.ForConsultant
{
    public partial class ConsultantWindow : Form
    {
        private BindingList<Question> unansweredQuestions;
        private BindingList<Question> consultantQuestions;
        private BindingList<QTheme> themes;

        private QuestionController questionController;
        private QThemeController qTHemeController;
        private PersonController personController;

        private List<DataGridViewRow> newRows;

        private StringValidator validator;

        private Person currUser;

        private stuff_shopContext db, db1;

        private bool first = true;
        private bool onlyAnswered = false;

        public ConsultantWindow(string userEmail)
        {
            InitializeComponent();

            validator = new StringValidator();

            db = new stuff_shopContext();
            db1 = new stuff_shopContext();

            qTHemeController = new QThemeController(db1);
            questionController = new QuestionController(db);
            personController = new PersonController();

            currUser = personController.FindPersonByEmail(userEmail);

            newRows = new List<DataGridViewRow>();

            RetrieveDataFromDT();
        }

        private void RetrieveDataFromDT()
        {
            BindingList<Question> unansweredQuestions = new BindingList<Question>(questionController.GetUnanswered(currUser.Id));
            BindingList<Question> consultantQuestions = new BindingList<Question>(questionController.GetQuestionsForConsultant(currUser));
         

            dataGridViewQuestions.DataSource = unansweredQuestions;

            themes = new BindingList<QTheme>(qTHemeController.GetThemes());

            dataGridViewQThemes.DataSource = themes;

            List<QTheme> qThemes = qTHemeController.GetThemes();
            foreach (QTheme qt in qThemes) {
                ColumnTheme.Items.Add(qt.ThemeName);
            }
            ColumnQuestionStatus.Items.Add("Ожидает ответа");
            ColumnQuestionStatus.Items.Add("Обрабатывается");
            ColumnQuestionStatus.Items.Add("Отвечен");

            dataGridViewConsultantQuestions.DataSource = consultantQuestions;

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

        private void dataGridViewQuestions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            unansweredQuestions = new BindingList<Question>(questionController.GetUnanswered(currUser.Id));
            for (int i = 0; i < dataGridViewQuestions.Rows.Count; i++)
            {
                Person user = personController.GetUser(Convert.ToInt32(dataGridViewQuestions.Rows[i].Cells[ColumnUserId.Index].Value));
                dataGridViewQuestions.Rows[i].Cells[ColumnUser.Index].Value = user.PersonSurname + " " + user.PersonName + " " + user.PersonPatronymic;
                
                switch(dataGridViewQuestions.Rows[i].Cells[ColumnQuestionStatusId.Index].Value.ToString())
                {
                    case "0":
                        dataGridViewQuestions.Rows[i].Cells[ColumnQuestionStatus.Index].Value = "Ожидает ответа";
                        break;
                    case "1":
                        dataGridViewQuestions.Rows[i].Cells[ColumnQuestionStatus.Index].Value = "Обрабатывается";
                        break;
                }
                dataGridViewQuestions.Rows[i].Cells[ColumnTheme.Index].Value = themes.First(theme => theme.Id == Convert.ToInt32(dataGridViewQuestions.Rows[i].Cells[ColumnThemeId.Index].Value)).ThemeName;
            }

        }

        private void dataGridViewQuestions_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            List<QTheme> themes = qTHemeController.GetThemes();
            ColumnTheme.Items.Clear();
            foreach (QTheme qt in themes)
            {
                ColumnTheme.Items.Add(qt.ThemeName);
            }
        }

        private void dataGridViewQuestions_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewColumn currColumn = dataGridViewQuestions.Columns[e.ColumnIndex];
            DataGridViewRow currRow = dataGridViewQuestions.Rows[e.RowIndex];
            if (currColumn.HeaderText == "Ответ" && currRow.Cells[ColumnQuestionStatusId.Index].Value.ToString() != "1")
            {
                currRow.Cells[ColumnConsultantId.Index].Value = currUser.Id;
                currRow.Cells[ColumnConsultant.Index].Value = currUser.PersonSurname + " " + currUser.PersonName + " " + currUser.PersonPatronymic;

                Question questionF = unansweredQuestions.First(question => question.Id == Convert.ToInt32(currRow.Cells[ColumnId.Index].Value));
                questionF.Consultant = currUser;
                questionF.QStatus = 1;

                questionController.UpdateQuestion(questionF);

                dataGridViewQuestions.Refresh();
            }
        }

        private void dataGridViewQuestions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn currColumn = dataGridViewQuestions.Columns[e.ColumnIndex];
            DataGridViewRow currRow = dataGridViewQuestions.Rows[e.RowIndex];
            DataGridViewCell currCell = currRow.Cells[e.ColumnIndex];

            Question questionF;
            if (currColumn.HeaderText == "Статус")
            {
                switch (currCell.Value.ToString()) 
                {
                    case "Ожидает ответа":
                        questionF = unansweredQuestions.First(question => question.Id == Convert.ToInt32(currRow.Cells[ColumnId.Index].Value));
                        //   currRow.Cells[ColumnQuestionStatusId.Index].Value = questionF.QStatus = 0;
                        questionF.QStatus = 0;
                        questionF.Consultant = null;
                        currRow.Cells[ColumnConsultant.Index].Value = null;
                        questionController.UpdateQuestion(questionF);
                        unansweredQuestions = new BindingList<Question>(questionController.GetUnanswered(currUser.Id));
                        dataGridViewQuestions.Refresh();
                        break;
                    case "Отвечен":
                        questionF = unansweredQuestions.First(question => question.Id == Convert.ToInt32(currRow.Cells[ColumnId.Index].Value));
                        questionF.QStatus = 2;
                        questionF.PublishADate = DateTime.Now;
                        questionController.UpdateQuestion(questionF);
                        unansweredQuestions = new BindingList<Question>(questionController.GetUnanswered(currUser.Id));
                        dataGridViewQuestions.Refresh();

                        dataGridViewQuestions.Rows.Remove(currRow);

                        onlyAnswered = true;

                        consultantQuestions = new BindingList<Question>(questionController.GetQuestionsForConsultant(currUser));
                        dataGridViewConsultantQuestions.DataSource = null;
                        dataGridViewConsultantQuestions.DataSource = consultantQuestions;
                        break;
                }

            }
            else if (currColumn.HeaderText == "Тема")
            {
                questionF = unansweredQuestions.First(question => question.Id == Convert.ToInt32(currRow.Cells[ColumnId.Index].Value));
                questionF.Theme = themes.First(theme => theme.ThemeName == currCell.Value.ToString());
                questionController.UpdateQuestion(questionF);
                unansweredQuestions = new BindingList<Question>(questionController.GetUnanswered(currUser.Id));
                dataGridViewQuestions.Refresh();
            }
        }

        private void dataGridViewConsultantQuestions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(first == true)
                themes = new BindingList<QTheme>(qTHemeController.GetThemes());
            first = false; 
            if(onlyAnswered)
            {
                
                onlyAnswered = false;
            }
            consultantQuestions = new BindingList<Question>(questionController.GetQuestionsForConsultant(currUser));
            for (int i = 0; i < dataGridViewConsultantQuestions.Rows.Count; i++)
            {
                Person user = personController.GetUser(Convert.ToInt32(dataGridViewConsultantQuestions.Rows[i].Cells[InfoColumnUserId.Index].Value));
                dataGridViewConsultantQuestions.Rows[i].Cells[InfoColumnUser.Index].Value = user.PersonSurname + " " + user.PersonName + " " + user.PersonPatronymic;
                dataGridViewConsultantQuestions.Rows[i].Cells[InfoColumnTheme.Index].Value = themes.First(theme => theme.Id == Convert.ToInt32(dataGridViewConsultantQuestions.Rows[i].Cells[InfoColumnThemeId.Index].Value)).ThemeName;
            }

        }


        private void dataGridViewConsultantQuestions_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow currRow = e.Row;
            Question questionF = consultantQuestions.First(question => question.Id == Convert.ToInt32(currRow.Cells[InfoColumnId.Index].Value));
            consultantQuestions.Remove(questionF);
            questionController.RemoveQuestion(questionF.Id);

            dataGridViewConsultantQuestions.Refresh();
            first = true;
        }

        private void dataGridViewQuestions_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow currRow = e.Row;
            Question questionF = unansweredQuestions.First(question => question.Id == Convert.ToInt32(currRow.Cells[ColumnId.Index].Value));
            unansweredQuestions.Remove(questionF);
            questionController.RemoveQuestion(questionF.Id);

            //   consultantQuestions.Add(questionF);
            // consultantQuestions = new BindingList<Question>(questionController.GetQuestionsForConsultant(currUser));
            // dataGridViewQuestions.Refresh();
            onlyAnswered = true;
        }

        private void buttonAddToSC_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(textBoxQuestionId.Text))
            {
                try
                {
                    Question question = questionController.GetQuestion(Convert.ToInt32(textBoxQuestionId.Text));
                    if (question != null)
                    {
                        UserInfoWIndow userInfoWIndow = new UserInfoWIndow(question.User.Id);
                        userInfoWIndow.Show();
                    }
                    else
                    {
                        ErrorWindow errorWindow = new ErrorWindow("Вопроса с таким id не существует ");
                        errorWindow.Show();
                    }
                }
                catch
                {
                    ErrorWindow errorWindow = new ErrorWindow("Некорректный id ");
                    errorWindow.Show();
                }
            }
            else
            {
                ErrorWindow errorWindow = new ErrorWindow("Вы не ввели значение Id вопроса");
                errorWindow.Show();
            } 
        }

        private void dataGridViewQThemes_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            QTheme qTheme = themes.First(theme => theme.Id == Convert.ToInt32(e.Row.Cells[ColumnQThemeId.Index].EditedFormattedValue));
            if (questionController.GetByTheme(qTheme).Count > 0)
            {
                ErrorWindow window = new ErrorWindow("Вы не можете удалить данную тему: есть вопросы, относящиеся к ней");
                e.Cancel = true;
                window.Show();
            }
            else qTHemeController.RemoveTheme(qTheme.Id);


        }

        private void dataGridViewQThemes_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            newRows.Add(e.Row);

        }

        private void dataGridViewQThemes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn currentColumn = dataGridViewQThemes.Columns[e.ColumnIndex];
            DataGridViewRow currentRow = dataGridViewQThemes.Rows[e.RowIndex];
            DataGridViewCell currentCell = currentRow.Cells[e.ColumnIndex];

            QTheme theme = themes.FirstOrDefault(qtheme => Convert.ToInt32(currentRow.Cells[ColumnQThemeId.Index].EditedFormattedValue) > 0 && qtheme.Id == Convert.ToInt32(currentRow.Cells[ColumnQThemeId.Index].EditedFormattedValue));
            if (theme != null)
            {
                if (currentColumn.HeaderText == "Название темы")
                {
                    theme.ThemeName = currentCell.EditedFormattedValue.ToString();
                    qTHemeController.UpdateTheme(theme);
                    dataGridViewQThemes.Refresh();
                }
                else if (currentColumn.HeaderText == "Описание темы")
                {
                    theme.ThemeDescription = currentCell.EditedFormattedValue.ToString() ?? "";
                    qTHemeController.UpdateTheme(theme);
                    dataGridViewQThemes.Refresh();
                }
            }
        }

        private void dataGridViewQThemes_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewColumn currentColumn = dataGridViewQThemes.Columns[e.ColumnIndex];
            DataGridViewRow currentRow = dataGridViewQThemes.Rows[e.RowIndex];
            DataGridViewCell currentCell = currentRow.Cells[e.ColumnIndex];

            if (currentColumn.HeaderText == "Название темы")
            {
                string name = currentCell.EditedFormattedValue.ToString();
                if (!validator.IsCorrectName(name))
                {
                    e.Cancel = true;
                    dataGridViewQThemes.Rows[e.RowIndex].ErrorText = "Некорректное или уже существующее в системе имя";
                }
            }

        }

        private void dataGridViewQThemes_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewQThemes.Rows[e.RowIndex].ErrorText = null;
        }

        private void dataGridViewQThemes_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewQThemes.Rows[e.RowIndex].ErrorText = null;
            if(dataGridViewQThemes.Rows[e.RowIndex].Cells[ColumnQThemeId.Index].EditedFormattedValue == null || Convert.ToInt32(dataGridViewQThemes.Rows[e.RowIndex].Cells[ColumnQThemeId.Index].EditedFormattedValue) < 1)
            {
                QTheme theme = new QTheme();
                theme.ThemeName = dataGridViewQThemes.Rows[e.RowIndex].Cells[ColumnThemeName.Index].EditedFormattedValue.ToString();
                object value = dataGridViewQThemes.Rows[e.RowIndex].Cells[ColumnThemeDesc.Index].EditedFormattedValue;
                if (value == null)
                    theme.ThemeDescription = "";
                else theme.ThemeDescription = value.ToString();

                qTHemeController.AddQTheme(theme);

                themes = new BindingList<QTheme>(qTHemeController.GetThemes());

                dataGridViewQThemes.Rows[e.RowIndex].Cells[ColumnQThemeId.Index].Value = themes[themes.Count - 1].Id;
                dataGridViewQThemes.Refresh();

                newRows.Remove(dataGridViewQThemes.Rows[e.RowIndex]);

            }
        }

        private void dataGridViewQThemes_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            QTheme qtheme;
            string name = dataGridViewQThemes.Rows[e.RowIndex].Cells[ColumnThemeName.Index].EditedFormattedValue.ToString();
            if(Convert.ToInt32(dataGridViewQThemes.Rows[e.RowIndex].Cells[ColumnQThemeId.Index].EditedFormattedValue) > 0)
             qtheme = themes.First(theme => theme.Id == Convert.ToInt32(dataGridViewQThemes.Rows[e.RowIndex].Cells[ColumnQThemeId.Index].EditedFormattedValue));
            else qtheme = null;
            if (!validator.IsCorrectName(name) || qtheme != null && Convert.ToInt32(dataGridViewQThemes.Rows[e.RowIndex].Cells[ColumnQThemeId.Index].EditedFormattedValue) != qtheme.Id)
            {
                e.Cancel = true;
                dataGridViewQThemes.Rows[e.RowIndex].ErrorText = "Некорректное или уже существующее в системе имя";
            }
        }

        private void dataGridViewQThemes_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            dataGridViewQThemes.Refresh();
        }
    }
}
