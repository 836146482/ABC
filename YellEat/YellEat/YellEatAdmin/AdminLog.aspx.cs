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
    public partial class AdminLog : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPower(AdminPower.用户操作记录管理);
                BindData();
            }
            pager1.PagerIndexChanged = BindData;
        }

        protected void rptAdminLog_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var id = Convert.ToInt32(e.CommandArgument);
                AdministratorBll.DeleteAdminLog(id);
                pager1.CurrentPagerIndex = 0;
                BindData();
            }
        }

        private void BindData()
        {
            pager1.DataItemCount = AdministratorBll.GetAdministrators().Count();
            rptAdminLog.DataSource =
                (from log in AdministratorBll.GetAdminLogs()
                 join admin in AdministratorBll.GetAdministrators()
                         on log.AdminID equals admin.AdministratorID
                     select new
                     {
                         log.CreateTime,
                         AdminName =admin.Account,
                         log.LogTypeName,
                         log.LogID
                     })
                    .OrderBy(p => p.CreateTime)
                    .Skip(pager1.CurrentPagerIndex*pager1.PageSize)
                    .Take(pager1.PageSize)
                    .ToArray();
            rptAdminLog.DataBind();
            pager1.SetPagerControlState();
        }
    }
}