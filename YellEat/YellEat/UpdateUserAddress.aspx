<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateUserAddress.aspx.cs" Inherits="YellEat.UpdateUserAddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>YellEat</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/style.css" />
     <script src="js/jquery-1.10.1.min.js"></script>  
</head>
<body>
    <form id="form1" runat="server">
    <div id="divUpdate" class="dialog">
                    <div class="add_title">修改收货地址</div>
                    <dl>
                        <dd>
                            <asp:TextBox runat="server" ID="tbxUpdateReceiver" placeholder="姓名" CssClass="width30"></asp:TextBox>
                            <asp:TextBox runat="server" ID="tbxUpdteMobile" placeholder="电话" CssClass="width50"></asp:TextBox>
                        </dd>
                        <dd>
                            <asp:TextBox runat="server" ID="tbxUpdateAddress" placeholder="地址" CssClass="width100"></asp:TextBox>
                        </dd>
                        <dd class="al-center">
                            <asp:Button runat="server" ID="btnCancel" Text="取消" CssClass="address-btn" OnClick="btnCancel_Click"  />
                            <asp:Button runat="server" ID="btnUpdate" Text="保存修改" CssClass="address-btn" OnClick="btnUpdate_OnClick" />
                        </dd>
                    </dl>
                    <asp:HiddenField ID="hfAddressId" runat="server" />

                </div>
    </form>
</body>
</html>
