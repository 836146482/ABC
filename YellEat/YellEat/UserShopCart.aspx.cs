using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;
using YellEat.Utility;

namespace YellEat
{
    public partial class UserShopCart : UserPageBase
    {
        /// <summary>
        /// //存放商店ID,产品ID和数量
        /// </summary>
        protected List<Tuple<int[],string>> keys
        {
            get {return (List<Tuple<int[],string>>)(Cache["Keys"] = new List<Tuple<int[], string>>()); }
            set { Cache["keys"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        //绑定数据
        private void BindData()
        {
            foreach (string cookie in Request.Cookies)
            {
                string[] str = Regex.Split(cookie, "shop_", RegexOptions.IgnoreCase);
                if (str.Length == 2)
                {
                    keys.Add(new Tuple<int[], string>(new int[2]{ Convert.ToInt32(str[0]), Convert.ToInt32(str[1]) }, Request.Cookies[cookie].Value));
                }
            }
            var shop = from s in ShopBll.GetCheckedShop().ToList()
                       join k in
                           (from s in keys group s by s.Item1[0] into g select new {key=g.Key })
                       on s.ShopID equals k.key
                       select new Ye_Shop()
                       {

                           ShopID = s.ShopID,
                           ShopName = s.ShopName
                       };
            rpt.DataSource = shop.ToList();
            rpt.DataBind();
        }
        //绑定餐馆数据
        protected void rpt_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var rpt = e.Item.FindControl("rptProduct") as Repeater;
                var shop = e.Item.DataItem as Ye_Shop;
                var entity = from p in ProductBll.GetProductByCondition(P => P.IsUpShelf == true)
                             join k in keys
                             on p.ProductID equals k.Item1[1]
                             select new
                             {
                                 ProductName = p.ProductName,
                                 Price = p.Price,
                                 Amount = k.Item2
                             };
                rpt.DataSource = entity;
                rpt.DataBind();
            }
        }
        //绑定产品
        protected void rptProduct_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                //var product = e.Item.DataItem as Ye_Product;
                //var lbl = e.Item.FindControl("lblAmount") as Label;
                //var hf = e.Item.FindControl("hfAmount") as HiddenField;
                //if (Request.Cookies["shop_" + product.ShopID] != null)
                //{
                //    var temp = Request.Cookies["shop_" + product.ShopID].Values[product.ProductID.ToString()];
                //    if (temp != null)
                //    {
                //        hf.Value = lbl.Text = temp;
                //    }
                //    else
                //    {
                //        hf.Value = lbl.Text = "0";
                //    }
                //}
                //else
                //{
                //    hf.Value = lbl.Text = "0";
                //}
                //lbl.Attributes["data-pid"] = product.ProductID.ToString();
            }
        }
        //生成订单并跳转
        protected void rpt_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "order":
                {
                    var rpt = e.Item.FindControl("rptProduct") as Repeater;
                    var shopId = e.CommandArgument.ToString();
                    var cookieName = "shop_" + shopId;
                    var lblList = new Dictionary<string,string>();//产品Id和数量键值对
                    rpt.Controls.OfType<RepeaterItem>().ToList().ForEach(rItem=>
                    {
                        if (rItem.ItemType==ListItemType.Item || rItem.ItemType == ListItemType.AlternatingItem)
                        {
                            lblList.Add((rItem.FindControl("lblAmount") as Label).Attributes["data-pid"],(rItem.FindControl("hfAmount") as HiddenField).Value);
                        }                        
                    });
                    var length = Request.Cookies[cookieName].Values.Keys.Count;
                    int p_num = 0;
                    for (int i = 0; i < length; i++)
                    {
                        var httpCookie = Request.Cookies[cookieName];
                        if (httpCookie != null)
                        {
                            var key = Request.Cookies[cookieName].Values.Keys[i];
                            string tmpStr=Request.Cookies[cookieName].Values[key];
                            int tmpInt = Convert.ToInt32(tmpStr);
                            p_num += tmpInt;
                            httpCookie.Values[key] = lblList.Single(p => p.Key == key).Value;
                        }
                    }
                    if (p_num <= 0)
                    {
                        WebUtil.Alert("数量必须大于0");
                        return;
                    }
                    Response.Redirect("UserSubmitOrder.aspx?shopid="+shopId);
                    break;
                }
            }
        }        
    }
}