using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;
using YellEat.Utility;

namespace YellEat.YellEatAdmin
{
    public partial class HandleShopFeedback : AdminPageBase
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
                var idstr = Request.QueryString["id"];
                int id;
                if (!int.TryParse(idstr, out id))
                {
                    WebUtil.AlertAndRedirect("非法请求","Default.aspx");
                }
                var data = from shop in ShopBll.GetShops()
                           join feedback in ShopBll.GetShopFeedbacks() on shop.ShopID equals feedback.ShopId
                           where feedback.ShopFeedbackID == id
                           select new {shop, feedback};
                Feedback = data.First().feedback;
                FeedbackShop = data.First().shop;
            }
        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            if (ShopBll.HandleShopFeedback(Convert.ToInt32(Request.QueryString["id"]),tbxFeedbackAnswer.Text))
            {
                AdministratorBll.AddAdminLog(new Ye_AdminLog()
                {
                    AdminID = YeAdministratorId,
                    LogTypeName = LogType.餐馆管理.ToString(),
                    CreateTime = DateTime.Now
                });
                WebUtil.AlertAndRedirect("反馈处理已提交保存！","ShopFeedbackList.aspx");
            }
            else
            {
                WebUtil.Alert("反馈意见保存失败！");
            }
        }
    }
}