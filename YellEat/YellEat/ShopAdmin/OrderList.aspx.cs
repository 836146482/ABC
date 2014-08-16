using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;

namespace YellEat.ShopAdmin
{
    public partial class OrderList : ShopAdminPageBase
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
            pager1.DataItemCount = OrderBll.GetOrdersByShopId(YeShopId).Count(p => p.IsShopDeleted == false);
            rpt.DataSource = OrderBll.GetOrdersByShopId(YeShopId).
                Where(p=>p.IsShopDeleted==false)
                .OrderBy(m=>m.OrderCreateTime)
                .Skip(pager1.PageSize*pager1.CurrentPagerIndex)
                .Take(pager1.PageSize).ToArray();
            rpt.DataBind();
            pager1.SetPagerControlState();
        }

        protected void rpt_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "del":
                {
                    var id = Convert.ToInt32(e.CommandArgument);
                    if (OrderBll.ShopDeleteOrder(id))
                    {
                        pager1.CurrentPagerIndex = 0;
                        BindData();                        
                    }
                    break;
                }
            }
        }
      
    }
}