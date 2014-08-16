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
    public partial class ChangePassword : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPower(AdminPower.修改个人密码);
            }
        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {            
            if (YeAdministrator.Password!=DESUtil.Encrypt(tbxOldPwd.Text))
            {
                WebUtil.Alert("您输入的当期登录密码不正确！");
                tbxOldPwd.Focus();
            }
            else
            {
                var newPwd = DESUtil.Encrypt(tbxNewPwd1.Text.Trim());
                if (AdministratorBll.ChangePassword(YeAdministratorId,newPwd))
                {
                    AdministratorBll.AddAdminLog(new Ye_AdminLog()
                    {
                        AdminID = YeAdministratorId,
                        LogTypeName = LogType.修改密码.ToString(),
                        CreateTime = DateTime.Now
                    });
                    WebUtil.Alert("密码修改成功！");
                    YeAdministrator.Password = newPwd;
                }
                else
                {
                    WebUtil.Alert("密码修改失败！");
                }
            }
        }
    }
}