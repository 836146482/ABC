<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.Master" AutoEventWireup="true" CodeBehind="ShopProductList.aspx.cs" Inherits="YellEat.ShopProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/font-awesome.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager1"></asp:ScriptManager>
    <div class="menu">
        <div class="dc clearfix">
            <div class="rest_logo">
                <img src='<%=VisitingShop.ShopLogoImg %>' style="width: 80px; height: 80px; border-radius: 40px;" />
            </div>
            <div class="rest_name">
                <p style="font-size: 18px; font-weight: bold"><%=VisitingShop.ShopName %></p>
                <asp:Literal runat="server" ID="ltlRank"></asp:Literal>
            </div>
            <div class="rest_fee">
                <span>
                    <img src="images/heart.png" /></span>
                <p>$<span id="minPrice"><%=VisitingShop.DeliveryMinPrice %></span>起送</p>
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server" ID="updatePanel1">
        <ContentTemplate>
            <asp:Repeater runat="server" ID="rptProductType" OnItemDataBound="rptProductType_OnItemDataBound" OnItemCommand="rptProductType_ItemCommand">
                <ItemTemplate>
                    <div class="menu_list">
                        <table>
                            <tr>
                                <th colspan="3">
                                    <span><%#Eval("Item2") %></span>
                                </th>
                            </tr>
                            <asp:Repeater runat="server" ID="rptProduct" OnItemDataBound="rptProduct_OnItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td class="align_left" style="word-break: break-all; width:840px;">
                                            <%#Eval("ProductName") %>
                                        </td>
                                        <td>
                                            <span class="color1">$<%#Eval("Price") %></span></td>
                                        <td class="pad0" id="<%#Eval("ShopID") %>,<%#Eval("ProductID") %>">
                                            <img src="images/dec.png" class="minus" />
                                            <asp:Label runat="server" CssClass="amount" ID="lblAmount" Text="0"></asp:Label>                                                                                       
                                            <img src="images/inc.png" class="add" />
                                            <asp:HiddenField runat="server" ID="hfAmount"/>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <p class="more">
                            <asp:LinkButton ID="MoreBtn" runat="server" CommandName="More" CommandArgument='<%#Eval("Item1")%>'>更多选择</asp:LinkButton>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div style="height: 30px;">&nbsp;</div>
            <div class="total">
                总价<span id="price1">$<span id="totalSpan">0</span></span>（还有$<span id="price2"><%=VisitingShop.DeliveryMinPrice %></span>起送）
            </div>
<%--            <div class="nav" style="z-index: 99999991; opacity: 0.5; color:#ff6a00; width: 40%;" onclick="__doPostBack('<%=btnAdd2Cart.UniqueID %>','')">
                <div class="w40" style="display: none;">
                    <asp:Button runat="server" ID="btnAdd2Cart" OnClick="btnAdd2Cart_OnClick" Text="提交" />
                </div>
            </div>--%>
            <script>
                $(function () {
                    //$('#imgCar').attr('src', 'images/icon1-1.png');
                    //$('#imgCar').parent('a').css('color', '#f07202');
                    var allAmount = $.cookie("allAmount");          
                    $(".add").click(function () {
                        var amount = $(this).prev(".amount");
                        var num = parseInt(amount.text());//文本框数量
                        if (num >= 1000) return;
                        allAmount++;
                        var total = parseFloat($("#totalSpan").text());//总价
                        var leave = parseFloat($("#price2").text());//剩多少价起送
                        var td = $(this).parent().prev();
                        var unitPrice = parseFloat(td.children("span").text().substring(1)); //价钱
                        var hidden = $(this).nextAll(":hidden");
                        total = (total + unitPrice).toFixed(2);
                        leave = (leave - unitPrice).toFixed(2);
                        leave = leave <= 0 ? 0 : leave;
                        amount.text(++num);
                        hidden.val(num);
                        $("#cartNum").text("(" + allAmount + ")");  //购物车数量
                        $("#totalSpan").text(total);
                        $("#price2").text(leave);
                        var arr = amount.parent().attr("id").valueOf().split(',');
                        $.cookie("allAmount", allAmount);
                        var shop = $.cookie(arr[0]+"shop_"+ arr[1]);
                        if (shop != null) {
                            $.cookie(arr[0] + "shop_" + arr[1], parseInt(shop) + 1);
                        }
                        else {
                            $.cookie(arr[0] + "shop_" + arr[1], 1, { expires: 7, path: '/' });
                        }
                    });
                   
                    $(".minus").click(function () {
                        var minPrice = parseFloat('<%=VisitingShop.DeliveryMinPrice %>');
                        var amount = $(this).next(".amount");
                        var num = parseInt(amount.text());//数量
                        if (num <= 0)
                        { return; }
                        else
                        { allAmount--; }
                        var total = parseFloat($("#totalSpan").text());//总价
                        var leave = parseFloat($("#price2").text());//剩余多少起送
                        var td = $(this).parent().prev();
                        var unitPrice = parseFloat(td.children("span").text().substring(1));//单价
                        var hidden = $(this).nextAll(":hidden");
                        $("#cartNum").text("(" + allAmount + ")");//购物车数量
                        amount.text(--num);
                        hidden.val(num);
                        total = (total - unitPrice).toFixed(2);
                        leave = (leave + unitPrice).toFixed(2);
                        $("#totalSpan").text(total);
                        $("#price2").text(leave);
                        var arr = amount.parent().attr("id").valueOf().split(',');
                        $.cookie("allAmount", allAmount);
                        $.cookie(arr[0] + "shop_" + arr[1], parseInt(shop) - 1);
                    });
                });
            </script>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
