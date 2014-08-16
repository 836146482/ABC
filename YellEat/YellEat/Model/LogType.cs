using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YellEat.Model
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        登录系统,
        退出系统,
        添加管理员,
        修改权限,
        修改密码,
        餐馆管理,
        会员管理,
        反馈处理,
        删除管理员
    }
}