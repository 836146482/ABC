<%@ Page Title="" Language="C#" MasterPageFile="~/ShopAdmin/ShopAdminMaster.Master" AutoEventWireup="true" CodeBehind="OrderResultList.aspx.cs" Inherits="YellEat.ShopAdmin.OrderResultList" %>

<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater runat="server" ID="rpt">
        <HeaderTemplate>
            <table class="table table-condensed">
                <thead>
                    <tr class="alert-danger">
                        <th>订单 ID</th>
                        <th>服务评分</th>
                        <th>送餐速度评分</th>
                        <th>用户评价</th>
                        <th>评价时间</th>
                        <th>操作</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("OrderID") %></td>
                <td><%#Eval("EatingStar") %></td>
                <td><%#Eval("DeliveryStar") %></td>
                <td><%#Eval("EvaluationContent") %></td>
                <td><%#Eval("CreateTime") %></td>
                <td><a href='OrderDetail.aspx?id=<%#Eval("OrderID") %>' class="btn btn-xs btn-danger">详情</a></td>
            </tr>
        </ItemTemplate> 
        <FooterTemplate>          
            </tbody> 
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <uc1:Pager runat="server" ID="pager1" />
</asp:Content>
