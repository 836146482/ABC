<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminLog.aspx.cs" Inherits="YellEat.YellEatAdmin.AdminLog" %>

<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager" EnablePartialRendering="True"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel1">
        <ContentTemplate>
            <asp:Repeater runat="server" ID="rptAdminLog" OnItemCommand="rptAdminLog_OnItemCommand">
                <HeaderTemplate>
                    <table class="table table-condensed">
                        <thead>
                            <tr>
                                <th>管理员</th>
                                <th>日志类型</th>
                                <th>时间</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("AdminName") %></td>
                        <td><%#Eval("LogTypeName") %></td>
                        <td><%#Eval("CreateTime") %></td>
                        <td>
                            <asp:Button runat="server" CommandName="del" CommandArgument='<%#Eval("LogID")%>' CssClass="btn btn-danger btn-xs" Text="删除" /></td>
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
