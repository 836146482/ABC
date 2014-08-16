using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;
using YellEat.Utility;

namespace YellEat.ShopAdmin
{
    public class ShopAdminPageBase:Page
    {
        /// <summary>
        /// 餐馆 ID
        /// </summary>
        protected int YeShopId
        {
            get { return (int)Session["YeShopId"]; }
            set { Session["YeShopId"] = value; }
        }
        /// <summary>
        /// 获取或设置餐馆信息
        /// </summary>
        protected Ye_Shop YeShop
        {
            get { return (Ye_Shop) (Cache["Ye_Shop"] ?? (Cache["Ye_Shop"] = ShopBll.GetShopById(YeShopId))); }
            set { Cache["Ye_Shop"] = value; }
        }
        /// <summary>
        /// 获取或设置餐馆的菜单类型列表
        /// </summary>
        protected List<Ye_ProductType> YeProductTypes
        {
            get { return (List<Ye_ProductType>)(Cache["YeProductTypes"] ?? (Cache["YeProductTypes"] = ProductBll.GetProductTypesByShopId(YeShopId))); }
            set { Cache["YeProductTypes"] = value; }
        }
        protected override void OnLoad(EventArgs e)
        {
            if (Session["YeShopId"] == null)
            {
                WebUtil.AlertAndRedirect("对不起，您登录超时了！请重新登录！", "Login.aspx");
            }
            (this.Master.FindControl("ltlCurrentShop") as Literal).Text = YeShop.ShopAccount;
            base.OnLoad(e);
        }
       
    }
}