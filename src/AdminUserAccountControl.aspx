<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminUserAccountControl.aspx.cs" Inherits="AdminUserAccountControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CloudDrive: Admin: View User Information</title>
    <link rel="icon" type="image/png" href="Styles/Images/SiteLogo.png"/>
    <link rel="stylesheet" href="~/Styles/Global_Styles.css" type="text/css" />
    <style>
        .UserInfoLabelStyle
        {
            padding: 10px;
            border-radius: 10px;
            font-family: 'Century Gothic';
            font-weight: bold;
            color: darkblue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <h1 style="width: 98%" class="HeadingStyle">
            CloudDrive: User Account Information
            <div style="float: right">
                <asp:Image ID="ImageAdminPic" ImageUrl="~/Images/NotificationImages/AdminPic.png" Height="45px" Width="45px" BorderWidth="0" runat="server" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
        </h1>
        </asp:Label><br><br>
        <asp:Panel ID="PanelShowInfos" runat="server" CssClass="BodyStyle" Width="95%">
            <br><br>
            <asp:Image ID="ImageUserProfilePicture" Height="200" Width="200" runat="server" /><br><br>
            <h2>
                <table align="center">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" CssClass="UserInfoLabelStyle" Text="Username:" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblUsername" CssClass="UserInfoLabelStyle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" CssClass="UserInfoLabelStyle" Text="First Name:" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFirstName" CssClass="UserInfoLabelStyle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" CssClass="UserInfoLabelStyle" Text="Middle Name:" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMiddleName" CssClass="UserInfoLabelStyle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" CssClass="UserInfoLabelStyle" Text="Last Name:" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblLastName" CssClass="UserInfoLabelStyle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" CssClass="UserInfoLabelStyle" Text="Gender:" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblGender" CssClass="UserInfoLabelStyle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" CssClass="UserInfoLabelStyle" Text="Date of Birth:" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDOB" CssClass="UserInfoLabelStyle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" CssClass="UserInfoLabelStyle" Text="Country:" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCountry" CssClass="UserInfoLabelStyle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" CssClass="UserInfoLabelStyle" Text="City:" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCity" CssClass="UserInfoLabelStyle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" CssClass="UserInfoLabelStyle" Text="Martial Status:" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMartialStatus" CssClass="UserInfoLabelStyle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" CssClass="UserInfoLabelStyle" Text="EMail Address:" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEMail" CssClass="UserInfoLabelStyle" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </h2>
        </asp:Panel>
        <asp:Panel ID="PanelAdminControlTools" Visible="false" runat="server">
            <br><br>
            <asp:Label ID="lblUserMessageSendingErrorMessage" runat="server" Font-Size="Large" CssClass="BodyStyle" BorderWidth="0"></asp:Label> <br>
            <asp:Label ID="lblSendUserMessage" Font-Size="Large" runat="server" CssClass="BodyStyle" BorderWidth="0" Text="Send user a message:"></asp:Label><br>
            <asp:TextBox ID="txtMessageToUser" Font-Size="X-Large" CssClass="TextBoxStyle" placeholder="Send a message to the user as a new notification" TextMode="MultiLine" runat="server" Height="114px" Width="581px"></asp:TextBox>
            <br>
            <asp:Button ID="btnSendUserMessage" CssClass="ButtonStyle" runat="server" Text="Send Message" OnClick="btnSendUserMessage_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="btnDeleteUser" CssClass="ButtonStyle" runat="server" Text="Delete User" OnClick="btnDeleteUser_Click" />
            <br><br>
        <a href="AdminPage.aspx" class="HyperlinkStyle"><img src="Styles/Images/Navigation Buttons/GoBack.png" height="40px" width="40px"/>&nbsp;&nbsp; Go back to Admin Page</a>
        </asp:Panel>

        <asp:Panel ID="PanelUserTools" Visible="false" runat="server">
            <div align="center">
        <a href="Homepage.aspx?s=1" class="HyperlinkStyle"><img src="Styles/Images/Navigation Buttons/GoBack.png" height="40px" width="40px"/>&nbsp;&nbsp; Go back to homepage</a>
        <br />
        <asp:LinkButton ID="linkGoBackToCustomerPage" CssClass="HyperlinkStyle" runat="server" OnClick="linkGoBackToCustomerPage_Click" ><img src="Styles/Images/Navigation Buttons/GoBack.png" height="40px" width="40px"/>&nbsp;&nbsp; Go back to your account</asp:LinkButton>
        <br>
    </div>
        </asp:Panel>
        
    </div>
    </form>
</body>
</html>
