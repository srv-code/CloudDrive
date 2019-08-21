<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPasswordPage.aspx.cs" Inherits="ForgotPasswordPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CloudDrive: Retrieve your password</title>
    <link rel="icon" type="image/png" href="Styles/Images/SiteLogo.png"/>
    <link rel="stylesheet" href="~/Styles/Global_Styles.css" type="text/css" />
    <style>
        .lblStyle
        {
            font-size: larger;
            padding: 7px;
            font-family: 'Century Gothic';
            font-weight: bold;
            color: darkblue;
        }
        .TextBoxStyle
        {
            height: 30px; width: 280px; font-size: larger;
            font-family: 'Century Gothic';
            color: black;
            border-width: 2px;
            border-color: #B9B9FF;
            background-color: #00FFFF;
            box-shadow: 4px 4px lightgray inset;
        }
            .TextBoxStyle:focus
            {
                background-color: white;
                border-width: 2px;
                border-color: #B9B9FF;
            }
            .TextBoxStyle:disabled
            {
                color: black;
                border-color: lightgray;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div align="center">
        <h1><asp:Label ID="Label1" runat="server" CssClass="HeadingStyle" Width="98%" Text="CloudDrive: Forgot Password?"></asp:Label></h1>
        <h3><asp:Label ID="Label2" runat="server" CssClass="lblStyle" BorderWidth="3px" Font-Size="X-Large" Text="Forgot your account password? Don't panic, we have solutions..."></asp:Label></h3>
        
    </div>
        <div align="center">
            <asp:Panel ID="PanelGetUserInputs" runat="server" CssClass="div_danger" Width="70%">
                <asp:Label ID="lblWarning" BackColor="DarkRed" Font-Size="Large" ForeColor="Yellow" runat="server"></asp:Label>
        <br>
        <div align="center">
            <table align="center">
                <tr>
                    <td>
                        <b class="lblStyle">Enter username:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsername" placeholder="Username" runat="server" CssClass="TextBoxStyle" OnTextChanged="txtUsername_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b class="lblStyle">Your security question:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSecurityQuestion" placeholder="Security Question" CssClass="TextBoxStyle" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b class="lblStyle">Your security answer:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSecurityAnswer" placeholder="Security Answer" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                    <asp:Button ID="btnGetPwd" CssClass="ButtonStyle" runat="server" OnClick="btnGetPwd_Click" Text="Get Password" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center"></td>
                </tr>
            </table>
            <br>
            <br>
		    <a href="Homepage.aspx?s=1" class="HyperlinkStyle"><img src="Styles/Images/Navigation Buttons/GoBack.png" height="40px" width="40px"/>&nbsp;&nbsp; Go back to homepage</a>

        </div>
            </asp:Panel>

        <asp:Panel ID="PanelShowUserPwd" Visible="false" runat="server" CssClass="div_danger" Width="70%">
            <asp:Label ID="lblShowUserPwd" CssClass="lblStyle" runat="server"></asp:Label>
            <br><br>
            <a href="Homepage.aspx?s=1" class="HyperlinkStyle"><img src="Styles/Images/Navigation Buttons/GoBack.png" height="40px" width="40px"/>&nbsp;&nbsp; Go back to homepage</a>
            </asp:Panel>
        </div>
        
    </form>
</body>
</html>
