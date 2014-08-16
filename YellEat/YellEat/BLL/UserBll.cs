using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Providers.Entities;
using YellEat.Model;

namespace YellEat.BLL
{
    public class UserBll
    {
        public static YellEatEntities _entities = new YellEatEntities();
        #region 用户管理
        /// <summary>
        /// 根据用户 ID 获取用户
        /// </summary>
        /// <returns></returns>
        public static Ye_User GetUserById(int id)
        {
            return _entities.Ye_User.FirstOrDefault(user => user.UserID == id);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool AddUser(Ye_User user)
        {
            _entities.Ye_User.Add(user);
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 根据邮箱获取用户密码
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static Ye_User GetPasswordByEmail(string email)
        {
            return _entities.Ye_User.FirstOrDefault(u => u.Email == email);
        }
        /// <summary>
        /// 用户登录，使用邮箱或手机号码以及密码登录
        /// </summary>
        /// <param name="username">用户名，可以是邮箱或手机号码</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static Ye_User Login(string username, string password)
        {
            return
                _entities.Ye_User.FirstOrDefault(
                    user => user.Password == password && ( user.UserName == username||user.Email == username || user.Mobile == username));
        }
        /// <summary>
        /// 更新用户登录时间
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <returns></returns>
        public static bool UpdateUserLastLoginTime(int userId)
        {
            var user = GetUserById(userId);
            user.LastLoginTime = DateTime.Now;
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Ye_User> GetUsers()
        {
            return _entities.Ye_User;
        }
        /// <summary>
        /// 将会员拉黑
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool SetUserBlack(int userId)
        {
            var user = GetUserById(userId);
            user.Status = (int)UserStatus.被拉黑;
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 将会员加入白名单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool SetUserWhite(int userId)
        {
            var user = GetUserById(userId);
            user.Status = (int)UserStatus.正常;
            return _entities.SaveChanges() > 0;
        }
        #endregion

        #region 用户地址管理
        /// <summary>
        /// 根据用户 ID 获取地址列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static List<Ye_UserAddress> GetUserAddressesByUserId(int userid)
        {
            return _entities.Ye_UserAddress.Where(addr => addr.UserID == userid).ToList();
        }
        /// <summary>
        /// 根据 地址 Id 获取用户收货地址
        /// </summary>
        /// <param name="userAddressId">地址 id</param>
        /// <returns></returns>
        public static Ye_UserAddress GetUserAddressById(int userAddressId)
        {
            return _entities.Ye_UserAddress.FirstOrDefault(addr => addr.UserAddressID == userAddressId);
        }
        /// <summary>
        /// 更新用户收货地址
        /// </summary>
        /// <param name="userAddress">收货地址</param>
        /// <returns></returns>
        public static bool UpdateUserAddress(Ye_UserAddress userAddress)
        {
            var addr = GetUserAddressById(userAddress.UserAddressID);
            addr.Address = userAddress.Address;
            //addr.Zip = userAddress.Zip;
            //addr.AptSuite = userAddress.AptSuite;
            addr.Receiver = userAddress.Receiver;
            addr.Mobile = userAddress.Mobile;
            if (userAddress.IsDefault)
            {
                var list = GetUserAddressesByUserId(userAddress.UserID);
                list.ToList().ForEach(l => l.IsDefault = false);
                addr.IsDefault = true;
            }
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 添加用户地址
        /// </summary>
        /// <param name="userAddress">用户地址</param>
        /// <returns></returns>
        public static bool AddUserAddress(Ye_UserAddress userAddress)
        {
            _entities.Ye_UserAddress.Add(userAddress);
            return _entities.SaveChanges() > 0;
        }

        #endregion

        #region  用户收藏管理
        /// <summary>
        /// 添加用户收藏，如已收藏则不再收藏
        /// </summary>
        /// <param name="userfav"></param>
        /// <returns></returns>
        public static bool AddUserCollection(Ye_UserCollection userfav)
        {
            if (GetUserCollectionsByUserId(userfav.UserID).Count(p => p.ShopID == userfav.ShopID) > 0)
            {
                return false;
            }
            _entities.Ye_UserCollection.Add(userfav);
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 获取指定用户的收藏
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <returns></returns>
        public static IQueryable<Ye_UserCollection> GetUserCollectionsByUserId(int userId)
        {
            return _entities.Ye_UserCollection.Where(fav => fav.UserID == userId);
        }
        #endregion

        #region 用户反馈管理
        /// <summary>
        /// 添加用户反馈
        /// </summary>
        /// <param name="feedback">用户反馈</param>
        /// <returns></returns>
        public static bool AddUserFeeback(Ye_UserFeedback feedback)
        {
            _entities.Ye_UserFeedback.Add(feedback);
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除会员反馈信息
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        public static bool DeleteUserFeedback(int feedbackId)
        {
            var feedback = _entities.Ye_UserFeedback.SingleOrDefault(p => p.UserFeedbackID == feedbackId);
            if (feedback == null) return false;
            feedback.IsAdminDeleted = true;
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 获取用户反馈
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Ye_UserFeedback> GetUserFeedbacks()
        {
            return _entities.Ye_UserFeedback.Where(p => p.IsAdminDeleted == false);
        }

        #endregion
    }
}