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
    public partial class SuccessWindow : Form
    {
        public SuccessWindow(string message)
        {
            InitializeComponent();
            labelErrorText.Text = message;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
