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
    public partial class AddProduct : ShopAdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Form.Enctype = "multipart/form-data";
            if (!IsPostBack)
            {
                WebControlUtil.BindDropDownList(ddlProductTypes,YeProductTypes,"ProductTypeName","ProductTypeID");
                WebControlUtil.BindDropDownList(ddlUnits,ProductBll.GetUnits().ToList(),"UnitName","UnitID");
            }
        }

        protected void btnOk_OnClick(object sender, EventArgs e)
        {
            if (ProductBll.GetProducts().Count(p => p.ShopID == YeShopId && p.ProductNo == tbxProductNO.Text.Trim()) > 0)
            {
                WebUtil.Alert("菜单编号重复，请重新填写菜单编号！");
                return;
            }
            var product = new Ye_Product()
            {
                ProductDesc = tbxProductDesc.Text,
                Price = Convert.ToDecimal(tbxPrice.Text),
                ShopID = YeShopId,
                ProductName = tbxProductName.Text,
                ProductNo = tbxProductNO.Text,
                ProductTypeID = Convert.ToInt32(ddlProductTypes.SelectedValue),
                UnitId = Convert.ToInt32(ddlUnits.SelectedValue),
                CreateDate = DateTime.Now,                
            };
            var fileName = string.Empty;
            if (!fupProductImage.HasFile)
            {
                WebUtil.Alert("请上传产品图片！");
                return;
            }else if (fupProductImage.FileBytes.Length > 1024*5120)
            {
                WebUtil.Alert("菜单图片不能超过 5 M！");
                return;
            }
            if (WebUtil.UploadImage(fupProductImage,"../upload/",new []{".png",".jpeg",".jpg"},out fileName))
            {
                product.ProductImage = "/upload/" + fileName;
            }
            else
            {
                WebUtil.Alert("上传图片失败，请重试。支持 jpg、png 格式！");
                return;
            }            

            if (ProductBll.AddProduct(product))
            {
                WebUtil.AlertAndReload("添加菜单成功！");
            }
            else
            {
                WebUtil.AlertAndReload("添加菜单失败！");
            }
        }
    }
}