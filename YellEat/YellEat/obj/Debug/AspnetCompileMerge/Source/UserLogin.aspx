<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="YellEat.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>YellEat Login</title>
    <meta id="viewport" name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <script src="js/jquery-1.10.1.min.js"></script>
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/jquery.fancybox.css" rel="stylesheet" />
    <script src="js/jquery.fancybox.pack.js"></script>
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <style>
        .btn {
            display: inline-block;
            padding: 0 10px;
            height: 40px;
            line-height: 40px;
            width: 70%;
            background: #f07202;
            margin-top: 8px;
            border-radius: 4px;
            font-size: 18px;
            font-weight: bold;
            color: #fff;
        }

        .tbx {
            height: 40px;
            width: 80%;
            margin-top: 20px;
            border-radius: 8px;
        }
    </style>
    <script>
        $(function () {
            var state = {
                padding: 0,
                modal: true,
                fitToView: true,
                width: '100%',
                height: 230,
                autoSize: false,
                afterLoad: function () {
                    $(".fancybox-overlay.fancybox-overlay-fixed").appendTo($("#form1"));
                }
            };
            $("#getPassword").fancybox(state);
            $("#sendEmail").click(function() {
                $("#<%=btnSendEmail.ClientID%>").click();
            });
            $("#customService").click(function() {
                $("#<%=btnCustomService.ClientID%>").click();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <div id="page-main" data-role="page">
            <header class="top2">
                <div class="top_l">
                    <a class="lb" href="javascript:history.back();"></a>
                </div>
                YellEat
		<div class="en">
            <a>
                <img src="images/english.jpg" />
            </a>
        </div>
            </header>
            <div class="menu">
                <div class="login">
                    <h2>Member Login</h2>
                    <div class="login-input">
                        <label>
                            <asp:TextBox runat="server" ID="tbxUserName" placeholder="Email/Phone/WeChat ID" CssClass="text" /></label>
                        <label>
                            <asp:TextBox runat="server" ID="tbxPwd" placeholder="Password" TextMode="Password" /></label>
                    </div>
                    <div class="login-button">
                        <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_OnClick" Text="Login with YellEat" />
                    </div>
                    <div class="forget">
                        <a id="getPassword" href="#modal">Forget your password</a>
                    </div>
                </div>
                <div class="dashed-line"></div>
                <div class="join">
                    <h2>Join us</h2>
                    <p>Proceed to checkout , and you will have an option to create an account at the end .</p>
                </div>
                <div class="create-button">
                    <a href="UserCreate.aspx">Create</a>
                </div>
            </div>
        </div>
        <div>
            <asp:UpdatePanel runat="server" ID="updatePanel1">
                <ContentTemplate>
                    <div style="display: none;" id="modal">
                        <div id="inline" class="dialog">
                            <div class="add_title">
                                <strong onclick="$.fancybox.close()">x</strong>
                            </div>
                            <div style="text-align: center; margin: 0 auto;">
                                <p>
                                    <asp:TextBox runat="server" ID="tbxEmail" CssClass="tbx" placeholder="Phone/Email" />
                                </p>
                                <p>
                                    <span id="sendEmail" class="btn">
                                        <img src="images/login-email.png" />&nbsp;Send Password</span>
                                </p>
                                <p>
                                    <span id="customService" class="btn">
                                        <img src="images/login-phone.png" />&nbsp;Custom service</span>
                                </p>
                            </div>
                        </div>
                        <div style="display: none; visibility: hidden">
                            <asp:Button runat="server" ID="btnSendEmail" OnClick="btnSendEmail_OnClick" Text="Send Password"></asp:Button>
                            <asp:Button runat="server" ID="btnCustomService" Text="Custom service" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
