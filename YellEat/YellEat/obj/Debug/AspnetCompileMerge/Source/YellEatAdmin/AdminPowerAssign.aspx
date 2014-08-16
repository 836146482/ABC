<%@ Page Title="" Language="C#" MasterPageFile="~/YellEatAdmin/YellEatAdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminPowerAssign.aspx.cs" Inherits="YellEat.YellEatAdmin.AdminPowerAssign" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        ul {
            padding-left: 10px;
        }
        ul li{ margin-left: 20px;}
        #powerlist{ margin-top: 20px;}
        #powerlist div .f14 label{ font-size: 14px;color: #A10B0D;}
    </style>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scr"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel">
        <ContentTemplate>            
            <div>
                <span>选择管理员：<asp:DropDownList runat="server" ID="ddl" AutoPostBack="True" OnSelectedIndexChanged="ddl_OnSelectedIndexChanged"/></span>
                <asp:Button runat="server" ID="btnSave" Text="保存权限设置" OnClick="btnSave_OnClick" CssClass="btn btn-xs btn-danger" />
            </div>
            <div id="powerlist">
                <div style="float: left; width: 200px;">
                    <asp:CheckBox runat="server" CssClass="f14" ID="cbxA" Text="会员管理" AutoPostBack="True" OnCheckedChanged="cbxA_OnCheckedChanged"/>
                    <ul class="list-unstyled">
                        <li>
                            <asp:CheckBox runat="server" ID="cbx1" Text="会员列表" AutoPostBack="True" OnCheckedChanged="cbx1_OnCheckedChanged"/>
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="cbx2" Text="会员意见处理" AutoPostBack="True" OnCheckedChanged="cbx1_OnCheckedChanged"/>
                        </li>
                    </ul>
                </div>
                <div style="float: left; width: 200px;">
                    <asp:CheckBox runat="server" CssClass="f14" ID="cbxB" Text=" 餐馆管理" AutoPostBack="True" OnCheckedChanged="cbxB_OnCheckedChanged"/>
                    <ul class="list-unstyled">
                        <li>
                            <asp:CheckBox runat="server" ID="cbx3" Text="餐馆类型管理" AutoPostBack="True" OnCheckedChanged="cbx3_OnCheckedChanged"/>
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="cbx4" Text="加盟餐馆管理" AutoPostBack="True" OnCheckedChanged="cbx3_OnCheckedChanged"/>
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="cbx5" Text="餐馆反馈处理" AutoPostBack="True" OnCheckedChanged="cbx3_OnCheckedChanged"/>
                        </li>
                    </ul>
                </div>
                <div style="float: left; width: 200px;">
                    <asp:CheckBox runat="server" CssClass="f14" ID="cbxC" Text="高级管理" AutoPostBack="True" OnCheckedChanged="cbxC_OnCheckedChanged" />
                    <ul class="list-unstyled">
                        <li>
                            <asp:CheckBox runat="server" ID="cbx6" Text="修改个人密码" AutoPostBack="True" OnCheckedChanged="cbx6_OnCheckedChanged"/>
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="cbx7" Text="用户账号管理" AutoPostBack="True" OnCheckedChanged="cbx6_OnCheckedChanged"/>
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="cbx8" Text="分配权限管理" AutoPostBack="True" OnCheckedChanged="cbx6_OnCheckedChanged"/>
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="cbx9" Text="用户操作记录管理" AutoPostBack="True" OnCheckedChanged="cbx6_OnCheckedChanged"/>
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="cbx10" Text="税金管理" AutoPostBack="True" OnCheckedChanged="cbx6_OnCheckedChanged"/>
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="cbx11" Text="系统配置" AutoPostBack="True" OnCheckedChanged="cbx6_OnCheckedChanged"/>
                        </li>
                    </ul>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
