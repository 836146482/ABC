using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;

namespace YellEat.YellEatAdmin
{
    public partial class UserOrderList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPower(AdminPower.会员历史订单);
                BindData();
            }
            pager1.PagerIndexChanged = BindData;
        }

        private void BindData()
        {
            pager1.DataItemCount = OrderBll.GetOrders().Count();
            using (var entities = new YellEatEntities())
            {
                var query = from order in entities.Ye_Order
                    join user in entities.Ye_User
                        on order.UserID equals user.UserID
                    join shop in entities.Ye_Shop
                        on order.ShopID equals shop.ShopID
                    select new
                    { 
                        order.OrderSN,
                        order.UserID,
                        order.OrderStatus,
                        order.OrderCreateTime,
                        order.Tax,
                        order.UnitCouponCost,
                        order.TotalPrice,
                        shop.ShopName,
                        user.UserName,
                        order.OrderID
                    };
                rpt.DataSource =
                    query.OrderByDescending(p => p.OrderCreateTime)
                        .Skip(pager1.CurrentPagerIndex*pager1.PageSize)
                        .Take(pager1.PageSize)
                        .ToArray();
                rpt.DataBind();
            }
            pager1.SetPagerControlState();
        }

        protected void rpt_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}