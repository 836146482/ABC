<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="UnitList.aspx.cs" Inherits="YellEat.YellEatAdmin.UnitList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/jquery.fancybox.pack.js"></script>
    <link href="../css/jquery.fancybox.css" rel="stylesheet" />
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
                afterLoad: function() {
                    $(".fancybox-overlay.fancybox-overlay-fixed").appendTo($("#form1"));
                }
            };
            $("#addUnit").fancybox(state);
            $(".updateUnit").fancybox(state);           
        });        
        function setShopTypeName(name, id) {
            $("#spUpdate").text(name);
            $("#<%=hf.ClientID%>").val(id);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager runat="server" ID="scrptManager1" EnablePartialRendering="true"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel1" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="text-align:right">
                <a href="#addModal" class="btn btn-sm btn-danger" id="addUnit"><i class="fa fa-plus"></i>&nbsp;&nbsp;添加新税金</a>
            </div>             
            <asp:Repeater runat="server" ID="rpt">
                <HeaderTemplate>
                    <table class="table-condensed table">
                        <thead>
                        <tr class="panel-info">
                            <td style="width:50px;">ID</td>
                            <th>税金名称</th>
                            <th>税金百分比</th>
                            <td style="width:100px;">
                                操作
                            </td>
                        </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%#Eval("UnitID") %></th>
                        <td><%#Eval("UnitName") %></td>
                        <td><%#Eval("UnitPoint") %></td>
                        <td>
                            <a href="#updateModal" class="btn btn-danger btn-xs updateUnit" onclick="setShopTypeName('<%#Eval("UnitName") %>',<%#Eval("UnitID")%>)">修改</a>
                            &nbsp;
                            <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-danger btn-xs" Text="删除" OnClientClick='return confirm("您确定要删除名为“<%#Eval("UnitName") %> %”的餐馆类型吗，该操作将导致系统异常！")' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                   
                    </table>
                </FooterTemplate>                
            </asp:Repeater>
            <div>
               
                <%--                <asp:Button runat="server" ID="btnDeleteMany" CssClass="btn btn-sm btn-primary" Text="批量删除" OnClick="btnDeleteMany_OnClick" />--%>
            </div>        
            <!-- 修改对话框 -->
            <div class="panel-primary" id="updateModal" style="display: none">
                <div class="panel-heading">
                    <p class="panel-title">修改税金 - <span style="font-size: 14px;" id="spUpdate"></span></p>
                </div>
                <div class="panel-body">
                    <table class="input-table">
                        <tr>
                            <th style="width:90px;">税金名称：</th>
                            <td style="width: 200px;"><asp:TextBox runat="server" ID="tbxUpdateUnit" CssClass="form-control"></asp:TextBox></td>                           
                            <td style="width: 100px;"><asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="tbxUpdateUnit" ErrorMessage="请输入税金名称" ForeColor="red"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <th>税金百分比：</th>
                            <td><asp:TextBox runat="server" ID="tbxUpdatePoint" CssClass="form-control"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                             <th colspan="3"><asp:Button runat="server" ID="btnUpdateUnit" OnClick="btnUpdateUnit_OnClick" CssClass="btn btn-sm btn-primary" Text="确定修改" /></th>
                        </tr>
                    </table>                 
                    <asp:HiddenField runat="server" ID="hf" />
                </div>
            </div>
            <!-- 添加对话框 -->
            <div class="panel-danger" id="addModal" style="display: none">
                <div class="panel-heading">
                    <p class="panel-title">新增税金</p>
                </div>
                <div class="panel-body">
                    <table style="margin: 10px;" class="input-table">
                        <tr>
                            <th style="width:90px;">新税金名称：</th>
                            <td style="width: 200px;">
                                <asp:TextBox runat="server" ID="tbxAddUnit" CssClass="form-control"></asp:TextBox>
                            </td>                            
                            <td>
                                <asp:RequiredFieldValidator runat="server" ID="rfv2" ControlToValidate="tbxAddUnit" ErrorMessage="请输入税金名称" ForeColor="red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>税金百分比：</th>
                            <td><asp:TextBox runat="server" ID="tbxAddPoint" CssClass="form-control"></asp:TextBox></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Button runat="server" ID="btnAddUnit" OnClick="btnAddUnit_OnClick" Text="确定添加" CssClass="btn btn-primary" OnClientClick="return true;" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>   
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
