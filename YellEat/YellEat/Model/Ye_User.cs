//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YellEat.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ye_User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string WxID { get; set; }
        public string FaceBookID { get; set; }
        public string QQ { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> LastLoginTime { get; set; }
        public System.DateTime RegisterTime { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string AptSuite { get; set; }
    }
}