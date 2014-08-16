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
    public partial class UnitList : System.Web.UI.Page
    {
        //税金列表
        protected List<Ye_Unit> Units
        {
            get { return (List<Ye_Unit>)(Cache["Units"] ?? (Cache["Units"] = ProductBll.GetUnits().ToList())); }
            set { Cache["Units"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(0);
            }
        }

        protected void btnAddUnit_OnClick(object sender, EventArgs e)
        {
            if (Units.SingleOrDefault(p => p.UnitName == tbxAddUnit.Text.Trim()) != null)
            {
                WebUtil.Alert("该税金已存在", this.Page);
                return;
            }
            else
            {
                if (ProductBll.AddUnit(new Ye_Unit()
                {
                    UnitName = tbxAddUnit.Text.Trim(),
                    UnitPoint = Convert.ToDecimal(tbxAddPoint.Text)
                }))
                {
                    Units = ProductBll.GetUnits().ToList();
                    BindData(0);
                }
                else
                {
                    WebUtil.Alert("添加税金失败", this.Page);
                    return;
                }
            }
        }

        protected void btnUpdateUnit_OnClick(object sender, EventArgs e)
        {
            if (Units.SingleOrDefault(p => p.UnitName == tbxAddUnit.Text.Trim()) != null)
            {
                WebUtil.Alert("该税金已存在", this.Page);
                return;
            }
            else
            {
                if (ProductBll.UpdateUnit(Convert.ToInt32(hf.Value), tbxUpdateUnit.Text.Trim(), Convert.ToDecimal(tbxUpdatePoint.Text.Trim())))
                {
                    Units = ProductBll.GetUnits().ToList();
                    BindData(0);
                }
                else
                {
                    WebUtil.Alert("修改餐馆类型失败", this.Page);
                    return;
                }
            }
        }



        // 绑定数据，分页索引从 0 开始      
        protected void BindData(int pagerIndex, int pagerSize = 10)
        {
            rpt.DataSource = Units.Skip(pagerIndex * pagerSize).Take(pagerSize);
            rpt.DataBind();
        }

    }
}