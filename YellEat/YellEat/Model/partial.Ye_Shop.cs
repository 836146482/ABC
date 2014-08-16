using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace YellEat.Model
{
    public partial class Ye_Shop
    {
         /// <summary>
        /// 获取餐馆是否正在营业
        /// </summary>
        public bool IsOpenNow
        {
            get
            {
                var now = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
                if (OpeningBeginMinute <= OpeningEndMinute)
                {
                    return now >= OpeningBeginMinute && now <= OpeningEndMinute;
                }
                else
                {
                    return now > OpeningEndMinute || now < OpeningBeginMinute;
                }
            }
        }
        /// <summary>
        /// 获取餐馆的营业时间
        /// </summary>
        public string OpenTime
        {
            get
            {
                var sb = new StringBuilder();
                var temp = OpeningBeginMinute/60;
                sb.Append(temp> 9 ? temp.ToString():"0"+temp.ToString());
                sb.Append(":");
                temp = OpeningBeginMinute%60;
                sb.Append(temp > 9 ? temp.ToString() : "0" + temp.ToString());
                sb.Append("-");
                temp = OpeningEndMinute/60;
                sb.Append(temp > 9 ? temp.ToString() : "0" + temp.ToString());
                sb.Append(":");
                temp = OpeningEndMinute%60;
                sb.Append(temp > 9 ? temp.ToString() : "0" + temp.ToString());
                return sb.ToString();
            }
        }
    }   
}