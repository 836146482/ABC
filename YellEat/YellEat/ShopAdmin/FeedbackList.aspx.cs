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
    public partial class FeedbackList :ShopAdminPageBase
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
            pager1.DataItemCount = ShopBll.GetShopFeedbacksByShopId(YeShopId).Count(p=>p.IsShopDeleted==false);
            rptShopFeedBack.DataSource = ShopBll.GetShopFeedbacksByShopId(YeShopId)
                .Where(o=>o.IsShopDeleted== false)
                .OrderBy(p => p.CreateTime)
                .Skip(pager1.PageSize * pager1.CurrentPagerIndex)
                .Take(pager1.PageSize).ToArray();
            rptShopFeedBack.DataBind();
            pager1.SetPagerControlState();
        }


        protected void rptShopFeedBack_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "del":
                {
                    var id = Convert.ToInt32(e.CommandArgument.ToString());                    
                    ShopBll.ShopDeleteShopFeedback(id);
                    pager1.CurrentPagerIndex = 0;
                    BindData();
                    break;
                }
            }
        }
    }
}