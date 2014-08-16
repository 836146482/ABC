<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="YellEat.ShopAdmin.Register" ClientIDMode="Static" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>YellEat 餐馆注册</title>
    <script src="../js/jquery-1.10.1.min.js"></script>
    <script src="../formValidator/formValidator-4.0.1.min.js" type="text/javascript"></script>
    <script src="../formValidator/formValidatorRegex.js" type="text/javascript"></script>
    <link href="../formValidator/style/validator.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/admin.css" rel="stylesheet" />   
    <style>
        body {
            width: 650px;
            margin: 0 auto;
        }
        table tr {
            height: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel panel-danger" style="margin:20px auto;">
            <div class="panel-heading">
                <h1 class="panel-title" style="font-size:22px">YellEat 餐馆注册</h1>
            </div>
            <div class="panel-body">
                <table class="input-table">                    
                    <tr>
                        <th>用户名：</th>
                        <td>
                            <asp:TextBox runat="server" ID="tbxUserName" name="tbxUserName" CssClass="form-control" Style="width: 180px; float: left;" />
                            <div id="tbxUserNameTip" style="width: 250px; float: left;"></div>
                        </td>
                    </tr>
                    <tr>
                        <th>密码：</th>
                        <td>
                            <asp:TextBox runat="server" ID="tbxUserPwd" name="tbxUserPwd" CssClass="form-control" TextMode="Password" Style="width: 180px; float: left;" />
                            <div id="tbxUserPwdTip" style="width: 250px; float: left;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th>确认密码：</th>
                        <td>
                            <asp:TextBox runat="server" ID="tbxUserPwdC" name="tbxUserPwdC" CssClass="form-control" TextMode="Password" Style="width: 180px; float: left;" />
                            <div id="tbxUserPwdCTip" style="width: 250px; float: left;"></div>
                        </td>
                    </tr>
                    <tr>
                        <th>餐馆名称：</th>
                        <td>
                            <asp:TextBox runat="server" ID="tbxShopName" name="tbxShopName" CssClass="form-control" Style="width: 180px; float: left;" />
                            <div id="tbxShopNameTip" style="width: 250px; float: left;"></div>
                        </td>
                    </tr>                               
                    <tr>
                        <th>邮编：</th>
                        <td>
                            <asp:TextBox ID="tbxShopZip" name="tbxShopZip" CssClass="form-control" Style="width: 180px; float: left;" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th>电话：</th>
                        <td>
                            <asp:TextBox runat="server" ID="tbxShopMobile" CssClass="form-control" name="tbxShopMobile" Style="width: 180px; float: left;" />
                        </td>
                    </tr>
                    <tr>
                        <th>邮箱：
                        </th>
                        <td>
                            <asp:TextBox ID="tbxShopEmail" name="tbxShopEmail" CssClass="form-control" Style="width: 180px; float: left;" runat="server" /><div
                                id="tbxShopEmailTip" style="width: 250px; float: left;">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th>传真：</th>
                        <td>
                            <asp:TextBox ID="tbxShopFax" name="tbxShopFax" CssClass="form-control" Style="width: 180px; float: left;" runat="server" />
                        </td>
                    </tr>
                     <tr>
                        <th>地址：</th>
                        <td>
                            <asp:TextBox runat="server" ID="tbxAddr" name="tbxAddr" CssClass="form-control" Style="width: 440px; float: left;" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="line-height: 80px; height: 80px; text-align: center;">
                            <a href="#">《YellEat 订餐软件服务协议》</a>
                            <asp:Button runat="server" ID="btnRegister" Text="同意并注册" CssClass="btn btn-danger" OnClick="btnRegister_OnClick" OnClientClick="return true;"/>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="errorlist">
        </div>
         <script type="text/javascript">
             $(document).ready(function () {
                 $.formValidator.initConfig({
                     formID: "form1", debug: false, submitOnce: false,
                     onError: function (msg, obj, errorlist) {
                         $("#errorlist").empty();
                         alert(msg);
                         return false;
                     },
                     onSuccess: function() {
                         return true;
                     },
                     submitAfterAjaxPrompt: '有数据正在异步验证，请稍等...'
                 });

                 $("#tbxUserName").formValidator({ ajax: true, onShow: "请输入用户名", onFocus: "用户名至少6个字符,最多12个字符", onCorrect: "该用户名可以注册" }).inputValidator({ min: 6, max: 12, onError: "你输入的用户名长度不正确" }).regexValidator({ regExp: "username", dataType: "enum", onError: "用户名格式不正确" })
                 .ajaxValidator({
                     dataType: "text",
                     async: true,
                     url: "../ashx/ShopAccountChecker.ashx",
                     success: function (data) {
                         if (data == "0") {
                             return true;
                         } else return false;
                     },
                     buttons: $("#btnRegister"),
                     error: function (jqXHR, textStatus, errorThrown) { alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown); },
                     onError: "该用户名不可用，请更换用户名",
                     onWait: "正在对用户名进行合法性校验，请稍候..."
                 });
                 $("#tbxUserPwd").formValidator({ onShow: "请输入密码", onFocus: "至少6个长度", onCorrect: "密码合法" }).inputValidator({ min: 6, empty: { leftEmpty: false, rightEmpty: false, emptyError: "密码两边不能有空符号" }, onError: "密码不能为空,请确认" });
                 $("#tbxUserPwdC").formValidator({ onShow: "请再次输入密码", onFocus: "至少6个长度", onCorrect: "密码一致" }).inputValidator({ min: 6, empty: { leftEmpty: false, rightEmpty: false, emptyError: "重复密码两边不能有空符号" }, onError: "重复密码不能为空,请确认" }).compareValidator({ desID: "tbxUserPwd", operateor: "=", onError: "2次密码不一致,请确认" });
                 $("#tbxShopEmail").formValidator({ onShow: "请输入邮箱", onFocus: "邮箱6-100个字符,输入正确了才能离开焦点", onCorrect: "邮箱格式合法有效", defaultValue: "" }).inputValidator({ min: 6, max: 100, onError: "你输入的邮箱长度非法,请确认" }).regexValidator({ regExp: "^([\\w-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([\\w-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$", onError: "你输入的邮箱格式不正确" });
                 $("#tbxShopName").formValidator({ onShow: "请输入餐馆中文名称", onCorrect: "输入正确" }).inputValidator({ min: 1, onError: "餐馆中文名称不能为空,请确认" });                
             });
    </script>
    </form>
</body>
</html>
