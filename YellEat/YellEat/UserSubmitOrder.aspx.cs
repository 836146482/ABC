using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;
using YellEat.Utility;

namespace YellEat
{
    public partial class UserSubmitOrder : UserPageBase
    {
        /// <summary>
        /// 当前正在提交订单的餐馆
        /// </summary>
        protected Ye_Shop OrderingShop
        {
            get
            {
                return (Ye_Shop)
                    (ViewState["OrderingShop"] ??
                     (ViewState["OrderingShop"] = ShopBll.GetShopById(Convert.ToInt32(Request.QueryString["shopid"]))));
            }
            set { ViewState["OrderingShop"] = value; }
        }
        //税金税率
        protected List<Ye_Unit> YeUnits
        {
            get { return (List<Ye_Unit>)(Cache["YeUnits"]??(Cache["YeUnits"] = ProductBll.GetUnits().ToList())); }
            set { Cache["YeUnits"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < OrderingShop.Rank; i++)
                {
                    sb.Append("<i class='fa fa-star' style='color:#F07202'></i>");
                }
                ltlRank.Text = sb.ToString();
                var addrs = UserBll.GetUserAddressesByUserId(YeUser.UserID);
                rptDeliveryInfo.DataSource = addrs;
                rptDeliveryInfo.DataBind();
                var addr = addrs.SingleOrDefault(p => p.IsDefault);
                if (addr != null)
                {
                    tbxMobile.Text = addr.Mobile;
                    tbxReceiver.Text = addr.Receiver;
                    tbxAddress.Text = addr.Address;
                }
                BindData();
                lblOrderSN.Text = OrderBll.CreateOrderSN(YeUser.UserID);
            }
        }
        //提交订单
        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxReceiver.Text))
            {
               WebUtil.Alert("请输入收货人！");
               return;
            }
            if (string.IsNullOrWhiteSpace(tbxAddress.Text))
            {
                WebUtil.Alert("请输入收货地址！");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbxMobile.Text))
            {
                WebUtil.Alert("请输入收货人地址！");
                return;
            }
            if (Convert.ToDecimal(hfTotalPrice.Value)<=0)
            {
                WebUtil.Alert("请先选好数量！");
                return;
            }
            //订单信息
            var order = new Ye_Order()
            {
                UserID = YeUser.UserID,
                ShopID = OrderingShop.ShopID,
                OrderSN = lblOrderSN.Text,
                OrderDesc = tbxOrderDesc.Text,
                OrderCreateTime = DateTime.Now,
                OrderCheckTime = null,
                OrderPayTime = null,
                IsUserDeleted = false,
                IsShopDeleted = false,
                Receiver = tbxReceiver.Text,
                ReceiveAddress = tbxAddress.Text,
                ReceiverMobile = tbxMobile.Text,
                TotalPrice = Convert.ToDecimal(hfTotalPrice.Value),
                Tax = Convert.ToDecimal(hfFax.Value),
                OrderStatus = (int)OrderStatus.已下单
            };
            if (!string.IsNullOrWhiteSpace(tbxCode.Text))
            {
                var coupon = ShopCouponBll.GetShopCouponsByShopId(OrderingShop.ShopID)
                    .SingleOrDefault(
                        s => s.BeginDate < DateTime.Now && s.EndDate > DateTime.Now && s.CouponCode == tbxCode.Text);
                if (coupon == null)
                {
                    WebUtil.Alert("优惠券验证码无效！");
                    return;
                }
                else
                {
                    var userCoupon =
                        UserCouponBll.GetUserCouponsByUserId(YeUser.UserID)
                            .SingleOrDefault(p => p.CouponId == coupon.CouponID);
                    if (userCoupon == null)
                    {
                        WebUtil.Alert("您没有该验证码的使用权限！");
                        return;
                    }
                    else
                    {
                        if (userCoupon.IsUsed)
                        {
                            WebUtil.Alert("该验证码已被使用作废！");
                            return;
                        }
                        else
                        {
                            UserCouponBll.UseCoupon(YeUser.UserID, userCoupon.UserCouponId);
                            order.ShopCouponID = coupon.CouponID;
                            order.UnitCouponCost = coupon.UnitCost;
                        }
                    }
                }
                //
            }
            var orderDetails = new List<Ye_OrderDetail>();//获取订单详情
            rptProduct.Controls.OfType<RepeaterItem>().ToList().ForEach(p =>
            {
                var lbl = p.FindControl("lblAmount") as Label;
                var hf = p.FindControl("hfAmount") as HiddenField;                
                orderDetails.Add(new Ye_OrderDetail()
                {
                    ProductID = Convert.ToInt32(lbl.Attributes["data-pid"]),
                    Quantity = Convert.ToInt32(hf.Value),
                    UnitCost = Convert.ToDecimal(lbl.Attributes["data-unitcost"])
                });
            });
            if (OrderBll.AddOrder(order, orderDetails))
            {
                Response.Cookies["shop_" + OrderingShop.ShopID.ToString()].Expires = DateTime.Now.AddDays(-1);//清空Cookie信息
                //WebUtil.AlertAndRedirect("您的订单已提交，请等候我们的回复！","ShopDetail.aspx?shopid="+OrderingShop.ShopID);
                WebUtil.AlertAndRedirect("您的订单已提交，请等候我们的回复！", "UserOrders.aspx");
            }
        }

        protected void rptProduct_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var product = e.Item.DataItem as Ye_Product;
            var lbl = e.Item.FindControl("lblAmount") as Label;
            var hf = e.Item.FindControl("hfAmount") as HiddenField;
            Ye_Unit ye_Unit = YeUnits.FirstOrDefault(p => p.UnitID == product.UnitId);
            if (ye_Unit == null)
            {
                lbl.Attributes["data-fax"] = "0";
            }
            else
            {
                string strUnitPrice= ((YeUnits.First(p => p.UnitID == product.UnitId).UnitPoint - 1) * product.Price).ToString();
                int num= strUnitPrice.IndexOf('.');
                lbl.Attributes["data-fax"] = strUnitPrice.Substring(0, num+5);
            }
            //lbl.Attributes["data-fax"] =
               // ((YeUnits.First(p => p.UnitID == product.UnitId).UnitPoint-1)*product.Price).ToString();
            if (Request.Cookies["shop_" + product.ShopID] != null)
            {
                var temp = Request.Cookies["shop_" + product.ShopID].Values[product.ProductID.ToString()];
                if (temp != null)
                {
                    hf.Value = lbl.Text = temp;
                }
                else
                {
                   hf.Value = lbl.Text = "0";
                }
            }
            else
            {
                hf.Value = lbl.Text = "0";
            }
        }

        private void BindData()
        {
            var productIds = new Dictionary<int, int>();//存放菜单 Id 和数量
            if(Request.Cookies["shop_"+OrderingShop.ShopID]!=null)
            {
                foreach (string key in Request.Cookies["shop_" + OrderingShop.ShopID].Values.Keys)
                {
                    productIds.Add(Convert.ToInt32(key), Convert.ToInt32(Request.Cookies["shop_" + OrderingShop.ShopID][key]));
                }               
            }
            rptProduct.DataSource =
                ProductBll.GetProducts().Where(p => productIds.Keys.Contains(p.ProductID)&& p.IsUpShelf).ToList();            
            rptProduct.DataBind();
        }
    }
}