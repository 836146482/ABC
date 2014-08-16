using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace YellEat.Utility
{
    public class ImageUtil
    {
        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <param name="verifyCode">验证码</param>
        /// <param name="charWidth">每个字符占据的宽度</param>
        /// <param name="imageHeight">图片高度</param>
        /// <returns>验证码图片</returns>
        public static Bitmap CreateVerifyCodeBitmap2(string verifyCode, int charWidth = 23, int imageHeight = 28)
        {
            const int randAngle = 45; //随机转动角度  
            var mapwidth = (int)(verifyCode.Length * charWidth);
            var map = new Bitmap(mapwidth, imageHeight);//创建图片背景  
            var g = Graphics.FromImage(map);
            g.Clear(Color.AliceBlue);//清除画面，填充背景  
            g.DrawRectangle(new Pen(Color.Black, 0), 0, 0, map.Width - 1, map.Height - 1);//画一个边框  
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//模式  
            var rand = new Random();
            //背景噪点生成  
            var jimPen = new Pen(Color.LightGray, 0);
            for (var i = 0; i < 50; i++)
            {
                var x = rand.Next(0, map.Width);
                var y = rand.Next(0, map.Height);
                g.DrawRectangle(jimPen, x, y, 1, 1);
            }
            //验证码旋转，防止机器识别  
            var chars = verifyCode.ToCharArray();//拆散字符串成单字符数组  
            //文字距中  
            var format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            //定义颜色  
            Color[] colors = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan,
                                 Color.Purple,Color.Peru,Color.OrangeRed,Color.Navy,Color.Maroon };
            //定义字体  
            string[] fonts = { "Verdana", "Times New Roman", "Microsoft Sans Serif", "Georgia", "Comic Sans MS", "Arial", "宋体", "微软雅黑", };
            foreach (var c in chars)
            {
                var cindex = rand.Next(12);//颜色
                var findex = rand.Next(7);//字体
                var fs = rand.Next(5) - 2;//字体大小变动
                var f = new Font(fonts[findex], 13 + fs, FontStyle.Bold);//字体样式(参数2为字体大小)  
                var b = new SolidBrush(colors[cindex]);
                var dot = new Point(16, 16);
                float angle = rand.Next(-randAngle, randAngle);//转动的度数  
                g.TranslateTransform(dot.X, dot.Y);//移动光标到指定位置  
                g.RotateTransform(angle);
                g.DrawString(c.ToString(), f, b, 1, 1, format);
                g.RotateTransform(-angle);//转回去  
                g.TranslateTransform(2, -dot.Y);//移动光标到指定位置  
            }
            //g.DrawString(verifyCode,fontstyle,new SolidBrush(Color.Blue),2,2); //标准随机码 
            g.Dispose();
            return map;
        }
    }
}