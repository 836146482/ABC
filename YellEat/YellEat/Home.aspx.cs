using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.Utility;
using System.Text;
using System.Net;

namespace YellEat
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbxAdd.Text = Request.Cookies["location"] ==null?"":Request.Cookies["location"].Value;
            }
            //WebClient client = new WebClient();
            //string url = "http://maps.google.com/maps/api/geocode/xml?latlng=39.910093,116.403945&language=zh-CN&sensor=false";
            //client.Encoding = Encoding.UTF8;
            //string responseTest = client.DownloadString(url);
            //tbxAdd.Text = responseTest;
        }

        protected void img_okgo_OnClick(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxAdd.Text))
            {
                WebUtil.Alert("请输入您所在的地址！");
            }
            //TODO:搜索位置
            Response.Redirect("ShopList.aspx?location="+Server.HtmlEncode(tbxAdd.Text),true);
        }
    }
}