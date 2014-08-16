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
    public partial class UpdateShopInfo : ShopAdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbxShopName.Text = YeShop.ShopName;
                tbxShopDesc.Text = YeShop.ShopDesc;
                tbxLatitude.Text = YeShop.Latitude.ToString();
                tbxLongitude.Text = YeShop.Longitude.ToString();
                tbxShopAdderss.Text = YeShop.ShopAddress;
                tbxShopEmail.Text = YeShop.ShopEmail;
                tbxShopFax.Text = YeShop.ShopFax;
                tbxShopMobile.Text = YeShop.ShopMobile;
                tbxShopQQ.Text = YeShop.ShopQQ;
                tbxShopZip.Text = YeShop.ShopZip;
                ddlDeliveryTime.DataSource = new[] { new { key = 0, value = "平均送达时间 30 min" }, new { key = 1, value = "平均送达时间 45 min" }, new { key = 2, value = "平均送达时间 60 min" } };
                ddlDeliveryTime.DataTextField = "value";
                ddlDeliveryTime.DataValueField = "key";
                ddlDeliveryTime.DataBind();
                ddlDeliveryTime.Items.FindByText(YeShop.DeliveryTime).Selected = true;
                tbxStartHour.Text = (YeShop.OpeningBeginMinute / 60).ToString();
                tbxStartMinute.Text = (YeShop.OpeningBeginMinute % 60).ToString();
                tbxEndHour.Text = (YeShop.OpeningEndMinute / 60).ToString();
                tbxEndMinute.Text = (YeShop.OpeningEndMinute % 60).ToString();
                if(YeShop.OpeningBeginMinute2!=null&&YeShop.OpeningEndMinute2!=null)
                {
                    tbxStartHour2.Text = (YeShop.OpeningBeginMinute2 / 60).ToString();
                    tbxStartMinute2.Text = (YeShop.OpeningBeginMinute2 % 60).ToString();
                    tbxEndHour2.Text = (YeShop.OpeningEndMinute2 / 60).ToString();
                    tbxEndMinute2.Text = (YeShop.OpeningEndMinute2 % 60).ToString();
                }
                if (!string.IsNullOrWhiteSpace(YeShop.ShopLogoImg))
                {
                    imgLogo.ImageUrl = YeShop.ShopLogoImg;                    
                }
                else
                {
                    imgLogo.Visible = false;
                }
                if (!string.IsNullOrWhiteSpace(YeShop.ShopMainImg))
                {
                    imgMain.ImageUrl = YeShop.ShopMainImg;
                }
                else
                {
                    imgMain.Visible = false;
                }               
                var shopTypes = ShopBll.GetCheckedShopTypesByShopId(YeShopId);
                cblShopTypes.DataSource = ShopBll.ShopTypes;
                cblShopTypes.DataTextField = "ShopTypeName";
                cblShopTypes.DataValueField = "ShopTypeId";
                cblShopTypes.DataBind();
                foreach (ListItem item in cblShopTypes.Items)
                {
                    if (shopTypes.FirstOrDefault(type=>type.ShopTypeId.ToString()==item.Value)!=null)
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            int? tmpBeginMinute2;
            int? tmpEndMinute2;
            if (string.IsNullOrEmpty(tbxStartHour2.Text) || string.IsNullOrEmpty(tbxStartMinute2.Text) || string.IsNullOrEmpty(tbxEndHour2.Text) || string.IsNullOrEmpty(tbxEndMinute2.Text))
            {
                tmpBeginMinute2 = null;
                tmpEndMinute2 = null;
            }
            else
            {
                tmpBeginMinute2 = Convert.ToInt32(tbxStartHour2.Text) * 60 + Convert.ToInt32(tbxStartMinute2.Text);
                tmpEndMinute2 = Convert.ToInt32(tbxEndHour2.Text) * 60 + Convert.ToInt32(tbxEndMinute2.Text);
            }
            var shop = new Ye_Shop()
            {
                ShopID = YeShopId,
                DeliveryTime = ddlDeliveryTime.SelectedItem.Text,
                ShopDesc = tbxShopDesc.Text,
                ShopZip = tbxShopZip.Text,
                ShopFax =  tbxShopFax.Text,
                ShopMobile = tbxShopMobile.Text,
                ShopEmail = tbxShopEmail.Text,
                ShopAddress = tbxShopAdderss.Text,
                ShopName = tbxShopName.Text,
                Longitude = Convert.ToDecimal(tbxLongitude.Text),
                Latitude = Convert.ToDecimal(tbxLatitude.Text),
                ShopQQ = tbxShopQQ.Text,                
                OpeningBeginMinute = Convert.ToInt32(tbxStartHour.Text)*60+Convert.ToInt32(tbxStartMinute.Text),
                OpeningEndMinute = Convert.ToInt32(tbxEndHour.Text)*60+Convert.ToInt32(tbxEndMinute.Text),
                OpeningBeginMinute2 = tmpBeginMinute2,
                OpeningEndMinute2=tmpEndMinute2,
                ShopLogoImg = imgLogo.ImageUrl,
                ShopMainImg = imgMain.ImageUrl
            };
            var str = "";
            if (fupShopLogoImg.HasFile)
            {
                if (fupShopLogoImg.FileBytes.Length > 1024*10240)
                {
                    WebUtil.Alert("餐馆 Logo 图片不能超过 10 M！");
                    return;
                }
                if (WebUtil.UploadImage(fupShopLogoImg, "../upload/", new [] { ".gif", ".jpg", ".png",".jpeg" }, out str))
                {
                    shop.ShopLogoImg = "/upload/" + str;
                }
                else
                {
                    WebUtil.Alert("餐馆 Logo 图片格式不被支持！");
                    return;
                }
            }            
            if (fupShopMainImg.HasFile)
            {
                if (fupShopMainImg.FileBytes.Length > 1024 * 10240)
                {
                    WebUtil.Alert("餐馆图片不能超过 10 M！");
                    return;
                }
                if (WebUtil.UploadImage(fupShopMainImg, "../upload/", new [] { ".gif", ".jpg", ".png" ,".jpeg"}, out str))
                {
                    shop.ShopMainImg = "/upload/" + str;
                }
                else
                {
                    WebUtil.Alert("餐馆主图 图片格式不被支持！");
                    return;
                }
            }           
            var f1 = ShopBll.UpdateShopInfo(shop);
            var list = new List<int>();
            foreach (ListItem item in cblShopTypes.Items)
            {
                if (item.Selected)
                {
                    list.Add(Convert.ToInt32(item.Value));
                }
            }
            var f2 = ShopBll.SetShopTypeChecked(YeShopId,list);
            if (f1||f2)
            {
                WebUtil.AlertAndReload("餐馆信息修改成功！");
            }
            else
            {
                WebUtil.AlertAndReload("餐馆信息修改失败！");
            }
        }
    }
}