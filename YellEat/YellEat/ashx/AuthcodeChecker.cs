using System.Web;
using System.Web.SessionState;

namespace YellEat.ashx
{
    /// <summary>
    /// AuthcodeChecker 类为验证码检查器
    /// </summary>
    public class AuthcodeChecker : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get { return false; }
        }
        /// <summary>
        /// 处理 Http 请求，从 Url 参数中验证传递过来的 AuthCode 是否正确
        /// 使用 WebHandler 标签即可使用该类,<%@ WebHandler Language="C#" Class="WJQ.Web.AuthcodeChecker" %>
        /// 使用该处理程序需在 Url 参数中传递 AuthCode 参数，验证成功返回字符串“1”，否则返回字符串“0”
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            var sessionCode = context.Session["RandomAuthCode"];
            var authcode = context.Request.QueryString["AuthCode"];
            if (sessionCode != null && authcode!=null && ((string)sessionCode).ToUpper() == authcode.ToUpper())
            {
                context.Response.Write("1");
            }
            else
            {
                context.Response.Write("0");
            }
        }
    }
}
