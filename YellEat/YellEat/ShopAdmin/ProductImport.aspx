<%@ Page Title="" Language="C#" MasterPageFile="~/ShopAdmin/ShopAdminMaster.Master" AutoEventWireup="true" CodeBehind="ProductImport.aspx.cs" Inherits="YellEat.ShopAdmin.ProductImport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel1">
        <ContentTemplate>
            <table class="input-table">
                <tr>                    
                    <td>
                        <asp:DropDownList runat="server" ID="ddlType">
                            <asp:ListItem>Excel 2007 以上版本</asp:ListItem>
                            <asp:ListItem>Excel 2003 以下版本</asp:ListItem>
                        </asp:DropDownList> 
                        <asp:FileUpload ID="fileUp" runat="server" style="display:inline"  />&nbsp;&nbsp;                                                
                    </td>                   
                </tr>
                <tr>
                    <td>
                        <a href="/xls/Template.zip" class="btn btn-danger btn-xs">下载模板</a>
                        <span>
                            <asp:Button ID="btnOK" runat="server" Text="确认导入" CssClass="btn btn-danger btn-xs" OnClick="btnOK_OnClick" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="panel-title" style="color: red">请确保导入的菜单分类和税金类型是系统已有的，否则因数据不完整而导入失败。菜单名称相同的将不再导入。</div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnOK" />
        </Triggers>
    </asp:UpdatePanel>
    <div>
        <p>菜单格式模板如下：</p>
        <table style="width: 400px;" class="table">
            <thead>
                <tr>
                    <td>菜单编号</td>
                    <td>菜单名称</td>
                    <td>菜单分类</td>
                    <td>税金类型</td>
                    <td>价格</td>
                    <td>菜单描述</td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>A0001</td>
                    <td>火腿</td>
                    <td>烧烤</td>
                    <td>不含税</td>
                    <td>1</td>
                     <td>菜单的简单描述</td>
                </tr>
                <tr>
                    <td>B0001</td>
                    <td>可口可乐</td>
                    <td>饮料</td>
                    <td>不含税</td>
                    <td>1</td>
                    <td>菜单的简单描述</td>
                </tr>
                <tr>
                    <td>C0001</td>
                    <td>素面</td>
                    <td>面食</td>
                    <td>不含税</td>
                    <td>1</td>
                     <td>菜单的简单描述</td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
