<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="SystemConfig.aspx.cs" Inherits="YellEat.YellEatAdmin.SystemConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #config table {
            width: 600px;
        }

       #config table  tr th {
            width: 100px;
        }

        #config p {
            font-size: 16px;
            font-weight: bold;
            font-family: 黑体;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="config">
        <p>邮件配置</p>
        <table class="input-table">
            <tr>
                <th>发送者邮箱：</th>
                <td>
                    <asp:TextBox runat="server" ID="tbxEmail" CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="rfv4" ControlToValidate="tbxEmail" ForeColor="red" ErrorMessage="请输入电子邮箱"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ID="rev2" ControlToValidate="tbxEmail" ForeColor="red" ErrorMessage="电子邮箱格式不正确" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <th>邮件服务器：</th>
                <td>
                    <asp:TextBox runat="server" ID="tbxEmailHost" CssClass="form-control"></asp:TextBox></td>
            </tr>
            <tr>
                <th>账&nbsp;&nbsp;号：</th>
                <td>
                    <asp:TextBox runat="server" ID="tbxEmailAccount" CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="rfv2" ControlToValidate="tbxEmailAccount" ForeColor="red" ErrorMessage="请输入电子邮箱账号"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <th>密&nbsp;&nbsp;码：</th>
                <td>
                    <asp:TextBox runat="server" ID="tbxPassword" TextMode="Password" CssClass="form-control"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="rfv3" ControlToValidate="tbxPassword" Text="请输入电子邮箱密码"></asp:RequiredFieldValidator></td>
            </tr>
        </table>
        <p>短信配置</p>
        <table class="input-table">
            <tr>
                <th>短信配置：</th>
                <td style="width:400px">
                    <asp:TextBox runat="server" ID="tbxSMSAddress" CssClass="form-control"></asp:TextBox></td>
                <td></td>
            </tr>
        </table>
        <br />
        <asp:Button runat="server" ID="btnOK" CssClass="btn btn-danger" OnClick="btnOK_OnClick" Text="保存系统配置" />
    </div>
</asp:Content>
