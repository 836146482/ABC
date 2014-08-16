<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="ShopList.aspx.cs" Inherits="YellEat.YellEatAdmin.ShopList" %>

<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/jquery.fancybox.pack.js"></script>
    <link href="../css/jquery.fancybox.css" rel="stylesheet" />
    <style type="text/css">
        .txtUpdate{
            width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager1"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel1">
        <ContentTemplate>
            <div style="text-align: right">
                <a href="../ShopAdmin/Register.aspx" class="btn btn-sm btn-danger" id="addShop" target="_blank"><i class="fa fa-plus"></i>&nbsp;&nbsp;添加新餐馆</a>
            </div>
            <asp:Repeater runat="server" ID="rpt" OnItemCommand="rpt_OnItemCommand">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr class="panel-primary">
                                <th>
                                    <input type="checkbox" id="cbxAll" /></th>
                                <th>餐馆中文名</th>
                                <th>电话</th>
                                <th>邮箱</th>
                                <th>QQ</th>
                                <th>传真</th>
                                <th>状态</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="cbx" /></td>
                        <td><%#Eval("ShopName") %></td>
                        <td><%#Eval("ShopMobile") %></td>
                        <td><%#Eval("ShopEmail") %></td>
                        <td><%#Eval("ShopQQ") %></td>
                        <td><%#Eval("ShopFax") %></td>
                        <td><%# Convert.ToBoolean(Eval("IsChecked"))?"<label class='label label-success'>已审核</label>":"<label class='label label-warning'>未审核</label>" %></td>
                        <td>
                            <a href="#detailModal" class="btn btn-xs btn-primary btn-detail" onclick="getdetail(<%#Eval("ShopId") %>)">详情</a>
                            <a href="#updateModal" class="btn btn-xs btn-primary btn-update" onclick="updetail(<%#Eval("ShopId") %>)">修改</a>
                            <asp:Button CssClass="btn btn-xs btn-danger" runat="server" ID="btnCheck" Text='<%# Convert.ToBoolean(Eval("IsChecked"))?"取消审核":"审核通过" %>' CommandName="sh" CommandArgument='<%#Eval("ShopID")+","+Eval("IsChecked") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
            <uc1:Pager runat="server" ID="pager1" />

            <!-- 详情对话框 -->
            <div id="detailModal" style="display: none;min-width:500px;text-align:center;" class="panel-danger">
                <div class="panel-heading">
                    <p class="panel-title">餐馆详情- <span style="font-size: 14px;" id="shopName"></span></p>
                </div>
                <div class="panel-body">
                    <table style="width:100%;">
                        <tr>
                            <td style="text-align:center;">餐馆账户：</td>
                            <td id="shopAccount" style="text-align:center;"></td>
                            <%-- <td style="width: 200px;">
                                <asp:TextBox runat="server" ID="tbxUpdateShopType" CssClass="form-control"></asp:TextBox></td>
                            <td style="width: 80px;">
                                <asp:Button runat="server" ID="btnUpdateShopType" OnClick="btnUpdateShopType_OnClick" CssClass="btn btn-sm btn-danger" Text="确定修改" /></td>--%>
                        </tr>
                        <tr>
                            <td style="text-align:center;">注册时间：</td>
                            <td id="shopRegisterTime" style="text-align:center;"></td>
                        </tr>
                        <tr>
                            <td style="text-align:center;">地&nbsp;&nbsp;址：</td>
                            <td id="shopAddress" style="text-align:center;" ></td>
                        </tr>
                        <tr>
                            <td style="text-align:center;">邮&nbsp;&nbsp;编：</td>
                            <td id="shopZip" style="text-align:center;"></td>
                        </tr>
                        <tr>
                            <td style="text-align:center;">电&nbsp;&nbsp;话：</td>
                            <td id="shopMobile" style="text-align:center;"></td>
                        </tr>
                        <tr>
                            <td style="text-align:center;">邮&nbsp;&nbsp;箱：</td>
                            <td id="shopEmail" style="text-align:center;"></td>
                        </tr>
                        <tr>
                            <td style="text-align:center;">Q&nbsp;&nbsp;Q：</td>
                            <td id="shopQQ" style="text-align:center;"></td>
                        </tr>
                        <tr>
                            <td style="text-align:center;">传&nbsp;&nbsp;真：</td>
                            <td id="shopFax" style="text-align:center;"></td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hf" />
                </div>
            </div>

            <!--修改对话框-->
             <div id="updateModal" style="display: none;min-width:500px;text-align:center;" class="panel-danger">
                <div class="panel-heading">
                    <p class="panel-title">餐馆信息- <span style="font-size: 14px;" id="upShopName"></span></p>
                </div>
                <div class="panel-body">
                    <table style="width:100%;">
                        <tr>
                            <td style="text-align:center;">餐馆账户：</td>
                            <td id="upShopAccount"  style="text-align:center;"></td>
                            <%-- <td style="width: 200px;">
                                <asp:TextBox runat="server" ID="tbxUpdateShopType" CssClass="form-control"></asp:TextBox></td>
                            <td style="width: 80px;">
                                <asp:Button runat="server" ID="btnUpdateShopType" OnClick="btnUpdateShopType_OnClick" CssClass="btn btn-sm btn-danger" Text="确定修改" /></td>--%>
                        </tr>
                        <tr>
                            <td style="text-align:center;">注册时间：</td>
                            <td id="upShopRegisterTime"  style="text-align:center;"></td>
                        </tr>
                        <tr>
                            <td style="text-align:center;">地&nbsp;&nbsp;址：</td>
                            <td>
                                <asp:TextBox ID="txtShopAddress" runat="server" CssClass="txtUpdate"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:center;">邮&nbsp;&nbsp;编：</td>
                            <td>
                                <asp:TextBox ID="txtShopZip" runat="server" CssClass="txtUpdate"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:center;">电&nbsp;&nbsp;话：</td>
                            <td>
                                <asp:TextBox ID="txtShopMobile" runat="server" CssClass="txtUpdate"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:center;">邮&nbsp;&nbsp;箱：</td>
                            <td>
                                <asp:TextBox ID="txtShopEmail" runat="server" CssClass="txtUpdate"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:center;">Q&nbsp;&nbsp;Q：</td>
                            <td>
                                <asp:TextBox ID="txtShopQQ" runat="server" CssClass="txtUpdate"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:center;">传&nbsp;&nbsp;真：</td>
                            <td>
                                <asp:TextBox ID="txtShopFax" runat="server" CssClass="txtUpdate"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align:center;">
                                <asp:Button ID="btnUpdateShop" runat="server" Text="修改" CssClass="btn btn-xs btn-primary" OnClick="btnUpdateShop_Click" />
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hfShopId" />
                </div>
            </div>
            <script type="text/javascript">
               
                $(function () {
                    var state = {
                        padding: 0,
                        maxWidth: 800,
                        maxHeight: 600,
                        fitToView: false,
                        width: '70%',
                        height: '70%',
                        autoSize: true,
                        closeClick: false,
                        openEffect: 'none',
                        closeEffect: 'none',
                        afterLoad: function () {
                            $(".fancybox-overlay.fancybox-overlay-fixed").appendTo($("#form1"));
                        }
                    };
                    $(".btn-detail").fancybox(state);
                    $(".btn-update").fancybox(state);
                });
                function getdetail(shopId) {
                    //alert("ff");
                    $.ajax({
                        type: "POST",
                        url: "GetShopDetail.ashx",
                        data: { shopId: shopId },
                        dataType:"json",
                        success: function (res) {
                            $("#shopName").text(res.ShopName);
                            //res.ShopID
                            $("#shopRegisterTime").text(res.RegisterTime.substr(0,10));
                            $("#shopAccount").text(res.ShopAccount);
                            $("#shopAddress").text(res.ShopAddress);
                            $("#shopZip").text(res.ShopZip);
                            $("#shopMobile").text(res.ShopMobile);
                            $("#shopEmail").text(res.ShopEmail);
                            $("#shopQQ").text(res.ShopQQ);
                            $("#shopFax").text(res.ShopFax);
                        }
                    });
                }
                function updetail(shopId)
                {
                    $.ajax({
                        type:"POST",
                        url: "GetShopDetail.ashx",
                        data: { shopId: shopId },
                        dataType: "json",
                        success: function (res) {
                            $("#upShopName").text(res.ShopName);
                            $("#upShopRegisterTime").text(res.RegisterTime.substr(0, 10));
                            $("#upShopAccount").text(res.ShopAccount);
                            $("#<%=txtShopAddress.ClientID%>").val(res.ShopAddress);
                            $("#<%=txtShopZip.ClientID%>").val(res.ShopZip);
                            $("#<%=txtShopMobile.ClientID%>").val(res.ShopMobile);
                            $("#<%=txtShopEmail.ClientID%>").val(res.ShopEmail);
                            $("#<%=txtShopQQ.ClientID%>").val(res.ShopQQ);
                            $("#<%=txtShopFax.ClientID%>").val(res.ShopFax);
                            $("#<%=hfShopId.ClientID%>").val(shopId);
                        }
                    });
                }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
