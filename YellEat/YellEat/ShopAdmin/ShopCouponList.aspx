<%@ Page Title="" Language="C#" MasterPageFile="~/ShopAdmin/ShopAdminMaster.Master" AutoEventWireup="true" CodeBehind="ShopCouponList.aspx.cs" Inherits="YellEat.ShopAdmin.ShopCouponList" %>

<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Repeater runat="server" ID="rpt" OnItemCommand="rpt_OnItemCommand">
                <HeaderTemplate>
                    <table class="table table-condensed">
                        <thead>
                            <tr class="alert-danger">
                                <th style="width:80px;">优惠券编号</th>
                                <th>优惠码</th>
                                <th>优惠价格</th>
                                <th>有效期</th>
                                <td style="width:40px;">操作</td>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%#Eval("CouponID") %></th>
                        <td><%#Eval("CouponCode") %></td>
                        <td>$<%#Eval("UnitCost") %></td>
                        <td>
                            <%#Eval("BeginDate","{0:yyyy-MM-dd}") %> -
                    <%#Eval("EndDate","{0:yyyy-MM-dd}") %>
                        </td>
                        <td>
                            <asp:Button runat="server" CommandName="del" CommandArgument='<%#Eval("CouponID") %>' ID="btnDelete" OnClientClick="return confirm('您确定要删除优惠券吗？')" CssClass="btn btn-danger btn-xs" Text="删除"/>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <uc1:Pager runat="server" ID="pager1" />
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
