<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="YellEat.Home" ClientIDMode="Static" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta charset="utf-8">
    <meta id="viewport" name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <title>YellEat</title>
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css" />
    <link href="css/jquery.fancybox.css" rel="stylesheet" />
    <script src="js/jquery-1.10.1.min.js"></script>    
    <script type="text/javascript">
        $(function() {
            var state = {
                padding: 0,
                modal: true,
                fitToView: true,
                width: '90%',
                height: '80px',
                autoSize: false,
                afterLoad: function() {
                    $(".fancybox-overlay.fancybox-overlay-fixed").appendTo($("#form1"));
                }
            };
            $("#aDeliveryInfo").fancybox(state);
            if ($.cookies.get("username") != "") {
                $("#spanName").text($.cookies.get("username"));
            } else {
                $("#spanName").text("Sir or Madam");
            }
            //获取地理位置
            var positionOption = {
                enableHighAccuracy: true,
                maximumAge: 30000,
                timeout: 5000
            };
            navigator.geolocation.getCurrentPosition(getPositionSuccess, function () { }, positionOption);            
        });
        function getPositionSuccess( position ){
            var lat = position.coords.latitude;
            var lng = position.coords.longitude;
            $.ajax({
                url:"http://maps.google.com/maps/api/geocode/xml?latlng="+ lat+
                    "," + lng + "&language=en-us&sensor=false",
                method:"post",
                success: function (result) {
                    console.log(result);
                    $("#tbxAddr").val(result.results.formatted_address);
                }
            }); 
        }

        function getPositionError(error) {
            switch (error.code) {
                case error.TIMEOUT:
                    alert("连接超时，请重试");
                    break;
                case error.PERMISSION_DENIED:
                    alert("您拒绝了使用位置共享服务，查询已取消");
                    break;
                case error.POSITION_UNAVAILABLE:
                    alert("获取位置信息失败");
                    break;
            }
        }
    </script>
</head>
<body id="home">
    <form id="form1" runat="server">
        <div id="page-main" data-role="page">
            <header>
                <div class="en">
                    <a id="aGetLocationInfo" href="#divGetLocationInfo">
                        <img src="images/english.jpg" /></a>
                </div>
            </header>
            <div style="text-align: center; margin-top: 20px">
                <img src="images/home.png" style="width: 90%" />
            </div>
            <div class="dtext">Dear <span id="spanName"></span>: </div>
            <div class="dtext2">您当前位置 : </div>
            <div class="white_text">
                <asp:TextBox ID="tbxAdd" CssClass="form-control" placeholder="Address" style="width: 70%; margin-left: 15%;background-color:#ffffff;opacity: 1;" runat="server" />
                <img id="img_location" class="simg" src="images/loc.png" onclick="getLocationInfo()"/>
            </div>
            <div class="ctext">开始点餐吧</div>
            <div class="cimg">
                <asp:ImageButton ID="img_okgo" CssClass="simg" src="images/ok.png" runat="server" OnClick="img_okgo_OnClick" />
            </div>
        </div>
    </form>
    <div style="display: none;" id="divGetLocationInfo">
        <p style="height: 60px; text-align: center; background: url(/images/loading.gif) no-repeat center">It's busy loading your location information...</p>
    </div>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.fancybox.pack.js"></script>
    <script src="js/jquery.cookies.2.2.0.min.js"></script>
<%--    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"> 
</script>--%>
</body>
</html>
