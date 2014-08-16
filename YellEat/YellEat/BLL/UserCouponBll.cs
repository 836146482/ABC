using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YellEat.Model;

namespace YellEat.BLL
{
    public class UserCouponBll
    {
        private static YellEatEntities _entities = new YellEatEntities();
        /// <summary>
        /// 获取指定用户的优惠券
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <returns></returns>
        public static IQueryable<Ye_UserCoupon> GetUserCouponsByUserId(int userId)
        {
            return _entities.Ye_UserCoupon.Where(c => c.UserId == userId);
        }
        /// <summary>
        /// 添加用户优惠券
        /// </summary>
        /// <param name="userCoupon"></param>
        /// <returns></returns>
        public static bool AddShopCoupon4User(Ye_UserCoupon userCoupon)
        {
            _entities.Ye_UserCoupon.Add(userCoupon);
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 判断用户是否已添加指定优惠券
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <param name="shopCouponId">优惠券 Id</param>
        /// <returns></returns>
        public static bool ExistsShopCoupon(int userId,int shopCouponId)
        {
            return _entities.Ye_UserCoupon.SingleOrDefault(u => u.UserId==userId && u.CouponId == shopCouponId) != null;
        }
        /// <summary>
        /// 使用优惠券
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <param name="userCouponId">优惠券 Id</param>
        /// <returns></returns>
        public static bool UseCoupon(int userId,int userCouponId)
        {
            var userCoupone = _entities.Ye_UserCoupon.SingleOrDefault(p => p.UserCouponId == userCouponId);
            if (userCoupone!= null)
            {
                userCoupone.IsUsed = true;
                return _entities.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}