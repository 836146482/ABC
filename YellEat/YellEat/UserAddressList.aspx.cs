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
    public partial class UserAddressList :UserPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        //protected void btnAdd_OnClick(object sender, EventArgs e)
        //{
        //    Response.Redirect("AddUserAddress.aspx");
        //    //var addrs = UserBll.GetUserAddressesByUserId(YeUser.UserID);
        //    //if (addrs.Count==3)
        //    //{
        //    //    WebUtil.Alert("You have got 3 Addresses!It's Limited.",this);
        //    //    return;
        //    //}
        //    //if (UserBll.AddUserAddress(new Ye_UserAddress()
        //    //{
        //    //    UserID = YeUser.UserID,
        //    //    Address = tbxAddress.Text,
        //    //    Zip = "",
        //    //    AptSuite = "",
        //    //    Receiver = tbxReceiver.Text,
        //    //    Mobile = tbxMobile.Text,
        //    //    IsDefault = addrs.Count==0
        //    //}))
        //    //{
        //    //    BindData();
        //    //}
        //    //else
        //    //{
        //    //    WebUtil.Alert("Sorry,something wrong happens.", this);
        //    //}
        //}

        private void BindData()
        {
            rpt.DataSource = UserBll.GetUserAddressesByUserId(YeUser.UserID);
            rpt.DataBind();
        }

       
        //protected void btnUpdate_OnClick(object sender, EventArgs e)
        //{
        //    //if (UserBll.UpdateUserAddress(new Ye_UserAddress()
        //    //{
        //    //    UserAddressID = Convert.ToInt32(hfUpdateID.Value),
        //    //    UserID = YeUser.UserID,
        //    //    Address = tbxUpdateAddress.Text,
        //    //    Mobile = tbxUpdteMobile.Text,
        //    //    IsDefault = true,
        //    //    Receiver = tbxUpdateReceiver.Text
        //    //}))
        //    //{
        //    //    BindData();
        //    //}
        //    //else
        //    //{
        //    //    WebUtil.Alert("信息修改失败！",this.Page);
        //    //}
        //}
    }
}