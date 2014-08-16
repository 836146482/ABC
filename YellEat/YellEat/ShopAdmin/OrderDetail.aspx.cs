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
    public partial class OrderDetail : ShopAdminPageBase
    {
        protected Ye_Order Order { get; set; }
        protected Ye_OrderResult OrderResult { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var ltl = this.Master.FindControl("ltlSiteMapPath") as Literal;
                ltl.Text = WebUtil.CreateBreadcrumbs(new List<Tuple<string, string>>()
                {
                    new Tuple<string, string>("YellEat 后台管理系统",""),
                    new Tuple<string, string>("餐馆管理首页",""),
                    new Tuple<string, string>("订单管理",""),
                    new Tuple<string, string>("订单详情","")
                });
                var id = Convert.ToInt32(Request.QueryString["id"]);
                var units = ProductBll.GetUnits().ToArray();
                var orderDetails = OrderBll.GetOrderDetailsByOrderID(id).ToArray();
                var details = from detail in orderDetails
                                join product in ProductBll.GetProducts() 
                                on detail.ProductID equals product.ProductID   
                                join unit in units 
                                on product.UnitId equals unit.UnitID
                                select new {detail.Quantity,detail.UnitCost,unit.UnitPoint,product.ProductName,product.ProductID};
                Order = OrderBll.GetOrders().SingleOrDefault(p => p.OrderID == id);
                OrderResult = OrderBll.GetOrderResultByOrderID(id);
                rptOrderDetail.DataSource = details.ToArray();
                rptOrderDetail.DataBind();
            }
        }
    }
}