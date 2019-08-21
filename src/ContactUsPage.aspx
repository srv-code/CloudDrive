<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactUsPage.aspx.cs" Inherits="contact_us" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CloudDrive: Contact Us</title>
    <link rel="icon" type="image/png" href="Styles/Images/SiteLogo.png"/>
    <link rel="stylesheet" href="~/Styles/Global_Styles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    <br>
    <asp:Label ID="Label1" CssClass="HeadingStyle" Width="98%" Font-Size="XX-Large" runat="server" Text="CloudDrive: Contact Us"></asp:Label>
    <br><br>
    <asp:Panel ID="Panel1" CssClass="BodyStyle" Width="70%" Font-Size="X-Large" runat="server">
    <br>For more information or help for this website contact Admin of the website. Else please feel free to write us to our e-mail provided below.<br>
	<br>Contact Us: <a href="mailto:CloudDrivesite4@gmail.com">CloudDrivesite4@gmail.com</a> (Our Official EMail ID)<br />
    <br>Phone Number: +91 1800 200 300<br />+91 1800 200 301<br><br>
     </asp:Panel>
    </asp:Label>
        <br><br><br>
        <a href="Homepage.aspx?s=1" class="HyperlinkStyle"><img src="Styles/Images/Navigation Buttons/GoBack.png" height="40px" width="40px"/>&nbsp;&nbsp; Go back to homepage</a>  
        <br />
        <asp:LinkButton ID="linkGoBackToCustomerPage" CssClass="HyperlinkStyle" runat="server" OnClick="linkGoBackToCustomerPage_Click"><img src="Styles/Images/Navigation Buttons/GoBack.png" height="40px" width="40px"/>&nbsp;&nbsp; Go back to your account</asp:LinkButton>
        <br>
        
    </form>
</body>
</html>
