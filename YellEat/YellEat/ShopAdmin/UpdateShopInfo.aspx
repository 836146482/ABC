<%@ Page Title="" Language="C#" MasterPageFile="~/ShopAdmin/ShopAdminMaster.Master" AutoEventWireup="true" CodeBehind="UpdateShopInfo.aspx.cs" Inherits="YellEat.ShopAdmin.UpdateShopInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #tblOpenTime input {
            width: 50px;
        }

        #tblOpenTime {
            font-weight: bold;
        }

        table tbody tr td label {
            width: 40px;
        }

        input[type="file"] {
            display: inline;
        }

        iframe {
            border: none;
            height: 40px;
            width: 500px;
            display: none;
        }

        #proType table tr td:first-child, #proType table tr td:last-child {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="input-table">
        <tr>
            <td style="width: 70px;">餐馆名称：</td>
            <td style="width: 430px;">
                <asp:TextBox runat="server" ID="tbxShopName" CssClass="form-control"></asp:TextBox></td>
            <td style="width: 200px">
                <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="tbxShopName" ErrorMessage="请输入餐馆中文名" ForeColor="red"></asp:RequiredFieldValidator>

            </td>
        </tr>       
        <tr>
            <td>餐馆类型：</td>
            <td id="proType">
                <asp:CheckBoxList runat="server" ID="cblShopTypes" RepeatDirection="Horizontal" /></td>
            <td></td>
        </tr>
        <tr>
            <td>地址：</td>
            <td>
                <asp:TextBox runat="server" ID="tbxShopAdderss" CssClass="form-control" placeholde="Street address,P.O box,company name,ctx/o"></asp:TextBox>
                
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfv2" ControlToValidate="tbxShopAdderss" ErrorMessage="请输入餐馆地址" ForeColor="red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>邮编：</td>
            <td>
                <asp:TextBox runat="server" ID="tbxShopZip" CssClass="form-control"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfv3" ControlToValidate="tbxShopZip" ForeColor="red" ErrorMessage="请输入餐馆邮编" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ID="rev1" ControlToValidate="tbxShopZip" ForeColor="red" ErrorMessage="餐馆邮编格式不正确" ValidationExpression="[0-9]{5}"  Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>电话：</td>
            <td>
                <asp:TextBox runat="server" ID="tbxShopMobile" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td>电子邮箱：</td>
            <td>
                <asp:TextBox runat="server" ID="tbxShopEmail" CssClass="form-control"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfv4" ControlToValidate="tbxShopEmail" ForeColor="red" ErrorMessage="请输入餐馆电子邮箱"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ID="rev2" ControlToValidate="tbxShopEmail" ForeColor="red" ErrorMessage="电子邮箱格式不正确" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>QQ：</td>
            <td>
                <asp:TextBox runat="server" ID="tbxShopQQ" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td>传真：</td>
            <td>
                <asp:TextBox runat="server" ID="tbxShopFax" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td>送餐时间：</td>
            <td style="text-align: left">
                <asp:DropDownList runat="server" ID="ddlDeliveryTime"/>                  
            </td>
            <td></td>
        </tr>
        <tr>
            <td>营业时间：</td>
            <td>
                <table id="tblOpenTime">
                    <tr>
                        <td>
                            (1)
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxStartHour" CssClass="form-control" MaxLength="2"></asp:TextBox></td>
                        <td>:</td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxStartMinute" CssClass="form-control" MaxLength="2"></asp:TextBox></td>
                        <td>&nbsp;-&nbsp;</td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxEndHour" CssClass="form-control" MaxLength="2"></asp:TextBox></td>
                        <td>:</td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxEndMinute" CssClass="form-control" MaxLength="2"></asp:TextBox></td>
                        <td>&nbsp;&nbsp;（例：9:30-13:30，全天营业请填 0:0-23:59)</td>
                    </tr>
                    <tr>
                        <td>
                            (2)
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxStartHour2" CssClass="form-control" MaxLength="2"></asp:TextBox></td>
                        <td>:</td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxStartMinute2" CssClass="form-control" MaxLength="2"></asp:TextBox></td>
                        <td>&nbsp;-&nbsp;</td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxEndHour2" CssClass="form-control" MaxLength="2"></asp:TextBox></td>
                        <td>:</td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxEndMinute2" CssClass="form-control" MaxLength="2"></asp:TextBox></td>
                        <td>&nbsp;&nbsp;（例：9:30-13:30，全天营业请填 0:0-23:59)</td>
                    </tr>
                </table>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>经度：</td>
            <td>
                <asp:TextBox runat="server" ID="tbxLongitude" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                <asp:RangeValidator runat="server" ID="rv1" Type="Double" MinimumValue="-180" MaximumValue="180" ControlToValidate="tbxLongitude" ErrorMessage="经度必须在-180度到180度之间" ForeColor="red"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>纬度：</td>
            <td>
                <asp:TextBox runat="server" ID="tbxLatitude" CssClass="form-control"></asp:TextBox>
            </td>
            <td>
                <asp:RangeValidator runat="server" ID="rv2" Type="Double" MinimumValue="-90" MaximumValue="90" ControlToValidate="tbxLatitude" ErrorMessage="纬度必须在-90度到90度之间" ForeColor="red"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: left; margin: 0; padding: 0;">
                <table>
                    <tr>
                        <td style="height: 40px;vertical-align: central;">
                            <input type="button" onclick="getJW()" value="点击获取经纬度" class="btn btn-primary btn-xs" />
                            <span id="jw" style="margin: 0; padding: 5px 0; font-size: 12px; font-weight: bold; display: none">正在努力为您获取地理信息，请耐心等候<span id="dot"></span></span>&nbsp;&nbsp;
                        </td>
                        <td>
                            <iframe id="geo"></iframe>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <p style="color: red">允许上传图片格式：.gif、.png、.jpg 以及 .jpeg，图片大小最大为 10 M</p>
                <div style="width: 50%; float: left; text-align: center">
                    <p>餐馆 Logo：<asp:FileUpload runat="server" ID="fupShopLogoImg" Height="35" /></p>
                    
                    <p>
                        <asp:Image runat="server" ID="imgLogo" Width="100" Height="100" style="border-radius:50px;border:1px solid yellowgreen"/>
                    </p>
                </div>
                <div style="width: 50%; float: left; text-align: left">
                    <p>餐馆主图：<asp:FileUpload runat="server" ID="fupShopMainImg" Height="35" /></p>
                    <p>
                        <asp:Image runat="server" ID="imgMain" Width="200" Height="200" />
                    </p>
                </div>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>餐馆描述：</td>
            <td>
                <asp:TextBox runat="server" ID="tbxShopDesc" TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center;">
                <asp:Button runat="server" ID="btnOK" CssClass="btn btn-danger" OnClick="btnOK_OnClick" Text="保存修改" OnClientClick="check()"/>
            </td>
            <td></td>
        </tr>
    </table>
    <script type="text/javascript">
        var __dot = 0;
        var __clicks = 0;
        var timer;
        function dot() {
            if (__clicks++ == 300) clearInterval(timer);
            if (__dot == 0) {
                $("#dot").text('');
                __dot++;
            } else if (__dot == 1) {
                $("#dot").text('.');
                __dot++;
            } else if (__dot == 2) {
                $("#dot").text('..');
                __dot++;
            } else if (__dot == 3) {
                $("#dot").text('...');
                __dot = 0;
            }
        }
        //获取经纬度
        function getJW() {
            $("#geo").attr("src", "GoogleGeograph.html");
            $("#jw").show();
            timer = setInterval("dot()", 1000);
        }
        //检验营业时间
        function check() {
            try {
                var a = parseInt($("#<%=tbxStartHour.ClientID%>").val());
                var b = parseInt($("#<%=tbxStartMinute.ClientID %>").val());
                var c = parseInt($("#<%=tbxEndHour.ClientID%>").val());
                var d = parseInt($("#<%=tbxEndMinute.ClientID%>").val());
                if (a >= 0 && a <= 23 && b >= 0 && b <= 60 && c >= 0 && c <= 23 && d >= 0 && d <= 60) {
                    return true;
                } else {
                    alert('营业时间格式有误！');
                    return false;
                }
            } catch(ex) {
                alert('请检查营业时间格式！');
                return false;
            }             
        }
    </script>
</asp:Content>
