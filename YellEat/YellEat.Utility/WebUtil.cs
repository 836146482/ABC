using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YellEat.Utility
{
    public class WebUtil
    {
        /// <summary>
        /// 向客户端输出警告框
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="page"></param>
        public static void Alert(string msg, Page page = null)
        {
            if (page == null)
            {
                HttpContext.Current.Response.Write(string.Format("<script type='text/javascript'>alert('{0}');</script>", msg));
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertandreload", string.Format("<script>alert('{0}');</script>", msg), false);
            }
        }
        /// <summary>
        /// 向客户端输出警告框并且重定向
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="page"></param>
        public static void AlertAndRedirect(string msg, string page)
        {
            HttpContext.Current.Response.Write(
                string.Format("<script>alert('{0}');location.href='{1}';</script>",
                msg, page));
            HttpContext.Current.Response.End();

        }
        /// <summary>
        /// 向客户端输出警告框并且重定向的 Ajax 版本
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="gotoPage"></param>
        /// <param name="page"></param>
        public static void AlertAndRedirect(string msg, string gotoPage, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertandredirect", string.Format("alert('{0}');location.href='{1}';", msg, gotoPage), true);
        }

        /// <summary>
        /// 向客户端提示没有权限
        /// </summary>
        public static void AlertNoPower()
        {
            AlertAndHistoryBack("对不起，您无权访问该页面！");
        }
        /// <summary>
        /// 向客户端输出警告信息并刷新当前页面
        /// </summary>
        /// <param name="msg"></param>
        public static void AlertAndReload(string msg)
        {
            HttpContext.Current.Response.Write(string.Format("<script>alert('{0}');location.reload();</script>", msg));
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 向客户端输出警告信息并刷新当前页面的Ajax版本
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="page"></param>
        public static void AlertAndReload(string msg, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertandreload", string.Format("<script>alert('{0}');location.reload();</script>", msg), false);
        }

        /// <summary>
        /// 向客户端输出警告信息并返回上一个页面
        /// </summary>
        /// <param name="msg"></param>
        public static void AlertAndHistoryBack(string msg)
        {
            HttpContext.Current.Response.Write(string.Format("<script>alert('{0}');history.go(-1);</script>", msg));
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 向客户端输出信息并返回上一页的 Ajax 版本
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="page"></param>
        public static void AlertAndHistoryBack(string msg, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertandhistoryback", string.Format("alert('{0}');history.back()", msg), true);
        }

        /// <summary>
        /// 创建面包屑导航条,根据参数 locations 以 Index 索引为 0 作为根
        /// </summary>
        /// <param name="locations">包含位置名和超链接的元组</param>
        /// <param name="seperator">路径分割符</param>
        /// <returns></returns>
        public static string CreateBreadcrumbs(List<Tuple<string, string>> locations, string seperator = "&gt;")
        {
            var count = locations.Count - 1;
            var sb = new StringBuilder();
            var i = 0;
            for (; i < count; i++)
            {
                sb.AppendFormat("<span><a title='{0}' href='{1}'>{0}</a><span>"
                          + "<span>&nbsp;{2}&nbsp;</span>", locations[i].Item1, locations[i].Item2, seperator);
            }
            sb.AppendFormat("<span><a title='{0}' href='{1}'>{0}</a><span>", locations[i].Item1, locations[i].Item2);
            return sb.ToString();
        }
        /// <summary>
        /// 是否是来自手机端的Web请求
        /// </summary>
        /// <returns></returns>
        public static bool IsMoblieRequest()
        {
            string agent = (HttpContext.Current.Request.UserAgent + "").ToLower().Trim();

            if (agent == "" ||
                agent.IndexOf("mobile") != -1 ||
                agent.IndexOf("mobi") != -1 ||
                agent.IndexOf("nokia") != -1 ||
                agent.IndexOf("samsung") != -1 ||
                agent.IndexOf("sonyericsson") != -1 ||
                agent.IndexOf("mot") != -1 ||
                agent.IndexOf("blackberry") != -1 ||
                agent.IndexOf("lg") != -1 ||
                agent.IndexOf("htc") != -1 ||
                agent.IndexOf("j2me") != -1 ||
                agent.IndexOf("ucweb") != -1 ||
                agent.IndexOf("opera mini") != -1 ||
                agent.IndexOf("mobi") != -1 ||
                agent.IndexOf("android") != -1 ||
                agent.IndexOf("iphone") != -1)
            {
                //终端可能是手机
                return true;
            }
            return false;
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="fup">文件上传控件</param>
        /// <param name="savePath">保存路径，如../upload/</param>
        /// <param name="allowExt">允许上传的字符串</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static bool UploadImage(FileUpload fup, string savePath, string[] allowExt, out string fileName)
        {
            string fileExtension = System.IO.Path.GetExtension(fup.FileName).ToLower();
            if (!allowExt.Contains(fileExtension.ToLower()))
            {
                fileName = "";
                return false;
            }

            var rand = new Random();
            var r = rand.Next(1, 100);
            fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_p" + r + fileExtension;
            fup.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(savePath) + fileName);
            return true;
        }

        /// <summary>
        /// 上传 xsl
        /// </summary>
        /// <param name="shopId">餐馆 Id</param>
        /// <param name="fup">文件上传控件</param>
        /// <param name="savePath">保存路径，如 ../upload/</param>
        /// <param name="fileName">允许上传的字符串</param>
        /// <returns></returns>
        public static bool UploadXls(int shopId,FileUpload fup, string savePath, out string fileName)
        {
            var allowExt = new string[] { ".xls", ".xlsx" };
            var fileExtension = System.IO.Path.GetExtension(fup.FileName).ToLower();
            if (!allowExt.Contains(fileExtension.ToLower()))
            {
                fileName = "";
                return false;
            }
            var rand = new Random();
            var r = rand.Next(1, 100);
            fileName = shopId + "_" + DateTime.Now.ToString("yyyyMMddHHmm") + fileExtension;
            fup.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(savePath) + fileName);
            return true;
        }

        public static string[] AllowImages = { ".gif", ".png", ".jpeg", ".jpg" };
    }


}