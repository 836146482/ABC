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
    public partial class ChangePassword : ShopAdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            if (YeShop.ShopPassword != DESUtil.Encrypt(tbxOldPwd.Text))
            {
                WebUtil.Alert("您输入的当期登录密码不正确！");
                tbxOldPwd.Focus();
                return;
            }
            else
            {
                var newPwd = DESUtil.Encrypt(tbxNewPwd1.Text.Trim());
                if (ShopBll.ChangePassword(YeShopId, newPwd))
                {
                    WebUtil.Alert("密码修改成功！");
                    YeShop.ShopPassword = newPwd;
                }
                else
                {
                    WebUtil.Alert("密码修改失败！");
                }
            }
        }
    }
}