<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.Master" AutoEventWireup="true" CodeBehind="UserOrderResult.aspx.cs" Inherits="YellEat.UserOrderResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/idangerous.swiper-2.1.min.js"></script>
    <script src="js/jquery-1.10.1.min.js"></script>
    <script src="js/jquery.raty.min.js"></script>
    <link href="css/idangerous.swiper.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- 用餐评价 -->
    <div class="eat">
		我要评价<span class="edit-icon"></span>
	</div>
	<div class="menu">
		<div class="comment" style="margin-top: 5px;">
			<dl>
				<dt><img src='<%=Shop.ShopLogoImg %>' style="width:80px;height: 80px;border-radius:40px;"/></dt>
				<dd><strong class="rt_name"><%=Shop.ShopName %></strong></dd>			
			</dl>
			<dl class="h40">
				<dt>服务品质</dt>
				<dd>
					<%--<a href="#star1" onclick="SetPoint('star1');">
                        <img id="star1" src="images/star.png" /></a>
                    <a href="#star2" onclick="SetPoint('star2');">
                        <img id="star2" src="images/star.png" /></a>
                    <a href="#star3" onclick="SetPoint('star3');">
                        <img id="star3" src="images/star.png" /></a>
                    <a href="#star4" onclick="SetPoint('star4');">
                        <img id="star4" src="images/star.png" /></a>
                    <a href="#star5" onclick="SetPoint('star5');">
                        <img id="star5" src="images/star.png" /></a>--%>
                    <span id="eatRaty"></span>
                    <asp:HiddenField ID="hfEatingStar"  runat="server" Value="1"/>
				</dd>
			</dl>
			<dl class="h40">
				<dt>送餐速度</dt>
				<dd>
					<%--<a href="#star1" onclick="SetPoint('star1');">
                        <img id="star1" src="images/star.png" /></a>
                    <a href="#star2" onclick="SetPoint('star2');">
                        <img id="star2" src="images/star.png" /></a>
                    <a href="#star3" onclick="SetPoint('star3');">
                        <img id="star3" src="images/star.png" /></a>
                    <a href="#star4" onclick="SetPoint('star4');">
                        <img id="star4" src="images/star.png" /></a>
                    <a href="#star5" onclick="SetPoint('star5');">
                        <img id="star5" src="images/star.png" /></a>--%>
                    <span id="deliveryRaty"></span>
                    <asp:HiddenField ID="hfDeliveryStar"  runat="server" Value="1"/>
				</dd>
			</dl>
			<div class="comment-content">
				<asp:TextBox runat="server" TextMode="MultiLine" ID="tbxContent" placeholder="写点评价，对其他吃货帮助很大喔！" Rows="4"></asp:TextBox>
			</div>
			<%--<div class="select-fee clearfix">
				<ul>
					<li><label><img class="radio-img" src="images/radio.jpg" /><span  class="checked-img"></span></label> 免费例汤</li>
					<li><label><img class="radio-img" src="images/radio.jpg" /><span  class="checked-img"></span></label> 免费可乐</li>
				</ul>
			</div>--%>
			<div class="comment-btn">
			    <asp:Button runat="server" Text="发表评论" ID="btnOK" OnClick="btnOK_OnClick"/>				
			</div>
		</div>
	</div>
    <script type="text/javascript">
        $("#eatRaty").raty({
            readOnly: true,
            path: "images/raty",
            size: 24,
            starOff: 'star-off-big.png',
            starOn: 'star-on-big.png'
        });
        $(function () {
            $("#eatRaty img:first").attr("src", "images/raty/star-on-big.png");
            $("#eatRaty img").each(function (index, element) {
                $(this).click(function () {
                    for (var i = 1; i < 6; i++) {
                        if (index >= i) $("#eatRaty img:eq(" + i + ")").attr("src", "images/raty/star-on-big.png");
                        else break;
                    }
                    for (; i < 6; i++) {
                        $("#eatRaty img:eq(" + i + ")").attr("src", "images/raty/star-off-big.png");
                    }
                    $("#<%=hfEatingStar.ClientID%>").val(index+1);
                    });
                });
        });
        $("#deliveryRaty").raty({
            readOnly: true,
            path: "images/raty",
            size: 24,
            starOff: 'star-off-big.png',
            starOn: 'star-on-big.png'
        });
        $(function () {
            $("#deliveryRaty img:first").attr("src", "images/raty/star-on-big.png");
            $("#deliveryRaty img").each(function (index, element) {
                $(this).click(function () {
                    for (var i = 1; i < 6; i++) {
                        if (index >= i) $("#deliveryRaty img:eq(" + i + ")").attr("src", "images/raty/star-on-big.png");
                        else break;
                    }
                    for (; i < 6; i++) {
                        $("#deliveryRaty img:eq(" + i + ")").attr("src", "images/raty/star-off-big.png");
                    }
                    $("#<%=hfDeliveryStar.ClientID%>").val(index+1);
                });
            });
        });
        <%--function SetPoint(tid) {
            var src = $("#" + tid).attr("src");
            var jqdom = $("#<%=hfEatingStar.ClientID%>");
            var points = jqdom.val();
            if (src == "images/star.png") {
                $("#" + tid).attr("src", "images/star_cancel.png");
                var d = parseInt(points) - 1;
                jqdom.val(d);
            } else {
                var d = parseInt(points) + 1;
                jqdom.val(d);
                $("#" + tid).attr("src", "images/star.png");
            }
        }--%>
    </script>
</asp:Content>
