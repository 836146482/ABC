<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="ShopFeedBackDetail.aspx.cs" Inherits="YellEat.YellEatAdmin.ShopFeedBackDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .list-group-item-heading{ font-size: 14px;font-weight: bold;}
         .list-group-item-text{ text-indent: 20px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="list-group" style="width: 800px;">
        <div class="list-group-item">
            <div class="list-group-item-heading">
                反馈信息处理：<%=FeedbackShop.ShopName %> 
                <span style="float: right">反馈时间：<%=Feedback.CreateTime %></span>
            </div>
            <div class="list-group-item-text">
               <%=Feedback.FeedbackContent %>
            </div>
        </div>
        <div class="list-group-item">
             <div class="list-group-item-heading">
                处理意见<span style="float: right">处理时间：<%=Feedback.HandledTime %></span>
            </div>
            <div class="list-group-item-text">
                <%=Feedback.HandleAnswer %>
            </div>
        </div>
    </div>        
</asp:Content>
