<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="UserFeedbackList.aspx.cs" Inherits="YellEat.YellEatAdmin.UserFeedbackList" %>

<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager1" EnablePartialRendering="True"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel1">
        <ContentTemplate>
            <asp:Repeater runat="server" ID="rptUserFeedback" OnItemCommand="rptUserFeedback_OnItemCommand">
                <HeaderTemplate>
                    <table class="table table-condensed">
                        <thead class="table table-condensed">
                            <tr>
                                <th>会员名称</th>
                                <th>反馈内容</th>
                                <th>反馈时间</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                    
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("UserName") %></td>
                        <td><%#Eval("FeedbackContent") %></td>
                        <td><%#Eval("CreateTime") %></td>
                        <td><asp:Button runat="server" ID="btnDelete" Text="删除" /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr style='<%= rptUserFeedback.Items.Count==0?"block":"none"%>'>
                        <td colspan="4" ><label>暂无反馈信息</label></td>                       
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <uc1:Pager runat="server" ID="pager1" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
