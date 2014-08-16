using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.DynamicData;
using YellEat.Model;

namespace YellEat.BLL
{
    public class ShopBll
    {
        private static YellEatEntities _entities = new YellEatEntities();
        static ShopBll()
        {
            ShopTypes = GetShopTypes();
        }
        #region 餐馆管理
        /// <summary>
        /// 修改管理登录密码
        /// </summary>
        /// <param name="yeShopId">餐馆 Id</param>
        /// <param name="newPwd">新密码</param>
        /// <returns></returns>
        public static bool ChangePassword(int yeShopId, string newPwd)
        {
            var shop = GetShopById(yeShopId);
            shop.ShopPassword = newPwd;
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 更新餐馆信息
        /// </summary>
        /// <param name="shop">餐馆</param>
        /// <returns></returns>
        public static bool UpdateShopInfo(Ye_Shop shop)
        {
            var temp = _entities.Ye_Shop.First(p => p.ShopID == shop.ShopID);
            temp.ShopFax = shop.ShopFax;
            temp.ShopMobile = shop.ShopMobile;
            temp.ShopQQ = shop.ShopQQ;
            temp.ShopAddress = shop.ShopAddress;
            temp.ShopDesc = shop.ShopDesc;
            temp.ShopEmail = shop.ShopEmail;
            temp.ShopName = shop.ShopName;
            temp.ShopZip = shop.ShopZip;
            temp.OpeningBeginMinute = shop.OpeningBeginMinute;
            temp.OpeningEndMinute = shop.OpeningEndMinute;
            temp.OpeningBeginMinute2 = shop.OpeningBeginMinute2;
            temp.OpeningEndMinute2 = shop.OpeningEndMinute2;
            temp.ShopLogoImg = shop.ShopLogoImg;
            temp.ShopMainImg = shop.ShopMainImg;
            temp.DeliveryTime = shop.DeliveryTime;
            temp.DeliveryMinPrice = shop.DeliveryMinPrice;
            temp.Latitude = shop.Latitude;
            temp.Longitude = shop.Longitude;
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 添加餐馆
        /// </summary>
        /// <param name="shop"></param>
        /// <returns></returns>
        public static bool AddShop(Ye_Shop shop)
        {
            _entities.Ye_Shop.Add(shop);
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 根据餐馆 Id 获取餐馆
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static Ye_Shop GetShopById(int shopId)
        {
            return _entities.Ye_Shop.FirstOrDefault(shop => shop.ShopID == shopId);
        }
        /// <summary>
        /// 根据餐馆类型 Id 获取餐馆列表
        /// </summary>
        /// <param name="shopTypeId"></param>
        /// <returns></returns>
        public static IQueryable<Ye_Shop> GetShopsByShopTypeId(int shopTypeId)
        {
            IQueryable<Ye_Shop> query = from shop2type in _entities.Ye_Shop2ShopType
                                        join shop in _entities.Ye_Shop on shop2type.ShopID equals shop.ShopID
                                        where shop2type.ShopTypeID == shopTypeId
                                        select shop;
            return query;
        }
        /// <summary>
        /// 获取所有餐馆
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Ye_Shop> GetShops()
        {
            return _entities.Ye_Shop;
        }
        /// <summary>
        /// 返回已经通过审核的餐馆
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Ye_Shop> GetCheckedShop()
        {
            return _entities.Ye_Shop.Where(s => s.IsChecked);
        }
        /// <summary>
        /// 获取正在营业的餐馆列表
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Ye_Shop> GetOpeningShop()
        {
            var now = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
            return _entities.Ye_Shop.Where(s => s.IsChecked &&
                                                (s.OpeningBeginMinute <= s.OpeningEndMinute
                                                    ? now >= s.OpeningBeginMinute && now <= s.OpeningEndMinute
                                                    : now > s.OpeningEndMinute || now < s.OpeningBeginMinute));
        }

        /// <summary>
        /// 餐馆管理登录
        /// </summary>
        /// <param name="account">账号名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static Ye_Shop Login(string account, string password)
        {
            var temp = _entities.Ye_Shop.FirstOrDefault(shop => shop.ShopAccount == account && shop.ShopPassword == password);
            if (temp != null)
            {
                temp.LastLoginTime = DateTime.Now;
                _entities.SaveChanges();
            }
            return temp;
        }
        /// <summary>
        /// 餐馆审核
        /// </summary>
        /// <param name="shopId">餐馆 Id</param>
        /// <param name="isChecked">是否通过审核</param>
        /// <returns></returns>
        public static bool SetShopCheckState(int shopId, bool isChecked = true)
        {
            var shop = GetShopById(shopId);
            shop.IsChecked = isChecked;
            return _entities.SaveChanges() > 0;
        }
        #endregion


        #region 餐馆类型管理
        /// <summary>
        /// 获取所有餐馆类型（静态存放）
        /// </summary>
        public static List<Ye_ShopType> ShopTypes { get; set; }
        /// <summary>
        /// 根据餐馆 Id 获取餐馆类型列表
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static List<Ye_ShopType> GetShopTypesByShopId(int shopId)
        {
            var query = from shop2type in _entities.Ye_Shop2ShopType
                        join type in _entities.Ye_ShopType on shop2type.ShopTypeID equals type.ShopTypeId
                        where shop2type.ShopID == shopId
                        select type;
            return query.ToList();
        }
        /// <summary>
        /// 获取所有餐馆类型
        /// </summary>
        /// <returns></returns>
        public static List<Ye_ShopType> GetShopTypes()
        {
            return _entities.Ye_ShopType.ToList();
        }
        /// <summary>
        /// 添加餐馆类型
        /// </summary>
        /// <param name="shopTypeName">餐馆类型</param>
        /// <returns></returns>
        public static bool AddShopType(string shopTypeName)
        {
            _entities.Ye_ShopType.Add(new Ye_ShopType() { ShopTypeName = shopTypeName });
            if (_entities.SaveChanges() > 0)
            {
                ShopTypes = GetShopTypes();
                return true;
            }
            return false;
        }
        /// <summary>
        /// 修改餐馆类型
        /// </summary>
        /// <param name="shopTypeId">餐馆类型 Id</param>
        /// <param name="shopTypeName">餐馆类型</param>
        /// <returns></returns>
        public static bool UpdateShopType(int shopTypeId, string shopTypeName)
        {
            var temp = _entities.Ye_ShopType.First(type => type.ShopTypeId == shopTypeId);
            temp.ShopTypeName = shopTypeName;
            if (_entities.SaveChanges() > 0)
            {
                ShopTypes = GetShopTypes();
                return true;
            }
            return false;
        }
        /// <summary>
        /// 删除餐馆类型
        /// </summary>
        /// <param name="shopTypeId"></param>
        /// <returns></returns>
        public static bool DeleteShopType(int shopTypeId)
        {
            var type = _entities.Ye_ShopType.Single(p => p.ShopTypeId == shopTypeId);
            _entities.Ye_ShopType.Remove(type);
            return _entities.SaveChanges() > 0;
        }

        #endregion

        #region 用户收藏管理

        /// <summary>
        /// 获取指定用户的收藏餐馆
        /// </summary>
        /// <param name="userId">用户 Id</param>
        /// <returns></returns>
        public static IQueryable<Ye_Shop> GetUserFavsByUserId(int userId)
        {
            return null;
            //查询收藏餐馆
            //var shops = from shop in _entities.Ye_Shop
            //    join fav in _entities.Ye_UserCollection on shop.ShopID equals fav.ShopID
            //    where fav.UserID == userId
            //    select new
            //    {
            //        ShopID = shop.ShopID,
            //        Clicks = shop.Clicks??0,
            //        ShopLogo = shop.ShopLogoImg,
            //        ShopName = shop.ShopName,
            //        Rank = shop.Rank,
            //        DeliveryTime = shop.DeliveryTime
            //    };
            //查询各餐馆品尝次数
            //var orderDetails = from orderdetail in _entities.Ye_OrderDetail
            //    where orderdetail.CreateUserID == userId
            //    group orderdetail by orderdetail.ShopID
            //    into g
            //    select new { ShopID = g.Key, ViewCount = g.Count()};
            //数据左联接
            //var query = from shop in shops
            //    join orderdetail in orderDetails
            //        on shop.ShopID equals orderdetail.ShopID
            //        into JoinedShopOrderDetails
            //    from orderdetail in JoinedShopOrderDetails.DefaultIfEmpty()
            //    select new ShowFav()
            //    {
            //        ShopID = shop.ShopID,
            //        ShopLogo = shop.ShopLogo,
            //        ShopName = shop.ShopName,
            //        Clicks = shop.Clicks,
            //        DeliveryTime = shop.DeliveryTime,
            //        Rank = shop.Rank,
            //        EatTimes = orderdetail.ViewCount,
            //    };
            //return query;
        }
        #endregion

        #region 意见反馈
        /// <summary>
        /// 添加餐馆反馈信息
        /// </summary>
        /// <param name="shopId">餐馆 Id</param>
        /// <param name="feedbackcontent">反馈内容</param>
        /// <returns></returns>
        public static bool AddShopFeedback(int shopId, string feedbackcontent)
        {
            var feedback = new Ye_ShopFeedback()
            {
                ShopId = shopId,
                FeedbackContent = feedbackcontent,
                IsHandled = false,
                CreateTime = DateTime.Now,
                HandleAnswer = "",
                HandledTime = DateTime.Now
            };
            _entities.Ye_ShopFeedback.Add(feedback);
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 获取执行餐馆的反馈列表
        /// </summary>
        /// <param name="shopId">餐馆 Id</param>
        /// <returns></returns>
        public static IQueryable<Ye_ShopFeedback> GetShopFeedbacksByShopId(int shopId)
        {
            return _entities.Ye_ShopFeedback.Where(fb => fb.ShopId == shopId);
        }
        /// <summary>
        /// 处理餐馆反馈
        /// </summary>
        /// <param name="feedbackId">反馈 Id</param>
        /// <param name="handleAnswer">处理意见</param>
        /// <returns></returns>
        public static bool HandleShopFeedback(int feedbackId, string handleAnswer)
        {
            var feedback = _entities.Ye_ShopFeedback.First(fd => fd.ShopFeedbackID == feedbackId);
            feedback.IsHandled = true;
            feedback.HandledTime = DateTime.Now;
            feedback.HandleAnswer = handleAnswer;
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 获取餐馆反馈信息
        /// </summary>
        public static IQueryable<Ye_ShopFeedback> GetShopFeedbacks()
        {
            return _entities.Ye_ShopFeedback;
        }
        /// <summary>
        /// 根据反馈 Id 获取餐馆反馈
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        public static Ye_ShopFeedback GetShopFeedbackById(int feedbackId)
        {
            return _entities.Ye_ShopFeedback.First(f => f.ShopFeedbackID == feedbackId);
        }

        public static bool ShopDeleteShopFeedback(int feedbackId)
        {
            var feedback = _entities.Ye_ShopFeedback.SingleOrDefault(p => p.ShopFeedbackID == feedbackId);
            if (feedback == null) return false;
            feedback.IsShopDeleted = true;
            return _entities.SaveChanges() > 0;
        }

        #endregion

        #region 餐馆及其类型对应管理
        /// <summary>
        /// 设置餐馆类型
        /// </summary>
        /// <param name="shopId">餐馆 Id</param>
        /// <param name="shopTypeIds">设为选中的餐馆类型</param>
        /// <returns></returns>
        public static bool SetShopTypeChecked(int shopId, List<int> shopTypeIds)
        {
            using (var tran = _entities.Database.BeginTransaction())
            {
                var existsShopTypes = _entities.Ye_Shop2ShopType.Where(s => s.ShopID == shopId).ToList();
                var addShop2ShopTypes = new List<Ye_Shop2ShopType>();

                #region 遍历所有餐馆类型,无则添加，有则设为选中

                Ye_Shop2ShopType temp;
                foreach (var type in ShopTypes)
                {
                    temp = existsShopTypes.SingleOrDefault(t => t.ShopTypeID == type.ShopTypeId);
                    if (temp == null)
                    {
                        //如果存在的 Shop2ShopType 还不存在该餐馆类型，则添加
                        addShop2ShopTypes.Add(new Ye_Shop2ShopType()
                        {
                            ShopID = shopId,
                            IsShopTypeChecked = true,
                            ShopTypeID = type.ShopTypeId
                        });
                    }
                    else //如果找到 Shop2ShopType 
                    {
                        temp.IsShopTypeChecked = true;
                    }
                }
                #endregion

                #region 将原来选中设置为不选中
                foreach (var type in existsShopTypes.Where(p => p.IsShopTypeChecked))
                {
                    if (!shopTypeIds.Contains(type.ShopTypeID))
                    {
                        type.IsShopTypeChecked = false;
                    }
                }
                #endregion
                _entities.Ye_Shop2ShopType.AddRange(addShop2ShopTypes);
                var result = _entities.SaveChanges() > 0;
                tran.Commit();
                return result;
            }
        }
        /// <summary>
        /// 获取餐馆选定的餐馆类型 Id
        /// </summary>
        /// <param name="shopId">餐馆 Id</param>
        /// <returns></returns>
        public static List<Ye_ShopType> GetCheckedShopTypesByShopId(int shopId)
        {
            var query = from shopType in _entities.Ye_ShopType
                        join shop2shoptype in _entities.Ye_Shop2ShopType on shopType.ShopTypeId equals shop2shoptype.ShopTypeID
                        where shop2shoptype.ShopID == shopId && shop2shoptype.IsShopTypeChecked
                        select shopType;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Ye_Shop2ShopType> GetShop2ShopTypes()
        {
            return _entities.Ye_Shop2ShopType;
        }

        #endregion

    }
}