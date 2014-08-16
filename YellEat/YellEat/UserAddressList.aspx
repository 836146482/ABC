<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.Master" AutoEventWireup="true" CodeBehind="UserAddressList.aspx.cs" Inherits="YellEat.UserAddressList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/jquery.fancybox.css" rel="stylesheet" />
    <script src="js/jquery.fancybox.pack.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager1"></asp:ScriptManager>
    <div class="eat">
        <span class="address-icon"></span>地址簿<span style="font-size:5px;">(只能保存3个地址)</span>
    </div>
    <asp:UpdatePanel runat="server" ID="updatePanel1">
        <ContentTemplate>
            <div class="menu">
                <div class="div_list">
                    <asp:Repeater runat="server" ID="rpt">
                        <ItemTemplate>
                            <div class="dc">
                                <dl>
                                    <dd><span><%#Eval("Receiver") %></span>&nbsp;&nbsp;<span><%#Eval("Mobile") %></span></dd>
                                    <dd class="qr">
                                        <label>
                                            <img class="radio-img" src="images/radio.jpg" />
                                            <span class="checked-img" style='display: <%#Convert.ToBoolean(Eval("IsDefault"))?"inline":"none" %>' data-uid='<%#Eval("UserAddressID") %>'></span>
                                        </label>
                                    </dd>
                                    <dd><%#Eval("Address") %></dd>
                                </dl>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div style="height: 44px">&nbsp;</div>
            <div class="total" style="text-align: center">
                <ul>
                    <li style="width: 50%; text-align: right; padding-right: 20px;"><a <%--id="fancy2"--%> href="AddUserAddress.aspx">添加新地址&nbsp;<img src="images/add.png" /></a></li>
                    <li style="width: 50%; text-align: left; padding-left: 20px;">
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="UpdateUserAddress.aspx" >&nbsp;&nbsp;编辑&nbsp;<img src="images/modify.png" /></asp:LinkButton>
                        <%--<a id="fancy1" href="#divUpdate">&nbsp;&nbsp;编辑&nbsp;<img src="images/modify.png" /></a>--%>
                    </li>
                </ul>
                <input type="hidden" name="hdUpdateId" id="hdUpdateId"/>
            </div>
            <%--<div style="display: none">
                <div id="divAdd" class="dialog">
                    <div class="add_title"><strong onclick="$.fancybox.close()">×</strong>添加新地址</div>
                    <dl>
                        <dd>
                            <asp:TextBox runat="server" ID="tbxReceiver" placeholder="姓名" CssClass="width30"></asp:TextBox>
                            <asp:TextBox runat="server" ID="tbxMobile" placeholder="电话" CssClass="width50"></asp:TextBox>
                        </dd>
                        <dd>
                            <asp:TextBox runat="server" ID="tbxAddress" placeholder="地址" CssClass="width100"></asp:TextBox>
                        </dd>
                        <dd class="al-center">
                            <asp:Button runat="server" ID="btnAdd" Text="添加" CssClass="address-btn" OnClick="btnAdd_OnClick" OnClientClick="return checkAdd();" />
                        </dd>
                    </dl>
                    <asp:HiddenField runat="server" ID="hfUpdateID" />
                </div>
            </div>--%>
            <%--<div style="display: none">
                <div id="divUpdate" class="dialog">
                    <div class="add_title"><strong onclick="$.fancybox.close()">×</strong>修改收货地址</div>
                    <dl>
                        <dd>
                            <asp:TextBox runat="server" ID="tbxUpdateReceiver" placeholder="姓名" CssClass="width30"></asp:TextBox>
                            <asp:TextBox runat="server" ID="tbxUpdteMobile" placeholder="电话" CssClass="width50"></asp:TextBox>
                        </dd>
                        <dd>
                            <asp:TextBox runat="server" ID="tbxUpdateAddress" placeholder="地址" CssClass="width100"></asp:TextBox>
                        </dd>
                        <dd class="al-center">
                            <asp:Button runat="server" ID="btnUpdate" Text="保存修改" CssClass="address-btn" OnClick="btnUpdate_OnClick" />
                        </dd>
                    </dl>
                </div>
            </div>--%>

           




            <script type="text/javascript">
                //function checkAdd() {
                //    if ($(".div_list .dc").length >= 3) {
                //        alert("You have got 3 Addresses!It's Limited");
                //        $("#divAdd strong:first").click();
                //    }
                //    return true;
                //}
                
                $(function () {
                    //初始化
                    var dom = $(".checked-img:visible");
                    $("#hdUpdateId").attr("value",dom.attr("data-uid"));
                    //alert($("#hdUpdateId").attr("value"));

                    $('.qr label').click(function () {
                        $('.checked-img').hide();
                        $(this).children('.checked-img').show();
                        var dom = $(".checked-img:visible");
                        $("#hdUpdateId").attr("value",dom.attr("data-uid"));
                        //alert($("#hdUpdateId").attr("value"));
                    });
                    //$(document).click(function (e) {
                    //    if ($(e.target).is('#submenu a')) {
                    //        $('#submenu dl').show();
                    //    } else {
                    //        $('#submenu dl').hide();
                    //    }
                    //});
                });
                    <%-- $("#fancy2").fancybox({
                        padding: 0,
                        modal: true,
                        fitToView: true,
                        width: '90%',
                        height: 185,
                        autoSize: false,
                        afterLoad: function () {
                            $(".fancybox-overlay.fancybox-overlay-fixed").appendTo($("#form1"));
                        }
                    });
                    $("#fancy1").fancybox({
                        padding: 0,
                        modal: true,
                        fitToView: true,
                        width: '90%',
                        height: 185,
                        autoSize: false,
                        afterLoad: function () {
                            var dom = $(".checked-img:visible");
                            var pre = dom.parents("dd:first").prev();
                            $("#<%=tbxUpdateReceiver.ClientID%>").val(pre.children("span:first").text());
                               $("#<%=tbxUpdateAddress.ClientID%>").val(dom.parents("dd:first").next().text());
                               $("#<%=tbxUpdteMobile.ClientID%>").val(pre.children("span:last").text());
                               $("#<%=hfUpdateID.ClientID%>").val(dom.attr("data-uid"));
                               $(".fancybox-overlay.fancybox-overlay-fixed").appendTo($("#form1"));
                        }
                    });--%>
                    <%--$("#<%=btnUpdate.ClientID%>").click(function () {

                        $(".fancybox-overlay.fancybox-overlay-fixed").appendTo($("#form1"));
                    })

                });;--%>

            </script>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
