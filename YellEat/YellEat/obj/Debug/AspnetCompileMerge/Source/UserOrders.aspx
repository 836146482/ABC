<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.Master" AutoEventWireup="true" CodeBehind="UserOrders.aspx.cs" Inherits="YellEat.UserOrders" %>
<%@ Import Namespace="System.ComponentModel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--  我吃过啥—— 用户订单列表 -->
    <div class="menu" id="divMenu">
    
    </div>
    <div style="display:none;" id="divData">
        <asp:Repeater runat="server" ID="rptOrders" OnItemDataBound="rptOrders_OnItemDataBound">
        <ItemTemplate>
            <div class="menu_list order">
                <table>
                    <tr>
                        <th colspan="3">
                            <span class="left">餐馆名：<%#Eval("ShopName") %></span>
                            <span class="right">订单号：<%#Eval("OrderSN") %></span>
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rptOrderDetail">
                        <ItemTemplate>
                            <tr>
                                <td class="align_left">
                                    <%#Eval("ProductName") %>
                                </td>
                                <td>
                                    <span class="color1">
                                        x<%#Eval("Quantity") %>
                                    </span>
                                </td>
                                <td class="pad0">
                                    $<%#Eval("UnitCost") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="3">
                            <span class="right">总价：$<%#Eval("TotalPrice") %></span>
                        </td>
                    </tr>	
                </table>
                <asp:Literal runat="server" ID="ltlState"></asp:Literal>
                <%# Convert.ToBoolean(Eval("HasOrderResult"))?@"<p class='comment icon10'><a href='#'>我已评价</a></p>":"<p class='comment'><a href='UserOrderResult.aspx?orderid="+Eval("OrderID")+"'>评价并赢取优惠</a></p>" %>                                               
            </div>
        </ItemTemplate>
    </asp:Repeater>    
    </div>
    <script type="text/javascript">
        $(function() {
            getData();
        });

        function getData() {
            $("#divMenu").append($("#divData").html());
        }
    </script>
</asp:Content>
