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
    public partial class UserList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPower(AdminPower.会员列表);
                BindData();
            }
            pager1.PagerIndexChanged = BindData;
        }

        private void BindData()
        {
            pager1.DataItemCount = UserBll.GetUsers().Count();
            rptUsers.DataSource = UserBll.GetUsers().OrderBy(u=>u.UserName).Skip(pager1.PageSize*pager1.CurrentPagerIndex).Take(pager1.PageSize).ToArray();
            rptUsers.DataBind();
            pager1.SetPagerControlState();
        }


        protected void rptUsers_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "setBlack":
                {
                    UserBll.SetUserBlack(Convert.ToInt32(e.CommandArgument));
                    AdministratorBll.AddAdminLog(new Ye_AdminLog()
                    {
                        LogTypeName = LogType.会员管理.ToString(),
                        CreateTime = DateTime.Now,
                        AdminID = YeAdministratorId
                    });
                    pager1.CurrentPagerIndex = 0;
                    BindData();
                    break;
                }
                case "setWhite":
                {
                    UserBll.SetUserWhite(Convert.ToInt32(e.CommandArgument));
                    AdministratorBll.AddAdminLog(new Ye_AdminLog()
                    {
                        LogTypeName = LogType.会员管理.ToString(),
                        CreateTime = DateTime.Now,
                        AdminID = YeAdministratorId
                    });
                    pager1.CurrentPagerIndex = 0;
                    BindData();                    
                    break;
                }
            }
        }
    }
}