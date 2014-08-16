using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;

namespace YellEat
{
    public partial class ShopProduct : ShopPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Request.QueryString["id"]);
                Ye_Product pro = ProductBll.GetProductById(ID);
                ProImage.ImageUrl = pro.ProductImage;
            }
        }
    }
}