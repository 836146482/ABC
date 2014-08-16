<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="YellEat.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        iframe {
            width: 80%;
            height: 150px;
        }
    </style> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <div style="text-align: left;vertical-align: central">        
			　<img src="images/contact.png" style="width:60px;height:60px;margin:5px;"/>&nbsp;<b>联系我们</b>
		</div>--%>
		<div class="menu">
			<div style="text-align:center;margin-top:10px;">
                 <iframe  frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="http://ditu.google.cn/maps?f=q&amp;source=s_q&amp;hl=zh-CN&amp;geocode=&amp;q=%E6%96%B0%E5%8D%8E%E7%9C%9F&amp;sll=23.387246,116.724501&amp;sspn=0.037972,0.084372&amp;brcurrent=3,0x3411dc903a177081:0x2a4f04f3a9f7fd9a,0,0x3411db9e8912d61d:0x1fb0f60e1dab02c5%3B5,0,0&amp;ie=UTF8&amp;hq=%E6%96%B0%E5%8D%8E%E7%9C%9F&amp;hnear=&amp;cid=17754866187059137441&amp;ll=23.388349,116.719394&amp;spn=0.018119,0.025749&amp;z=14&amp;iwloc=B&amp;output=embed"></iframe>
			</div>
			<div class="contact">
				<ul>
					<li><span>Email:1179646406@qq.com</span></li>
					<li><span>Wechat:123456</span></li>
					<li><span>Address:149,Blake St,San Francisco,CA</span></li>
					<li><span>Telephone:123456</span></li>
					<li><span>我要推荐新餐馆</span></li>
					<li><span>建议与投诉</span></li>
				</ul>
			</div>
		</div>
</asp:Content>
