using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;

namespace YellEat.YellEatAdmin
{
    public partial class ShopFeedbackList : AdminPageBase
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
            pager1.DataItemCount = ShopBll.GetShopFeedbacks().Count();
            rptShopFeedBack.DataSource =
                ShopBll.GetShopFeedbacks()
                    .OrderBy(p => p.CreateTime)
                    .Skip(pager1.PageSize*pager1.CurrentPagerIndex)
                    .Take(pager1.PageSize).ToArray();
            rptShopFeedBack.DataBind();
            pager1.SetPagerControlState();
        }
    }
}