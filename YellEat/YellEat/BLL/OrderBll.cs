using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.Util;
using DotNetOpenAuth.Messaging;
using YellEat.Model;
using YellEat.Utility;

namespace YellEat.BLL
{
    public class OrderBll
    {
        private static YellEatEntities _entities = new YellEatEntities();
        #region 订单处理
        /// <summary>
        /// 获取指定用户的所有订单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static IQueryable<Ye_Order> GetOrdersByUserId(int userId)
        {
            return _entities.Ye_Order.Where(o => o.UserID == userId);
        }
        /// <summary>
        /// 获取指定餐馆的订单
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static IQueryable<Ye_Order> GetOrdersByShopId(int shopId)
        {
            return _entities.Ye_Order.Where(o => o.ShopID == shopId);
        }
        /// <summary>
        /// 获取所有订单
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Ye_Order> GetOrders()
        {
            return _entities.Ye_Order;
        }
        /// <summary>
        /// 根据 Id 获取订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static Ye_Order GetOrderByID(int orderId)
        {
            return _entities.Ye_Order.SingleOrDefault(p=>p.OrderID==orderId);
        }
        /// <summary>
        /// 根据菜单Id获取与之相关的订单
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static List<int> GetOrderIDsByProductId(int productId)
        {
            return _entities.Ye_OrderDetail.Where(o => o.ProductID == productId).Select(o=>o.OrderID).ToList();
        }


        /// <summary>
        /// 餐馆删除订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static bool ShopDeleteOrder(int orderId)
        {
            var order = _entities.Ye_Order.SingleOrDefault(p => p.OrderID == orderId);
            if (order == null) return false;
            order.IsShopDeleted = true;
            return _entities.SaveChanges() > 0;
        }

       
        /// <summary>
        /// 用户删除订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static bool UserDeleteOrder(int orderId)
        {
            var order = _entities.Ye_Order.SingleOrDefault(p => p.OrderID == orderId);
            if (order == null) return false;
            order.IsUserDeleted = true;
            return _entities.SaveChanges() > 0;
        }
        #endregion
        #region 订单项处理
        /// <summary>
        /// 获取指定订单的订单项
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static IQueryable<Ye_OrderDetail> GetOrderDetailsByOrderID(int orderId)
        {
            return _entities.Ye_OrderDetail.Where(detail => detail.OrderID == orderId);
        }
        /// <summary>
        /// 获取所有订单项
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Ye_OrderDetail> GetOrderDetails()
        {
            return _entities.Ye_OrderDetail;
        }        
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="order">订单详情</param>
        /// <param name="orderDetails">订单明细</param>
        /// <returns></returns>
        public static bool AddOrder(Ye_Order order, List<Ye_OrderDetail> orderDetails)
        {
            order.Ye_OrderDetail = orderDetails;
            _entities.Ye_Order.Add(order);
            return _entities.SaveChanges() > 0;
        }
        #endregion

        #region 订单评价
        /// <summary>
        /// 获取指定用户的订单评价
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static IQueryable<Ye_OrderResult> GetOrderResultsByUserId(int userId)
        {
            return _entities.Ye_OrderResult.Where(o => o.UserID == userId);
        }
        /// <summary>
        /// 获取指定餐馆的用餐评价
        /// </summary>
        /// <param name="shopId">餐馆 Id</param>
        /// <returns></returns>
        public static IQueryable<Ye_OrderResult> GetOrderResultsByShopId(int shopId)
        {
            return _entities.Ye_OrderResult.Where(p => p.ShopID == shopId);
        }
        /// <summary>
        /// 添加订单评价
        /// </summary>
        /// <param name="orderResult">订单评价</param>
        /// <returns></returns>
        public static bool AddOrderResult(Ye_OrderResult orderResult)
        {
            _entities.Ye_OrderResult.Add(orderResult);
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 获取指定订单的用餐评价
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static Ye_OrderResult GetOrderResultByOrderID(int orderId)
        {
            return _entities.Ye_OrderResult.FirstOrDefault(p => p.OrderID == orderId);
        }

        #endregion
        /// <summary>
        /// 生成订单码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string CreateOrderSN(int userId)
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("{0:X}", userId).PadLeft(4, '0'));
            sb.Append(DateTime.Now.ToString("yyyyMMddHHmmss"));
            return sb.ToString();
        }
      
    }
}