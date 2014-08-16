<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="ShopTypeList.aspx.cs" Inherits="YellEat.YellEatAdmin.ShopTypeList" %>

<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/jquery.fancybox.pack.js"></script>
    <link href="../css/jquery.fancybox.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scrptManager1" EnablePartialRendering="true"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel1" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="text-align: right">
                <a href="#addModal" class="btn btn-sm btn-danger" id="addShop"><i class="fa fa-plus"></i>&nbsp;&nbsp;添加新类型</a>
            </div>
            <asp:Repeater runat="server" ID="rpt" OnItemCommand="rpt_OnItemCommand">
                <HeaderTemplate>
                    <table class="table-condensed table">
                        <thead>
                            <tr class="panel-info">
                                <th style="width: 70px;">
                                    <span>
                                        <input type="checkbox" id="cbxAll" />全选 </span>
                                </th>
                                <td>类型名称</td>
                                <th style="width: 60px;">餐馆数</th>
                                <td style="width: 100px;">操作</td>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="cbxList" /></td>
                        <th><%#Eval("ShopTypeName") %></th>
                        <td><%#Eval("ShopCount") %></td>
                        <td>
                            <a href="#updateModal" class="btn btn-danger btn-xs updateShop" onclick="setShopTypeName('<%#Eval("ShopTypeName") %>',<%#Eval("ShopTypeId")%>)">修改</a>
                            &nbsp;
                            <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-danger btn-xs del" Text="删除" OnClientClick="return confirm('您确定要删除该餐馆类型吗？该操作可能导致系统异常！')" CommandName="del" CommandArgument='<%#Eval("ShopTypeId") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
            <div>
                <%--                <asp:Button runat="server" ID="btnDeleteMany" CssClass="btn btn-sm btn-primary" Text="批量删除" OnClick="btnDeleteMany_OnClick" />--%>
            </div>
            <!-- 修改对话框 -->
            <div class="panel-danger" id="updateModal" style="display: none">
                <div class="panel-heading">
                    <p class="panel-title">修改餐馆类型 - <span style="font-size: 14px;" id="spUpdate"></span></p>
                </div>
                <div class="panel-body">
                    <table>
                        <tr>
                            <td style="width: 80px;">餐馆类型：</td>
                            <td style="width: 200px;">
                                <asp:TextBox runat="server" ID="tbxUpdateShopType" CssClass="form-control"></asp:TextBox></td>
                            <td style="width: 80px;">
                                <asp:Button runat="server" ID="btnUpdateShopType" OnClick="btnUpdateShopType_OnClick" CssClass="btn btn-sm btn-danger" Text="确定修改" /></td>
                        </tr>
                    </table>
                    <asp:HiddenField runat="server" ID="hf" />
                </div>
            </div>
            <!-- 添加对话框 -->
            <div class="panel-danger" id="addModal" style="display: none">
                <div class="panel-heading">
                    <p class="panel-title">新增餐馆类型</p>
                </div>
                <div class="panel-body">
                    <table style="margin: 10px;">
                        <tr>
                            <td style="width: 90px;">新餐馆类型名：</td>
                            <td style="width: 200px;">
                                <asp:TextBox runat="server" ID="tbxAddShopType" CssClass="form-control"></asp:TextBox></td>
                            <td style="width: 80px">
                                <asp:Button runat="server" ID="btnAddShopType" OnClick="btnAddShopType_OnClick" CssClass="btn btn-sm btn-danger" Text="确定添加" /></td>
                        </tr>
                    </table>
                </div>
            </div>
              <script type="text/javascript">
                  $(function () {
                      var state = {
                          padding: 0,
                          maxWidth: 800,
                          maxHeight: 600,
                          fitToView: true,
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
                      $("#addShop").fancybox(state);
                      $(".updateShop").fancybox(state);                   
                    });
                    function setShopTypeName(name, id) {
                        $("#spUpdate").text(name);
                        $("#<%=hf.ClientID%>").val(id);
                    }
                </script>
            <uc1:Pager runat="server" ID="pager1" />
        </ContentTemplate>
    </asp:UpdatePanel>
   <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="position: relative; top: 50%; left: 50%; margin-top: 22px; margin-left: 22px;">
                <img src="../images/loading.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
  --%>
</asp:Content>
