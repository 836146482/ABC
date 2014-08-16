using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YellEat.Model;
using YellEat.BLL;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YellEat.YellEatAdmin
{
    /// <summary>
    /// GetShopDetail 的摘要说明
    /// </summary>
    public class GetShopDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            
            //context.Response.Write("Hello World");
            if (string.IsNullOrEmpty(context.Request.Form["shopId"]))
            {
                return;
            }
            int shopId = Convert.ToInt32(context.Request.Form["shopId"]);
            Ye_Shop shop = ShopBll.GetShopById(shopId);
            if (shop == null)
            {
                return;
            }
            string strJson = JsonConvert.SerializeObject(shop);
            context.Response.Write(strJson);
            
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