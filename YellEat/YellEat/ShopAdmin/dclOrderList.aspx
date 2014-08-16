<%@ Page Title="" Language="C#" MasterPageFile="~/ShopAdmin/ShopAdminMaster.Master" AutoEventWireup="true" CodeBehind="dclOrderList.aspx.cs" Inherits="YellEat.ShopAdmin.dclOrderList" %>

<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager1"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Repeater runat="server" ID="rpt" OnItemDataBound="rpt_OnItemDataBound">
                <HeaderTemplate>
                    <table class="table table-condensed">
                        <thead>
                            <tr class="alert-success">
                                <td>以下为订单列表</td>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td colspan="3">
                            <table class="table table-bordered">
                                <tr class="alert-danger">
                                    <th>订单编号</th>
                                    <td><%#Eval("OrderSN") %></td>
                                    <th>下单时间</th>
                                    <td><%#Eval("OrderCreateTime") %></td>
                                    <th>订单总价</th>
                                    <td style="font-weight: bold">$<%#Eval("TotalPrice") %></td>
                                </tr>
                                <tr>
                                    <th>收货人</th>
                                    <td><%#Eval("Receiver") %></td>
                                    <th>联系电话</th>
                                    <td><%#Eval("ReceiverMobile") %></td>
                                    <th>收货地址</th>
                                    <td><%#Eval("ReceiveAddress") %></td>
                                </tr>
                                <tr>
                                    <th>是使用优惠券</th>
                                    <td><%# (int?)Eval("ShopCouponID")==null?"否":"是" %></td>
                                    <th>优惠券编号</th>
                                    <td><%# (int?)Eval("ShopCouponID")==null?"":Eval("ShopCouponID") %></td>
                                    <th>优惠价格</th>
                                    <td><%#(int?)Eval("ShopCouponID")==null?"":Eval("UnitCouponCost") %></td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:Repeater runat="server" ID="rptOrderDetail">
                                            <HeaderTemplate>
                                                <table class="table table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th style="width:80px;">菜单编号</th>
                                                            <td>菜单名</td>
                                                            <td>数量</td>
                                                            <td>单价</td>
                                                            <td>税率</td>
                                                            <th>小计</th>
                                                        </tr>
                                                    </thead>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <th><%#Eval("ProductID") %></th>
                                                    <td><%#Eval("ProductName") %></td>
                                                    <td><%#Eval("Quantity") %></td>
                                                     <td><%#Eval("UnitCost") %></td>
                                                    <td><%#Eval("UnitPoint") %></td>                                                   
                                                    <td><%#Convert.ToInt32(Eval("Quantity"))*Convert.ToDecimal(Eval("UnitCost")) %></td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>                                                
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" style="text-align: center">
                                    <asp:Button runat="server" ID="btnSend" CssClass="btn btn-danger btn-xs" Text=" 受 理 下 单 "/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>                   
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
            <uc1:Pager runat="server" ID="pager1" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

