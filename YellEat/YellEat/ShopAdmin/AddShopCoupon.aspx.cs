using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;
using YellEat.Utility;

namespace YellEat.ShopAdmin
{
    public partial class AddShopCoupon :ShopAdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rvDate1.MinimumValue = DateTime.Now.ToString("yyyy-MM-dd");
                rvDate1.MaximumValue = "2299-1-1";
                rvDate2.MinimumValue = DateTime.Now.ToString("yyyy-MM-dd");
                rvDate2.MaximumValue = "2299-1-1";
            }
        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(tbxBeginDate.Text)>Convert.ToDateTime(tbxEndDate.Text))
            {
                WebUtil.Alert("优惠结束日期必须在优惠开始日期之后");
                return;
            }
            if (ShopCouponBll.AddShopCoupon(new Ye_ShopCoupon()
            {
                ShopID = YeShopId,
                CouponCode = tbxCouponCode.Text,
                BeginDate = Convert.ToDateTime(tbxBeginDate.Text),
                EndDate = Convert.ToDateTime(tbxEndDate.Text),
                UnitCost = Convert.ToDecimal(tbxUnitCost.Text),
                CouponContent = ""
            }))
            {
                WebUtil.AlertAndRedirect("添加优惠券成功！","ShopCouponList.aspx");
            }
            else
            {
                WebUtil.Alert("优惠券添加失败！");
            }
        }
    }
}