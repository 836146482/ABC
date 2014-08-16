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
    public partial class UserDetail : AdminPageBase
    {
        protected Ye_User user;
        private int pageSize = 5;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CheckPower(AdminPower.用户详细信息);
                DataControl();
            }

            pagerOrder.PagerIndexChanged = DataControl;
            pagerCollection.PagerIndexChanged = DataControl;
        }

        protected void DataControl()
        {
            int userId;
            if (string.IsNullOrEmpty(Request.QueryString["UserId"]) || !int.TryParse(Request.QueryString["UserId"], out userId))
            {
                return;
            }
            using (YellEatEntities ef = new YellEatEntities())
            {
                
                user = ef.Ye_User.FirstOrDefault(o => o.UserID == userId);
                if (user == null)
                {
                    return;
                }
                //var query=from order in ef.Ye_Order
                //          join shop in ef.Ye_Shop on order.ShopID equals shop.ShopID
                //          join p in (
                //               from detail in ef.Ye_OrderDetail
                //               join product in ef.Ye_Product on detail.ProductID equals product.ProductID
                //              group new{detail,product} by detail.OrderID
                //              ) on order.OrderID equals 
                var queryOrder = ef.Ye_Order.Where(o => o.UserID == user.UserID).Join(ef.Ye_OrderDetail, o => o.OrderID, p => p.OrderID,
                       (o, p) => new
                       {
                           ShopId = o.ShopID,
                           OrderSN = o.OrderSN,
                           OrderCreateTime = o.OrderCreateTime,
                           TotalPrice = o.TotalPrice,
                           ReceiverMobile = o.ReceiverMobile,
                           ReceiveAddress = o.ReceiveAddress,
                           UnitCouponCost = o.UnitCouponCost,
                           Tax = o.Tax,
                           OrderStatus = o.OrderStatus,
                           ProductID = p.ProductID,
                           Quantity = p.Quantity,
                           UnitCost = p.UnitCost,
                       })
                       .Join(ef.Ye_Shop, o => o.ShopId, p => p.ShopID,
                       (o, p) => new
                       {
                           ShopId = o.ShopId,
                           OrderSN = o.OrderSN,
                           OrderCreateTime = o.OrderCreateTime,
                           TotalPrice = o.TotalPrice,
                           ReceiverMobile = o.ReceiverMobile,
                           ReceiveAddress = o.ReceiveAddress,
                           UnitCouponCost = o.UnitCouponCost,
                           Tax = o.Tax,
                           OrderStatus = o.OrderStatus,
                           ProductID = o.ProductID,
                           Quantity = o.Quantity,
                           UnitCost = o.UnitCost,
                           ShopName = p.ShopName
                       });
                pagerOrder.PageSize = pageSize;
                pagerOrder.DataItemCount = ef.Ye_Order.Where(o => o.UserID == user.UserID).Count();
                repOrder.DataSource = queryOrder.OrderByDescending(o => o.OrderCreateTime).Skip(pagerOrder.PageSize * pagerOrder.CurrentPagerIndex).Take(pagerOrder.PageSize).ToList();
                repOrder.DataBind();
                pagerOrder.SetPagerControlState();

                pagerCollection.PageSize = pageSize;
                pagerCollection.DataItemCount = ef.Ye_UserCollection.Where(o => o.UserID == user.UserID).Count();
                repCollection.DataSource = ef.Ye_UserCollection.Where(o => o.UserID == user.UserID)
                    .Join(ef.Ye_Shop, o => o.ShopID, p => p.ShopID, (o, p) => new
                    {
                        ShopId = o.ShopID,
                        ShopName = p.ShopName,
                        EatCount = ef.Ye_Order.Where(q => q.UserID == o.UserID && q.ShopID == o.ShopID).Count(),
                        UserCollectionID=o.UserCollectionID
                    }).OrderByDescending(o => o.UserCollectionID).Skip(pagerCollection.PageSize * pagerCollection.CurrentPagerIndex).Take(pagerCollection.PageSize).ToList();
                
                //repCollection.DataSource = queryCoolection;
                repCollection.DataBind();
                pagerCollection.SetPagerControlState();
                

            }
        }
    }

}