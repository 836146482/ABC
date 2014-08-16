<%@ Page Title="" Language="C#" MasterPageFile="~/ShopAdmin/ShopAdminMaster.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="YellEat.ShopAdmin.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="input-table table-condensed" style="width:600px;">
        <tr>
            <th style="width:80px;">菜单分类：</th>
            <td style="text-align:left;font-size:14px;width:380px;">
                <asp:DropDownList runat="server" ID="ddlProductTypes" /></td>
            <td></td>
        </tr>
        <tr>
            <th>菜单编号：</th>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbxProductNO"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="tbxProductNO" ErrorMessage="请输入产品编号" ForeColor="red"/>
            </td>
        </tr>
        <tr>
            <th>菜单名称：</th>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbxProductName"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="请输入菜单名称" ControlToValidate="tbxProductName" ForeColor="red"/>
            </td>
        </tr>
        <tr>
            <th>税金：</th>
            <td style="text-align:left;font-size:14px;">
                <asp:DropDownList runat="server" ID="ddlUnits" /></td>
            <td>                
            </td>
        </tr>
        <tr>
            <th>价格：</th>
            <td>
                <asp:TextBox runat="server" ID="tbxPrice" CssClass="form-control"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rfv4" runat="server" ErrorMessage="请输入价格" Display="Dynamic" ControlToValidate="tbxPrice" ForeColor="red"/>
                <asp:RegularExpressionValidator ID="rev1" runat="server" ErrorMessage="请输入正确的价格" ControlToValidate="tbxPrice" ValidationExpression="^\d+(\.\d+)?$" ForeColor="red" />
            </td>
        </tr>
        <tr>
            <th>菜单图片：</th>
            <td colspan="2">
                <asp:FileUpload runat="server" ID="fupProductImage" /><span style="color: red">&nbsp;&nbsp;(支持图片格式：.png、.jpeg、.jpg 以及 .gif，允许上传图片大小最大为 5 M)</span>
            </td>           
        </tr>
        <tr>
            <th>菜单描述：</th>
            <td colspan="2">
                <asp:TextBox runat="server" ID="tbxProductDesc" TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox>
            </td>           
        </tr>
        <tr>
            <td colspan="3" style="text-align: center;">
                <asp:Button runat="server" ID="btnOk" CssClass="btn btn-danger" Text="确定添加" OnClick="btnOk_OnClick" />
            </td>
        </tr>
    </table>
</asp:Content>
