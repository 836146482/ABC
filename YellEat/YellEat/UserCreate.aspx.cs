using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;
using YellEat.Utility;

namespace YellEat
{
    public partial class UserCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void btnSendSMS_OnClick(object sender, EventArgs e)
        //{
           
        //}
        protected void btnRegister_OnClick(object sender, EventArgs e)
        {
            var user = new Ye_User()
            {
                Address = tbxAddress.Text.Trim(),
                UserName = tbxName.Text.Trim(),
                Zip =  tbxZip.Text.Trim(),
                AptSuite = tbxAptSuite.Text.Trim(),
                Mobile = tbxPhone.Text.Trim(),
                Password = DESUtil.Encrypt(tbxPassword.Text.Trim()),
                Email = tbxEmail.Text.Trim(),
                FaceBookID = "",
                QQ = "",
                WxID = "",
                Status = 0,  
                LastLoginTime = DateTime.Now,
                RegisterTime = DateTime.Now
            };
            if (UserBll.GetUsers().SingleOrDefault(u => u.UserName == user.UserName) != null)
            {
                WebUtil.Alert("The username is used,please change a new username.");//当前用户已经存在！请使用其他用户名注册！
                return;
            }
            if (UserBll.AddUser(user))
            {
                Session["YeUser"] = UserBll.Login(user.UserName, user.Password);
                if (Request.Cookies["location"] == null)
                {
                    var cookie = new HttpCookie("location", user.Address);
                    cookie.Expires = DateTime.MaxValue;
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    Response.Cookies["location"].Value = user.Address;
                }
                if (Request.Cookies["username"] == null)
                {
                    var cookie = new HttpCookie("username", user.UserName);
                    cookie.Expires = DateTime.MaxValue;
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    Request.Cookies["username"].Value = user.UserName;
                }
                WebUtil.AlertAndRedirect("Register successfully","Home.aspx");
            }
            else
            {
                WebUtil.Alert("Failed to register.");
            }
        }


        protected void btnFacebook_OnClick(object sender, EventArgs e)
        {
            
        }
    }
}