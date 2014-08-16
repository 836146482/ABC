using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using YellEat.Model;

namespace YellEat
{
    public class UserPageBase:Page
    {
        /// <summary>
        /// 获取或设置当前用户
        /// </summary>
        public Ye_User YeUser
        {
            get
            {
                return (Ye_User)Session["YeUser"];
            }
            set
            {
                Session["YeUser"] = value;
            }
        }

        public UserPageBase()
        {
            this.Load += (obj, e) =>
            {
                if (YeUser == null)
                {
                    Response.Redirect("UserLogin.aspx");
                    Response.End();
                }
            };
        }
    }
}