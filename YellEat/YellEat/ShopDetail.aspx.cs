using System;
using System.Collections.Generic;
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
    public partial class ShopDetail : Page
    {
        //当前访问的餐馆
        protected Ye_Shop VisitingShop
        {
            get { return (Ye_Shop)Session["VisitingShop"]; }
            set { Session["VisitingShop"] = value; }
        }

        //唯一可用优惠券 
        protected Ye_ShopCoupon YeShopCoupon 
        {
            get { return (Ye_ShopCoupon) ViewState["YeShopCoupon"]; }
            set { ViewState["YeShopCoupon"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var idstr = Request.QueryString["shopid"];
                int id;
                if (idstr ==null || !int.TryParse(idstr,out id))
                {
                    Response.Redirect("ShopList.aspx");
                    return;
                }
                VisitingShop = ShopBll.GetShopById(id);
                if (VisitingShop  == null)
                {
                    Response.Redirect("ShopList.aspx");
                    return;
                }
                YeShopCoupon = ShopCouponBll.GetShopCouponsByShopId(VisitingShop.ShopID).FirstOrDefault(c => c.BeginDate<DateTime.Now && c.EndDate>DateTime.Now);               
                var sb = new StringBuilder();
                for (int i = 0; i < VisitingShop.Rank; i++)
                {
                    sb.Append("<i class='fa fa-star' style='color:#F07202'></i>");
                }
                ltlRank.Text = sb.ToString();                
                rptProducts.DataSource = ProductBll.GetProductsByShopId(VisitingShop.ShopID).OrderBy(p=>p.RecommendLevel).Take(10).ToList();
                rptProducts.DataBind();
                rptProductTypes.DataSource = ProductBll.GetProductTypesByShopId(VisitingShop.ShopID).Take(2).ToList();
                rptProductTypes.DataBind();
            }
        }

        protected void btnAddCoupon_OnClick(object sender, EventArgs e)
        {
            if (Session["YeUser"] == null)
            {
                WebUtil.AlertAndRedirect("Please login first,then get the coupon!","UserLogin.aspx");
                return;
            }
            var user = (Ye_User) Session["YeUser"];
            //TODO:确定优惠券规则,使用一次还是使用多次
            if (UserCouponBll.ExistsShopCoupon(user.UserID,YeShopCoupon.CouponID))
            {
                WebUtil.AlertAndReload("You have got the coupon.");
            }
            else
            {
                if (UserCouponBll.AddShopCoupon4User(new Ye_UserCoupon()
                {
                    ShopId = VisitingShop.ShopID,
                    CouponId = YeShopCoupon.CouponID,
                    IsUsed = false,
                    UserId = user.UserID
                }))
                {
                    WebUtil.AlertAndReload("Get the coupon successfully.");
                }
                else
                {
                    WebUtil.AlertAndReload("Failed to get the coupon.");
                }
            }
        }

        protected void btnAdd2Collction_OnClick(object sender, ImageClickEventArgs e)
        {
            if (Session["YeUser"] == null)
            {
                WebUtil.AlertAndRedirect("Please login first.","UserLogin.aspx");               
            }
            else
            {
                var user = (Ye_User) Session["YeUser"];
                if (UserBll.GetUserCollectionsByUserId(user.UserID).Count(p=>p.ShopID==VisitingShop.ShopID)>0)
                {
                    WebUtil.AlertAndReload("You had collected the shop.");
                }
                else
                {
                    if (UserBll.AddUserCollection(new Ye_UserCollection()
                    {
                        UserID = user.UserID,
                        ShopID = VisitingShop.ShopID,
                        IsCollecting = true
                    }))
                    {
                        WebUtil.AlertAndReload("Collect the shop successfully");
                    }
                    else
                    {
                        WebUtil.AlertAndReload("Failed to Collect the shop ");   
                    }
                }
            }
        }
    }
}