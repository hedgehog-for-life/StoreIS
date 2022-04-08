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
    public partial class JobAppWindow : Form
    {
        private Person user;

        private PersonController personController;
        private EmploymentAppController employmentAppController;

        private stuff_shopContext db;

        private EmploymentApp newEmpApp;
        private EmploymentApp employmentApp;

        private StringValidator validator;
        private InputValidator iValidator;
        private DateTimeValidator dtValidator;
        private DigitClassesValidator dValidator;

        public JobAppWindow(string userEmail)
        {
            InitializeComponent();
            db = new stuff_shopContext();

            personController = new PersonController();
            user = personController.FindPersonByEmail(userEmail);
            employmentAppController = new EmploymentAppController(db);

            labelApplicationChosenResumeTExt.Text = "";

            validator = new StringValidator();
            dtValidator = new DateTimeValidator();
            iValidator = new InputValidator();
            dValidator = new DigitClassesValidator();

            saveResumeFileDialog.DefaultExt = "pdf";
            saveResumeFileDialog.Filter = "Resume pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveResumeFileDialog.FilterIndex = 2;
            saveResumeFileDialog.FileName = "resume.pdf";
            saveResumeFileDialog.CheckFileExists = false;
            saveResumeFileDialog.CheckPathExists = true;
            saveResumeFileDialog.RestoreDirectory = true;
            saveResumeFileDialog.InitialDirectory = @"C:\\";

            textBoxSeniority.Text = "0";

            employmentApp = employmentAppController.GetEmploymentApp(user);
            if (employmentApp != null)
            {
                panelCurrentApplication.Visible = true;
                panelNewApplication.Visible = false;

                switch (employmentApp.AppStatus) 
                {
                    case 0:
                        labelHasAppStatus.Text = "Ожидает рассмотрения";
                        break;
                    case 1:
                        labelHasAppStatus.Text = "Находится на рассмотрении";
                        break;
                    case 2:
                        labelHasAppStatus.Text = "Одобрена";
                        break;
                    case 3:
                        labelHasAppStatus.Text = "Отклонена";
                        break;
                }
                labelHasAppFIO.Text = user.PersonSurname + " " + user.PersonName + " " + user.PersonPatronymic;
                labelHasAppDB.Text = user.BirthDate.ToShortDateString();
                labelHasAppPhone.Text = "+7" + employmentApp.ContactNumber;
                labelHasAppEmail.Text = employmentApp.ContactEmail;

                labelHasAppSeniority.Text = employmentApp.Seniority.ToString();
                labelHasAppFile.Text = "Save File";

                labelHasAppSeniority.Text = employmentApp.Seniority.ToString();
            }
            else
            {
                panelCurrentApplication.Visible = false;
                panelNewApplication.Visible = true;

                textBoxApplicantName.Text = user.PersonSurname + " " + user.PersonName + " " + user.PersonPatronymic;
                dateTimePickerApplicantDB.Text = user.BirthDate.ToShortDateString();
                textBoxApplicantPhone.Text = user.Phone;
                textBoxApplicationEmail.Text = user.Email;

                newEmpApp = new EmploymentApp();
                newEmpApp.Applicant = user;
                newEmpApp.ContactNumber = user.Phone;
                newEmpApp.ContactEmail = user.Email;

            }

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

        private void buttonChooseResumeFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Выберете файл резюме";
                dlg.Filter = "pdf files (*.pdf)|*.pdf";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    byte[] resumeFilePDF = System.IO.File.ReadAllBytes(dlg.FileName);

                    newEmpApp.Resume = resumeFilePDF;
                    labelApplicationChosenResumeTExt.Text = dlg.FileName;
                }
            }
        }

        private void labelApplicationChosenResumeTExt_Click(object sender, EventArgs e)
        {
            saveResumeFileDialog.FileName = labelApplicationChosenResumeTExt.Text;

            if (saveResumeFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveResumeFileDialog.FileName, newEmpApp.Resume);
            }
        }

        private void textBoxApplicantPhone_Validated(object sender, EventArgs e)
        {
            buttonSendApp.Enabled = true;

            errorProvider1.SetError(textBoxApplicantPhone, "");
        }

        private void textBoxApplicantPhone_Validating(object sender, CancelEventArgs e)
        {
            if (!validator.IsPhoneNumber(textBoxApplicantPhone.Text))
            {
                e.Cancel = true;
                textBoxApplicantPhone.Select(0, textBoxApplicantPhone.Text.Length);

                buttonSendApp.Enabled = false;

                this.errorProvider1.SetError(textBoxApplicantPhone, "Некорректный номер телефона.");
            }
        }

        private void textBoxApplicationEmail_Validated(object sender, EventArgs e)
        {
            buttonSendApp.Enabled = true;

            errorProvider1.SetError(textBoxApplicationEmail, "");
        }

        private void textBoxApplicationEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!validator.IsCorrectEmail(textBoxApplicationEmail.Text))
            {
                e.Cancel = true;
                textBoxApplicationEmail.Select(0, textBoxApplicationEmail.Text.Length);

                buttonSendApp.Enabled = false;

                this.errorProvider1.SetError(textBoxApplicationEmail, "Некорректный email.");
            }
        }
        

        private void textBoxSeniority_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!iValidator.IsDigitOrControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxApplicationEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!iValidator.isEmailSymbols(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxApplicantPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!iValidator.IsDigitOrControl(e.KeyChar))
                e.Handled = true;
        }

        private void buttonSendApp_Click(object sender, EventArgs e)
        {
            newEmpApp.Seniority = Convert.ToInt32(textBoxSeniority.Text);
            newEmpApp.AppStatus = 0;
            newEmpApp.ContactEmail = textBoxApplicationEmail.Text;
            newEmpApp.ContactNumber = textBoxApplicantPhone.Text;

            if (newEmpApp.Resume == null)
            {
                ErrorWindow errorWindow = new ErrorWindow("Вы обязаны загрузить файл с резюме");
                errorWindow.Show();
            }
            else
            {
                employmentAppController.AddEmploymentApp(newEmpApp);

                panelNewApplication.Visible = false;
                panelCurrentApplication.Visible = true;

                labelHasAppFIO.Text = user.PersonSurname + " " + user.PersonName + " " + user.PersonPatronymic;
                labelHasAppDB.Text = user.BirthDate.ToShortDateString();
                labelHasAppPhone.Text = "+7" + newEmpApp.ContactNumber;
                labelHasAppEmail.Text = newEmpApp.ContactEmail;

                labelHasAppSeniority.Text = newEmpApp.Seniority.ToString();
                labelHasAppFile.Text = "Save File";
            }

        }

        private void textBoxSeniority_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxSeniority.Text == "")
            {
                e.Cancel = true;
                textBoxSeniority.Select(0, textBoxSeniority.Text.Length);

                buttonSendApp.Enabled = false;

                this.errorProvider1.SetError(textBoxSeniority, "Поле должно быть заполнено.");
            }
        }

        private void textBoxSeniority_Validated(object sender, EventArgs e)
        {
            buttonSendApp.Enabled = true;

            errorProvider1.SetError(textBoxSeniority, "");
        }

        private void labelHasAppFile_Click(object sender, EventArgs e)
        {
            saveResumeFileDialog.FileName = labelApplicationChosenResumeTExt.Text;

            if (saveResumeFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveResumeFileDialog.FileName, employmentApp.Resume);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShoppingCartWindow shoppingCartWindow = new ShoppingCartWindow(user.Email);
            shoppingCartWindow.Show();
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

        private void buttonQuestion_Click(object sender, EventArgs e)
        {
            QuestionWindow window = new QuestionWindow(user.Email);
            window.Show();
            this.Hide();
        }
    }
}
