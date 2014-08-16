using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;

namespace YellEat.Utility
{
    public class ExcelUtil
    {
        /// <summary>
        /// 将 Excel 2003 版本以下的 Execl 数据导入到 DataSet
        /// </summary>
        /// <param name="xlsPath">Excel 路径</param>
        /// <param name="sheetIndex">工作簿的索引</param>
        /// <param name="hdr">工作簿首行行为</param>
        /// <returns></returns>
        public static DataSet Excel80ToDataSet(string xlsPath,int sheetIndex = 1,HDR hdr = HDR.YES)
        {
            if (!File.Exists(xlsPath))
            {
                throw new FileNotFoundException("xlsPath");
            }
            if (sheetIndex < 0)
            {
                throw new ArgumentOutOfRangeException("sheetIndex","参数 sheetIndex 必须大于等于 1");
            }
            var strConn =
                string.Format(
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= {0};Extended Properties='Excel 8.0;HDR={1};IMEX=1';",xlsPath,hdr.ToString());                       
            using ( var conn = new OleDbConnection(strConn))
            {
                conn.Open();
                var cmd = new OleDbCommand(string.Format("SELECT * From [sheet{0}$]",sheetIndex),conn);
                var da = new OleDbDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
        }
        /// <summary>
        /// 将 Excel 2003 版本以下的 Execl 数据导入到 DataSet
        /// </summary>
        /// <param name="xlsPath">Excel 路径</param>
        /// <param name="sheetIndex">工作簿的索引</param>
        /// <param name="hdr">工作簿首行行为</param>
        /// <returns></returns>
        public static DataSet Excel120ToDataSet(string xlsPath, int sheetIndex = 1, HDR hdr = HDR.YES)
        {
            if (!File.Exists(xlsPath))
            {
                throw new FileNotFoundException("xlsPath");
            }
            if (sheetIndex < 0)
            {
                throw new ArgumentOutOfRangeException("sheetIndex", "参数 sheetIndex 必须大于等于 1");
            }
            var strConn =
                string.Format(
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= {0};Extended Properties='Excel 12.0 Xml;HDR={1};IMEX=1';", xlsPath, hdr.ToString());
            using (var conn = new OleDbConnection(strConn))
            {
                conn.Open();
                var cmd = new OleDbCommand(string.Format("SELECT * From [sheet{0}$]", sheetIndex),conn);
                var da = new OleDbDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
        }    
    }
    /// <summary>
    /// IMEX 模式，Excel 操作的模式
    /// </summary>
    public enum IMEX
    {
        /// <summary>
        /// 导入模式，只写
        /// </summary>
        Export = 0,
        /// <summary>
        /// 导入模式，只读
        /// </summary>
        Import = 1,
        /// <summary>
        /// 连接模式
        /// </summary>
        Linked = 2
    }
    /// <summary>
    /// HDR 模式，Excel 工作簿 第一行行为
    /// </summary>
    public enum HDR
    {
        /// <summary>
        /// 第一行是标题
        /// </summary>
        YES,
        /// <summary>
        /// 第一行不是标题
        /// </summary>
        NO
    }
}