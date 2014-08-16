<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="YellEat.YellEatAdmin.UserDetail" %>

<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>
<%@ Import Namespace="YellEat.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-danger">
        <div class="panel-heading">用户信息</div>
        <div class="panel-body">
            <table class="input-table">
                <tr>
                    <td>用户名：<%=user.UserName %></td>
                    <td>手机号码：<%=user.Mobile %></td>
                </tr>
                <tr>
                    <td>邮箱：<%=user.Email %></td>
                    <td>邮编：<%=user.Zip %></td>
                </tr>
                <tr>
                    <td>地址：<%=user.Address %></td>
                </tr>
            </table>
        </div>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upOrder" runat="server" ChildrenAsTriggers="True">
        <ContentTemplate>
            <div class="panel panel-danger">
                <div class="panel-heading">历史订单</div>
                <div class="panel-body">
                    <table class="table table-condensed">
                        <asp:Repeater ID="repOrder" runat="server">
                            <HeaderTemplate>
                                <thead>
                                    <tr>
                                        <td style="width: 150px;">订单编号</td>
                                        <th>餐馆名称</th>
                                        <th>下单时间</th>
                                        <th>优惠</th>
                                        <th>税费</th>
                                        <th>订单总价</th>
                                        <th>订单状态</th>
                                    </tr>
                                </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("OrderSN") %></td>
                                    <td><%#Eval("ShopName") %></td>
                                    <td><%#Convert.ToDateTime(Eval("OrderCreateTime")).ToString("yyyy-MM-dd") %></td>
                                    <td><%#Eval("UnitCouponCost") %></td>
                                    <td><%#Eval("Tax") %></td>
                                    <td><%#Eval("TotalPrice") %></td>
                                    <td>
                                        <%# (OrderStatus)Eval("OrderStatus") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div class="panel-footer">
                        <uc1:Pager ID="pagerOrder" runat="server" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="panel panel-danger">
            <div class="panel-heading">收藏店铺</div>
            <div class="panel-body">
                <table class="table table-condensed">
                        <asp:Repeater ID="repCollection" runat="server">
                            <HeaderTemplate>
                                <thead>
                                    <tr>
                                        <th>餐馆名称</th>
                                        <th>吃过次数</th>
                                    </tr>
                                </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("ShopName") %></td>
                                    <td><%#Eval("EatCount") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div class="panel-footer">
                        <uc1:Pager ID="pagerCollection" runat="server" />
                    </div>
            </div>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
