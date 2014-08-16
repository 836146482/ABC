using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using YellEat.Model;

namespace YellEat.BLL
{
    public class ShopCouponBll
    {
        private static YellEatEntities _entities = new YellEatEntities();
        /// <summary>
        /// 获取指定餐馆的优惠券
        /// </summary>
        /// <param name="shopId">餐馆 Id</param>
        /// <returns></returns>
        public static IQueryable<Ye_ShopCoupon> GetShopCouponsByShopId(int shopId)
        {
            return _entities.Ye_ShopCoupon.Where(c=>c.ShopID == shopId);
        }
        /// <summary>
        /// 获取所有优惠券
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Ye_ShopCoupon> GetShopCoupons()
        {
            return _entities.Ye_ShopCoupon;
        }
        /// <summary>
        /// 添加优惠券
        /// </summary>
        /// <param name="shopCoupon"></param>
        /// <returns></returns>
        public static bool AddShopCoupon(Ye_ShopCoupon shopCoupon)
        {
            _entities.Ye_ShopCoupon.Add(shopCoupon);
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除优惠券
        /// </summary>
        /// <param name="couponId"></param>
        /// <returns></returns>
        public static bool DeleteShopCoupon(int couponId)
        {
            var coupon = _entities.Ye_ShopCoupon.SingleOrDefault(p => p.CouponID == couponId);
            if (coupon != null) return false;
            coupon.IsShopDeleted = true;
            return _entities.SaveChanges() > 0;
        }
    }
}