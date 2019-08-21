<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignupPage.aspx.cs" Inherits="SignupPage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CloudDrive: Create an Account</title>
    <link rel="icon" type="image/png" href="Styles/Images/SiteLogo.png"/>
    <link rel="stylesheet" href="~/Styles/Global_Styles.css" type="text/css" />
    <style>
        .TextBoxStyle
        {
	        font-family: 'Century Gothic';
	        color: black; 
	        border-width: 2px;
	        border-color: #B9B9FF;
	        background-color: #00FFFF;
	        box-shadow: 4px 4px lightgray inset;
            height: 30px; width: 200px; font-size: larger;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <div align="center">
        <h1 class="HeadingStyle" style="width: 98%"><asp:Label ID="Label1" runat="server" Text="CloudDrive: Fill your information to signup!"></asp:Label></h2>
                <br>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
        <ContentTemplate>
            <asp:Panel ID="PanelAcceptInfos1" Width="90%" CssClass="BodyStyle" BorderColor="DarkBlue" BorderWidth="2px" runat="server">
            <%--<asp:Label ID="lblWarning" BackColor="DarkRed" ForeColor="Yellow" runat="server"></asp:Label>--%>
            <table border="0" class="table" bordercolor="darkblue" align="center">
                <caption><br><h4 class="BodyStyle" style="border-width: 0px;">[Fields marked with * are mandatory]</h4></caption>
                <tr>
                    <td class="BodyStyle" style="border-width: 0px;">Username*:</td>
                    <td>
                        <asp:TextBox ID="txtUsername" placeholder="Choose a Username" CssClass="TextBoxStyle" runat="server"></asp:TextBox></td><td><asp:Button ID="btnCheckUsername" CssClass="ButtonStyle" runat="server" Text="Check username availability" OnClick="btnCheckUsername_Click" /></td><td>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <asp:Image ID="ImageCheckUserName" ImageUrl="Images/NotificationImages/SmallLoading.gif" Height="20px" Width="20px" runat="server" />
                            </ProgressTemplate>
                        </asp:UpdateProgress></td><td>
                        <asp:Label ID="lblCheckUsernameAvailability" CssClass="BodyStyle" style="border-width: 0px;" runat="server"></asp:Label><br>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
        <asp:Panel ID="PanelAcceptInfos2" Width="90%" CssClass="BodyStyle" BorderColor="DarkBlue" BorderWidth="2px" runat="server" Enabled="False"> 
              
            <table border="0" class="table" bordercolor="darkblue" align="center">
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">First Name*:</td>
                    <td>
                        <asp:TextBox ID="txtFirstName" placeholder="First Name" CssClass="TextBoxStyle" runat="server"></asp:TextBox>                                                               &nbsp;&nbsp;&nbsp; <asp:Label ID="lblFirstNameError" runat="server" ForeColor="Red"></asp:Label>               
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">Middle Name:</td>
                    <td>
                        <asp:TextBox ID="txtMiddleName" placeholder="Middle Name" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">Last Name*:</td>
                    <td>
                        <asp:TextBox ID="txtLastName" placeholder="Last Name" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp; <asp:Label ID="lblLastNameError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">Gender*:</td>
                    <td>
                        <asp:RadioButton ID="RadioButtonMale" CssClass="BodyStyle" style="border-width: 0px;" Text="Male" GroupName="Gender" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;<asp:RadioButton ID="RadioButtonFemale" CssClass="BodyStyle" style="border-width: 0px;" Text="Female" GroupName="Gender" runat="server" />
                        &nbsp;&nbsp;&nbsp; <asp:Label ID="lblGenderError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">Date of birth*:</td>
                    <td>
                        <asp:TextBox ID="txtDOB" placeholder="Date of Birth" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="txtDOB_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDOB"></asp:CalendarExtender>
                        &nbsp;&nbsp;&nbsp; <asp:Label ID="lblDOBError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">Country*:</td>
                    <td>
                        <asp:DropDownList ID="DropDownListCountry" CssClass="ButtonStyle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListCountry_SelectedIndexChanged"></asp:DropDownList>
                        &nbsp;&nbsp;&nbsp; <asp:Label ID="lblCountryError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">City*:</td>
                    <td>
                        <asp:DropDownList ID="DropDownListCities" CssClass="ButtonStyle" runat="server"></asp:DropDownList>
                        &nbsp;&nbsp;&nbsp; <asp:Label ID="lblCitiesError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">Phone Number*:</td>
                    <td>
                        <asp:TextBox ID="txtPhNo" placeholder="Phone Number" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp; <asp:Label ID="lblPhoneNumberError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">Email Address*:</td>
                    <td>
                        <!-- TextMode="Email" -->
                        <asp:TextBox ID="txtEMail" placeholder="EMail Address" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp; <asp:Label ID="lblEmailError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">Security Question*:</td>
                    <td>
                        <asp:DropDownList ID="DropDownListSecurityQuestion" CssClass="ButtonStyle" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownListSecurityQuestion_SelectedIndexChanged">
                            <asp:ListItem>Choose a question</asp:ListItem>
                            <asp:ListItem>What is your nick name?</asp:ListItem>
                            <asp:ListItem>In which town was your mother born?</asp:ListItem>
                            <asp:ListItem>What is your mother&#39;s maiden name?</asp:ListItem>
                            <asp:ListItem>What was the number of your first phone?</asp:ListItem>
                            <asp:ListItem>Create a question yourself</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="txtCustomSecurityQuestion" Visible="false" placeholder="Custom Security Question" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp; <asp:Label ID="lblSecurityError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">Security Answer*:</td>
                    <td>
                        <asp:TextBox ID="txtSecurityAnswer" CssClass="TextBoxStyle" placeholder="Security Answer" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp; <asp:Label ID="lblSecurityAnswerError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">Martial Status*:</td>
                    <td>
                        <asp:RadioButton ID="RadioButtonMarried" CssClass="BodyStyle" style="border-width: 0px;" GroupName="MStatus" Text="Married" runat="server" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RadioButton ID="RadioButtonUnmarried" CssClass="BodyStyle" style="border-width: 0px;" GroupName="MStatus" Text="Unmarried" runat="server" />
                        &nbsp;&nbsp;&nbsp; <asp:Label ID="lblMartialStatusError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">Password*:</td>
                    <td>
                        <asp:TextBox ID="txtPassword1" placeholder="Password" CssClass="TextBoxStyle" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:PasswordStrength ID="txtPassword1_PasswordStrength" runat="server" Enabled="True" TargetControlID="txtPassword1"></asp:PasswordStrength>
                        &nbsp;&nbsp;&nbsp; <asp:Label ID="lblPassword1Error" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">Re-enter Password*:</td>
                    <td>
                        <asp:TextBox ID="txtPassword2" placeholder="Password Again" CssClass="TextBoxStyle" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:PasswordStrength ID="txtPassword2_PasswordStrength" runat="server" Enabled="True" TargetControlID="txtPassword2"></asp:PasswordStrength>
                        &nbsp;&nbsp;&nbsp; <asp:Label ID="lblPassword2Error" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td colspan="2" align="center">
                        <asp:CheckBox ID="CheckBoxAgreeTerms" CssClass="BodyStyle" style="border-width: 0px;" runat="server" />
                        <font color="red"><b>I agree the </font>
                        <a href="Terms_and_PoliciesPage.aspx" target="_blank">terms and policies</a>
                        <font color="red">&nbsp;of the webiste.</b></font>&nbsp;&nbsp;
                        <asp:Label ID="lblAgreeConfirmation" ForeColor="Red" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td colspan="2" align="center">
                        <asp:Button ID="btnSignup" CssClass="ButtonStyle" runat="server" Text="Sign Up" OnClick="btnSignup_Click" ValidationGroup="vg1" />
                    </td>
                </tr>
            </table>
            <br><br>
            <a href="Homepage.aspx?s=1" class="HyperlinkStyle"><img src="Styles/Images/Navigation Buttons/GoBack.png" height="40px" width="40px"/>&nbsp;&nbsp; Go back to homepage</a>
        </asp:Panel>
        </b>
        <br>
        <asp:Panel ID="PanelShowInfos" Width="90%" CssClass="BodyStyle" BorderColor="DarkBlue" BorderWidth="2px" Visible="false" runat="server">
            <center><h1 class="BodyStyle" style="border-width: 2px; border-color: darkblue; width: 98%;">Review your provided information</h1></center>
            <table border="0" bordercolor="red" align="center" class="table">
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">
                        Username:
                    </td>
                    <td class="BodyStyle" style="border-width: 0px;">
                        <asp:Label ID="lblUsername" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">
                        First Name:
                    </td>
                    <td class="BodyStyle" style="border-width: 0px;">
                        <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">
                        Middle Name:
                    </td>
                    <td class="BodyStyle" style="border-width: 0px;">
                        <asp:Label ID="lblMiddleName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">
                        Last Name:
                    </td>
                    <td class="BodyStyle" style="border-width: 0px;">
                        <asp:Label ID="lblLastName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">
                        Gender:
                    </td>
                    <td class="BodyStyle" style="border-width: 0px;">
                        <asp:Label ID="lblGender" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">
                        Date of Birth:
                    </td>
                    <td class="BodyStyle" style="border-width: 0px;">
                        <asp:Label ID="lblDOB" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">
                        Country:
                    </td>
                    <td class="BodyStyle" style="border-width: 0px;">
                        <asp:Label ID="lblCountry" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">
                        City:
                    </td>
                    <td class="BodyStyle" style="border-width: 0px;">
                        <asp:Label ID="lblCity" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">
                        Phone Number:
                    </td>
                    <td class="BodyStyle" style="border-width: 0px;">
                        <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">
                        Martial Status:
                    </td>
                    <td class="BodyStyle" style="border-width: 0px;">
                        <asp:Label ID="lblMartialStatus" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">
                        Profile Picture:
                    </td>
                    <td align="center">
                        <asp:Image ID="imgProfilePic" Height="50" Width="50" runat="server" />
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">
                        EMail Address:
                    </td>
                    <td class="BodyStyle" style="border-width: 0px;">
                        <asp:Label ID="lblEMail" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">
                        Security Question:
                    </td>
                    <td class="BodyStyle" style="border-width: 0px;">
                        <asp:Label ID="lblSecurityQuestion" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td class="BodyStyle" style="border-width: 0px;">
                        Security Answer:
                    </td>
                    <td class="BodyStyle" style="border-width: 0px;">
                        <asp:Label ID="lblSecurityAnswer" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            
            <asp:Button ID="btnChangeInfo" CssClass="ButtonStyle" runat="server" Text="Change Information" OnClick="btnChangeInfo_Click" />
            <br><br><br>
            <asp:Button ID="btnGoToCustAccountPage" CssClass="ButtonStyle" runat="server" Text="See your newly created account page" OnClick="btnGoToCustAccountPage_Click" />
    
        </asp:Panel>
        </ContentTemplate>
        </asp:UpdatePanel>
        
        </div>   
    </form>
</body>
</html>
