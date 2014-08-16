<%@ Page Title="" Language="C#" MasterPageFile="~/ShopAdmin/ShopAdminMaster.Master" AutoEventWireup="true" CodeBehind="FeedbackList.aspx.cs" Inherits="YellEat.ShopAdmin.FeedbackList" %>

<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel1">
        <ContentTemplate>
            <asp:Repeater runat="server" ID="rptShopFeedBack" OnItemCommand="rptShopFeedBack_OnItemCommand">
                <HeaderTemplate>
                    <table class="table table-condensed">
                        <thead>
                            <tr class="alert-danger">
                                <th>ID</th>
                                <th>反馈内容</th>
                                <th>反馈时间</th>
                                <th>是否已处理</th>
                                <th>处理时间</th>
                                <th>反馈答复</th>
                                <td style="width:40px;">操作</td>
                            </tr>
                        </thead>
                        <tbody></tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("ShopFeedbackID") %></td>
                        <td><%#Eval("FeedbackContent") %></td>
                        <td><%#Eval("CreateTime") %></td>
                        <td><%# Convert.ToBoolean(Eval("IsHandled"))?"<span class='bg-success'>已处理</span>":"<span class='bg-danger'>未处理</span>" %></td>
                        <td><%# Convert.ToBoolean(Eval("IsHandled"))?Eval("HandledTime").ToString():"" %></td>
                        <td><%#Eval("HandleAnswer") %></td>
                        <td>
                            <asp:Button runat="server" ID="btnDelete" CommandName="del" CommandArgument='<%#Eval("ShopFeedbackID") %>' Text="删除" CssClass="btn btn-xs btn-danger" OnClientClick="return confirmEx(this)"></asp:Button></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>                   
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
            <uc1:Pager runat="server" ID="pager1" />
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <script>
        function confirmEx(obj) {
            var txt = $(obj).parent().prev().text();
            if (txt == "") {
                return confirm("当前反馈尚未得到回复，您确定要删除吗这条反馈信息吗？");                
            }
            return true;
        }
    </script>
</asp:Content>
