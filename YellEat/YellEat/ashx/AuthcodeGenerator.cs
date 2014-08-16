using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.SessionState;
using YellEat.Utility;

namespace YellEat.ashx
{
    /// <summary>
    /// AuthcodeGenerator 类用以支持 Web 生成验证码
    /// 可使用Session["RandomAuthCode"] 获取生成的验证码
    /// 使用 WebHandler 标签即可使用该类,<%@ WebHandler Language="C#" Class="WJQ.Web.AuthcodeGenerator" %>
    /// </summary>  
    public class AuthcodeGenerator : IHttpHandler, IRequiresSessionState
    {
        public AuthcodeGenerator()
        {
            AuthCodeLength = 4;
            FontSize = 15;
            ImageHeight = 35;
        }

        public void ProcessRequest(HttpContext context)
        {
            var code = StringUtil.CreateRandomCode(AuthCodeLength);
            context.Session["RandomAuthCode"] = code;
            var bmp = ImageUtil.CreateVerifyCodeBitmap2(code);
            context.Response.Clear();
            context.Response.ContentType = "image/jpeg";
            var msm = new MemoryStream();
            bmp.Save(msm,ImageFormat.Jpeg);
            context.Response.BinaryWrite(msm.ToArray());
        }        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 生成验证码使用的字体大小
        /// </summary>
        protected int FontSize { get; set; }
        /// <summary>
        /// 生成的验证码图片的高度
        /// </summary>
        protected int ImageHeight { get; set; }
        /// <summary>
        /// 生成的验证码的个数
        /// </summary>
        protected int AuthCodeLength { get; set; }
    }
}
