using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YellEat.Model;

namespace YellEat.BLL
{
    /// <summary>
    /// YellEat 管理员管理类
    /// </summary>
    public class AdministratorBll
    {
        private static YellEatEntities _entities = new YellEatEntities();

        #region 管理员管理
        /// <summary>
        /// 根据管理员 ID 获取管理员
        /// </summary>
        /// <param name="adminId">管理员 ID</param>
        /// <returns></returns>
        public static Ye_Administrator GetAdministratorById(int adminId)
        {
            return _entities.Ye_Administrator.FirstOrDefault();
        }
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="account">账号名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static Ye_Administrator Login(string account, string password)
        {
            var admin = _entities.Ye_Administrator.FirstOrDefault(a => a.Account == account && a.Password == password);
            if (admin != null)
            {
                admin.LastLoginTime = DateTime.Now;
                _entities.SaveChanges();
            }
            return admin;
        }
        /// <summary>
        /// 管理员更换密码
        /// </summary>
        /// <param name="administratorId">管理员Id</param>
        /// <param name="password">新密码</param>
        /// <returns></returns>
        public static bool ChangePassword(int administratorId,string password)
        {
            var admin = GetAdministratorById(administratorId);
            admin.Password = password;
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Ye_Administrator> GetAdministrators()
        {
            return _entities.Ye_Administrator;
        }
        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="adminId">管理员 Id</param>
        /// <returns></returns>
        public static bool DeleteAdministrator(int adminId)
        {
            var temp = GetAdministratorById(adminId);
            if (temp == null) return false;
            _entities.Ye_Administrator.Remove(temp);
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除多个管理员
        /// </summary>
        /// <param name="adminIds">要删除的管理员 Id列表</param>
        /// <returns></returns>
        public static bool DeleteAdministrators(List<int> adminIds)
        {
            var temp = _entities.Ye_Administrator.Where(a => adminIds.Contains(a.AdministratorID));
            _entities.Ye_Administrator.RemoveRange(temp);
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 添加新的管理员
        /// </summary>
        /// <param name="administrator"></param>
        /// <returns></returns>
        public static bool AddAdministrator(Ye_Administrator administrator)
        {
            _entities.Ye_Administrator.Add(administrator);
            return _entities.SaveChanges() > 0;
        }
        #endregion

        #region 权限管理
        /// <summary>
        /// 获取管理员权限表
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Ye_AdminPower> GetAdminPowers()
        {
            return _entities.Ye_AdminPower;
        }
        /// <summary>
        /// 获取管理员权限 ID 列表
        /// </summary>
        /// <param name="adminId">管理员 ID</param>
        /// <returns></returns>
        public static List<int> GetAdminPowerByAdminId(int adminId)
        {
            var query = from power in _entities.Ye_Admin2AdminPower
                        join admin in _entities.Ye_Administrator on power.AdministratorID equals admin.AdministratorID
                where admin.AdministratorID == adminId
                select power.AdminPowerID;
            return query.ToList();

        }
        /// <summary>
        /// 更新管理员权限列表
        /// </summary>
        /// <param name="adminId">管理员 Id</param>
        /// <param name="intList">管理员拥有的权限</param>
        /// <returns>更新是否成功</returns>
        public static bool UpdateAdminPower(int adminId, List<int> intList)
        {
            var powers = _entities.Ye_Admin2AdminPower.Where(p => p.AdministratorID == adminId);
            _entities.Ye_Admin2AdminPower.RemoveRange(powers);
            var newPowers = new List<Ye_Admin2AdminPower>();
            intList.ForEach(p=>newPowers.Add(new Ye_Admin2AdminPower(){AdministratorID = adminId,IsAdminAuthorized = true}));
            _entities.Ye_Admin2AdminPower.AddRange(newPowers);
            return _entities.SaveChanges() > 0;
        }

        #endregion

        #region 管理员日志
        /// <summary>
        /// 添加管理员日志
        /// </summary>
        /// <param name="log"></param>
        public static void AddAdminLog(Ye_AdminLog log)
        {
            _entities.Ye_AdminLog.Add(log);
            _entities.SaveChanges();
        }
        /// <summary>
        /// 删除管理员日志
        /// </summary>
        /// <param name="logId"></param>
        public static void DeleteAdminLog(int logId)
        {
            var log = _entities.Ye_AdminLog.SingleOrDefault(p => p.LogID == logId);
            if (log == null) return;
            _entities.Ye_AdminLog.Remove(log);
        }
        /// <summary>
        /// 删除一系列管理员日志
        /// </summary>
        /// <param name="logList"></param>
        public static void DeleteAdminLogs(List<int> logList)
        {
            var logs = _entities.Ye_AdminLog.Where(l => logList.Contains(1));
            _entities.Ye_AdminLog.RemoveRange(logs);
        }
        /// <summary>
        /// 获取所有管理员日志
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Ye_AdminLog> GetAdminLogs()
        {
            return _entities.Ye_AdminLog;
        }

        #endregion
    }
}