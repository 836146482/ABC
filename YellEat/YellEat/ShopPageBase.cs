using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using YellEat.Model;

namespace YellEat
{
    public class ShopPageBase:Page
    {
        /// <summary>
        /// 当前正在访问的餐馆
        /// </summary>
        public Ye_Shop VisitingShop
        {
            get { return (Ye_Shop)Session["VisitingShop"]; }
            set { Session["VisitingShop"] = value; }
        }

        public ShopPageBase()
        {
            this.Load += (sender, args) =>
            {
                if (VisitingShop == null)
                {
                    Response.Redirect("ShopList.aspx");
                    Response.End();
                }
            };
        }
    }
}