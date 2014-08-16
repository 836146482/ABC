using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinClient
{
    public partial class OrderNotifyForm : Form
    {
        public OrderNotifyForm()
        {
            InitializeComponent();
        }

        private void OrderNotifyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("您确定要退出程序吗？")==DialogResult.OK)
            {
                
            }
            ;
        }
    }
}
