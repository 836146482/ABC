using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace YellEat.Utility
{
    public class StringUtil
    {
        /// <summary>
        /// 生成随机码
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CreateRandomCode(int length)
        {
            int rand;
            char code;
            var randomcode = new StringBuilder();
            //生成一定长度的验证码  
            var random = new Random();
            for (var i = 0; i < length; i++)
            {
                rand = random.Next();               
                if (rand % 3 == 0)
                {
                    code = (char)('A' + (char)(rand % 26));
                    if (code== 'I'||code =='O' || code=='Z' )
                    {
                        code = 'F';
                    }
                }
                else
                {
                    code = (char)('0' + (char)(rand % 10));
                }
                randomcode.Append(code);
            }
            return randomcode.ToString();
        }
        /// <summary>
        /// 剪裁字符串
        /// </summary>
        /// <param name="source"></param>
        /// <param name="length"></param>
        /// <param name="addDot"></param>
        /// <returns></returns>
        public static string Cut(string source, int length,bool addDot)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return source;
            }
            if (length > 0 && source.Length > length)
            {
                return addDot ? source.Substring(0, length)+"..." : source.Substring(0, length);
            }
            return source;
        }

        /// <summary>
        /// 将字符串中的 '\n' 换行符装换为 <br /> 标签
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetHtmlBR(string source)
        {            
            return string.IsNullOrWhiteSpace(source)?source:source.Replace("\n", "<br/>");
        }
    }
}