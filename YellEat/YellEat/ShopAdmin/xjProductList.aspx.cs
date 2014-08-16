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
    public partial class xjProductList : ShopAdminPageBase
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
                where product.ShopID == YeShopId && product.IsUpShelf == false
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
            rpt.DataSource = query.OrderBy(p => p.RecommendLevel)
                .Skip(pager1.PageSize * pager1.CurrentPagerIndex)
                .Take(pager1.PageSize).ToList();
            rpt.DataBind();
            pager1.SetPagerControlState();
        }

        protected void rpt_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var id = Convert.ToInt32(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                case "del":
                    {
                        if (ProductBll.CheckProduct(id))        //菜单出现在订单中
                        {
                            List<int> lisOrderId= OrderBll.GetOrderIDsByProductId(id);
                            foreach(int orderId in lisOrderId)
                            {
                                OrderBll.ShopDeleteOrder(orderId);
                            }
                            //ProductBll.DeleteProduct(id);
                            WebUtil.Alert("菜单删除成功！", this);
                            pager1.CurrentPagerIndex = 0;
                            BindData();
                        }
                        else
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
                case "sj":
                    {
                        if (ProductBll.SetProductSaleState(id, true))
                        {
                            WebUtil.Alert("菜单上架成功！", this);
                            pager1.CurrentPagerIndex = 0;
                            BindData();
                        }
                        else
                        {
                            WebUtil.Alert("菜单上架失败！", this);
                        }
                        break;
                    }
            }
        }
    }
}