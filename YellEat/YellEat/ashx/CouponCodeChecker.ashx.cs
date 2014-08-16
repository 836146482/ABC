using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using YellEat.BLL;

namespace YellEat.ashx
{
    /// <summary>
    /// CouponCodeChecker 的摘要说明
    /// </summary>
    public class CouponCodeChecker : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var userid = context.Request.Params["userid"];
            var shopid = context.Request.Params["shopid"];
            var code = context.Request.Params["code"];
            context.Response.ContentType = "text/json";
            if (userid==null||shopid==null||code==null)
            {
                context.Response.Write(JsonConvert.ToString(new { code = 0}));
            }
            else
            {
                var sid = Convert.ToInt32(shopid);
                var userCoupons =
                    UserCouponBll.GetUserCouponsByUserId(Convert.ToInt32(userid))
                        .Where(p => p.IsUsed == false && p.IsUserDeleted == false && p.ShopId == sid)
                        .ToArray();
                var shopCoupon = ShopCouponBll.GetShopCouponsByShopId(sid).SingleOrDefault(p => p.CouponCode == code);
                if (shopCoupon!=null && userCoupons.Count(p=>p.CouponId==shopCoupon.CouponID)>0)
                {
                    context.Response.Write(JsonConvert.SerializeObject(new { code = 1,dollor= shopCoupon.UnitCost}));
                }
                else
                {
                    context.Response.Write(JsonConvert.ToString(new { code = 0 }));
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}