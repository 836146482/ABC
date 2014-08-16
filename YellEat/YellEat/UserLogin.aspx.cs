using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;
using YellEat.Utility;

namespace YellEat
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }
         protected void btnSendEmail_OnClick(object sender, EventArgs e)
        {
            try
            {
                var user = UserBll.GetPasswordByEmail(tbxEmail.Text.Trim());
                if (user == null)
                {            
                    WebUtil.Alert("Email doesn't exist.");
                    return;
                }            
                var host = SysConfig.Instance.EmailHost;
                var emailPassword = DESUtil.Decrypt(SysConfig.Instance.EmailPassword);
                var email = SysConfig.Instance.Email;
                var client = new SmtpClient(host);
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(email, emailPassword);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                var addressFrom = new MailAddress(email, "");
                var addressTo = new MailAddress(tbxEmail.Text.Trim(), "Get Password" );
                var message = new MailMessage(addressFrom, addressTo);
                message.Subject = "Get Password";
                message.Body = "Dear Sir or Madam,it's from Yelleat.Your password is '" + DESUtil.Decrypt(user.Password)+"' .Keep it please.";
                message.Sender = new MailAddress(email);
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                client.Send(message);
                WebUtil.Alert("Email is sent Successfully.");
            }
            catch 
            {
                WebUtil.Alert("Email is sent failed", this.Page);
            }
        }
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            var user = UserBll.Login(tbxUserName.Text.Trim(), DESUtil.Encrypt(tbxPwd.Text.Trim()));
            if (user == null)
            {
                WebUtil.Alert("Email,mobile or password is incorrect!");
            }
            else
            {
                UserBll.UpdateUserLastLoginTime(user.UserID);
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
                    Response.Cookies["username"].Value = user.UserName;
                }
                Session["YeUser"] = user;
                Response.Redirect("Home.aspx");//登录后跳转
            }
        }
   
    }
}