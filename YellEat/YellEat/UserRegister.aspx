<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="YellEat.UserRegister" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta charset="utf-8">
    <meta id="viewport" name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <title>YellEat</title>
    <link rel="stylesheet" href="css/style.css" />
    <script src="js/jquery-1.10.1.min.js"></script>
    <style>
        .reg-form span{
	        display:inline-block;
	        width:80px;
	        text-align: right;
        }
        .length4{ width: 80%;}
        .c{width:26%}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page-main" data-role="page">
            <header class="top2">
                <div class="top_l">
                    <a class="lb" onclick="javacript:history.back();"></a>
                </div>
                YellEat
             <div class="en">
                 <a>
                     <img src="images/english.jpg" /></a>
             </div>
            </header>
            <div class="menu">
                <div class="reg">
                    <div class="contact"></div>
                    <div class="cj_acc"><a href="#">创建账号</a></div>
                    <div class="reg-form">
                        <ul>
                            <li>
                                <span>姓：</span><asp:TextBox runat="server" CssClass="input-1 length2" ID="tbxFirstName" />
                                <span style="display: inline;">
                                    名：<asp:TextBox runat="server" CssClass="input-1 c" ID="tbxLastName"/>                               
                                </span>
                            </li>
                            <li><span>密码：</span><asp:TextBox runat="server" CssClass="input-1 length4" ID="tbxPwd1" TextMode="Password"></asp:TextBox></li>
                            <li><span>密码确认：</span><asp:TextBox runat="server" CssClass="input-1 length4" ID="tbxPwd2" TextMode="Password"></asp:TextBox></li>
                            <li><span>邮箱：</span><asp:TextBox runat="server" CssClass="input-1 length4" ID="tbxEmail" /></li>
                            <li><span>手机：</span><asp:TextBox runat="server" ID="tbxMobile" CssClass="input-1 length3" />
                               <%-- <asp:TextBox runat="server" CssClass="input-1 length1" placeholder="验证码" />
                                <span style="display: none;">
                                    <asp:Button runat="server" ID="btnSendCode" OnClick="btnSendCode_OnClick" Text="发送验证码" /></span>--%>
                            </li>
                            <li><span>地址：</span><asp:TextBox CssClass="input-1 length4 location" runat="server" ID="tbxAddress" /></li>
                        </ul>
                    </div>
                    <div class="has_login">                        
                        <p><asp:ImageButton runat="server" ID="imgBtn" OnClick="imgBtn_OnClick" ImageUrl="images/right.png" /></p>
                        <a href="UserLogin.aspx">已有帐号，我要登陆</a>
                    </div>
                </div>
            </div>
            <div>
                <img style="width: 100%;" src="images/footer_bg.png" /></div>
            <footer class="fter" id="conReg">
                <div class="fter1">English</div>
                <div class="fter2">|</div>
                <div class="fter1">中文</div>
            </footer>
        </div>
        <!-- 欠缺发送短信功能 -->
    </form>
</body>
</html>
