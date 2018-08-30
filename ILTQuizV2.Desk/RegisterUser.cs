using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ILTQuizV2.Desk
{
    public partial class RegisterUser : Form
    {
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void LblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PnlLogin.Visible = false;
            PnlRegister.Visible = true;
            LblRegister.Visible = false;
            LblLogar.Visible = true;
        }

        private void LblLogar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PnlRegister.Visible = false;
            PnlLogin.Visible = true;
            LblRegister.Visible = true;
            LblLogar.Visible = false;
        }
    }
}
