using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YellEat
{
    public partial class Mobile : System.Web.UI.MasterPage
    {
        //购物车数量
        protected int cartNum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //ShopCartNum shopCartNum =new ShopCartNum();
            //cartNum=shopCartNum.GetShopCartNum();
        }
    }
}