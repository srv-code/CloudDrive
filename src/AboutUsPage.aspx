<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AboutUsPage.aspx.cs" Inherits="about_us" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CloudDrive: About Us</title>
    <link rel="icon" type="image/png" href="Styles/Images/SiteLogo.png"/>
    <link rel="stylesheet" href="~/Styles/Global_Styles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    <br>
    <asp:Label ID="Label1" CssClass="HeadingStyle" Font-Size="XX-Large" runat="server" Width="98%" Text="CloudDrive: About Us"></asp:Label>
    <br><br>
    <asp:Panel ID="Panel1" CssClass="BodyStyle" Width="95%" Font-Size="Large" runat="server">
   <br>Founded on July 2014, CloudDrive allows billions of people to search, view, securely store/archieve and share user their data (eg. images, videos, musics, documents, computer executables) as well as to search and view other users' uploaded data. CloudDrive provides a forum for people to connect, inform and inspire others across the globe and acts as a distribution platform for original content creators and advertisers large and small.        
        <br><h2>• Getting Started</h2>
        We&#39;ve put together a step-by-step guide to get you started on CloudDrive.<br> Create your Account in CloudDrive website and LOGIN to participate and access your website as a user or member.
        <h2>• Community Guidelines Read up on our guidelines for participating in the CloudDrive community.</h2>
        <h2>• <a href="ContactUsPage.aspx" style="color: #CC00CC">Contact Us </a> : Find contact information for our various departments. </h2></br>
        </asp:Panel>
    </asp:Label>
        <br><br><br>
        <a href="Homepage.aspx?s=1" class="HyperLinkStyle"><img src="Styles/Images/Navigation Buttons/GoBack.png" height="40px" width="40px"/>&nbsp;&nbsp; Go back to homepage</a>
        <br />
        <asp:LinkButton ID="linkGoBackToCustomerPage" CssClass="HyperlinkStyle" runat="server" OnClick="linkGoBackToCustomerPage_Click"><img src="Styles/Images/Navigation Buttons/GoBack.png" height="40px" width="40px"/>&nbsp;&nbsp; Go back to your account</asp:LinkButton>
        <br>
        </form>
</body>
</html>
