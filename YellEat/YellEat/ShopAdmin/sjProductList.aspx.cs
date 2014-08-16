using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Controls;
using YellEat.Utility;

namespace YellEat.ShopAdmin
{
    public partial class sjProductList : ShopAdminPageBase
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
            pager1.PagerIndexChanged = BindData;
        }
        //绑定数据
        private void BindData()
        {
            var query =
                from product in ProductBll.GetProducts()
                join type in ProductBll.GetProductTypes() on product.ProductTypeID equals type.ProductTypeID                                  
                join unit in ProductBll.GetUnits() on product.UnitId equals unit.UnitID
                orderby product.RecommendLevel
                where product.ShopID == YeShopId && product.IsUpShelf 
                select new
                {
                   product.ProductID,
                   product.ProductName,
                   type.ProductTypeName,
                   product.ProductNo,
                   unit.UnitName,
                   product.Price,
                   product.CreateDate,
                   product.RecommendLevel
                };
            pager1.DataItemCount = query.Count();
            rpt.DataSource = query.OrderBy(p=>p.RecommendLevel)
                .Skip(pager1.PageSize*pager1.CurrentPagerIndex)
                .Take(pager1.PageSize).ToArray();
            rpt.DataBind();
            pager1.SetPagerControlState();
        }

        protected void rpt_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var id = Convert.ToInt32(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                case"del":
                {
                    if (ProductBll.CheckProduct(id))       //菜单出现在订单中，进行下架处理
                    {
                        if(ProductBll.SetProductSaleState(id,false))
                        {
                            WebUtil.Alert("菜单成功删除！", this);
                            pager1.CurrentPagerIndex = 0;
                            BindData();
                        }
                        else
                        {
                            WebUtil.Alert("菜单删除失败！", this);
                        }
                    }
                    else                                    //菜单没出现在订单中，进行删除处理
                    {
                        if (ProductBll.DeleteProduct(id))
                        {
                            WebUtil.Alert("菜单成功删除！", this);
                            pager1.CurrentPagerIndex = 0;
                            BindData();
                        }
                        else
                        {
                            WebUtil.Alert("菜单删除失败！", this);
                        }
                    }
                    break;                    
                }
                case "xj":
                {
                    if (ProductBll.SetProductSaleState(id, false))
                    {
                        WebUtil.Alert("菜单下架成功！", this);
                        pager1.CurrentPagerIndex = 0;
                        BindData();
                    }
                    else
                    {
                        WebUtil.Alert("菜单下架失败！",this);
                    }
                    break;
                }
            }
        }
    }
}