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
    public partial class UserCoupon : UserPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var entities = new YellEatEntities())
                {
                    var userCoupons = entities.Ye_UserCoupon.Where(p=>p.UserId == YeUser.UserID);
                    var shopCoupons = entities.Ye_ShopCoupon;
                    var shops = entities.Ye_Shop;
                    var data = (from shopCoupon in shopCoupons
                        join userCoupon in userCoupons on shopCoupon.CouponID equals userCoupon.CouponId
                        join shop in shops on shopCoupon.ShopID equals shop.ShopID
                        select new
                        {
                            shopCoupon.CouponCode,
                            shop.ShopName,
                            shopCoupon.CouponContent,
                            shopCoupon.BeginDate,
                            shopCoupon.EndDate,
                            userCoupon.IsUsed,
                            shopCoupon.UnitCost
                        }).ToList();
                    var useful =
                        data.Where(p => p.IsUsed == false && p.BeginDate < DateTime.Now && p.EndDate > DateTime.Now);
                    rptUsefulCoupon.DataSource = useful;
                    rptUsefulCoupon.DataBind();
                    rptNotUsefulCoupon.DataSource = data.Except(useful);
                    rptNotUsefulCoupon.DataBind();
                }
            }
        }
    }
}