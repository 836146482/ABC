using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;

namespace YellEat.YellEatAdmin
{
    public partial class UserFeedbackList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPower(AdminPower.会员意见处理);
                BindData();
            }
            pager1.PagerIndexChanged = BindData;
        }

        protected void rptUserFeedback_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                switch (e.CommandName)
                {
                    case "del":
                    {
                        var id = Convert.ToInt32(e.CommandArgument);
                        if (UserBll.DeleteUserFeedback(id))
                        {
                            AdministratorBll.AddAdminLog(new Ye_AdminLog()
                            {
                                AdminID = YeAdministratorId,
                                LogTypeName = LogType.会员管理.ToString(),
                                CreateTime = DateTime.Now
                            });
                            pager1.CurrentPagerIndex = 0;
                            BindData();
                        }
                        break;                        
                    }
                }
            }
        }

        private void BindData()
        {
            pager1.DataItemCount = UserBll.GetUserFeedbacks().Count();
            rptUserFeedback.DataSource =
                UserBll.GetUserFeedbacks()
                    .OrderBy(p => p.CreateTime)
                    .Skip(pager1.PageSize*pager1.CurrentPagerIndex)
                    .Take(pager1.PageSize)
                    .ToArray();
            rptUserFeedback.DataBind();
            pager1.SetPagerControlState();
        }
    }
}