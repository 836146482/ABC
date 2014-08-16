<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="YellEat.YellEatAdmin.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .row{ margin-bottom: 10px;}        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-danger" style="width: 600px;">
        <div class="panel-heading">修改个人密码</div>
        <div class="panel-body">
            <table class="input-table">
                <tr>
                    <th>旧密码：</th>
                    <td><asp:TextBox runat="server" TextMode="Password" ID="tbxOldPwd" CssClass="form-control"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ForeColor="red"
                        ID="rfv1" runat="server" ErrorMessage="请输入当期登录密码！" ControlToValidate="tbxOldPwd" Display="Dynamic" /></td>
                </tr>
                <tr>
                    <th>新密码：</th>
                    <td><asp:TextBox runat="server" ID="tbxNewPwd1" TextMode="Password" CssClass="form-control"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ForeColor="red"
                        ID="rfv2" runat="server" ErrorMessage="请输入新密码！" ControlToValidate="tbxNewPwd1" Display="Dynamic" /></td>
                </tr>
                <tr>
                    <th>密码确认：</th>
                    <td><asp:TextBox runat="server" ID="tbxNewPwd2" TextMode="Password" CssClass="form-control"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator runat="server" ErrorMessage="请输入确认密码" ForeColor="red" ID="rfv3" ControlToValidate="tbxNewPwd2"></asp:RequiredFieldValidator>
                         <asp:CompareValidator runat="server" ID="cv1" ControlToValidate="tbxNewPwd2" ControlToCompare="tbxNewPwd1"
                        ErrorMessage="两次输入的密码不一致！" ForeColor="red"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center">
                         <asp:Button runat="server" ID="btnOK" Text="确定修改" CssClass="btn btn-danger btn-sm" OnClick="btnOK_OnClick"></asp:Button>
                        &nbsp;
                        <input type="reset" value="清空重置" class="btn btn-sm btn-danger"/>
                    </td>
                </tr>
            </table>
        </div>
    </div> 

</asp:Content>
