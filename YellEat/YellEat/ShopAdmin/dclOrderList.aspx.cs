using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;

namespace YellEat.ShopAdmin
{
    public partial class dclOrderList : ShopAdminPageBase
    {
        protected List<Ye_OrderDetail> OrderDetails { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
            pager1.PagerIndexChanged = BindData;
        }
        //数据绑定
        private void BindData()
        {
            pager1.DataItemCount = OrderBll.GetOrdersByShopId(YeShopId).Count(o => o.IsShopDeleted == false && o.OrderStatus==1);
            var orders = OrderBll.GetOrdersByShopId(YeShopId).Where(o=>o.IsShopDeleted==false).OrderBy(o=>o.OrderCreateTime).Skip(pager1.PageSize * pager1.CurrentPagerIndex).Take(pager1.PageSize);
            OrderDetails = (from detail in OrderBll.GetOrderDetails()
                join order in OrderBll.GetOrders() on detail.OrderID equals order.OrderID
                where order.ShopID == YeShopId             
                select detail).ToList();
            rpt.DataSource = orders.ToArray();
            rpt.DataBind();
            pager1.SetPagerControlState();
        }
        //订单项绑定
        protected void rpt_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
            {
                var order = e.Item.DataItem as Ye_Order;
                var rptOrderDetail = e.Item.FindControl("rptOrderDetail") as Repeater;
                var query = from detail in OrderDetails
                    join product in ProductBll.GetProducts()
                        on detail.ProductID equals product.ProductID 
                    join unit in ProductBll.GetUnits()
                        on product.UnitId equals unit.UnitID 
                    where detail.OrderID == order.OrderID
                    select new { 
                        product.ProductName,
                        product.ProductID,
                        detail.Quantity,
                        detail.UnitCost,
                        unit.UnitPoint
                    };
                rptOrderDetail.DataSource = query.ToList();
                rptOrderDetail.DataBind();
            }
        }
    }
}