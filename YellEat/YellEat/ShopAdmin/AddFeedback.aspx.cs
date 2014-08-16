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
    public partial class AddFeedback : ShopAdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxFeedbackContent.Text))
            {
                if (ShopBll.AddShopFeedback(YeShopId, tbxFeedbackContent.Text))
                {
                    WebUtil.AlertAndRedirect("感谢您的意见反馈,请耐心等待我们的回复！","FeedbackList.aspx");
                }
                else
                {
                    WebUtil.Alert("提交意见反馈时出错");
                }
            }
        }
    }
}