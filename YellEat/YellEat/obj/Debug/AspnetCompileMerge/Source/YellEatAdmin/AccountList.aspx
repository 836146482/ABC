<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="AccountList.aspx.cs" Inherits="YellEat.YellEatAdmin.AccountList" %>
<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/jquery.fancybox.pack.js"></script>
    <link href="../css/jquery.fancybox.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager1"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel1">
        <ContentTemplate>
            <p style="text-align: right">
                <a href="#addModal" class="btn btn-sm btn-danger" id="add"><i class="fa fa-plus"></i>&nbsp;&nbsp;创建新用户</a>
            </p>
            <asp:Repeater runat="server" ID="rpt" OnItemCommand="rpt_OnItemCommand">
                <HeaderTemplate>
                    <table class="table table-condensed">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>登录账号名称</th>
                                <th>最后登录时间</th>
                                <th>注册时间</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("AdministratorID") %></td>
                        <td><%#Eval("Account") %></td>
                        <td><%#Eval("LastLoginTime") %></td>
                        <td><%#Eval("CreateTime") %></td>
                        <td>
                            <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-xs btn-danger" Text="删除" CommandName="del" CommandArgument='<%#Eval("AdministratorID") %>' /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
            <uc1:Pager runat="server" ID="pager1" />
            <script type="text/javascript">
                $(function () {
                    $("#add").fancybox({
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
            <!-- 添加用户弹窗 -->
            <div class="panel-primary" id="addModal" style="display: none">
                <div class="panel-heading">添加用户账户</div>
                <div class="panel-body">
                    <table class="input-table">
                        <tr>
                            <th style="width: 80px;">用户名：</th>
                            <td>
                                <asp:TextBox runat="server" ID="tbxAccount" CssClass="form-control"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ForeColor="red"
                                    ID="rfv1" runat="server" ErrorMessage="请输入用户名" ControlToValidate="tbxAccount" Display="Dynamic" /></td>
                        </tr>
                        <tr>
                            <th>密&nbsp;&nbsp;码：</th>
                            <td>
                                <asp:TextBox TextMode="Password" runat="server" ID="tbxPwd1" CssClass="form-control"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ForeColor="red"
                                    ID="rfv2" runat="server" ErrorMessage="请输入密码！" ControlToValidate="tbxPwd1" Display="Dynamic" /></td>
                        </tr>
                        <tr>
                            <th>确认密码：</th>
                            <td>
                                <asp:TextBox TextMode="Password" runat="server" ID="tbxPwd2" CssClass="form-control"></asp:TextBox></td>
                            <td>
                                <asp:CompareValidator runat="server" ID="cv1" ControlToValidate="tbxPwd2" ControlToCompare="tbxPwd1"
                                    ErrorMessage="两次输入的密码不一致！" ForeColor="red"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: center">
                                <asp:Button runat="server" ID="btnOK" CssClass="btn btn-sm btn-primary" OnClick="btnOK_OnClick" Text="确定添加" />
                                &nbsp;
                        <input type="reset" class="btn btn-sm btn-primary" value="清空重置" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
