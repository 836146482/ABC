<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ShopList.aspx.cs" Inherits="YellEat.ShopList" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta charset="utf-8">
    <title>YellEat</title>
    <meta id="viewport" name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <link rel="stylesheet" href="css/style.css" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/jquery-1.10.1.min.js"></script>
    <script src="js/jquery.fancybox.pack.js"></script>
    <link href="css/jquery.fancybox.css" rel="stylesheet" />
    <script src="js/jquery.dragval-1.0.js"></script>
    <script src="js/jquery-ui-1.10.4.min.js"></script>
    <script src="js/jquery.cookie.js"></script>
    <script src="js/jquery.raty.min.js"></script>
    <link href="css/jquery.dragval-1.0.css" rel="stylesheet" />
    <style type="text/css">
        .page-width {
            width: 100%;
        }
    </style>
</head>

<body>
    <form runat="server" id="form1">
        <!-- 餐厅列表 -->
        <asp:ScriptManager runat="server" ID="scriptManager1"></asp:ScriptManager>
        <div id="page-main" data-role="page">
            <asp:UpdatePanel runat="server" ID="updatePanel1">
                <ContentTemplate>
                    <div id="page-pack">
                        
                        <div id="page2" class="page-width">
                            <header class="top2">
                                <div class="top_l"><a class="lb"  id="mhome"></a></div>
                                YellEat
				                <div class="en">
                                    <a>
                                        <img src="images/english.jpg" />
                                    </a>
                                </div>
                        </header>
                            <div class="top3"><%=Location %></div>
                            <div class="search">
                                <div id="mleft" class="filter"></div>
                                <div class="search-btn">
                                    <asp:ImageButton runat="server" ID="imgBtnSearch" OnClick="imgBtnSearch_OnClick" ImageUrl="images/search-btn.png"></asp:ImageButton>
                                </div>
                                <div class="search-input">
                                    <asp:TextBox runat="server" ID="tbxSearch" />
                                </div>
                            </div>
                            <div class="menu">
                                <asp:Repeater ID="rptShopList" runat="server" OnItemDataBound="rptShopList_OnItemDataBound">
                                    <ItemTemplate>
                                        <div class="div_list">
                                            <a href='ShopDetail.aspx?shopid=<%#Eval("ShopID") %>'>
                                                <div class="dc" style="width: 95%">
                                                    <table style="vertical-align: text-top; width: 100%">
                                                        <tr>
                                                            <td style="width: 25%; text-align: center">
                                                                <div class="dlogo" style="margin-top: 5px">
                                                                    <img src="images/df.JPG" />
                                                                </div>
                                                            </td>
                                                            <td style="width: 45%; text-align: left">
                                                                <p style="font-size: 14px;"><%#Eval("ShopName") %></p>
                                                                <p>
                                                                    <span style="color: #ff6600;">
                                                                        <asp:Literal runat="server" ID="ltlRank"></asp:Literal>
                                                                    </span>
                                                                    <%#Eval("Clicks") %>&nbsp;reviews
                                                                </p>
                                                                <p class="active"><%#Eval("DeliveryTime") %></p>
                                                            </td>
                                                            <td style="width: 30%; text-align: center">
                                                                <div style="margin-top: 5px;">
                                                                    <%# Convert.ToBoolean(Eval("IsOpenNow"))
                                                        ?"<div class='open_time'><span>Open</span><p><i class='fa fa-clock-o'></i>"+Eval("OpenTime")+"</p></div>"
                                                        :"<div class='close_time'><span>Closed</span><p><i class='fa fa-clock-o'></i>"+Eval("OpenTime")+"</p></div>" %>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Button runat="server" ID="btnMore" Text="加载更多..." OnClientClick="keepData()" OnClick="btnMore_OnClick"/>
                            </div>
                            <div class="nav">
                                <ul>
                                    <li class="w40"><a href="UserShopCart.aspx">
                                        <img src="images/icon1.png" />
                                        购物车<span id="cartNum"></span></a></li>
                                    <li class="w20"><a href="Home.aspx">
                                        <img src="images/icon2.png" /></a></li>
                                    <li class="w40" id="submenu"><a href="javascript:;">
                                        <img src="images/icon3.png" />我的账户</a>
                                        <dl>
                                            <dd><a href="Contact.aspx">联系我们</a></dd>
                                            <dd><a href="UserOrders.aspx">历史订单</a></dd>
                                            <dd><a href="UserCollection.aspx">我的收藏</a></dd>
                                            <dd><a href="UserCenter.aspx">用户中心</a></dd>
                                        </dl>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div id="page1" class="page-width" style="display: none;">
                            <header class="top2">
                                <div class="top_l"><a class="lb"  id="mright"></a></div>
                                YellEat
				                <div class="en">
                                    <a>
                                        <img src="images/english.jpg" />
                                    </a>
                                </div>
                            </header>
                            <div class="eat">
                                筛选　<span class="filter-icon"></span>
                            </div>
                            <div class="menu">
                                <div class="filter-box">
                                    <div class="ship">
                                        <h2>送货筛选</h2>
                                        <ul id="radio-deliver" class="clearfix">
                                            <li class="selected">送货</li>
                                            <li>自取</li>
                                        </ul>
                                    </div>
                                    <div class="attr-box">
                                        <asp:HiddenField runat="server" ID="hfShopTypes" />
                                        <h2>菜式筛选</h2>
                                        <div class="type-filter">
                                            <asp:Repeater runat="server" ID="rptShopTypes">
                                                <ItemTemplate>
                                                    <dl>
                                                        <dt><%#Eval("ShopTypeName") %></dt>
                                                        <dd>
                                                            <label>
                                                                <img src="images/checkbox.png" />
                                                                <span data='<%#Eval("ShopTypeId") %>' class="checked-img green"></span>
                                                            </label>
                                                        </dd>
                                                    </dl>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <div class="other-filter" style="clear: both">
                                            <dl>
                                                <dt class="clearfix">评价筛选</dt>
                                                <dd>
                                                    <span id="raty"></span>
                                                    <asp:HiddenField ID="hfEatingStar" runat="server" Value="1" />
                                                </dd>
                                            </dl>
                                            <dl>
                                                <dt>点餐次数</dt>
                                                <dd>
                                                    <div id="Slider2" class="Dragval">
                                                        <asp:HiddenField runat="server" ID="hfOrderCount" Value="0" />
                                                    </div>
                                                    <script type="text/javascript">
                                                        $(function () {
                                                            $("#Slider2").dragval({ step: 100, min: 0, max: 400, startValue: 0, indicStep: 43 });
                                                        });
                                                    </script>
                                                </dd>
                                            </dl>
                                            <dl>
                                                <dt class="clearfix">送餐速度(min)</dt>
                                                <dd>
                                                    <div id="Slider3" class="Dragval">
                                                        <asp:HiddenField runat="server" ID="hfMinDeliveryPrice" Value="0" />
                                                    </div>

                                                    <script type="text/javascript">
                                                        $(function () {
                                                            $("#Slider3").dragval({ step: 10, min: 0, max: 40, startValue: 0, indicStep: 43 });
                                                        });
                                                    </script>
                                                </dd>
                                            </dl>
                                        </div>
                                        <p style="margin-top: 50px;" class="view">
                                            <a id="back">保存筛选</a>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div style="display: none" id="divData">             
            </div>
        </div>
        <script type="text/javascript">
            //raty插件
            $("#raty").raty({
                readOnly: true,
                path: "images/raty",
                size: 24,
                starOff: 'star-off-big.png',
                starOn: 'star-on-big.png'
            });
            $('#page-pack').css('width', $('#page-main').width() * 2);
            $('.page-width').css('width', $('#page-main').width());
            $(function () {
                ShowAmount();
                $('#radio-deliver li').click(function () {
                    var idx = $(this).index();
                    $('#radio-deliver li').removeClass('selected').eq(idx).addClass('selected');

                });
                $('.type-filter dl label').click(function () {
                    var green = $(this).children('.green');
                    if (green.is(":hidden")) {
                        green.show();
                    } else {
                        green.hide();
                    }
                    var check = $('.type-filter dl label span:visible');
                    var v = '';
                    $.each(check, function (i, n) {
                        v += $(n).attr('data') + ',';
                    });
                    $('#<%=hfShopTypes.ClientID%>').val(v);
                });
                $(document).click(function (e) {
                    if ($(e.target).is('#submenu a')) {
                        $('#submenu dl').show();
                    } else {
                        $('#submenu dl').hide();
                    }
                });
                $(".fancy").fancybox({
                    padding: 0,
                    modal: true,
                    fitToView: true,
                    width: '70%',
                    height: 185,
                    autoSize: false
                });
                $('#mleft').click(function () {
                    console.log('mleft');
                    $('#page1').show();
                    $('#page2').hide();
                    //$('#page-pack').stop().animate({ marginLeft: -$('#page-main').width()-20 + 'px' }, 500);
                });
                $('#mright').click(function () {
                    console.log('mright');
                    $('#page1').hide();
                    $('#page2').show();
                    //$('#page-pack').stop().animate({ marginLeft: 0 + 'px' }, 500);
                });
                $('#mhome').click(function(){
                    history.back();

                });
                $("#back").click(function () {
                    console.log('back');
                    $('#page1').hide();
                    $('#page-pack').stop().animate({ marginLeft: '0px' }, 500);
                    $(document).scrollTop();
                });
                $("#raty img:first").attr("src", "images/raty/star-on-big.png");
                $("#raty img").each(function (index, element) {
                    $(this).click(function () {
                        for (var i = 1; i < 6; i++) {
                            if (index >= i) $("#raty img:eq(" + i + ")").attr("src", "images/raty/star-on-big.png");
                            else break;
                        }
                        for (; i < 6; i++) {
                            $("#raty img:eq(" + i + ")").attr("src", "images/raty/star-off-big.png");
                        }
                        $("#<%=hfEatingStar.ClientID%>").val(index);
                    });
                });
            });

            function keepData() {
                $("#divData").appendChild($(".menu .div_list"));
            }

            function loadData() {
                $("#divData").children().insertBefore(".menu");
            }
            //显示购物车数量
            function ShowAmount() {
                var AllAmount = $.cookie('allAmount');
                $('#cartNum').text('(' + AllAmount + ')');
            }
        </script>
    </form>
</body>
</html>




