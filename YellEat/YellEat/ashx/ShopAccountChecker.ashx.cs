using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using YellEat.BLL;

namespace YellEat.ashx
{
    /// <summary>
    /// ShopAccountChecker 的摘要说明
    /// </summary>
    public class ShopAccountChecker : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var shopAccount = context.Request["tbxUserName"];
            context.Response.Write(ShopBll.GetShops().SingleOrDefault(s => s.ShopAccount == shopAccount) == null
                ? "0"
                : "1");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}