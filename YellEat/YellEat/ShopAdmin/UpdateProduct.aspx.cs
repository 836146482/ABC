using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;
using YellEat.Utility;

namespace YellEat.ShopAdmin
{
    public partial class UpdateProduct : ShopAdminPageBase
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {              
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("ProductList.aspx");
                }
                var id = Convert.ToInt32(Request.QueryString["id"]);
                var product = ProductBll.GetProductById(id);
                tbxPrice.Text = product.Price.ToString();
                tbxProductDesc.Text = product.ProductDesc;
                tbxProductNO.Text = product.ProductNo;
                tbxProductName.Text = product.ProductName;
                imgProductImage.ImageUrl = product.ProductImage;
                WebControlUtil.BindDropDownList(ddlProductTypes, YeProductTypes, "ProductTypeName", "ProductTypeID");
                WebControlUtil.BindDropDownList(ddlUnits, ProductBll.GetUnits().ToList(), "UnitName", "UnitID");
                ddlProductTypes.SelectedValue = product.ProductTypeID.ToString();
                ddlUnits.SelectedValue = product.UnitId.ToString();                
            }
            var ltl = this.Master.FindControl("ltlSiteMapPath") as Literal;
            ltl.Text = WebUtil.CreateBreadcrumbs(new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("YellEat 后台管理系统",""),
                new Tuple<string, string>("餐馆管理首页",""),
                new Tuple<string, string>("菜单管理",""),
                new Tuple<string, string>("修改菜单","")
            });
        }

        protected void btnOk_OnClick(object sender, EventArgs e)
        {
            int productId=Convert.ToInt32(Request.QueryString["id"]);
            if (ProductBll.GetProducts().Count(p=>p.ShopID==YeShopId&& p.ProductNo==tbxProductNO.Text.Trim() && p.ProductID!=productId)>0)
            {
                WebUtil.Alert("菜单编号重复，请重新填写菜单编号！");
                return;
            }
            var product = new Ye_Product()
            {
                ProductID = productId,
                ProductDesc = tbxProductDesc.Text,
                Price = Convert.ToDecimal(tbxPrice.Text),
                ShopID = YeShopId,
                ProductName = tbxProductName.Text,
                ProductNo = tbxProductNO.Text,
                ProductTypeID = Convert.ToInt32(ddlProductTypes.SelectedValue),
                UnitId = Convert.ToInt32(ddlUnits.SelectedValue),
                CreateDate = DateTime.Now,
            };
            if (!fupProductImage.HasFile)
            {
                product.ProductImage = imgProductImage.ImageUrl;
            }
            else
            {
                var oldImage = Server.MapPath(product.ProductImage);
                string str = string.Empty;
                if (WebUtil.UploadImage(fupProductImage, "../upload/", new[] { ".gif", ".jpg", ".png", ".jpeg" }, out str))
                {
                    product.ProductImage = "/upload/" + str;
                    try
                    {
                        File.Delete(oldImage);
                    }
                    catch 
                    {
                        
                    }                   
                }
                else
                {
                    WebUtil.Alert("餐馆 Logo 图片格式不被支持！");
                    return;
                }
            }
            if (ProductBll.UpdateProduct(product))
            {
                WebUtil.Alert("菜单修改成功！");
            }
            else
            {
                WebUtil.Alert("菜单修改失败！");
            }
        }
    }
}