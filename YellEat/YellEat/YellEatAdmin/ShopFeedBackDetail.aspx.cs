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
    public partial class ShopFeedBackDetail : AdminPageBase
    {
        //反馈餐馆
        protected Ye_Shop FeedbackShop { get; set; }
        //反馈内容
        protected Ye_ShopFeedback Feedback { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPower(AdminPower.加盟餐馆管理);
                var id = Convert.ToInt32(Request.QueryString["id"]);
                var data = from shop in ShopBll.GetShops()
                    join feedback in ShopBll.GetShopFeedbacks() on shop.ShopID equals feedback.ShopId
                    where feedback.ShopFeedbackID == id
                    select new {shop,feedback};
                Feedback = data.First().feedback;
                FeedbackShop = data.First().shop;
            }
        }
    }
}