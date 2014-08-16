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
            <asp:Repeater runat="server" ID="rptProductType" OnItemDataBound="rptProductType_OnItemDataBound">
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
                                        <td class="align_left" style="word-break: break-all">
                                            <%#Eval("ProductName") %>
                                        </td>
                                        <td>
                                            <span class="color1">$<%#Eval("Price") %></span></td>
                                        <td class="pad0" id="<%#Eval("ShopID") %>,<%#Eval("ProductID") %>">
                                            <img src="images/dec.png" class="minus" />
                                            <asp:Label runat="server" CssClass="amount" ID="lblAmount"></asp:Label>                                                                                       
                                            <img src="images/inc.png" class="add" />
                                            <asp:HiddenField runat="server" ID="hfAmount"/>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <p class="more"><a href="#">+更多选择</a></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div style="height: 30px;">&nbsp;</div>
            <div class="total">
                总价<span id="price1">$<span id="totalSpan">0</span></span>（还有$<span id="price2">0</span>起送）
            </div>
            <div class="nav" style="z-index: 99999991; background: yellow; opacity: 0.5; width: 40%;" onclick="__doPostBack('<%=btnAdd2Cart.UniqueID %>','')">
                <div class="w40" style="display: none;">
                    <asp:Button runat="server" ID="btnAdd2Cart" OnClick="btnAdd2Cart_OnClick" Text="提交" />
                </div>
            </div>
            <script>
                $(function () {                   
                    $(".add").click(function () {
                        
                        var $amount = $(this).prev(".amount");
                        var txt = $amount.text();//文本框数量
                        var num = parseInt(txt);
                        if (num >= 1000) return;
                        
                        //获取要修改的html标签,ajax执行成功后进行数据修改
                        var total = parseFloat($("#totalSpan").text());
                        var leave = parseFloat($("#price2").text());
                        var td = $(this).parent().prev();
                        var unitPrice = parseFloat(td.children("span").text().substring(1));
                        var hidden = $(this).nextAll(":hidden");
                        
                        //修改cookies的数据
                        var str = $amount.parent().attr("id").valueOf();
                        
                        $.ajax({
                            type: 'POST',
                            url: 'UpdateShopCart.aspx',
                            data: { item: "add", data: str },
                            success: function () {
                                $amount.text(++num);
                                hidden.val(num);
                                $("#cartNum").text("(" + num + ")");  //购物车数量
                                total += unitPrice;
                                leave -= unitPrice;
                                leave = leave <= 0 ? 0 : leave;
                                $("#totalSpan").text(total);
                                $("#price2").text(leave);
                            }
                        });
                        
                    });
                    $(".minus").click(function () {
                        var minPrice = parseFloat('<%=VisitingShop.DeliveryMinPrice %>');
                        var $amount = $(this).next(".amount");//数量
                        var txt = $amount.text();
                        var num = parseInt(txt);
                        if (num <= 0) return;
                        //获取要修改的html标签,ajax执行成功后进行数据修改,回调函数里无法用$(this)
                        var total = parseFloat($("#totalSpan").text());
                        var leave = parseFloat($("#price2").text());
                        var td = $(this).parent().prev();
                        var unitPrice = parseFloat(td.children("span").text().substring(1));
                        var hidden=$(this).nextAll(":hidden");
                        //修改cookies的数据
                        var str = $amount.parent().attr("id").valueOf();
                        $.ajax({
                            type: 'POST',
                            url: 'UpdateShopCart.aspx',
                            data: { item: "minus", data: str },
                            success: function () {
                                $amount.text(--num);
                                hidden.val(num);
                                $("#cartNum").text("(" + num + ")");  //购物车数量
                                total -= unitPrice;
                                leave -= unitPrice;
                                leave = leave <= parseFloat(minPrice) ? parseFloat(minPrice) : leave;
                                $("#totalSpan").text(total);
                                $("#price2").text(leave);
                            }
                        });                        
                    });
                    var total = 0;
                    var leave = parseInt($("#minPrice").text());                  
                    //绑定总价和剩余价格 
                    var sub = 0;
                    $.each($(".amount"), function(index,content) {
                        if ($(this).text() == "0") return;
                        sub = parseInt($(this).text()) * parseFloat($(this).parent().prev().children("span").text().substring(1));
                        total += sub;
                        leave -= sub;
                    });
                    if (leave < 0) leave = 0;
                    $("#totalSpan").text(total);
                    $("#price2").text(leave);
                });
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
