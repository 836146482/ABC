<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="ShopFeedbackList.aspx.cs" Inherits="YellEat.YellEatAdmin.ShopFeedbackList" %>

<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Repeater runat="server" ID="rptShopFeedBack">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <td style="width:70px;">餐馆 ID</td>
                            <th>反馈内容</th>
                            <th>创建时间</th>
                            <th style="width: 80px;">是否已处理</th>
                            <th>处理时间</th>
                            <td>操作</td>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%#Eval("ShopId") %></th>
                        <td style="width: 500px;"><%#Eval("FeedbackContent") %></td>
                        <td><%#Eval("CreateTime") %></td>
                        <td><%# Convert.ToBoolean(Eval("IsHandled"))?"<span class='bg-success'>已处理</span>":"<span class='bg-danger'>未处理</span>" %></td>
                        <td><%# Convert.ToBoolean(Eval("IsHandled"))?Eval("HandledTime").ToString():"" %></td>
                        <td><%#Convert.ToBoolean(Eval("IsHandled"))?"<a href='ShopFeedBackDetail.aspx?id="+Eval("ShopId")+"' class='btn btn-xs btn-info'>详情</a>":"<a href='HandleShopFeedback.aspx?id="+Eval("ShopId")+"' class='btn btn-xs btn-danger'>处理</a>" %></td>
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
