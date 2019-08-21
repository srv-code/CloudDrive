<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserAccInfoPage.aspx.cs" Inherits="UserAccInfoPage" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CloudDrive: Change your account information</title>
    <link rel="icon" type="image/png" href="Styles/Images/SiteLogo.png"/>
    <link rel="stylesheet" href="~/Styles/Global_Styles.css" type="text/css" />
    <style>
        .lblStyle_local
        {
          	padding: 10px;
	        border-style: solid;
	        font-family: 'Century Gothic'; font-weight: bold;
            color: darkblue;
        }
        .TextBoxStyle
        {
            height: 30px; width: 200px; font-size: larger;
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
                color: gray;
                border-color: lightgray;
            }
        .PanelLoggedInUserStyle
        {
            width: 80%;
            border-radius: 0px; border-width: 2px; border-color: lightblue;
            padding: 10px;
	        border-style: solid;
	        font-family: 'Century Gothic'; font-weight: bold;
            color: darkblue;
        }
        .PanelUpdateUserInfo
        {
            border-radius: 0px; border-width: 2px; border-color: lightblue;
            padding: 10px;
	        border-style: solid;
	        font-family: 'Century Gothic'; font-weight: bold;
            color: darkblue;
            text-align: center;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        
        <div align="left" style="float: left; width: 100%;">
    <div align="center"><h1 class="HeadingStyle">CloudDrive: Change your account information</h1></div>
            <div align="right" style="float: right; width: 15%;">
                <div style="float: right">
            &nbsp;
            <asp:Image ID="ImageProPic" Height="50" Width="50" runat="server" />
        </div>
            <asp:Panel ID="PanelSignedInAsInfo" CssClass="PanelLoggedInUserStyle" runat="server">
                <asp:Label ID="lblLoggedInAs" runat="server"></asp:Label><br><br>
            <asp:HyperLink ID="HyperLinkVisitAcc" runat="server" CssClass="HyperlinkStyle">Go back to your account</asp:HyperLink>
            <br>
            <asp:LinkButton ID="LinkButtonUserLogout" CssClass="HyperlinkStyle" runat="server" OnClick="LinkButtonUserLogout_Click">Logout</asp:LinkButton>
            </asp:Panel>
        </div>
            <br><br><br><br><br><br>
        
                <div align="center">
                    <center><asp:Button ID="btnLoadInfo" CssClass="ButtonStyle" runat="server" Text="Load your information" OnClick="btnLoadInfo_Click" /></center>
                    <br>
                    
                <asp:Panel ID="PanelUserInfo1" CssClass="PanelLoggedInUserStyle" Enabled="false" runat="server">
                    <table>
                        <tr>
                            <td><b>Username:</b></td>
                            <td>
                                <asp:TextBox ID="txtUsername" placeholder="Username" CssClass="TextBoxStyle" runat="server"></asp:TextBox> 
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:Panel ID="PanelUserInfo2" CssClass="PanelLoggedInUserStyle" Enabled="false" runat="server">
                    <table>
                        <tr>
                            <td><b>First Name:</b></td>
                            <td>
                                <asp:TextBox ID="txtFirstName" placeholder="First Name" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td><b>Middle Name:</b></td>
                            <td>
                                <asp:TextBox ID="txtMiddleName" placeholder="Middle Name" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td><b>Last Name:</b></td>
                            <td>
                                <asp:TextBox ID="txtLastName" placeholder="Last Name" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td><b>Gender:</b></td>
                            <td>
                                <asp:RadioButton ID="RadioButtonMale" Text="Male" GroupName="gender" CssClass="BodyStyle" BorderWidth="0px" runat="server" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="RadioButtonFemale" Text="Female" GroupName="gender" CssClass="BodyStyle" BorderWidth="0px" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td><b>Date of Birth:</b></td>
                            <td>
                                <asp:TextBox ID="txtDOB" placeholder="Date of Birth" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="txtDOB_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDOB">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td><b>Country:</b></td>
                            <td>
                                <asp:DropDownList ID="DropDownListCountry" AutoPostBack="true" CssClass="ButtonStyle" runat="server" OnSelectedIndexChanged="DropDownListCountry_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td><b>City:</b></td>
                            <td>
                                <asp:DropDownList ID="DropDownlistCity" AutoPostBack="true" CssClass="ButtonStyle" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td><b>Phone Number:</b></td>
                            <td>
                                <asp:TextBox ID="txtPhNo" placeholder="Phone Number" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td><b>Martial Status:</b></td>
                            <td>
                                <asp:RadioButton ID="RadioButtonMarried" Text="Married" CssClass="BodyStyle" BorderWidth="0px" runat="server" />
                                <asp:RadioButton ID="RadioButtonUnmarried" Text="Unmarried" CssClass="BodyStyle" BorderWidth="0px" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td><b>Email Address:</b></td>
                            <td>
                                <!--TextMode="Email"-->
                                <asp:TextBox ID="txtEMail" placeholder="EMail Address" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td><b>Security Question:</b></td>
                            <td>
                                <asp:DropDownList ID="DropDownListSecurityQuestion" AutoPostBack="true" CssClass="ButtonStyle" runat="server" OnSelectedIndexChanged="DropDownListSecurityQuestion_SelectedIndexChanged">
                                    <asp:ListItem>Choose a question</asp:ListItem>
                                    <asp:ListItem>What is your nick name?</asp:ListItem>
                                    <asp:ListItem>In which town was your mother born?</asp:ListItem>
                                    <asp:ListItem>What is your mother&#39;s maiden name?</asp:ListItem>
                                    <asp:ListItem>What was the number of your first phone?</asp:ListItem>
                                    <asp:ListItem>Create a question yourself</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxCustomSecurityQuestion" placeholder="Custom Security Question" Visible="false" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxCustomSecurityQuestion" CssClass="BodyStyle" Display="None" ErrorMessage="Please enter your custom security question"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                </asp:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td><b>Security Answer:</b></td>
                            <td>
                                <asp:TextBox ID="txtSecurityAnswer" placeholder="Security Answer" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <b><asp:CheckBox ID="CheckBoxAgreeTerms" runat="server" />I agree the <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Terms_PoliciesPage.aspx" runat="server">terms and policies</asp:HyperLink>   &nbsp;of the webiste.&nbsp;&nbsp;</b><asp:Label ID="lblAgreeConfirmation" BackColor="DarkRed" ForeColor="Yellow" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnUpdateInfo" CssClass="ButtonStyle" runat="server" Text="Update Information" OnClick="btnUpdateInfo_Click" />
                            </td>
                        </tr>
                    </table>
                    
                </asp:Panel>
        <br>
        </div> 
        <div align="center">
            <h2><asp:Label ID="lblInfoUpdateConfirmation" ForeColor="Yellow" BackColor="DarkRed" runat="server"></asp:Label></h2>
        </div>
        </div>
    </form>
</body>
</html>
