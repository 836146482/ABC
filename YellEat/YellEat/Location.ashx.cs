using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;


namespace YellEat
{
    /// <summary>
    /// Location1 的摘要说明
    /// </summary>
    public class Location1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            WebClient client = new WebClient();
            string url = "http://maps.google.com/maps/api/geocode/xml?latlng=39.910093,116.403945&language=zh-CN&sensor=false";
            client.Encoding = Encoding.UTF8;
            string responseTest = client.DownloadString(url);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}