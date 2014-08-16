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
    public partial class AccountList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPower(AdminPower.用户账号管理);
                BindData();
            }
            pager1.PagerIndexChanged = BindData;
        }
      
        private void BindData()
        {
            pager1.DataItemCount = AdministratorBll.GetAdministrators().Count();
            rpt.DataSource = AdministratorBll.GetAdministrators().OrderBy(p=>p.AdministratorID).Skip(pager1.PageSize*pager1.CurrentPagerIndex).Take(pager1.PageSize).ToArray();
            rpt.DataBind();
            pager1.SetPagerControlState();
        }

        //删除项
        protected void rpt_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="del")
            {
                var id = Convert.ToInt32(e.CommandArgument);
                if (AdministratorBll.DeleteAdministrator(id))
                {
                    AdministratorBll.AddAdminLog(new Ye_AdminLog()
                    {
                        AdminID = YeAdministratorId,
                        LogTypeName = LogType.删除管理员.ToString(),
                        CreateTime = DateTime.Now
                    });
                }                
                BindData();
            }
        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            if (AdministratorBll.GetAdministrators().SingleOrDefault(a=>a.Account==tbxAccount.Text)!=null)
            {
                WebUtil.Alert("该用户名已存在！");
                return;
            }
            else
            {
                if (AdministratorBll.AddAdministrator(new Ye_Administrator()
                {                    
                    Account = tbxAccount.Text.Trim(),
                    Password = DESUtil.Encrypt(tbxPwd1.Text.Trim()),
                    CreateTime = DateTime.Now,
                    LastLoginTime = DateTime.Now
                }))
                {
                    AdministratorBll.AddAdminLog(new Ye_AdminLog()
                    {
                        AdminID = YeAdministratorId,
                        LogTypeName = LogType.添加管理员.ToString(),
                        CreateTime = DateTime.Now
                    });
                    WebUtil.AlertAndReload("成功添加管理员！");
                }
                else
                {
                    WebUtil.Alert("创建新管理员时出错！");
                }
            }
        }
    }
}