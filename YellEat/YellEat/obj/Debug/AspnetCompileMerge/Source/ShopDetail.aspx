<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.Master" AutoEventWireup="true" CodeBehind="ShopDetail.aspx.cs" Inherits="YellEat.ShopDetail" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="js/jq.Slide.js"></script>
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/jquery.fancybox.css" rel="stylesheet" />
    <script src="js/jquery.fancybox.pack.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="menu">
        <div class="rt_content">
            <!-- <div class="open"></div> -->
            <%=VisitingShop.IsOpenNow ? "<div class='open'></div>":"<div class='close'></div>" %>
            <div class="rt_logo">
                <img src='<%=VisitingShop.ShopLogoImg %>' style="width: 80px; height: 80px; border-radius: 45px;margin-left:10px;" alt='<%=VisitingShop.ShopName %>' />
            </div>
            <div class="rt_info">
                <ul>
                    <li>
                        <span><strong class="rt_name"><%=VisitingShop.ShopName %></strong></span>
                        <span class="rt_pj">
                            <asp:Literal runat="server" ID="ltlRank"></asp:Literal></span>
                        <span>
                            <asp:ImageButton runat="server" ID="btnAdd2Collction" OnClick="btnAdd2Collction_OnClick" ImageUrl="/images/collect.png" /></span>
                    </li>
                    <li>
                        <asp:Repeater runat="server" ID="rptProductTypes">
                            <ItemTemplate>
                                <span class="rt_type"><%#Eval("ProductTypeName") %></span>
                            </ItemTemplate>
                        </asp:Repeater>
                        <span>minimum:$<%=VisitingShop.DeliveryMinPrice %></span>
                    </li>
                    <li><span class="ico rt_ico1"></span><%=VisitingShop.OpenTime %></li>
                    <li><span class="ico rt_ico2"></span><%=VisitingShop.ShopAddress %></li>
                    <li><span class="ico rt_ico3"></span><%=VisitingShop.ShopMobile %></li>
                    <li><span class="ico rt_ico3"></span><%=VisitingShop.DeliveryTime %></li>
                </ul>
            </div>
        </div>
        <div class="coupon clearfix">
            <p>优惠</p>
            <%= YeShopCoupon == null ? "" : @"<a class='fancy' href='#inline'>优惠 $"+ YeShopCoupon.UnitCost+" </a>" %>
            <!-- 获取优惠券 -->
        </div>
        <div class="food">
            <h2>Eye Candy</h2>
            <div id="slide-box">
                <div class="slide-content" id="temp4">
                    <div class="wrap">
                        <ul class="JQ-slide-content">
                            <asp:Repeater runat="server" ID="rptProducts">
                                <ItemTemplate>
                                    <li>
                                        <a href='ShopProduct.aspx?id=<%#Eval("ProductID") %>'>
                                            <img src='<%#Eval("ProductImage")%>' alt='<%#Eval("ProductName") %>' /><%#Eval("ProductName") %>
                                        </a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="JQ-slide-nav"><a class="next" href="javascript:;"></a><a class="prev" href="javascript:;"></a></div>
                </div>
            </div>
            <!--slide-box end-->
        </div>
        <div class="view">
            <a href="ShopProductList.aspx"><span class="view_icon"></span>View Menu</a>
        </div>

        <div style="display: none">
            <div id="inline" class="dialog">
                <div class="add_title"><strong onclick="$.fancybox.close()">×</strong><%=VisitingShop.ShopName %></div>
                <dl>
                    <dd>折扣码：<%= YeShopCoupon==null?"":YeShopCoupon.CouponCode %></dd>
                    <dd><%= YeShopCoupon == null?"":YeShopCoupon.CouponContent %></dd>
                    <dd>有效期：<%= YeShopCoupon==null?"":YeShopCoupon.BeginDate.ToString("yy/MM/dd")+" - "+ YeShopCoupon.EndDate.ToString("yy/MM/dd") %></dd>
                    <dd class="al-center">
                        <asp:Button ID="btnAddCoupon" runat="server" Text="添 加" OnClick="btnAddCoupon_OnClick" CssClass="address-btn" UseSubmitBehavior="False" />
                    </dd>
                </dl>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#temp4").Slide({
                effect: "scroolLoop",
                autoPlay: false,
                speed: "normal",
                timer: 3000,
                steps: 1
            });

            $(".fancy").fancybox({
                padding: 0,
                modal: true,
                fitToView: true,
                width: '100%',
                height: 185,
                autoSize: false,
                afterLoad: function () {
                    $(".fancybox-overlay.fancybox-overlay-fixed").appendTo($("#form1"));
                }                
            });
            $(".fancy2").fancybox({
                padding: 0,
                modal: true,
                fitToView: true,
                width: '70%',
                height: 125,
                autoSize: false,
                afterLoad: function () {
                    $(".fancybox-overlay.fancybox-overlay-fixed").appendTo($("#form1"));
                }
            });           
        });
    </script>
</asp:Content>
