﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class YellEatEntities : DbContext
    {
        public YellEatEntities()
            : base("name=YellEatEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Ye_Admin2AdminPower> Ye_Admin2AdminPower { get; set; }
        public virtual DbSet<Ye_Administrator> Ye_Administrator { get; set; }
        public virtual DbSet<Ye_AdminLog> Ye_AdminLog { get; set; }
        public virtual DbSet<Ye_AdminPower> Ye_AdminPower { get; set; }
        public virtual DbSet<Ye_Order> Ye_Order { get; set; }
        public virtual DbSet<Ye_OrderDetail> Ye_OrderDetail { get; set; }
        public virtual DbSet<Ye_OrderResult> Ye_OrderResult { get; set; }
        public virtual DbSet<Ye_Product> Ye_Product { get; set; }
        public virtual DbSet<Ye_ProductType> Ye_ProductType { get; set; }
        public virtual DbSet<Ye_Shop> Ye_Shop { get; set; }
        public virtual DbSet<Ye_Shop2ShopType> Ye_Shop2ShopType { get; set; }
        public virtual DbSet<Ye_ShopCoupon> Ye_ShopCoupon { get; set; }
        public virtual DbSet<Ye_ShopFeedback> Ye_ShopFeedback { get; set; }
        public virtual DbSet<Ye_ShopType> Ye_ShopType { get; set; }
        public virtual DbSet<Ye_Unit> Ye_Unit { get; set; }
        public virtual DbSet<Ye_User> Ye_User { get; set; }
        public virtual DbSet<Ye_UserAddress> Ye_UserAddress { get; set; }
        public virtual DbSet<Ye_UserCollection> Ye_UserCollection { get; set; }
        public virtual DbSet<Ye_UserCoupon> Ye_UserCoupon { get; set; }
        public virtual DbSet<Ye_UserFeedback> Ye_UserFeedback { get; set; }
    }
}