<%@ Page Title="" Language="C#" MasterPageFile="~/ShopAdmin/ShopAdminMaster.Master" AutoEventWireup="true" CodeBehind="xjProductList.aspx.cs" Inherits="YellEat.ShopAdmin.xjProductList" %>

<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel1">
        <ContentTemplate>
            <asp:Repeater runat="server" ID="rpt" OnItemCommand="rpt_OnItemCommand">
                <HeaderTemplate>
                    <table class="table table-condensed">
                        <thead>
                            <tr class="alert-danger">
                                <td style="width:80px;">菜单编号</td>                               
                                <th>菜单名称</th>
                                <th>菜单分类</th>                                
                                <th>税金</th>
                                <th>价格</th>
                                <th>创建时间</th>
                                <td style="width: 150px;">操作</td>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%#Eval("ProductNo") %></th>                        
                        <td><%#Eval("ProductName") %></td>
                        <td><%#Eval("ProductTypeName") %></td>                       
                        <td><%#Eval("UnitName") %></td>
                        <td><%#Eval("Price") %></td>
                        <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd") %></td>
                        <td>
                            <a href="UpdateProduct.aspx?id=<%#Eval("ProductID") %>" class="btn btn-xs btn-danger">更新</a>
                            <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-xs btn-danger" Text="删除" CommandName="del" CommandArgument='<%#Eval("ProductID") %>' OnClientClick="return confirm('您确定要删除菜单吗？')" />
                            <asp:Button runat="server" ID="btnxj" CssClass="btn btn-xs btn-danger" Text="上架" CommandName="sj" CommandArgument='<%#Eval("ProductID") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td colspan="8"></td>
                    </tr>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
            <uc1:Pager runat="server" ID="pager1" />
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
