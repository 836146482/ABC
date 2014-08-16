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
    public partial class UserRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
  
        protected void imgBtn_OnClick(object sender, ImageClickEventArgs e)
        {
            var user = new Ye_User()
            {
                Address = tbxAddress.Text.Trim(),
                UserName = tbxFirstName.Text.Trim() + " " + tbxLastName.Text.Trim(),
                //Zip =  tbxZip.Text.Trim(),
                //Aptsuite = tbxAptSuite.Text.Trim(),
                Mobile = tbxMobile.Text.Trim(),
                Password = DESUtil.Encrypt(tbxPwd1.Text.Trim()),
                Email = tbxEmail.Text.Trim(),
                FaceBookID = "",
                QQ = "",
                WxID = "",
                Status = 0,
                Zip = "",
                AptSuite = "",
                LastLoginTime = DateTime.Now,
                RegisterTime = DateTime.Now
            };
            if (UserBll.GetUsers().SingleOrDefault(u=>u.UserName==user.UserName)!=null)
            {
                WebUtil.Alert("当前用户已经存在！请使用其他用户名注册！");
                return;
            }            
            if (UserBll.AddUser(user))
            {
                Session["YeUser"] = UserBll.Login(user.UserName, user.Password);
                Response.Redirect("Home.aspx");                
            }
            else
            {
                WebUtil.Alert("注册失败！");
            }
        }

        //protected void btnSendCode_OnClick(object sender, EventArgs e)
        //{
        //    //TODO:发送短信
        //}
    }
}