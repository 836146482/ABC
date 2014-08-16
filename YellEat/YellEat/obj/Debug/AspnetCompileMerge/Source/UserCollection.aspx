<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.Master" AutoEventWireup="true" CodeBehind="UserCollection.aspx.cs" Inherits="YellEat.UserCollection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="eat">
        我的收藏　<span class="edit-icon heart-icon"></span>
    </div>
    <div class="menu">
        <div class="div_list">
            <asp:Repeater ID="rptShopList" runat="server" OnItemDataBound="rptShopList_OnItemDataBound">
                <ItemTemplate>
                    <a href='ShopDetail.aspx?shopid=<%#Eval("ShopID") %>'>
                        <div class="dc">
                            <div class="dlogo">
                                <img src="images/df.JPG" />
                            </div>
                            <ul style="width:50%">
                                <li><%#Eval("ShopName") %></li>
                                <li>
                                    <span style="color: #ff6600;">
                                        <asp:Literal runat="server" ID="ltlRank"></asp:Literal>
                                    </span>
                                    <%#Eval("Clicks") %>&nbsp;reviews
                                </li>
                                <li class="active"><%#Eval("DeliveryTime") %></li>
                            </ul>
                            <div class="eat-num" style="width:60px">
                                <p>
                                    <img src="images/heart.png" /></p>
                                <span>吃过<%#Eval("EatCount") %>次</span>
                            </div>
                        </div>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
