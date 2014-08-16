<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSubmitOrder.aspx.cs" Inherits="YellEat.UserSubmitOrder" %>

<%@ Import Namespace="YellEat.BLL" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta charset="utf-8">
    <meta id="viewport" name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <title>YellEat</title>
    <script src="js/jquery-1.10.1.min.js"></script>
    <link rel="stylesheet" href="css/style.css" />
    <link href="css/reset.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/jquery.fancybox.css" rel="stylesheet" />
    <script src="js/jquery.fancybox.pack.js"></script>
</head>
<body>
    <form runat="server" id="form1">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <div id="page-main" data-role="page">
            <header class="top2">
                <div class="top_l">
                    <a class="lb" href="javascript:history.go(-1);"></a>
                </div>
                YellEat
		<div class="en">
            <a>
                <img src="images/english.jpg" /></a>
        </div>
            </header>
            <div class="menu">
                <div class="order-box">
                    <h2><a id="aDeliveryInfo" href="#divDeliveryInfo">送餐信息<span class="icon4"></span></a></h2>
                    <div class="order-info">
                        <ul>
                            <li>
                                <span>收货人：</span><asp:TextBox ID="tbxReceiver" CssClass="input-1 length1" runat="server" />
                                <span>手机：</span><asp:TextBox ID="tbxMobile" CssClass="input-1 length2" runat="server" />
                            </li>
                            <li><span style="text-align: center; width: 35%;">收货地址：</span><asp:TextBox ID="tbxAddress" class="input-1 length4" runat="server" Style="width: 65%" /></li>
                        </ul>
                    </div>
                </div>
                <div class="order-box">
                    <h2>餐厅信息<span class="icon6"></span></h2>
                    <div class="order-info clearfix">
                        <dl>
                            <dt>
                                <img src='<%=OrderingShop.ShopLogoImg %>' style="width: 80px; height: 80px; border-radius: 40px; margin: 5px;" /></dt>
                            <dd class="pf">
                                <%=OrderingShop.ShopName %>
                                <asp:Literal runat="server" ID="ltlRank"></asp:Literal>
                            </dd>
                            <dd class="active">&nbsp;<%=OrderingShop.DeliveryTime %></dd>
                        </dl>
                    </div>
                </div>
                <div class="order-box">
                    <h2>订单详情<span class="icon7"></span></h2>
                    <div class="order-info clearfix">
                        <table style="width: 100%;">
                            <tr>
                                <th colspan="3" style="text-align: center">
                                    <p style="width: 100%;">订单号：<asp:Label runat="server" ID="lblOrderSN"></asp:Label></p>
                                </th>
                            </tr>
                            <asp:Repeater runat="server" ID="rptProduct" OnItemDataBound="rptProduct_OnItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td class="align_left" style="word-break: break-all;">
                                            <%#Eval("ProductName") %>
                                        </td>
                                        <td>
                                            <span class="color1">$<%#Eval("Price") %></span>
                                        </td>
                                        <td class="pad0" style="width: 90px;">
                                            <img src="images/dec.png" class="minus" />
                                            <asp:Label ID="lblAmount" CssClass="amount" runat="server" data-pid='<%#Eval("ProductID") %>' data-unitcost='<%#Eval("Price") %>' />
                                            <img src="images/inc.png" class="add" />
                                            <asp:HiddenField runat="server" ID="hfAmount" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <div class="order-text">
                            <p>备注</p>
                            <p>
                                <asp:TextBox runat="server" TextMode="MultiLine" Rows="5" ID="tbxOrderDesc"></asp:TextBox>
                            </p>
                        </div>
                        <ul class="clearfix">
                            <li><i>小计：</i>$<span id="subTotal"></span></li>
                            <li><i>折扣码：</i><span><asp:TextBox CssClass="length0" ID="tbxCode" runat="server" /></span></li>
                            <li class="red"><i>优惠：</i>$<span id="couponSpan">0</span></li>
                            <li><i>税金：</i>$<span id="faxSpan"></span></li>
                            <li><i>合计：</i>$<span id="totalSpan"></span></li>
                        </ul>
                        <div class="buttonf60">
                            <asp:HiddenField runat="server" ID="hfTotalPrice" />
                            <asp:HiddenField runat="server" ID="hfFax" />
                            <asp:Button runat="server" Text="提交订单" ID="btnOK" OnClick="btnOK_OnClick" />
                        </div>
                    </div>
                </div>
            </div>
            <%--<div class="next">
                <input type="button" class="continue" value="Continue" />
            </div>--%>
            <div style="display: none">
                <div id="divDeliveryInfo" class="dialog">
                    <div class="add_title"><strong onclick="$.fancybox.close()">×</strong>添加新地址</div>
                    <asp:Repeater runat="server" ID="rptDeliveryInfo">
                        <ItemTemplate>
                            <div>
                                <p>
                                    <input type="radio" name="rdDeliveryInfo" data-id='<%#Eval("UserAddressID") %>' />
                                    <span><i class="fa fa-user"></i><%#Eval("Receiver") %>&nbsp;&nbsp;</span><span><i class="fa fa-phone"></i><%#Eval("Mobile") %></span>
                                </p>
                                <p>
                                    <%#Eval("Address") %>
                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        var state = {
            padding: 0,
            modal: true,
            fitToView: true,
            width: '90%',
            height: "160px",
            autoSize: false,
            afterLoad: function () {
                $(".fancybox-overlay.fancybox-overlay-fixed").appendTo($("#form1"));
            }
        };
        $("#aDeliveryInfo").fancybox(state);
        $(function () {
            $(".add").click(function () {
                var $amount = $(this).prev(".amount");
                var txt = $amount.text();//文本框数量
                var num = parseInt(txt);
                if (num >= 1000) return;
                $amount.text(++num);
                $(this).nextAll(":hidden").val(num);
                cal();
            });
            $(".minus").click(function () {
                var $amount = $(this).next(".amount");//数量                
                var txt = $amount.text();
                var num = parseInt(txt);
                if (num <= 0) return;
                $amount.text(--num);
                $(this).nextAll(":hidden").val(num);
                cal();
            });
            cal();
            //数据初始化           
        });

        function cal() {
            var sub = 0.0;//小计
            var fax = 0.0;//税费
            var coupon = parseFloat($("#couponSpan").text());
            $.each($(".amount"), function (index, content) {
                if ($(this).text() == "0") return;
                sub += parseInt($(this).text()) * parseFloat($(this).parent().prev().children("span").text().substring(1));
                fax += parseInt($(this).text()) * parseFloat($(this).attr("data-fax"));
            });

            $("#faxSpan").text(fax.toFixed(2));
            $("#subTotal").text(sub.toFixed(2));
            $("#couponSpan").text(coupon);
            if (sub + fax < coupon) {
                $("#couponSpan").text(0);
                $("#totalSpan").text((sub + fax).toFixed(2));
            } else {
                $("#totalSpan").text((sub + fax - coupon).toFixed(2));
            }
            $("#<%=hfTotalPrice.ClientID%>").val($("#totalSpan").text());
           $("#<%=hfFax.ClientID%>").val($("#faxSpan").text());
       }

       $("#<%=tbxCode.ClientID%>").focusout(function () {
            if ($(this).val() == "") return;
            $.ajax({
                url: "/ashx/CouponCodeChecker.ashx",
                data: {
                    userid: "<%=YeUser.UserID%>",
                   shopid: "<%=OrderingShop.ShopID%>",
                   code: $(this).val()
               },
               method: "post",
               error: function (result) {
                   alert('Error to check the coupon code.');
               },
               success: function (result) {
                   if (result.code == 1) {
                       $("#couponSpan").text(result.dollor);
                       cal();
                   } else {
                       alert("Coupon code is not available now.");
                   }
               }
           });
       });
    </script>
</body>
</html>
