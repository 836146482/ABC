<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.Master" AutoEventWireup="true" CodeBehind="UserCoupon.aspx.cs" Inherits="YellEat.UserCoupon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="eat">
        用户中心　<span class="member-icon"></span>
    </div>
    <div class="menu">
        <div class="count-box">
            <h2>未使用的优惠卷</h2>
            <div class="cout-use clearfix">
                <asp:Repeater runat="server" ID="rptUsefulCoupon">
                    <ItemTemplate>
                        <dl class="clearfix">
                            <dt>折扣码：<%#Eval("CouponCode") %></dt>
                            <dd><%#Eval("ShopName") %></dd>
                            <dd><%# "优惠  "+Eval("UnitCost") %></dd>
                            <%--<dd><%#Eval("CouponContent") %></dd>--%>
                            <!--优惠内容-->
                            <!--优惠内容-->
                            <dd>
                                有效期<br /><%# Convert.ToDateTime(Eval("BeginDate")).ToString("d") %>-<%# Convert.ToDateTime(Eval("EndDate")).ToString("d") %>
                            </dd>
                        </dl>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="count-box">
            <h2>已使用/已过期的优惠券</h2>
            <div class="cout-use colorgray clearfix">
                <asp:Repeater runat="server" ID="rptNotUsefulCoupon">
                    <ItemTemplate>
                        <dl class="clearfix">
                            <dt>折扣码：<%#Eval("CouponCode") %></dt>
                            <dd><%#Eval("ShopName") %></dd>
                            <dd><%# "优惠  "+Eval("UnitCost") %></dd>
<%--                            <dd><%#Eval("CouponContent") %></dd>--%>
                            <!--优惠内容-->
                            <dd>
                                <br />
                                有效期<%# Convert.ToDateTime(Eval("BeginDate")).ToString("d") %>-<%# Convert.ToDateTime(Eval("EndDate")).ToString("d") %></dd>
                        </dl>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
