using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YellEat
{
    public class ShopCartNum
    {
        //获取购物车数量
        public int GetShopCartNum()
        {
            int sum = 0;
            var keys = HttpContext.Current.Request.Cookies.Keys;
            foreach (string key in keys)
            {
                if (key.StartsWith("shop_"))
                {
                    var productIds = HttpContext.Current.Request.Cookies[key].Values.Keys;
                    foreach (string productId in productIds)
                    {
                        var productNum = HttpContext.Current.Request.Cookies[key].Values[productId];
                        if (productNum != null)
                        {
                            int num = Convert.ToInt32(productNum);
                            sum += num;
                        }
                    }
                }
            }
            return sum;
        }
    }
}