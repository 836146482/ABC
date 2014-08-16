using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YellEat.Model
{
    /// <summary>
    /// UserStatus 标识会员状态
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// 会员状态正常
        /// </summary>
        正常 = 0,
        /// <summary>
        /// 会员状态被拉黑
        /// </summary>
        被拉黑,
    }
}