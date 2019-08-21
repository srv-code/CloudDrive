<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NotificationsPage.aspx.cs" Inherits="NotificationsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CloudDrive: View your notifications</title>
    <link rel="icon" type="image/png" href="Styles/Images/SiteLogo.png"/>
    <link rel="stylesheet" href="~/Styles/Global_Styles.css" type="text/css" />
    
    <style>
        .Notifications 
        {
            padding: 1px;
	        font-family: 'Century Gothic'; font-weight: bold;
            font-size: small;
            background-color: lightblue;
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="left">
    <br>
    <asp:Label ID="lblHeading" CssClass="HeadingStyle" Width="98%" Font-Size="XX-Large" runat="server" Text="CloudDrive: Notifications of "></asp:Label>
        <br><br>
        <center><h2><asp:Label ID="lblNewNotificationMessage" CssClass="BodyStyle" runat="server"></asp:Label></h2></center>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <br><br><br>
        </div>
        <div align="center">
        <a href="Homepage.aspx?s=1" class="HyperlinkStyle"><img src="Styles/Images/Navigation Buttons/GoBack.png" height="40px" width="40px"/>&nbsp;&nbsp; Go back to homepage</a>
        <br />
        <asp:LinkButton ID="linkGoBackToCustomerPage" CssClass="HyperlinkStyle" runat="server" OnClick="linkGoBackToCustomerPage_Click"><img src="Styles/Images/Navigation Buttons/GoBack.png" height="40px" width="40px"/>&nbsp;&nbsp; Go back to your account</asp:LinkButton>
        <br>
    </div>
    </form>
</body>
</html>
