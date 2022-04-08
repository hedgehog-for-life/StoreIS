using Store.Controllers;
using Store.DataBase.Entities;
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
    public partial class UserInfoWIndow : Form
    {
        private PersonController personController;

        public UserInfoWIndow(int userId)
        {
            InitializeComponent();
            personController = new PersonController();

            SetData(personController.GetUser(userId));
        }

        private void SetData(Person user)
        {
            labelUserName.Text = user.PersonSurname + " " + user.PersonName + " " + user.PersonPatronymic;
            labelDateBirth.Text = user.BirthDate.ToShortDateString();
            labelPhone.Text = "+7" + user.Phone;
            labelEmail.Text = user.Email;
        }

        private void buttonAddToSC_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
