using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;
using YellEat.Utility;

namespace YellEat.ShopAdmin
{
    public partial class ProductImport : ShopAdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            if (!fileUp.HasFile)
            {
                WebUtil.Alert("请先选择要上传的文件！", this);
                return;
            }
            var fileName = "";
            if (WebUtil.UploadXls(YeShopId, fileUp, "../xls/", out fileName))
            {


                DataTable dt;
                #region Excel 文件上传

                try
                {
                    if (ddlType.SelectedIndex == 1)
                    {
                        dt = ExcelUtil.Excel80ToDataSet(Server.MapPath("../xls/" + fileName)).Tables[0];
                    }
                    else
                    {
                        dt = ExcelUtil.Excel120ToDataSet(Server.MapPath("../xls/" + fileName)).Tables[0];
                    }

                }
                catch
                {
                    WebUtil.Alert("Excel 文件上传失败！请检查文件格式");
                    return;
                }
                #endregion
                int i = 2;//用于检查报错！
                try
                {
                      #region Excel 数据验证并转为实体
                    var products = new List<Ye_Product>();
                    var units = ProductBll.GetUnits().ToList();
                    Ye_ProductType productype = null;
                    Ye_Unit unit = null;
                    var existProducts = ProductBll.GetProductsByShopId(YeShopId).ToList();
                    foreach (DataRow row in dt.Rows)
                    {
                        if (existProducts.Count(p=>p.ProductName==row[1].ToString())>0)
                        {
                            break;
                        }
                        productype = YeProductTypes.SingleOrDefault(type => type.ProductTypeName == row[2].ToString());
                        if (productype == null)
                        {
                            WebUtil.Alert(string.Format("您现有的菜单分类中暂无名为“{0}”的菜单分类，请检查 Excel 文件第 {1} 行或先创建菜单分类“{0}”！", row[2], i),
                                this);
                            return;
                        }
                        unit = units.SingleOrDefault(u => u.UnitName == row[3].ToString());
                        if (unit == null)
                        {
                            WebUtil.Alert(string.Format("税金类型中暂不存在为“{0}”的税金类型，请检查 Excel 文件第 {1} 行", row[4], i),
                                this);
                            return;
                        }
                        products.Add(new Ye_Product()
                        {
                            ProductNo = row[0].ToString(), //第 1列
                            ProductName = row[1].ToString(), //第 2 列
                            ProductTypeID = productype.ProductTypeID, //第 3 列
                            UnitId = unit.UnitID,//第 4 列
                            Price = decimal.Parse(row[4].ToString()), //第 5 列
                            ProductDesc = row[5].ToString(), // 第6列                            
                            ProductImage = "",                            
                            ShopID = YeShopId,
                            Clicks = 0,
                            Discount = 0,
                            IsUpShelf = false,
                            CreateDate = DateTime.Now,
                            RecommendLevel = 0
                        });
                        i++;
                    }
                    #endregion                  
                    if (ProductBll.AddProducts(products)) WebUtil.Alert("菜单已成功创建导入！", this);
                }
                catch
                {
                    WebUtil.Alert(string.Format("Excel 文件内菜单的数据格式可能有误，请检查第 {0} 行！", i), this);
                }
                finally
                {
                    File.Delete(fileName);//删除已上传文件
                }
            }
            else
            {
                WebUtil.Alert("Excel 文件上传失败！", this);
            }
        }

    }
}