using Store.Controllers;
using Store.DataBase.Entities;
using Store.Validators;
using Store.Windows.ForAdmin;
using Store.Windows.ForConsultant;
using Store.Windows.ForCourier;
using Store.Windows.ForHR;
using Store.Windows.ForUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.Windows
{
    public partial class RegistrationForm : Form
    {
        private UserRoleController roleController;
        private PersonController personController;
        private InputValidator inputValidator;
        private int[] rolesIndexes;

        public RegistrationForm()
        {
            InitializeComponent();
            roleController = new UserRoleController();
            personController = new PersonController();
            inputValidator = new InputValidator();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker1.Value = dateTimePicker1.MaxDate;

            labelCode.Hide();
            textBoxCode.Hide();

            List<UserRole> roles = roleController.GetRoles();
            rolesIndexes = new int[roles.Count()];
            for (int i = 0; i < roles.Count(); i++)
            {
                comboBoxRoles.Items.Add(roles[i].RoleName.Substring(5));
                rolesIndexes[i] = roles[i].Id;
            }
            comboBoxRoles.SelectedItem = "USER";

            textBoxEmail.MaxLength = 255;
            textBoxSurname.MaxLength = textBoxName.MaxLength = textBoxPatronymic.MaxLength = 50;
            textBoxNumber.MaxLength = 10;

            textBoxPassword.PasswordChar = '*';

            Bitmap sizedImage = new Bitmap(pictureBoxAlert.Image, new Size(pictureBoxAlert.Width,pictureBoxAlert.Height));
            pictureBoxAlert.Image = sizedImage;
            sizedImage = new Bitmap(pictureBoxIcon.Image, new Size(pictureBoxIcon.Width, pictureBoxIcon.Height));
            pictureBoxIcon.Image = sizedImage;
            pictureBoxAlert.Hide();
            labelSignUpFailed.Hide();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        // Регистрация пользователя
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            if (personController.FindPersonByEmail(email) == null)
            {
                if (!personController.NewUser(email, textBoxPassword.Text, textBoxSurname.Text, textBoxName.Text,
                    textBoxPatronymic.Text, dateTimePicker1.Value, textBoxNumber.Text,
                    rolesIndexes[comboBoxRoles.SelectedIndex], textBoxCode.Text))
                {
                    labelSignUpFailed.Text = "Ошибка регистрации.\nПожалуйста, перепроверьте введенные данные";
                    labelSignUpFailed.Show();
                    pictureBoxAlert.Show();
                }
                else
                {
                    if (comboBoxRoles.SelectedItem.ToString() == "ADMIN")
                    {
                        GoodInfoWindow goodInfoWindow = new GoodInfoWindow(email);
                        goodInfoWindow.Show();
                        this.Hide();
                    }
                    else if (comboBoxRoles.SelectedItem.ToString() == "КУРЬЕР")
                    {
                        CourierWindow courierWindow = new CourierWindow(email);
                        courierWindow.Show();
                        this.Hide();
                    }
                    else if (comboBoxRoles.SelectedItem.ToString() == "USER")
                    {
                        MainWindow mainWindow = new MainWindow(email);
                        mainWindow.Show();
                        this.Hide();
                    }
                    else if (comboBoxRoles.SelectedItem.ToString() == "КОНСУЛЬТАНТ")
                    {
                        ConsultantWindow mainWindow = new ConsultantWindow(email);
                        mainWindow.Show();
                        this.Hide();
                    }
                    else if (comboBoxRoles.SelectedItem.ToString() == "КАДРОВИК")
                    {
                        HRWindow hrWindow = new HRWindow(email);
                        hrWindow.Show();
                        this.Hide();
                    }

                    SuccessWindow successWindow = new SuccessWindow("Добро пожаловать в магазин товаров, " + textBoxName.Text + "!\nВаша регистрация прошла успешно");
                    successWindow.Show();
                    this.Hide();
                    labelSignUpFailed.Hide();
                    pictureBoxAlert.Hide();
                }
            }
            else
            {
                labelSignUpFailed.Text = "Пользователь с таким email уже сушествует.";
                labelSignUpFailed.Show();
                pictureBoxAlert.Show();
            }
        }

        private void comboBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRoles.SelectedItem.ToString() != "USER")
            {
                labelCode.Show();
                textBoxCode.Show();
            }
            else
            {
                labelCode.Hide();
                textBoxCode.Hide();
            }

        }

        private void textBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!inputValidator.IsDigitOrControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!inputValidator.isEmailSymbols(e.KeyChar)) 
                e.Handled = true;
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar != (char)Keys.Space || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBoxSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!inputValidator.isLetterOrControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!inputValidator.isLetterOrControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxPatronymic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!inputValidator.isLetterOrControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar != (char)Keys.Space || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }
    }
}
