using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;
using YellEat.Utility;

namespace YellEat.YellEatAdmin
{
    public partial class Login : System.Web.UI.Page
    {
        protected string timeTemp = DateTime.Now.ToString("yyyyMMddhhmmss");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxAccount.Text))
            {
                WebUtil.Alert("用户名不能为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbxPassword.Text))
            {
                WebUtil.Alert("密码不能为空！");
                return;
            }
            var admin = AdministratorBll.Login(tbxAccount.Text.Trim(), DESUtil.Encrypt(tbxPassword.Text));
            if (admin != null)
            {
                AdministratorBll.AddAdminLog(new Ye_AdminLog()
                {
                    AdminID = admin.AdministratorID,
                    LogTypeName = LogType.登录系统.ToString(),
                    CreateTime = DateTime.Now
                });
                Session["YeAdministratorId"] = admin.AdministratorID;
                Cache["YeAdministrator"] = admin;
                Response.Redirect("~/YellEatAdmin/Default.aspx", true);
            }
            else
            {
                WebUtil.AlertAndRedirect("用户名或密码不正确！", "Login.aspx");
            }
        }
    }
}