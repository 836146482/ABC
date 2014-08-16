<%@ Page Title="" Language="C#" MasterPageFile="~/ShopAdmin/ShopAdminMaster.Master" AutoEventWireup="true" CodeBehind="AddShopCoupon.aspx.cs" Inherits="YellEat.ShopAdmin.AddShopCoupon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/My97DatePicker/WdatePicker.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="input-table" style="width:600px;">
        <tr>
            <th>优惠券优惠码：</th>
            <td><asp:TextBox runat="server" ID="tbxCouponCode" CssClass="form-control"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator runat="server" ID="rfv" ErrorMessage="请输入优惠码" ForeColor="red" ControlToValidate="tbxCouponCode"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ID="rev" ErrorMessage="优惠码必须是 3-5 位数字或字母" ForeColor="red" ControlToValidate="tbxCouponCode" ValidationExpression="([a-z|0-9|A-Z]{3,5})"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <th>优惠价格（$)：</th>
            <td><asp:TextBox runat="server" ID="tbxUnitCost" CssClass="form-control"></asp:TextBox></td>
            <td><asp:RangeValidator runat="server" ID="rvPrice" ControlToValidate="tbxUnitCost" MinimumValue="0" ErrorMessage="请输入大于 0 的小数" Type="Double" ForeColor="red"></asp:RangeValidator></td>
        </tr>
        <tr>
            <th>优惠开始日期：</th>
            <td><asp:TextBox runat="server" ID="tbxBeginDate" CssClass="form-control" onclick="WdatePicker()"></asp:TextBox></td>
            <td><asp:RangeValidator runat="server" ID="rvDate1" ControlToValidate="tbxBeginDate" Type="Date" ErrorMessage="该日期已过期或无效" ForeColor="red"></asp:RangeValidator></td>
        </tr>
        <tr>
            <th>优惠结束日期：</th>
            <td><asp:TextBox runat="server" ID="tbxEndDate" CssClass="form-control" onclick="WdatePicker()"></asp:TextBox></td>
            <td><asp:RangeValidator runat="server" ID="rvDate2" ControlToValidate="tbxEndDate" Type="Date" ErrorMessage="该日期已过期或无效" ForeColor="red"></asp:RangeValidator></td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Button runat="server" ID="btnOK" OnClick="btnOK_OnClick" Text="确定添加" CssClass="btn btn-danger"/>
            </td>
        </tr>
    </table>
</asp:Content>
