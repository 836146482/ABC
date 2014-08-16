<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="ShopList.aspx.cs" Inherits="YellEat.YellEatAdmin.ShopList" %>

<%@ Register Src="~/Controls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager1"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel1">
        <ContentTemplate>
            <asp:Repeater runat="server" ID="rpt" OnItemCommand="rpt_OnItemCommand">
            <HeaderTemplate>
                <table class="table">
                    <thead>
                        <tr class="panel-primary">
                            <th><input type="checkbox" id="cbxAll"/></th>
                            <th>餐馆中文名</th>
                            <th>电话</th>
                            <th>邮箱</th>
                            <th>QQ</th>
                            <th>传真</th>
                            <th>状态</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><asp:CheckBox runat="server" ID="cbx"/></td>
                    <td><%#Eval("ShopName") %></td>
                    <td><%#Eval("ShopMobile") %></td>
                    <td><%#Eval("ShopEmail") %></td>
                    <td><%#Eval("ShopQQ") %></td>
                    <td><%#Eval("ShopFax") %></td>
                    <td><%# Convert.ToBoolean(Eval("IsChecked"))?"<label class='label label-success'>已审核</label>":"<label class='label label-warning'>未审核</label>" %></td>
                    <td>                     
                        <a href="#" class="btn btn-xs btn-primary">详情</a>
                        <a href="#" class="btn btn-xs btn-primary">修改</a>
                        <asp:Button CssClass="btn btn-xs btn-danger" runat="server" ID="btnCheck" Text='<%# Convert.ToBoolean(Eval("IsChecked"))?"取消审核":"审核通过" %>' CommandName="sh" CommandArgument='<%#Eval("ShopID")+","+Eval("IsChecked") %>' />                                                                            
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
