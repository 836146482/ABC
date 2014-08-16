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
    public partial class ShopCouponList : ShopAdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
            pager1.PagerIndexChanged = BindData;
        }

        private void BindData()
        {
            pager1.DataItemCount = ShopCouponBll.GetShopCouponsByShopId(YeShopId).Count(o => o.IsShopDeleted == false);
            rpt.DataSource = ShopCouponBll.GetShopCouponsByShopId(YeShopId)
                .Where(o => o.IsShopDeleted == false)
                .OrderBy(p => p.EndDate)
                .Skip(pager1.PageSize * pager1.CurrentPagerIndex)
                .Take(pager1.PageSize).ToArray();
            rpt.DataBind();
        }

        protected void rpt_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "del":
                    {
                        var id = Convert.ToInt32(e.CommandArgument);
                        var coupon = ShopCouponBll.GetShopCoupons().Single(p => p.CouponID == id);
                        if (coupon.BeginDate < DateTime.Now && coupon.EndDate > DateTime.Now)
                        {
                            WebUtil.Alert("该优惠券尚处于有效期内，无法删除。若要删除，请联系 YellEat 管理员!", this);
                        }
                        if (ShopCouponBll.DeleteShopCoupon(id))
                        {
                            pager1.CurrentPagerIndex = 0;
                            BindData();
                        }
                        break;
                    }
            }
        }
    }

}