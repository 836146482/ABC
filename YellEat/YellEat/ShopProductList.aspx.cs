using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;

namespace YellEat
{
    public partial class ShopProductList : ShopPageBase
    {
        /// <summary>
        /// 餐馆所有菜名,缓存
        /// </summary>
        protected List<Ye_Product> YeProducts
        {
            get { return (List<Ye_Product>)(Cache["YeProducts"] ?? (Cache["YeProducts"] = new List<Ye_Product>())); }
            set { Cache["YeProducts"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < VisitingShop.Rank; i++)
                {
                    sb.Append("<i class='fa fa-star' style='color:#F07202'></i>");
                }
                ltlRank.Text = sb.ToString();
                BindData();
            }
        }
        //绑定餐馆的每个菜式类型的产品
        protected void rptProductType_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem||e.Item.ItemType==ListItemType.Item)
            {
                var rpt = e.Item.FindControl("rptProduct") as Repeater;
                var tuple = e.Item.DataItem as Tuple<int, string>;
                var Product = YeProducts.Where(p => p.ProductTypeID == tuple.Item1);
                rpt.DataSource = Product.Count() >= 5 ? Product.Take(5) : Product;
                rpt.DataBind();
            }
        }
        protected void rptProduct_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //购物车cookie填充
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var Product =e.Item.DataItem as Ye_Product;
                var cookie=Request.Cookies[Product.ShopID + "shop_" + Product.ProductID];
                if(cookie!=null)
                ((Label)e.Item.FindControl("lblAmount")).Text = cookie.Value;
            }
        }
        //数据绑定
        private void BindData()
        {
            if (YeProducts.Count == 0)
            {
                YeProducts = ProductBll.GetProductByCondition(P => P.ShopID == VisitingShop.ShopID && P.IsUpShelf == true).ToList();
            }
            var data = from type in ProductBll.GetProductTypesByShopId(VisitingShop.ShopID)
                       join g in
                           (from product in YeProducts
                            group product by product.ProductTypeID)
                       on type.ProductTypeID equals g.Key
                       select new Tuple<int, string>(type.ProductTypeID, type.ProductTypeName);
            rptProductType.DataSource = data;     
            rptProductType.DataBind();
        }
        protected void rptProductType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "More")
            {
                object a = e.CommandSource;
                int ProductTypeID = Convert.ToInt32(e.CommandArgument);
                var rpt= e.Item.FindControl("rptProduct") as Repeater;
                int Count = rpt.Controls.Count;
                if (Count > 5)
                {
                    rpt.DataSource = YeProducts.Where(P => P.ProductTypeID == ProductTypeID).Take(5);
                    rpt.DataBind();
                }
                else
                {
                    rpt.DataSource = YeProducts.Where(P => P.ProductTypeID == ProductTypeID);
                    rpt.DataBind();
                }
            }
        }        
    }
}