using Store.Controllers;
using Store.DataBase.Entities;
using Store.Validators;
using Store.Windows;
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

namespace Store
{
    public partial class LoginForm : Form
    {
        private PersonController personController;
        private InputValidator inputValidator;

        public LoginForm()
        {
            InitializeComponent();
            personController = new PersonController();
            inputValidator = new InputValidator();

            textBoxEmail.MaxLength = 255;
            textBoxPassword.PasswordChar = '*';

            Bitmap sizedImage = new Bitmap(pictureBoxAlert.Image, new Size(pictureBoxAlert.Width, pictureBoxAlert.Height));
            pictureBoxAlert.Image = sizedImage;
            sizedImage = new Bitmap(pictureBoxIcon.Image, new Size(pictureBoxIcon.Width, pictureBoxIcon.Height));
            pictureBoxIcon.Image = sizedImage;
            pictureBoxAlert.Hide();
            labelLoginFailed.Hide();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
            this.Hide();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Person user = personController.FindPersonByEmail(textBoxEmail.Text);
            if (user != null && personController.IsPasswordVerified(textBoxPassword.Text, user.UserPassword)) {
                if(user.Role.RoleName == "ROLE_ADMIN")
                {
                    GoodInfoWindow goodInfoWindow = new GoodInfoWindow(user.Email);
                    goodInfoWindow.Show();
                    //Test_Window test_Window = new Test_Window();
                    //test_Window.Show();
                    this.Hide();
                }
                else if(user.Role.RoleName == "ROLE_КУРЬЕР")
                {
                    CourierWindow courierWindow = new CourierWindow(user.Email);
                    courierWindow.Show();
                    this.Hide();
                }
                else if(user.Role.RoleName == "ROLE_USER")
                {
                    MainWindow mainWindow = new MainWindow(user.Email);
                    mainWindow.Show();
                    this.Hide();
                }
                else if(user.Role.RoleName == "ROLE_КОНСУЛЬТАНТ")
                {
                    ConsultantWindow mainWindow = new ConsultantWindow(user.Email);
                    mainWindow.Show();
                    this.Hide();
                }
                else if (user.Role.RoleName == "ROLE_КАДРОВИК")
                {
                    HRWindow hrWindow = new HRWindow(user.Email);
                    hrWindow.Show();
                    this.Hide();
                }
                pictureBoxAlert.Hide();
                labelLoginFailed.Hide();
                
            }
            else
            {
                pictureBoxAlert.Show();
                labelLoginFailed.Show();
            }
        }

        private void textBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!inputValidator.isEmailSymbols(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar != (char)Keys.Space || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }
    }
}
