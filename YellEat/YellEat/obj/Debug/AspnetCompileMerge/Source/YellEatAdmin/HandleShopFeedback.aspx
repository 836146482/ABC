<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="HandleShopFeedback.aspx.cs" Inherits="YellEat.YellEatAdmin.HandleShopFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-danger"  style="width: 600px;">
        <div class="panel-heading">
            <%=FeedbackShop.ShopName %>反馈信息处理
        </div>
        <div class="panel-body">
            <div class="list-group">
                <div class="list-group-item">
                    <div class="list-group-item-heading">
                        <div class="panel-title">反馈内容<span style="float: right">反馈时间：<%=Feedback.CreateTime %></span></div>
                    </div>
                    <div class="list-group-item-text">
                        <div style="margin:10px;">
                            <%=Feedback.FeedbackContent %>
                        </div>
                    </div>
                </div>
                <div class="list-group-item">
                    <div class="list-group-item-heading panel-danger">
                        <div class="panel-title">处理意见</div>
                    </div>
                    <div class="panel-body">
                        <asp:TextBox runat="server" ID="tbxFeedbackAnswer" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                        <br />
                        <p style="text-align: center">
                            <asp:Button runat="server" OnClick="btnOK_OnClick" ID="btnOK" Text="保存回复" OnClientClick="return  confirm('反馈处理一经提交无法修改，您确定要提交反馈处理吗？')" CssClass="btn btn-danger" />
                            &nbsp;&nbsp;
                            <input type="submit" value="清空重置" class="btn btn-danger" />
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
