using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;
using YellEat.Utility;

namespace YellEat.ShopAdmin
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_OnClick(object sender, EventArgs e)
        {
            var shop = new Ye_Shop()
            {
                ShopAccount = tbxUserName.Text.Trim(),
                ShopPassword = DESUtil.Encrypt(tbxUserPwd.Text.Trim()),
                RegisterTime = DateTime.Now,
                LastLoginTime = DateTime.Now,
                ShopName = tbxShopName.Text,
                ShopAddress = tbxAddr.Text,
                ShopMobile = tbxShopMobile.Text,
                ShopEmail = tbxShopEmail.Text,
                ShopFax = tbxShopFax.Text,
                ShopZip = tbxShopZip.Text,
                ShopDesc = "",
                ShopLogoImg = "",
                ShopMainImg = "",
                ShopQQ = "",
                ShopQRCodeImg = "",
                Longitude = 0,
                Latitude = 0,
                DeliveryTime = "",
                DeliveryMinPrice = 0,
                RecommendLevel = 0,
                IsChecked = false,
                OpeningBeginMinute = 0,
                OpeningEndMinute = 0,
                Rank = 3,
                Clicks = 0,                
            };
            if (ShopBll.AddShop(shop))
            {
                WebUtil.AlertAndRedirect("您的餐馆已成功注册，请耐心等待审核！", "Login.aspx");
            }
            else
            {
                WebUtil.Alert("餐馆注册失败！");
            }
        }
    }
}