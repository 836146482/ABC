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
    public partial class AdminPowerAssign : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPower(AdminPower.分配权限管理);
                WebControlUtil.BindDropDownList(ddl,AdministratorBll.GetAdministrators().ToArray(),"Account","AdministratorID");
                ddl.SelectedValue = YeAdministratorId.ToString();
                BindData(YeAdministratorId);
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (ddl.SelectedValue == YeAdministratorId.ToString())
            {
                WebUtil.Alert("您无法修改自身的权限！");
            }
            else
            {
                var list = new List<int>();
                for (int i = 1; i < 12; i++)
                {
                    var c = this.FindControl("cbx" + i.ToString()) as CheckBox;
                    if (c.Checked)
                    {
                        list.Add(i);
                    }
                }
                if (AdministratorBll.UpdateAdminPower(YeAdministratorId, list))
                {
                    AdministratorBll.AddAdminLog(new Ye_AdminLog()
                    {
                        AdminID = YeAdministratorId,
                        LogTypeName = LogType.修改权限.ToString(),
                        CreateTime = DateTime.Now
                    });
                    WebUtil.AlertAndRedirect("权限更新成功！", "");
                }
            }
        }

        private void BindData(int adminId)
        {
            var power = AdministratorBll.GetAdminPowerByAdminId(adminId).Select(p => "cbx" + p.ToString());
            var cbxes = updatePanel.ContentTemplateContainer.Controls.OfType<CheckBox>();
            cbxes.ToList().ForEach(p=>p.Checked = false);
            cbxes.Where(p => power.Contains(p.ID)).ToList().ForEach(c => c.Checked = true);
            cbx1_OnCheckedChanged(this,EventArgs.Empty);
            cbx3_OnCheckedChanged(this, EventArgs.Empty);
            cbx6_OnCheckedChanged(this, EventArgs.Empty);
        }

        #region 选中大项
        protected void cbxA_OnCheckedChanged(object sender, EventArgs e)
        {
            cbx1.Checked = cbx2.Checked = cbxA.Checked;
        }

        protected void cbxB_OnCheckedChanged(object sender, EventArgs e)
        {
            cbx3.Checked = cbx4.Checked = cbxB.Checked;
        }

        protected void cbxC_OnCheckedChanged(object sender, EventArgs e)
        {
            cbx5.Checked = cbx6.Checked = cbx7.Checked = cbx8.Checked = cbx9.Checked = true;
        }
        #endregion

        #region 选中小项
        protected void cbx1_OnCheckedChanged(object sender, EventArgs e)
        {
            cbxA.Checked = cbx1.Checked && cbx2.Checked;
        }
        protected void cbx3_OnCheckedChanged(object sender, EventArgs e)
        {
            cbxB.Checked = cbx3.Checked && cbx4.Checked && cbx5.Checked;
        }
        protected void cbx6_OnCheckedChanged(object sender, EventArgs e)
        {
            cbxC.Checked = cbx6.Checked && cbx7.Checked 
                && cbx8.Checked && cbx9.Checked && 
                cbx10.Checked && cbx11.Checked;
        }
        #endregion

        protected void ddl_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            BindData(Convert.ToInt32(ddl.SelectedValue));
        }
    }
}