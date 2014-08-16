<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="YellEat.YellEatAdmin.UserList" %>
<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager1"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel1">
        <ContentTemplate>
            <asp:Repeater runat="server" ID="rptUsers" OnItemCommand="rptUsers_OnItemCommand">
                <HeaderTemplate>
                    <table class="table table-condensed">
                        <thead>
                            <tr>
                                <th>用户名</th>
                                <th>手机号码</th>
                                <th>邮箱</th>
                                <th>QQ</th>
                                <th>邮编</th>
                                <th>地址</th>
                                <th>注册时间</th>
                                <th>最后登录时间</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><a href="UserDetail.aspx?UserId=<%#Eval("UserId") %>"><%#Eval("UserName") %></a></td>
                        <td><%#Eval("Mobile") %></td>
                        <td><%#Eval("Email") %></td>
                        <td><%#Eval("QQ") %></td>
                        <td><%#Eval("Zip") %></td>
                        <td><%#Eval("Address") %></td>
                        <td><%#Eval("RegisterTime") %></td>
                        <td><%#Eval("LastLoginTime") %></td>
                        <td>
                            <asp:Button runat="server" CssClass="btn btn-xs btn-success" Text="加入白名单" CommandName="setWhite" CommandArgument='<%#Eval("UserID") %>' Visible='<%#Eval("Status").ToString()=="1" %>'/>
                            <asp:Button runat="server" CssClass="btn btn-xs btn-danger" Text="加入黑名单" CommandName="setBlack" CommandArgument='<%#Eval("UserID") %>' Visible='<%#Eval("Status").ToString()=="0" %>'/>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
            <uc1:Pager runat="server" ID="pager1" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
