<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.Master" AutoEventWireup="true" CodeBehind="UserCenter.aspx.cs" Inherits="YellEat.UserCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="eat">
        用户中心　<span class="member-icon"></span>
    </div>
    <div class="menu">
        <div class="member-box">
            <div class="member-center">
                <dl>
                    <dt>用户名：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="tbxName" CssClass="input-1"></asp:TextBox>
                    </dd>
                </dl>               
                <dl>
                    <dt>手机：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="tbxMobile" CssClass="input-1"></asp:TextBox></dd>
                </dl>
                <dl>
                    <dt>Email：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="tbxEmail" CssClass="input-1"></asp:TextBox></dd>
                </dl>
                <dl>
                    <dt>facebook：</dt>
                    <dd>
                        <asp:TextBox runat="server" ID="tbxFacebook" CssClass="input-1"></asp:TextBox></dd>
                </dl>
            </div>
            <div class="member-menu">
                <dl>
                    <dt>
                        <a href="UserAddressList.aspx"><img src="images/address.png" /></a>
                    </dt>
                    <dd><a href="UserAddressList.aspx">地址簿管理</a></dd>
                </dl>
                <dl>
                    <dt>
                       <a href="UserCoupon.aspx">
                        <img src="images/count.png" />
                        </a>
                    </dt>
                    <dd><a href="UserCoupon.aspx">折扣码管理</a></dd>
                </dl>
            </div>
        </div>
    </div>
</asp:Content>
