<%@ Page Title="" Language="C#" MasterPageFile="~/ShopAdmin/ShopAdminMaster.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="YellEat.ShopAdmin.OrderDetail" %>

<%@ Import Namespace="YellEat.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table tr td {
            text-align: center !important;
        }

        table tr td:nth-of-type(odd) {
            font-weight: bold;
        }

        table tr td:nth-of-type(even) {
            font-weight: normal;
        }    
         #tblDetails tbody tr td{ font-weight: normal !important;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h4>订单内容</h4>
        <table class="table table-hover table-bordered">
            <tr>
                <td>订单编号：</td>
                <td><%=Order.OrderSN %></td>
                <td>下单时间：</td>
                <td><%=Order.OrderCreateTime %></td>
                <td>订单状态：</td>
                <td><%=(OrderStatus)Order.OrderStatus %></td>
                <td>受理时间：</td>
                <td><%=Order.OrderCheckTime %></td>
            </tr>
            <tr>
                <td>收货人：</td>
                <td><%=Order.Receiver %></td>
                <td>收货人电话：</td>
                <td><%=Order.ReceiverMobile %></td>
                <td>收货地址：</td>
                <td colspan="3"><%=Order.ReceiveAddress %></td>
            </tr>
            <tr>
                <td>优惠券：</td>
                <td><%=Order.ShopCouponID %></td>
                <td>优惠价格：</td>
                <td><%= Order.UnitCouponCost%></td>
                <td>税费：</td>
                <td><%=Order.Tax %></td>
                <td>总计：</td>
                <td>$<%=Order.TotalPrice %></td>
            </tr>
            <tr>
                <th>订单备注：</th>
                <th colspan="7"><%=Order.OrderDesc %></th>
            </tr>
        </table>
    </div>
    <div>
        <h4>菜单详情</h4>
        <asp:Repeater runat="server" ID="rptOrderDetail">
            <HeaderTemplate>
                <table class="table table-bordered table-hover" id="tblDetails">
                    <thead>
                        <tr>
                            <td style="width: 80px;">菜单编号</td>
                            <th>菜单名</th>
                            <th>数量</th>
                            <th>单价</th>
                            <th>税率</th>
                            <td style="font-weight: bold">小计</td>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("ProductID") %></td>
                    <td><%#Eval("ProductName") %></td>
                    <td><%#Eval("Quantity") %></td>
                    <td><%#Eval("UnitCost") %></td>
                    <td><%#Eval("UnitPoint") %></td>
                    <td><%#Convert.ToInt32(Eval("Quantity"))*Convert.ToDecimal(Eval("UnitCost")) %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div>
        <h4>订单评价</h4>
        <p><span>送餐速度：&nbsp;&nbsp;</span><%=OrderResult!=null?OrderResult.DeliveryStar.ToString()+" 分":"暂未评价" %></p>
        <p><span>用餐评价：&nbsp;&nbsp;</span><%=OrderResult!=null?OrderResult.EatingStar.ToString()+" 分":"暂未评价" %></p>
        <p><span>评价内容：&nbsp;&nbsp;</span><%= OrderResult!=null?OrderResult.EvaluationContent:"暂未评价" %></p>
    </div>
</asp:Content>
