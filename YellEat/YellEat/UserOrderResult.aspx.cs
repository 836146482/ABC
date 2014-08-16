using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;
using YellEat.Utility;

namespace YellEat
{
    public partial class UserOrderResult : UserPageBase
    {
        protected Ye_Shop Shop { get; set; }

        protected int ShopId
        {
            get { return (int)ViewState["ShopId"]; }
            set { ViewState["ShopId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var orderId = Convert.ToInt32(Request.QueryString["orderId"]);
                var order = OrderBll.GetOrderByID(Convert.ToInt32(orderId));
                Shop = ShopBll.GetShopById(order.ShopID);
                ShopId = Shop.ShopID;
            }   
        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            byte byteDeliveryStar=1;
            byte byteEatingStar=1;
            byte.TryParse(hfDeliveryStar.Value, out byteDeliveryStar);
            byte.TryParse(hfEatingStar.Value, out byteEatingStar);
            if (OrderBll.AddOrderResult(new Ye_OrderResult()
            {
                OrderID = Convert.ToInt32(Request.QueryString["orderId"]),
                ShopID = ShopId,
                UserID = YeUser.UserID,
                EvaluationContent = tbxContent.Text,
                DeliveryStar = byteDeliveryStar,//待修改
                EatingStar = byteEatingStar,//待修改
                CreateTime = DateTime.Now
            }))
            {
                WebUtil.AlertAndRedirect("感谢您的支持！", "UserOrders.aspx");
            }
            else
            {
                WebUtil.AlertAndRedirect("用餐评价失败！", "UserOrders.aspx");
            }

        }
    }
}