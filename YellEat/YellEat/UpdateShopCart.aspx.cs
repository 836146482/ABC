using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YellEat
{
    public partial class UpdateShopCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string data=Request.Form["data"];
            string[] arr=data.Split(',');
            string shopId = arr[0];
            string productId=arr[1];
            if (Request.Cookies["shop_" + shopId] == null)
            {
                var cookie = new HttpCookie("shop_" + shopId);//初使化并设置Cookie的名称                        
                cookie.Expires = DateTime.MaxValue;//设置过期时间
                Response.AppendCookie(cookie);
            }
            if (Request.Cookies["allAmount"] == null)
            {
                var cookie = new HttpCookie("allAmount");
                cookie.Expires = DateTime.MaxValue;
                Response.AppendCookie(cookie);
            }
            string strNum = Request.Cookies["shop_"+shopId].Values[productId];
            int AllNum = Convert.ToInt32(Request.Cookies["allAmount"].Value);
            int intNum = Convert.ToInt32(strNum);
            if(Request.Form["item"].Equals("add")){
                intNum++;
                AllNum++;
            }else
            {
                intNum--;
                AllNum--;
            }
            Response.Cookies["shop_" + shopId].Values[productId] = intNum.ToString();
            Response.Cookies["allAmount"].Value = AllNum.ToString();
            //Response.Write(strNum);
        }
    }
}