<%@ Page Title="" Language="C#" MasterPageFile="~/ShopAdmin/ShopAdminMaster.Master" AutoEventWireup="true" CodeBehind="AddFeedback.aspx.cs" Inherits="YellEat.ShopAdmin.AddFeedback" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-danger" style="width: 500px;">
        <div class="panel-heading">
            <div class="title">添加反馈内容</div>
        </div>    
        <div class="panel-body">
            <h5>反馈内容：</h5>
            <asp:TextBox runat="server" TextMode="MultiLine" Rows="10" ID="tbxFeedbackContent" CssClass="form-control"></asp:TextBox>
            <br/>
            <p style="text-align: center">
                 <asp:Button runat="server" ID="btnOK" CssClass="btn btn-danger" Text="确定反馈" OnClick="btnOK_OnClick" OnClientClick="return check()" />
                &nbsp;&nbsp;
                <input type="reset" value="清空重填" class="btn btn-danger"/>
            </p>            
        </div>            
    </div>   
    <script type="text/javascript">
        function  check() {
            if ($("#tbxFeedbackContent").val().trim() == '') {
                alert('反馈内容不能为空！');
                $("#tbxFeedbackContent").focus();
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
