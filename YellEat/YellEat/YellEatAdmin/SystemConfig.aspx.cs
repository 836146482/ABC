using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Win32;
using YellEat.Model;

namespace YellEat.YellEatAdmin
{
    public partial class SystemConfig : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPower(AdminPower.系统管理);
                var sysconfig = SysConfig.Instance;
                tbxEmail.Text = sysconfig.Email;
                tbxEmailAccount.Text = sysconfig.EmailAccount;
                tbxEmailHost.Text = sysconfig.EmailHost;
                tbxSMSAddress.Text = sysconfig.SMSAddress;
                tbxPassword.Text = sysconfig.EmailPassword;
            }
        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            var sysconfig = SysConfig.Instance;
            sysconfig.Email = tbxEmail.Text;
            sysconfig.EmailAccount = tbxEmailAccount.Text;
            sysconfig.EmailHost = tbxEmailHost.Text;
            sysconfig.EmailPassword = tbxPassword.Text;
            sysconfig.SMSAddress = tbxSMSAddress.Text;
            sysconfig.SaveToFile();
        }
    }
}