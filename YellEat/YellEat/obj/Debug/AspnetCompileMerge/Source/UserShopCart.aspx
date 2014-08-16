<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.Master" AutoEventWireup="true" CodeBehind="UserShopCart.aspx.cs" Inherits="YellEat.UserShopCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .submitOrder{ margin: 0 auto;height: 30px;line-height: 30px;color: #fff;background: #f07202;padding: 0 5px;border-radius: 5px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align: center; padding: 10px;border-bottom:1px dashed #787878;font-size:17px;font-weight: bold;">购物车&nbsp;&nbsp;<img src="images/icon1.png" /></p>
    <asp:Repeater runat="server" ID="rpt" OnItemDataBound="rpt_OnItemDataBound" OnItemCommand="rpt_OnItemCommand">
        <ItemTemplate>
            <div style="margin: 10px auto; width: 90%;">
                <p><%#Eval("Item2") %></p>
                <div>
                    <asp:Repeater runat="server" ID="rptProduct" OnItemDataBound="rptProduct_OnItemDataBound">
                        <HeaderTemplate>
                            <table style="width:100%;line-height:34px;">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="align_left" style="word-break: break-all;padding-left:10px;font-size:14px;">
                                    <%#Eval("ProductName") %>
                                </td>
                                <td>
                                    <span class="color1">$<%#Eval("Price") %></span></td>
                                <td class="pad0" style="width:90px;" id="<%#Eval("ShopID") %>,<%#Eval("ProductID") %>">
                                    <img src="images/dec.png" class="minus"  />                                   
                                    <asp:Label runat="server" ID="lblAmount" CssClass="amount"></asp:Label>
                                    <img src="images/inc.png" class="add" />
                                    <asp:HiddenField runat="server" ID="hfAmount"/>
                                    
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <p style=" text-align: center;border-bottom:1px #787878 dashed;margin:5px 0;padding:5px 0;">                    
                 <asp:Button runat="server" ID="btnSumit" Text="生成订单" CommandName="order" CommandArgument='<%#Eval("Item1") %>' CssClass="submitOrder"/>
                </p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <script type="text/javascript">
        $(function () {            
            $(".add").click(function () {
                var $amount = $(this).prev(".amount");
                var txt = $amount.text();//文本框数量
                var num = parseInt(txt);
                if (num >= 1000) return;
                //回调函数里无法用$(this)
                var hidden=$(this).nextAll(":hidden");
                //修改cookies的数据
                var str = $amount.parent().attr("id").valueOf();
                $.ajax({
                    type: 'POST',
                    url: 'UpdateShopCart.aspx',
                    data: {item:"add",data:str},
                    success: function () {
                        $amount.text(++num);
                        hidden.val(num);
                        $("#cartNum").text("(" + num + ")");    //购物车数量
                    }
                });
            });
            $(".minus").click(function () {
                var $amount = $(this).next(".amount");//数量                
                var txt = $amount.text();
                var num = parseInt(txt);
                if (num <= 0) return;
                //回调函数里无法用$(this)
                var hidden= $(this).nextAll(":hidden");
                //修改cookies的数据
                var str = $amount.parent().attr("id").valueOf();
                $.ajax({
                    type: 'POST',
                    url: 'UpdateShopCart.aspx',
                    data: { item: "minus", data: str },
                    success: function () {
                        $amount.text(--num);
                        hidden.val(num);
                        $("#cartNum").text("(" + num + ")");   //购物车数量
                    }
                });
            });              
        });
    </script>
</asp:Content>
