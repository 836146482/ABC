using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Controls;

namespace YellEat.ShopAdmin
{
    public partial class OrderResultList : ShopAdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();   
            }
            pager1.PagerIndexChanged = BindData;
        }

        private void BindData()
        {
            pager1.DataItemCount =
                OrderBll.GetOrderResultsByShopId(YeShopId).Count(p => p.IsShopDeleted == false);
            rpt.DataSource = OrderBll.GetOrderResultsByShopId(YeShopId)
                .Where(p=>p.IsShopDeleted==false)
                .OrderBy(p => p.CreateTime)
                .Skip(pager1.PageSize*pager1.CurrentPagerIndex)
                .Take(pager1.PageSize).ToArray();
            rpt.DataBind();
            pager1.DataBind();
        }
    }
}