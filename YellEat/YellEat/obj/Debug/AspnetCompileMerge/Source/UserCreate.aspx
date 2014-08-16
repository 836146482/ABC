<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCreate.aspx.cs" Inherits="YellEat.UserCreate" ClientIDMode="Static"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta id="viewport" name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <title>YellEat User Register</title>
    <link href="css/style.css" rel="stylesheet" />
    <script src="js/jquery-1.10.1.min.js"></script>
    <style>            
        .tbl{border-radius:5px;color: #aaaaaa;border:2px solid #aaaaaa;width: 90%;margin: 0 auto;padding: 5px 0;} 
        .tbl p{ line-height: 40px;text-align: center; }
        .gbtn {
            background-color: #72B903;
            color: white;
            border-radius: 5px;
            padding: 5px;
        }
        input[type=text] {
            line-height: 25px;
            border: none;
            border-bottom: 1px solid #aaaaaa;
            margin: 0 auto;
            width: 90%;
        }
        .reg{ font-size: 22px;background: none;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page-main" data-role="page">
            <asp:ScriptManager runat="server" ID="scriptManager1"></asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="updatePanel1">
                <ContentTemplate>
                    <header class="top2">
                        <div class="top_l">
                            <a class="lb" onclick="javacript:history.back();"></a>
                        </div>
                        Create
                         <div class="en">
                             <a>
                                 <img src="images/english.jpg" /></a>
                         </div>
                    </header>
                    <div class="menu">
                        <br/>
                        <div class="tbl">
                            <p>
                                 <asp:TextBox runat="server" ID="tbxAddress" placeholder="Apartment,suite,unit,building,floor,ect *"></asp:TextBox>
                            </p>
                            <p>
                                <asp:TextBox runat="server" ID="tbxZip" placeholder=" Zip *" MaxLength="5"></asp:TextBox>
                            </p>
                            <p>
                                <asp:TextBox runat="server" ID="tbxAptSuite" placeholder=" Apt,Suite "></asp:TextBox>
                            </p>
                        </div>                       
                        <br/>      
                        <div class="tbl">
                            <p>
                                <asp:TextBox runat="server" ID="tbxName" placeholder=" Name *"></asp:TextBox>
                            </p>
                            <p>
                                <asp:TextBox runat="server" ID="tbxPhone" placeholder=" Phone *" ></asp:TextBox>
                                    <%--<asp:Button runat="server" ID="btnSendSMS" OnClick="btnSendSMS_OnClick" Text="Get the code" Width="35%" CssClass="gbtn" style="margin-bottom:10px;"/>--%>
                            </p>
                           <%-- <p>
                                <asp:TextBox runat="server" ID="tbxCode" placeholder=" Enter the code *"></asp:TextBox>
                            </p>--%>
                            <p>
                                <asp:TextBox runat="server" ID="tbxEmail" placeholder=" Email *"></asp:TextBox>
                            </p>
                            <p>
                                <asp:TextBox runat="server" ID="tbxPassword" placeholder=" Password *" TextMode="Password"></asp:TextBox>
                            </p>
                            <p>
                                <asp:TextBox runat="server" ID="tbxPassword2" placeholder=" Comfirm Password *" TextMode="Password"></asp:TextBox>
                            </p>
                        </div>                        
                        <br/>   
                        <div style="text-align: center">
                            <asp:Button runat="server" ID="btnFacebook" style="height:45px;border-radius:5px;width:200px;background: url(/images/facebookid.png) no-repeat" Text="       Login with Facebook" OnClick="btnFacebook_OnClick"/>
                        </div>
                        <div style="height:32px;">&nbsp;</div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <footer class="fter" id="conReg" style="text-align: center">
                <p style="text-align: center">
                    <asp:Button runat="server" ID="btnRegister" OnClick="btnRegister_OnClick" Text="Continue" CssClass="reg" OnClientClick="return check()"/>
                </p>
            </footer>
        </div>
    </form>
    <script type="text/javascript">
        function check() {
            if ($("#tbxAddress").val() == "") {
                $("#tbxAddress").focus();
                return false;
            }
            if ($("#tbxZip").val() == "") {
                $("tbxZip").focus();
                return false;
            }
            if ($("#tbxAptSuite").val()=="") {
                $("#tbxAptSuite").focus();
                return false;
            }
            if ($("#tbxEmail").val() == "") {
                $("#tbxEmail").focus();
                return false;
            }
            if ($("#tbxPassword").val()=="") {
                $("#tbxPassword").focus();
                return false;
            }
            if ($("#tbxPassword2").val()=="") {
                $("#tbxPassword").focus();
                return false;
            }
            return true;
        }
    </script>
</body>
</html>
