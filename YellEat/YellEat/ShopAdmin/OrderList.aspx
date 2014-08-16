<%@ Page Title="" Language="C#" MasterPageFile="~/ShopAdmin/ShopAdminMaster.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="YellEat.ShopAdmin.OrderList" %>
<%@ Import Namespace="YellEat.Model" %>

<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="udpatePanel">
        <ContentTemplate>
            <asp:Repeater runat="server" ID="rpt" OnItemCommand="rpt_OnItemCommand">
                <HeaderTemplate>
                    <table class="table table-condensed">
                        <thead>
                            <tr class="alert-danger">
                                <td style="width:150px;">订单编号</td>
                                <th>用户编号</th>
                                <th>下单时间</th>
                                <th>受理时间</th>
                                <th>订单总价</th>
                                <th>订单状态</th>
                                <td>操作</td>
                            </tr>
                        </thead>
                        <tbody></tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("OrderSN") %></td>
                        <td><%#Eval("UserID") %></td>
                        <td><%#Eval("OrderCreateTime") %></td>
                        <td><%#Eval("OrderCheckTime") %></td>
                        <td><%#Eval("TotalPrice") %></td>
                        <td><%# (OrderStatus)Eval("OrderStatus") %></td>
                        <td>
                            <a href='OrderDetail.aspx?id=<%#Eval("OrderID") %>' class="btn btn-danger btn-xs">详情</a>
                            <asp:Button runat="server" ID="btnDelete" CommandName="del" CommandArgument='<%#Eval("OrderId") %>' CssClass="btn btn-danger btn-xs" Text="删除" OnClientClick="return confirmDel(this)"/>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <uc1:Pager runat="server" ID="pager1" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function confirmDel(obj) {
            if ($(obj).parent().prev().text() == '已下单') return confirm('该订单尚未经过处理，您确定要删除该订单吗？');
            return confirm("您确定要删除该订单吗？");
        }
    </script>
</asp:Content>
