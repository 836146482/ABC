using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Utility;

namespace YellEat.ShopAdmin
{
    public partial class ProductTypeManage : ShopAdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
            pager1.PagerIndexChanged = BindData;
        }

        protected void btnOk_OnClick(object sender, EventArgs e)
        {
            if (YeProductTypes.Exists(p=>p.ProductTypeName == tbxProductType.Text.Trim()))
            {
                WebUtil.Alert(string.Format("已在名为“{0}”的菜单分类", tbxProductType.Text),this);
            }
            else
            {
                if (ProductBll.AddProductType(YeShopId, tbxProductType.Text))
                {
                    WebUtil.Alert("菜单分类添加成功!",this.Page);
                    YeProductTypes = ProductBll.GetProductTypesByShopId(YeShopId);
                    pager1.CurrentPagerIndex = 0;
                    BindData();                    
                }
                else
                {
                    WebUtil.Alert("菜单分类添加失败!",this.Page);
                }
            }
        }

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(hfUpdateTypeId.Value);
            if (ProductBll.UpdateProductType(id,tbxProductType2.Text.Trim()))
            {
                WebUtil.Alert("菜单修改添加成功");
                YeProductTypes.First(p => p.ProductTypeID == id).ProductTypeName = tbxProductType2.Text.Trim();
                BindData();
            }
            else
            {
                WebUtil.Alert("菜单分类修改失败");
            }
        }

        private void BindData()
        {
            var data = from p in ProductBll.GetProductTypes()
                join g in
                    (from type in ProductBll.GetProducts()
                    group type by type.ProductTypeID)                 
                    on p.ProductTypeID equals g.Key into tempResult
                    from g in tempResult.DefaultIfEmpty()
                    where p.ShopID == YeShopId
                select new
                {
                    p.ProductTypeID,
                    p.ProductTypeName,
                    ProductCount = g.Count(),
                };
            pager1.DataItemCount = data.Count();
            var temp = data.OrderBy(p => p.ProductTypeName).Skip(pager1.PageSize * pager1.CurrentPagerIndex).Take(pager1.PageSize).ToArray();
            rpt.DataSource = temp;
            rpt.DataBind();
            pager1.SetPagerControlState();          
        }

        protected void rpt_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType== ListItemType.AlternatingItem|| e.Item.ItemType == ListItemType.Item)
            {
                switch (e.CommandName)
                {
                    case "del":
                    {
                        if (ProductBll.DeleteProductTypeAndProducts(Convert.ToInt32(e.CommandArgument)))
                        {
                            WebUtil.Alert("成功删除菜单分类",this.Page);
                            YeProductTypes = ProductBll.GetProductTypesByShopId(YeShopId);
                            pager1.CurrentPagerIndex = 0;
                            BindData();
                        }
                        break;
                    }
                }
            }
        }
    }
}