<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserAddress.aspx.cs" Inherits="YellEat.AddUserAddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>YellEat</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/style.css" />
     <script src="js/jquery-1.10.1.min.js"></script>    
</head>
<body>
    <form id="form1" runat="server">

        <div id="divAdd" class="dialog">
            <div class="add_title">添加新地址</div>
            <dl>
                <dd>
                    <asp:TextBox runat="server" ID="tbxReceiver" placeholder="姓名" CssClass="width30"></asp:TextBox>
                    <asp:TextBox runat="server" ID="tbxMobile" placeholder="电话" CssClass="width50"></asp:TextBox>
                </dd>
                <dd>
                    <asp:TextBox runat="server" ID="tbxAddress" placeholder="地址" CssClass="width100"></asp:TextBox>
                </dd>
                <dd class="al-center">
                    <asp:Button runat="server" ID="btnCancel" Text="取消" CssClass="address-btn" OnClick="btnCancel_Click"  />
                    <asp:Button runat="server" ID="btnAdd" Text="添加" CssClass="address-btn" OnClick="btnAdd_OnClick" OnClientClick="return checkAdd();" />
                </dd>
            </dl>
            <asp:HiddenField runat="server" ID="hfUpdateID" />
        </div>

    </form>
</body>
</html>
