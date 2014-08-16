using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Web;
using YellEat.Model;

namespace YellEat.BLL
{
    public class ProductBll
    {
        private static YellEatEntities _entities = new YellEatEntities();
        
        #region 菜单管理
        /// <summary>
        /// 获取所有餐馆的菜单
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Ye_Product> GetProducts()
        {
            return _entities.Ye_Product;
        }
        /// <summary>
        /// 获取指定餐馆的菜单
        /// </summary>
        /// <param name="shopId">餐馆 Id</param>
        /// <returns></returns>
        public static IQueryable<Ye_Product> GetProductsByShopId(int shopId)
        {
            return _entities.Ye_Product.Where(p => p.ShopID == shopId);
        }
        public static IEnumerable<Ye_Product>GetProductByCondition(Expression<Func<Ye_Product,bool>>where)
        {
            return _entities.Ye_Product.Where(where);
        }
        /// <summary>
        /// 根据菜单 Id 获取菜单
        /// </summary>
        /// <param name="productId">菜单 Id</param>
        /// <returns></returns>
        public static Ye_Product GetProductById(int productId)
        {
            return _entities.Ye_Product.SingleOrDefault(p => p.ProductID == productId);
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="product">菜单</param>
        /// <returns></returns>
        public static bool AddProduct(Ye_Product product)
        {
            _entities.Ye_Product.Add(product);
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 添加多个菜单
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public static bool AddProducts(IEnumerable<Ye_Product> products)
        {
            _entities.Ye_Product.AddRange(products);
            return _entities.SaveChanges() >0 ;
        }

        /// <summary>
        /// 修改菜单信息
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static bool UpdateProduct(Ye_Product product)
        {
            var p = ProductBll.GetProductById(product.ProductID);
            p.ProductNo = product.ProductNo;
            p.ProductName = product.ProductName;
            p.RecommendLevel = product.RecommendLevel;
            p.ProductImage = product.ProductImage;
            p.ProductDesc = product.ProductDesc;
            p.Price = product.Price;
            p.UnitId = product.UnitId;
            p.ProductTypeID = product.ProductTypeID;
            return _entities.SaveChanges() > 0;
        }

        /// <summary>
        /// 检查菜单是否在订单中出现过
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static bool CheckProduct(int productId)
        {
            int count=_entities.Ye_OrderDetail.Count(o => o.ProductID == productId);
            if(count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="productId">菜单 Id</param>
        /// <returns></returns>
        public static bool DeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            if(product == null) return false;
            _entities.Ye_Product.Remove(product);
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除菜单列表
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns></returns>
        public static bool DeleteProducts(List<int> productIds)
        {
            var products = _entities.Ye_Product.Where(p => productIds.Contains(p.ProductID));
            _entities.Ye_Product.RemoveRange(products.ToArray());
            return _entities.SaveChanges() > 0;
        }
        

        /// <summary>
        /// 设置产品上下架状态
        /// </summary>
        /// <param name="productId">产品 Id</param>
        /// <param name="upShelf">是否上架，默认上架</param>
        /// <returns></returns>
        public static bool SetProductSaleState(int productId,bool upShelf = true)
        {
            var p = GetProductById(productId);
            p.IsUpShelf = upShelf;
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 设置产品列表上下架状态
        /// </summary>
        /// <param name="productIds">产品 Id 列表</param>
        /// <param name="upShelf">是否上架，默认上架</param>
        /// <returns></returns>
        public static bool SetProductsSaleState(List<int> productIds, bool upShelf = true)
        {
            var products = _entities.Ye_Product.Where(p => productIds.Contains(p.ProductID));
            products.ToList().ForEach(p=>p.IsUpShelf = upShelf);
            return _entities.SaveChanges() > 0;
        }
        #endregion

        #region 菜单分类管理
        /// <summary>
        /// 获取所有菜单分类
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Ye_ProductType> GetProductTypes()
        {
            return _entities.Ye_ProductType;
        }

        /// <summary>
        /// 获取指定商家的菜单类型
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static List<Ye_ProductType> GetProductTypesByShopId(int shopId)
        {
            return _entities.Ye_ProductType.Where(type => type.ShopID == shopId).ToList();
        }
        /// <summary>
        /// 添加菜单分类
        /// </summary>
        /// <param name="shopId">餐馆 Id</param>
        /// <param name="productTypeName">分类名称</param>
        /// <returns></returns>
        public static bool AddProductType(int shopId, string productTypeName)
        {
            var type = new Ye_ProductType()
            {
                ShopID = shopId,
                ProductTypeName = productTypeName
            };
            _entities.Ye_ProductType.Add(type);
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 修改菜单分类
        /// </summary>
        /// <param name="productTypeId">菜单分类 Id</param>
        /// <param name="productTypeName">菜单分类名称</param>
        /// <returns></returns>
        public static bool UpdateProductType(int productTypeId, string productTypeName)
        {
            var type = _entities.Ye_ProductType.First(t => t.ProductTypeID == productTypeId);
            type.ProductTypeName = productTypeName;
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除菜单类型并删除菜单
        /// </summary>
        /// <param name="productTypeId">菜单类型 Id</param>
        /// <returns></returns>
        public static bool DeleteProductTypeAndProducts(int productTypeId)        
        {
            using (var tran = _entities.Database.BeginTransaction())
            {
                var productType = _entities.Ye_ProductType.SingleOrDefault(type => type.ProductTypeID == productTypeId);
                _entities.Ye_ProductType.Remove(productType);
                var products = _entities.Ye_Product.Where(p=>p.ProductTypeID==productTypeId);
                _entities.Ye_Product.RemoveRange(products);
                var result = _entities.SaveChanges() > 0;
                tran.Commit();
                return result;
            }
        }

        #endregion

        #region 税金管理
        /// <summary>
        /// 添加税金
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static bool AddUnit(Ye_Unit unit)
        {
            _entities.Ye_Unit.Add(unit);
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 获取税金列表
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Ye_Unit> GetUnits()
        {
            return _entities.Ye_Unit;
        }
        /// <summary>
        /// 获取税金
        /// </summary>
        /// <returns></returns>
        public static Ye_Unit GetUnitById(int unitId)
        {
            return _entities.Ye_Unit.FirstOrDefault(o => o.UnitID == unitId);
        }
        /// <summary>
        /// 更新税金
        /// </summary>
        /// <param name="unitId">税金 Id</param>
        /// <param name="unitName">税金名称</param>
        /// <param name="unitPoint">税金百分比</param>
        /// <returns></returns>
        public static bool UpdateUnit(int unitId, string unitName, decimal unitPoint)
        {
            var unit = _entities.Ye_Unit.Single(u => u.UnitID == unitId);
            unit.UnitName = unitName;
            unit.UnitPoint = unitPoint;
            return _entities.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除税金
        /// </summary>
        /// <param name="unitId">税金 Id</param>
        /// <returns></returns>
        public static bool DeleteUnit(int unitId)
        {
            var unit = _entities.Ye_Unit.Single(u => u.UnitID == unitId);
            _entities.Ye_Unit.Remove(unit);
            return _entities.SaveChanges() > 0;
        }
        #endregion

    }
}