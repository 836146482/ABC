using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Utility;

namespace YellEat.ShopAdmin
{
    public partial class Login : System.Web.UI.Page
    {
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
            var shop = ShopBll.Login(tbxAccount.Text.Trim(), DESUtil.Encrypt(tbxPassword.Text));
            if (shop != null)
            {
                Session["YeShopId"] = shop.ShopID;
                Cache["Ye_Shop"] = shop;
                Response.Redirect("Default.aspx", true);
            }
            else
            {
                WebUtil.AlertAndRedirect("用户名或密码不正确！", "Login.aspx");
            }
        }
    }
}