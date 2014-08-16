using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;
using YellEat.ShopAdmin;
using YellEat.Utility;

namespace YellEat
{
    public partial class ShopList : Page
    {
        //购物车数量
        protected int cartNum = 0; 
        //用户当前位置
        protected string Location
        {
            get { return (string) ViewState["Location"]; }
            set { ViewState["Location"] = value; }
        }

        protected int CurrentPageIndex
        {
            get { return (int) ViewState["CurrentPageIndex"]; }
            set { ViewState["CurrentPageIndex"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Location = Request.QueryString["location"];
                if (Location == null)
                {
                    WebUtil.AlertAndRedirect("非法请求！","Home.aspx");
                }
                CurrentPageIndex = 0;
                rptShopTypes.DataSource = ShopBll.GetShopTypes();
                rptShopTypes.DataBind();
                BindData(0);
                ShopCartNum shopCartNum = new ShopCartNum();
                cartNum = shopCartNum.GetShopCartNum();
            }
        }
       /// <summary>
       /// 数据绑定并过滤
       /// </summary>
       /// <param name="pagerIndex">分页索引</param>
       /// <param name="rank">餐馆等级</param>
       /// <param name="clicks">餐馆点击次数</param>
       /// <param name="minDeliveryPrice">最小送餐价格</param>
       /// <param name="shopTypeIds">餐馆类型 Id 列表</param>
       /// <param name="condition">关键字查询</param>
       /// <param name="pageSize">页大小</param>
        private void BindData(int pagerIndex,int rank = 1,int clicks = 0,int minDeliveryPrice = 0,List<int> shopTypeIds = null,string condition= "",int pageSize = 10)
        {
            IQueryable<Ye_Shop> query = ShopBll.GetCheckedShop();
            if (rank != 1)
            {
                query = query.Where(shop => shop.Rank > rank);
            }
            if (clicks != 0)
            {
                query = query.Where(shop => shop.Clicks >= clicks);
            }
            if (minDeliveryPrice != 0)
            {
                query = query.Where(shop => shop.DeliveryMinPrice <= minDeliveryPrice);
            }
            if (shopTypeIds != null)
            {
                query = query.Where(shop => shopTypeIds.Contains(shop.ShopID));
            }
            if (!string.IsNullOrWhiteSpace(condition))
            {
                query = query.Where(shop =>shop.ShopName.IndexOf(condition) > -1);
            }
            var data =query.OrderBy(p => p.RecommendLevel).Skip(pagerIndex*pageSize).Take(pageSize+1).ToList();          
            btnMore.Visible = data.Count > pageSize;          
           rptShopList.DataSource = data.Take(pageSize);
            rptShopList.DataBind();
        }

        protected void imgBtnSearch_OnClick(object sender, ImageClickEventArgs e)
        {
            var list = new List<int>();
            CurrentPageIndex = 0;
            hfShopTypes.Value.Split(',').Where(p=>p!="").ToList().ForEach(i=>list.Add(Convert.ToInt32(i)));
            BindData(0, condition: tbxSearch.Text, rank: Convert.ToInt32(hfEatingStar.Value));
        }

        protected void rptShopList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem|| e.Item.ItemType == ListItemType.Item)
            {
                if (e.Item.DataItem!=null)
                {
                    var rank = e.Item.FindControl("ltlRank") as Literal;
                    var shop = e.Item.DataItem as Ye_Shop;
                    var sb = new StringBuilder();
                    for (int i = 0; i < shop.Rank; i++)
                    {
                        sb.Append("<i class='fa fa-star'></i>");
                    }
                    rank.Text = sb.ToString();
                }               
            }
        }

        protected void btnMore_OnClick(object sender, EventArgs e)
        {
            CurrentPageIndex++;
            var list = new List<int>();     
            hfShopTypes.Value.Split(',').Where(p => p != "").ToList().ForEach(i => list.Add(Convert.ToInt32(i)));
            BindData(CurrentPageIndex, condition: tbxSearch.Text, rank: Convert.ToInt32(hfEatingStar.Value));
            ScriptManager.RegisterClientScriptBlock(updatePanel1,this.GetType(),"loadData","loadData()",true);
        }
    }
}