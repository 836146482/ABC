<%@ Page Title="" Language="C#" MasterPageFile="~/ShopAdmin/ShopAdminMaster.Master" AutoEventWireup="true" CodeBehind="ProductTypeManage.aspx.cs" Inherits="YellEat.ShopAdmin.ProductTypeManage" %>

<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        select option {
            padding: 3px;
        }

        table tr td:last-child {
            text-align: right;
        }
    </style>
    <link href="../css/jquery.fancybox.css" rel="stylesheet" />
    <script src="../js/jquery.fancybox.pack.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManger1" EnablePartialRendering="True"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel1" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="text-align: right;">
                <a href="#addPanel" class="fancy btn btn-danger btn-sm"><i class="fa fa-plus"></i>&nbsp;添加菜单分类</a>
            </div>
            <div>
                <asp:Repeater runat="server" ID="rpt" OnItemCommand="rpt_OnItemCommand">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>分类名称</th>
                                    <th style="width: 100px;">菜单数</th>
                                    <td style="width: 100px;">操作</td>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("ProductTypeName") %></td>
                            <td><%#Eval("ProductCount") %></td>
                            <td>
                                <a class="btn btn-xs btn-danger" data-cid='<%#Eval("ProductTypeId") %>' onclick="triggerUpdate(this)">更新</a>
                                <span style="display: none"><%#Eval("ProductTypeID") %></span>
                                <asp:Button runat="server" ID="btnDelete" CommandName="del" Text="删除" CommandArgument='<%#Eval("ProductTypeId") %>' OnClientClick="return confirm('删除菜单分类将会连其关联的菜单一起删除，您确定要删除吗？')" CssClass="btn btn-danger btn-xs" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <div id="addPanel" style="display: none">
                <div class="panel-danger">
                    <div class=" panel-heading">
                        <p class="panel-title">添加菜单分类</p>
                    </div>
                    <div class="panel-body">
                        <table>
                            <tr>
                                <td style="width: 80px;">分类名称：</td>
                                <td>
                                    <asp:TextBox runat="server" ID="tbxProductType" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnOk" Text="确定添加" CssClass="btn btn-danger btn-sm" OnClick="btnOk_OnClick" OnClientClick="return check1();"/></td>
                            </tr>
                        </table>
                    </div>
                </div>

            </div>
            <div id="updatePanel" style="display: none">
                <div class="panel-danger">
                    <div class="panel-heading">
                        <p class="panel-title">修改菜单分类 —— <span id="updateProType"></span></p>
                           <asp:HiddenField runat="server" ID="hfUpdateTypeId" />
                    </div>
                    <div class="panel-body">
                        <table>
                            <tr>
                                <td>新分类名称：</td>
                                <td>
                                    <asp:TextBox runat="server" ID="tbxProductType2" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnUpdate" Text="确定修改" CssClass="btn btn-danger btn-sm" OnClick="btnUpdate_OnClick" OnClientClick="return check2();" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div style="display: none;">
                <a class="fancy" href="#updatePanel" id="aaaa"></a>
            </div>
         
            <script type="text/javascript">
                function check1() {
                    if ($("#<%=tbxProductType.ClientID%>").val() == '') {
                        alert('请输入新的菜单分类名称！');
                        $("#<%=tbxProductType.ClientID%>").focus();
                        return false;
                    }
                    return true;
                }
                function check2() {
                    if ($("#<%=tbxProductType2.ClientID%>").val() == '') {
                        alert('请输入新的菜单分类名称！');
                        $("#<%=tbxProductType2.ClientID%>").focus();
                         return false;
                     }
                     return true;
                 }
                 //参数 obj 为dom
                 function triggerUpdate(obj) {
                     $("#updateProType").text($(obj).parent().prev().prev().text());
                     $("#<%=hfUpdateTypeId.ClientID%>").val($(obj).attr("data-cid"));
                     $("#aaaa").click();
                 }
                 $(function () {
                     $(".fancy").fancybox({
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
                     });
                    });
            </script>
            <uc1:Pager runat="server" ID="pager1" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
