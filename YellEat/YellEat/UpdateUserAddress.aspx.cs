using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.Utility;
using YellEat.BLL;
using YellEat.Model;

namespace YellEat
{
    public partial class UpdateUserAddress : UserPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.Form["hdUpdateId"]) || Request.Form["hdUpdateId"]=="0")
                {
                    WebUtil.AlertAndRedirect("页面过期失效", "UserAddressList.aspx");
                    return;
                }
                int addressId=0;
                int.TryParse(Request.Form["hdUpdateId"], out addressId);
                Ye_UserAddress address= UserBll.GetUserAddressById(addressId);
                if (address==null)
                {
                    WebUtil.AlertAndRedirect("该地址不存在", "UserAddressList.aspx");
                    return;
                }
                tbxUpdateReceiver.Text = address.Receiver;
                tbxUpdteMobile.Text = address.Mobile;
                tbxUpdateAddress.Text = address.Address;
                hfAddressId.Value = addressId.ToString();
            }
            
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserAddressList.aspx");
        }

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            if (UserBll.UpdateUserAddress(new Ye_UserAddress()
            {
                UserAddressID = Convert.ToInt32(hfAddressId.Value),
                UserID = YeUser.UserID,
                Address = tbxUpdateAddress.Text,
                Mobile = tbxUpdteMobile.Text,
                IsDefault = true,
                Receiver = tbxUpdateReceiver.Text
            }))
            {
                WebUtil.AlertAndRedirect("信息修改成功", "UserAddressList.aspx");
            }
            else
            {
                WebUtil.AlertAndRedirect("信息修改失败", "UserAddressList.aspx");
            }
        }
    }
}