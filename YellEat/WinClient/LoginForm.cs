using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinClient.YellEatClient;


namespace WinClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Program.Client = new YellEatServiceClient();            
            if (Program.Client.Login(tbxUserName.Text,tbxPassword.Text))
            {               
                this.Hide();
                var result = new OrderNotifyForm().ShowDialog(this);
                if (result!= DialogResult.No)
                {
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("用户名或密码不正确！");
            }
        }
    }
}
