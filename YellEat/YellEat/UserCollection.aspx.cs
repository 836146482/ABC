using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;

namespace YellEat
{
    public partial class UserCollection : UserPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(0);
            }
        }

        protected void rptShopList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                if (e.Item.DataItem != null)
                {
                    var rank = e.Item.FindControl("ltlRank") as Literal;
                    dynamic shop = e.Item.DataItem;
                    var sb = new StringBuilder();
                    for (int i = 0; i < shop.Rank; i++)
                    {
                        sb.Append("<i class='fa fa-star'></i>");
                    }
                    rank.Text = sb.ToString();
                }
            }
        }

        private void BindData(int pagerIndex, int pageSize = 10)
        {
            Ye_User user=(Ye_User)Session["YeUser"];
            using (var entities = new YellEatEntities())
            {
                var query =
                    from collect in entities.Ye_UserCollection
                    join shop in entities.Ye_Shop
                        on collect.ShopID equals shop.ShopID
                    join g in
                        (from order in entities.Ye_Order
                         where order.UserID == YeUser.UserID
                         group order by order.ShopID)
                        on collect.ShopID equals g.Key
                        into temp
                    from g in temp.DefaultIfEmpty()
                    where collect.IsCollecting && collect.ShopID == shop.ShopID && collect.UserID==user.UserID
                    select new
                    {
                        shop.ShopID,
                        shop.ShopName,
                        shop.Clicks,
                        shop.DeliveryTime,
                        EatCount = g.Count(),
                        shop.Rank
                    };
                rptShopList.DataSource = query.OrderBy(s => s.EatCount).Skip(pagerIndex*pageSize).Take(pageSize).ToArray();
                rptShopList.DataBind();
            }
        }
    }
}