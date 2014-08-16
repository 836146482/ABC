<%@ Page Title="" Language="C#" MasterPageFile="~/ShopAdmin/ShopAdminMaster.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="YellEat.ShopAdmin.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-danger" style="width: 600px;">
        <div class="panel-heading">修改餐馆登录密码</div>
        <div class="panel-body">
            <table class="input-table">
                <tr>
                    <th style="width:70px">旧密码：</th>
                    <td style="width:350px;">
                        <asp:TextBox runat="server" TextMode="Password" ID="tbxOldPwd" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ForeColor="red"
                            ID="rfv1" runat="server" ErrorMessage="请输入当期登录密码！" ControlToValidate="tbxOldPwd" Display="Dynamic" /></td>
                </tr>
                <tr>
                    <th>新密码：</th>
                    <td>
                        <asp:TextBox runat="server" ID="tbxNewPwd1" TextMode="Password" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ForeColor="red"
                            ID="rfv2" runat="server" ErrorMessage="请输入新密码！" ControlToValidate="tbxOldPwd" Display="Dynamic" /></td>
                </tr>
                <tr>
                    <th>密码确认：</th>
                    <td>
                        <asp:TextBox runat="server" ID="tbxNewPwd2" TextMode="Password" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ID="rfv3" ErrorMessage="请输入密码确认！" ControlToValidate="tbxNewPwd2" ForeColor="red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator runat="server" ID="cv1" ControlToValidate="tbxNewPwd2" ControlToCompare="tbxNewPwd1"
                            ErrorMessage="两次输入的密码不一致！" ForeColor="red" Display="Dynamic"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div style="text-align: center">
                            <asp:Button runat="server" ID="btnOK" Text="确定修改" CssClass="btn btn-danger btn-sm" OnClick="btnOK_OnClick"></asp:Button>
                            &nbsp;
                            <input type="reset" value="清空重置" class="btn btn-sm btn-danger" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
