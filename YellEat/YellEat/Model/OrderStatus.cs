using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YellEat.Model
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatus
    {
        已下单 = 1, //第一阶段
        已受理 = 21,//第二阶段
        已送出 = 22,
        已付款 = 31,//第三阶段
        已评价 = 32,
        已取消 = 91,//非正常阶段
        已退货 = 92
    }
}