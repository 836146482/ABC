<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="UserOrderList.aspx.cs" Inherits="YellEat.YellEatAdmin.UserOrderList" %>
<%@ Import Namespace="YellEat.Model" %>
<%@ Register TagPrefix="uc1" TagName="Pager" Src="~/Controls/Pager.ascx" %>
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
                                <th>用户名称</th>
                                <th>餐馆名称</th>
                                <th>下单时间</th>
                                <th>优惠</th>
                                <th>税费</th>                                
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
                        <td><%#Eval("ShopName") %></td>
                        <td><%#Convert.ToDateTime(Eval("OrderCreateTime")).ToString("yyyy-MM-dd") %></td>
                        <td><%#Eval("UnitCouponCost") %></td>
                        <td><%#Eval("Tax") %></td>                            
                        <td><%#Eval("TotalPrice") %></td>
                        <td><%# (OrderStatus)Eval("OrderStatus") %></td>
                        <td>
                           <%-- <a href='OrderDetail.aspx?id=<%#Eval("OrderID") %>' class="btn btn-danger btn-xs">详情</a>--%>
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
</asp:Content>
