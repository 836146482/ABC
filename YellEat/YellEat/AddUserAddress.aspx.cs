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
    public partial class AddUserAddress : UserPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            var addrs = UserBll.GetUserAddressesByUserId(YeUser.UserID);
            if (addrs.Count==3)
            {
                WebUtil.Alert("You have got 3 Addresses!It\\'s Limited.",this);
                return;
            }
            if (UserBll.AddUserAddress(new Ye_UserAddress()
            {
                UserID = YeUser.UserID,
                Address = tbxAddress.Text,
                Zip = "",
                AptSuite = "",
                Receiver = tbxReceiver.Text,
                Mobile = tbxMobile.Text,
                IsDefault = addrs.Count==0
            }))
            {
                WebUtil.AlertAndRedirect("Success", "UserAddressList.aspx");
            }
            else
            {
                WebUtil.AlertAndRedirect("Sorry,something wrong happens.", "UserAddressList.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserAddressList.aspx");
        }
    }
}