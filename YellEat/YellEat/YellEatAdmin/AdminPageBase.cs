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
    public class AdminPageBase:Page
    {
        protected override void OnLoad(EventArgs e)
        {
            if (Session["YeAdministratorId"] == null)
            {
                WebUtil.AlertAndRedirect("对不起，您登录超时了！请重新登录！", "Login.aspx");
            }
            (this.Master.FindControl("ltlCurrentShop") as Literal).Text = YeAdministrator.Account;
            base.OnLoad(e);
        }
        /// <summary>
        /// 获取或设置管理员 ID
        /// </summary>
        protected int YeAdministratorId
        {
            get { return (int)Session["YeAdministratorId"]; }
            set { Session["YeAdministratorId"] = value; }
        }
        /// <summary>
        /// 获取或设置管理员
        /// </summary>
        protected Ye_Administrator YeAdministrator
        {
            get { return (Ye_Administrator) (Cache["YeAdministrator"] ?? (Cache["YeAdministrator"] = AdministratorBll.GetAdministratorById(YeAdministratorId))); }
            set { Cache["YeAdministrator"] = value; }
        }
        /// <summary>
        ///获取或设置用户权限
        /// </summary>
        protected List<int> AdminPowers
        {
            get
            {
                return
                    (List<int>) (Cache["AdminPowers"] ?? (Cache["AdminPowers"] =
                        AdministratorBll.GetAdminPowerByAdminId(YeAdministratorId)));
            }
            set
            {
                Cache["AdminPowers"] = value;
            }
        }

        /// <summary>
        /// 用户权限检查
        /// </summary>
        /// <param name="adminPower">管理员权限</param>
        /// <returns></returns>
        protected void CheckPower(AdminPower adminPower)
        {
            if (!AdminPowers.Contains((int)adminPower))
            {
                WebUtil.AlertNoPower();
            }
        }
    }
}