<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="YellEat.YellEatAdmin.Login" ClientIDMode="Static" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="" name="description" />
    <meta content="" name="keywords" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <script src="../js/jquery-1.10.1.min.js"></script>
    <title>YellEat 后台管理登陆</title>
    <style type="text/css">
        html, body {
            background: #a50358;
            font-size: 12px;
            height: 100%;
            width: 100%;
            margin: 0px;
            padding: 0px;
        }

        #main {
            width: 1000px;
            height: 602px;
            margin: auto;
            position: absolute;
            top: 0;
            left: 0;
            bottom: 0;
            right: 0;
            background: url(../images/login_bg_big.png) no-repeat center center;
        }

        #login-form {
            width: 451px;
            height: 253px;
            margin: auto;
            position: absolute;
            top: 0;
            left: 0;
            bottom: 0;
            right: 0;
            background: url(../images/login_bg.png);
            color: #fff;
        }

        .txt {
            width: 120px;
            height: 20px;
            border: 0 none;
        }

        .size {
            width: 51px;
        }

        #login-table {
            padding: 50px 0 0 210px;
        }

            #login-table tr {
                height: 30px;
            }

        .login-btn {
            width: 84px;
            height: 23px;
            background: url(../images/login-btn.png) no-repeat 0 0;
            border: 1px solid #a50358;
            border-radius: 10px;
            color: #fff;
            cursor: pointer;
        }

        .auto-style1 {
            width: 62px;
        }
    </style>
</head>
<body>
    <form runat="server" id="form1">
        <div id="main">
            <div id="login-form">
                <div id="login-table">
                    <table>
                        <tr>
                            <td>用户名：</td>
                            <td colspan="2">
                                <asp:TextBox runat="server" ID="tbxAccount" CssClass="txt" />
                            </td>
                        </tr>
                        <tr>
                            <td>密&nbsp;&nbsp;码：</td>
                            <td colspan="2">
                                <asp:TextBox runat="server" ID="tbxPassword" CssClass="txt" TextMode="Password" /></td>
                        </tr>
                        <tr>
                            <td>验证码：</td>
                            <td>
                                <input type="text" id="tbxCheckAuthCode" class="txt size" maxlength="4" /></td>
                            <td class="auto-style1">
                                <img alt="" id="imgAuthCode" src='../ashx/AuthcodeGenerator.ashx?timeTemp=<%=timeTemp %>' style="height: 30px; width: 60px; cursor: pointer">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: center">
                                <asp:Button runat="server" ID="btnLogin" CssClass="login-btn" OnClick="btnLogin_OnClick" Text="登  录" OnClientClick="return check();" />
                        </tr>
                    </table>
                </div>
            </div>
            <input type="hidden" id="hdnCodeState" />
        </div>
        <script type="text/javascript">
            $("#tbxCheckAuthCode").focusout(function () {
                $.ajax({
                    type: "post",
                    url: "../ashx/AuthcodeChecker.ashx?AuthCode=" + $("#tbxCheckAuthCode").val(),//修改验证程序路径
                    success: function (result) {
                        if (result == '1') {
                            $("#hdnCodeState").val('1');
                        } else {
                            alert('验证码不正确！');
                            $("#hdnCodeState").val('0');
                        }
                    }
                });
            });

            $("#imgAuthCode").bind("click", function () {
                $(this).attr("src", "../ashx/AuthcodeGenerator.ashx");//修改图片生成程序路径
            });

           <%-- $("#<%=btnLogin.ClientID %>").click(function () {
                if ($("#tbxAccount").val() == '') {
                    alert('请输入用户名！');
                    $("#tbxAccount").focus();
                    return false;
                }
                if ($("#tbxPassword").val() == '') {
                    alert('请输入密码！');
                    $("#tbxPassword").focus();
                    return false;
                }
                if ($("#tbxCheckAuthCode").val() == '') {
                    alert('请输入验证码！');
                    $("#tbxCheckAuthCode").focus();
                    return false;
                }

                $.ajax({
                    type: "post",
                    url: "../ashx/AuthcodeChecker.ashx?AuthCode=" + $("#tbxCheckAuthCode").val(),//修改验证程序路径
                    success: function (result) {
                        if (result == '1') {
                            $("#hdnCodeState").val('1');
                            return false;
                        } else {
                            alert('验证码不正确！');
                            $("#hdnCodeState").val('0');
                            return false;
                        }
                    }

                });
                return true;

            });--%>


            function check() {
                if ($("#tbxAccount").val() == '') {
                    alert('请输入用户名！');
                    $("#tbxAccount").focus();
                    return false;
                }
                if ($("#tbxPassword").val() == '') {
                    alert('请输入密码！');
                    $("#tbxPassword").focus();
                    return false;
                }
                if ($("#tbxCheckAuthCode").val() == '') {
                    alert('请输入验证码！');
                    $("#tbxCheckAuthCode").focus();
                    return false;
                }

                
                if ($("#hdnCodeState").val() != '1') {
                    alert('验证码不正确！');
                    $("#tbxCheckAuthCode").focus();
                    return false;
                }
                return true;
            }
        </script>
    </form>
</body>
</html>
