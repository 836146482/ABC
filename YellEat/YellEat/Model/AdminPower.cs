using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YellEat.Model
{
    /// <summary>
    /// 管理员权限枚举    
    /// </summary>
    public enum AdminPower
    {
        会员列表 = 1,
        会员意见处理,
        会员历史订单,
        会员收藏餐馆,
        餐馆类型管理,
        加盟餐馆管理,
        餐馆反馈处理,
        修改个人密码,
        用户账号管理,
        分配权限管理,
        用户操作记录管理,
        税金管理,
        系统管理,
        用户详细信息
    }
}