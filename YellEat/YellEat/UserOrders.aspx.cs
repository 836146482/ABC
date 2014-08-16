using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;

namespace YellEat
{
    public partial class UserOrders : UserPageBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected List<Ye_Product> ShowShopProducts
        {
            get { return (List<Ye_Product>)(Cache["ShowShopProducts"] ?? (Cache["ShowShopProducts"] = new List<Ye_Shop>())); }
            set { Cache["ShowShopProducts"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(0);
            }
        }
        //订单绑定
        protected void rptOrders_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var rpt = e.Item.FindControl("rptOrderDetail") as Repeater;
                dynamic data = e.Item.DataItem;
                int orderId = data.OrderID;
                using (var entities = new YellEatEntities())
                {
                    var query = from orderDetail in entities.Ye_OrderDetail
                        join product in entities.Ye_Product
                            on orderDetail.ProductID equals product.ProductID
                        where orderId == orderDetail.OrderID
                        select new { product.ProductName,orderDetail.Quantity,orderDetail.UnitCost};
                    rpt.DataSource = query.ToList();
                    rpt.DataBind();
                }

            }
        }
        //绑定数据
        private void BindData(int pagerIndex,int pageSize = 10)
        {
            using (var entities = new YellEatEntities())
            {
                var query = from shop in entities.Ye_Shop
                    join order in entities.Ye_Order on shop.ShopID equals order.ShopID
                    join g in
                        (from orderDetail in entities.Ye_OrderDetail
                         join product in entities.Ye_Product on orderDetail.ProductID equals product.ProductID
                           group new { orderDetail,product} by orderDetail.OrderID)
                        on order.OrderID equals g.Key
                    join orderResult in entities.Ye_OrderResult on order.OrderID equals orderResult.OrderID
                    into temp from orderResult in temp.DefaultIfEmpty()
                    where order.UserID == YeUser.UserID
                    select new
                    {
                        order.TotalPrice,
                        shop.ShopName,
                        order.OrderSN,
                        order.OrderID,
                        HasOrderResult= orderResult!=null
                    };
                rptOrders.DataSource = query.OrderByDescending(o=>o.OrderID).Skip(pagerIndex*pageSize).Take(pageSize).ToArray();
                rptOrders.DataBind();
            }
        }
    }
}