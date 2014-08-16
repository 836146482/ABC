<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="YellEat.Controls.Pager" %>
<div style="text-align: right">
    <asp:Label ID="lblRC" runat="server"></asp:Label>
    <asp:Label ID="lblCP" runat="server"></asp:Label>
    <asp:Label ID="lblPC" runat="server"></asp:Label>
    <asp:Button runat="server" ID="btnFirst" CssClass="btn btn-danger btn-xs" Text="首页" OnClick="btnFirst_OnClick" />
    <asp:Button runat="server" ID="btnPrev" CssClass="btn btn-danger btn-xs" Text="上一页" OnClick="btnPrev_OnClick" />
    <asp:Button runat="server" ID="btnNext" CssClass="btn btn-danger btn-xs" Text="下一页" OnClick="btnNext_OnClick" />
    <asp:Button runat="server" ID="btnLast" CssClass="btn btn-danger btn-xs" Text="末页" OnClick="btnLast_OnClick" />
</div>
