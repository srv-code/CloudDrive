<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CloudDrive: Home</title>
    <link rel="icon" type="image/png" href="Styles/Images/SiteLogo.png"/>
    <link rel="stylesheet" href="~/Styles/Global_Styles.css" type="text/css" />

    <!-- Start WOWSlider.com HEAD section --> <!-- add to the head of your page -->
	<link rel="stylesheet" type="text/css" href="WowSlider/engine1/style.css" />
	<script type="text/javascript" src="WowSlider/engine1/jquery.js"></script>
	<!-- End WOWSlider.com HEAD section -->

    <style>
        .SearchlblStyle
        {
            padding: 1px;
	        font-family: 'Century Gothic'; font-weight: bold;
            color: darkblue;
            font-size: small;
        }
        .SearchResultsStyle
        {
            text-decoration: none;
            padding: 1px;
	        font-family: 'Century Gothic'; font-weight: bold;
            color: darkblue;
            font-size: larger;
        }
        .imgPopupCancel
        {
            float: right;
        }
        .LoginButtonStyle
        {           
            float: right; padding: 10px;
	        font-family: 'Century Gothic';
	        border-radius: 4px;
	        font-size: large; 
	        font-weight: bold;
	        border-width: 0px; 
	        background-color: rgba(255, 255, 255, 0.00); color: white;
        }
        .LoginButtonStyle:hover {color: darkblue;}
        .LogBackgroundStyle
        {
            padding: 10px;
            background: -webkit-linear-gradient(#B9B9FF, #6262FF, #B9B9FF);
	        background: -o-linear-gradient(#B9B9FF, white, #B9B9FF);
	        background: -moz-linear-gradient(#B9B9FF, white, #B9B9FF);
        }
        .LoginLogoutStyle
        {
            padding-right: 6%;
        }
        #AlignRight
        {
            float: right;
            width: 20%;
        }
        #AlignImageRight 
        {
            float: right;
            width: 5%;
        }
        .PanelAlignLeft 
        {
            float: left;
            width: 100%;
        }
        .SlideShowDiv
        {
            width: 50%; 
            text-align:center; 
            float: left;
            padding-left: 20%;
        }
        .SessionExpiredMessage {
            color: red;
            font-weight: bolder;
            font-family: 'Century Gothic';
            font-size: medium;
            padding: 3px;
            border-radius: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>

        
    <div align="center">
        
        <div style="height: 40px;">            
            <h1 class="HeadingStyle">                
                <asp:Image ID="imgIcon" ImageAlign="AbsBottom" ImageUrl="Styles/Images/SiteLogo.png" Height="45px" Width="45px" runat="server" />
                &nbsp;CloudDrive
                <asp:Button ID="btnAboutUs" Text="About Us" CssClass="LoginButtonStyle" runat="server" OnClick="btnAboutUs_Click" />
                <asp:Button ID="btnContactUs" Text="Contact Us" CssClass="LoginButtonStyle" runat="server" OnClick="btnContactUs_Click" />
                <asp:Button ID="btnT_P" Text="Terms & Policies" CssClass="LoginButtonStyle" runat="server" OnClick="btnT_P_Click" />
                <asp:Button ID="btnLogin" Text="Login" CssClass="LoginButtonStyle" runat="server" OnClick="btnLogin_Click" />
                <asp:Button ID="btnLogout" Text="Logout" CssClass="LoginButtonStyle" runat="server" OnClick="btnLogout_Click" />
                <div style="float: right"><asp:Image ID="ImageProPic" Visible="false" Height="45px" Width="45px" BorderWidth="0" runat="server" /></div>
            </h1>
        </div>    
        <br>       
        <br> 
        <asp:Label ID="lblLoginErrorMessage" Visible="false" Height="35" CssClass="LabelStyle" runat="server" ForeColor="Red" Text="Wrong credentials entered! Please try again!" ></asp:Label>   
        <asp:Label ID="lblSessionExpiredMessage" Visible="false" CssClass="SessionExpiredMessage" runat="server" Text="Your session expired! Please login again to continue."></asp:Label>     
    </div>
    <!---------------------------------- Startin WOWSlider.com BODY section -------------------------------------------------->
        <div align="center">
            <div id="wowslider-container1">
	<div class="ws_images"><ul>
		

        <li><img src="WowSlider/data1/images/accessible_from_all_kinds_of_devices.png" alt="Accessible from all kinds of devices" title="Accessible from all kinds of devices" id="wows1_0"/></li>
		<li><img src="WowSlider/data1/images/easiest_way_for_upload_and_download_of_files.jpg" alt="Easiest way for downloading files from cloud storage" title="Easiest way for downloading files from cloud storage" id="wows1_1"/></li>
		<li><img src="WowSlider/data1/images/easiest_way_for_upload_and_download_of_files2.jpg" alt="Easiest way for uploading files to cloud storage" title="Easiest way for uploading files to cloud storage" id="wows1_2"/></li>
		<li><img src="WowSlider/data1/images/gigantic_cloud_storage_service.jpg" alt="Gigantic cloud storage service" title="Gigantic cloud storage service" id="wows1_3"/></li>
		<li><img src="WowSlider/data1/images/instant_file_uploading_and_downloading.jpg" alt="Instant file uploading and downloading" title="Instant file uploading and downloading" id="wows1_4"/></li>
		<li><img src="WowSlider/data1/images/online_file_management.jpg" alt="Online file management" title="Online file management" id="wows1_5"/></li>
		<li><img src="WowSlider/data1/images/prevention_from_any_kind_of_unauthorized_access.png" alt="Prevention from any kind of unauthorized access" title="Prevention from any kind of unauthorized access" id="wows1_6"/></li>
		<li><img src="WowSlider/data1/images/securest_cloud_storage.jpg" alt="Securest cloud storage" title="Securest cloud storage" id="wows1_7"/></a></li>
		<li><img src="WowSlider/data1/images/support_for_a_million_of_file_types.jpg" alt="Support for a million of file types" title="Support for a million of file types" id="wows1_8"/></li>
        <li><img src="WowSlider/data1/images/Secure_File_Archiving_Service.jpg" alt="Secure file archiving service" title="Secure file archiving service" id="wows1_9"/></li>
        <li><img src="WowSlider/data1/images/Multi-format_file_upload_facility.gif" alt="Multi-format file upload facility" title="Multi-format file upload facility" id="wows1_10"/></li>
        <li><img src="WowSlider/data1/images/Supports_most_of_the_devices_you_use.jpg" alt="Supports most of the devices you use" title="Supports most of the devices you use" id="wows1_11"/></li>
        <li><img src="WowSlider/data1/images/cloud_storage.jpg" alt="cloud storage" title="cloud storage" id="wows1_12"/></li>
        <li><img src="WowSlider/data1/images/Most_Efficient_Cloud_Computing_Service.jpg" alt="Most Efficient Cloud Computing Service" title="Most Efficient Cloud Computing Service" id="wows1_13"/></li>	
	</ul></div>
	<div class="ws_bullets"><div>
		<a href="#" title="CloudDrive_Slider"><img src="WowSlider/data1/tooltips/accessible_from_all_kinds_of_devices.png" alt="CloudDrive_Slider"/>1</a>
        <a href="#" title="Easiest way for upload and download of files"><img src="WowSlider/data1/tooltips/easiest_way_for_upload_and_download_of_files.jpg" alt="Easiest way for upload and download of files"/>2</a>
		<a href="#" title="Easiest way for upload and download of files"><img src="WowSlider/data1/tooltips/easiest_way_for_upload_and_download_of_files2.jpg" alt="Easiest way for upload and download of files2"/>3</a>
		<a href="#" title="Gigantic cloud storage service"><img src="WowSlider/data1/tooltips/gigantic_cloud_storage_service.jpg" alt="Gigantic cloud storage service"/>4</a>
		<a href="#" title="Instant file uploading and downloading"><img src="WowSlider/data1/tooltips/instant_file_uploading_and_downloading.jpg" alt="Instant file uploading and downloading"/>5</a>
		<a href="#" title="Online file management"><img src="WowSlider/data1/tooltips/online_file_management.jpg" alt="Online file management"/>6</a>
		<a href="#" title="Prevention from any kind of unauthorized access"><img src="WowSlider/data1/tooltips/prevention_from_any_kind_of_unauthorized_access.png" alt="Prevention from any kind of unauthorized access"/>7</a>
		<a href="#" title="Securest cloud storage"><img src="WowSlider/data1/tooltips/securest_cloud_storage.jpg" alt="Securest cloud storage"/>8</a>
		<a href="#" title="Support for a million of file types"><img src="WowSlider/data1/tooltips/support_for_a_million_of_file_types.jpg" alt="Support for a million of file types"/>9</a>
	</div></div><span class="wsl"><a href="http://wowslider.com/vu">image carousel</a> by WOWSlider.com v6.8</span>
	<div class="ws_shadow"></div>
	</div>	
	<script type="text/javascript" src="WowSlider/engine1/wowslider.js"></script>
	<script type="text/javascript" src="WowSlider/engine1/script.js"></script>
        </div>
    <!---------------------------------- End WOWSlider.com BODY section -------------------------------------------------->

        <!---------------------------------- Useless Controls -------------------------------------------------->
        <asp:Button ID="btn1" Visible="false" runat="server" Text="Button" />
        <!---------------------------------- Useless Controls -------------------------------------------------->



<div align="center">
        
        <asp:ModalPopupExtender ID="ModalPopupExtenderPanelLogin" PopupControlID="PopupPanelUserLogin" DropShadow="true" TargetControlID="btnLogin"
        CancelControlID="imgButtonCancel1" BackgroundCssClass="ModalBackgroundStyle" runat="server"></asp:ModalPopupExtender>
			
            <asp:Panel ID="PopupPanelUserLogin" DefaultButton="btnPopupLogin" CssClass="LoginPanelStyle" Visible="false" BorderWidth="2" BorderColor="LightBlue" runat="server">
                <div align="center">
                    <asp:Label ID="lblLoginCaption" CssClass="HeadingStyle" Font-Size="X-Large" Height="40px" Width="620px" runat="server" Text="Log In to Your Account">
                        <asp:ImageButton ID="imgButtonCancel1" CssClass="imgPopupCancel" Height="28" Width="28" ImageUrl="Images/NotificationImages/popup-close-button.png" runat="server" />
                    </asp:Label>
                </div>
                    <br>
                <asp:Label ID="lblLoginUsername" CssClass="LabelStyle" runat="server" Font-Size="X-Large" Text="Username:"></asp:Label>&nbsp;&nbsp;&nbsp;
			    <asp:TextBox ID="txtLoginUsername" placeholder="Username" CssClass="TextBoxStyle" Height="40px" Width="400px" Font-Size="X-Large" runat="server"></asp:TextBox>
                <br>
			    <asp:Label ID="lblLoginPassword" CssClass="LabelStyle" runat="server" Font-Size="X-Large" Text="Password:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtLoginPassword" TextMode="Password" placeholder="Password" CssClass="TextBoxStyle" Height="40px" Width="400px" Font-Size="X-Large" runat="server"></asp:TextBox>
                <br><asp:Button ID="btnPopupLogin" runat="server" CssClass="ButtonStyle" Height="50" Width="100" 
                    Font-Size="X-Large" Text="Log In" OnClick="btnPopupLogin_Click" />
                <br><br><asp:HyperLink ID="HyperLinkForgotPassword" NavigateUrl="~/ForgotPasswordPage.aspx" CssClass="HyperlinkStyle" runat="server" Target="_blank" Text="Forgot Password?"></asp:HyperLink>
                <br><asp:HyperLink ID="HyperLinkSignup" NavigateUrl="~/SignupPage.aspx" Target="_blank" CssClass="HyperlinkStyle" runat="server" Text="Don't have an account? Create one here in just a fly..."></asp:HyperLink>
            </asp:Panel>
			

		<asp:ModalPopupExtender ID="ModalPopupExtenderPanelLogout" DropShadow="true" PopupControlID="PopupPanelUserLogout" TargetControlID="btnLogout"
        CancelControlID="imgButtonCancel2" BackgroundCssClass="ModalBackgroundStyle" runat="server"></asp:ModalPopupExtender>

			<asp:Panel ID="PopupPanelUserLogout" DefaultButton="btnPopupLogout" CssClass="LoginPanelStyle" Visible="false" BorderWidth="2" BorderColor="LightBlue" runat="server">
                <div align="center">
                    <asp:Label ID="Label1" CssClass="HeadingStyle" Font-Size="X-Large" Height="40px" Width="620px" runat="server" Text="Visit to or Log Out from Your Account">
                        <asp:ImageButton ID="imgButtonCancel2" CssClass="imgPopupCancel" Height="28" Width="28" ImageUrl="Images/NotificationImages/popup-close-button.png" runat="server" />
                    </asp:Label>
                </div>
                    <br>
                <div style="float: left;">
                    <asp:Label ID="Label2" runat="server" Text="" Width="50px"></asp:Label>    
                    <asp:Image ID="imgPopupUserPic" Visible="true" Height="210" Width="210" runat="server" />
                </div>
                <div style="float: right;">
                    <br>
                    <asp:Label ID="lbl1" CssClass="LabelStyle" Font-Size="X-Large" runat="server" Text="Logged In as"></asp:Label>
                    <asp:Label ID="Label5" runat="server" Text="" Width="100px"></asp:Label><br>
                    <asp:Label ID="lblLoggedInUsername" runat="server" CssClass="LabelStyle" Font-Size="X-Large" Text=""></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="" Width="100px"></asp:Label>    
                    <br><br><asp:Button ID="btnPopupVisitUserAcc" runat="server" CssClass="ButtonStyle" Height="50" Font-Size="X-Large" Text="Visit Your Account" />
                    <asp:Label ID="Label6" runat="server" Text="" Width="90px"></asp:Label>
                    <br><br><asp:Button ID="btnPopupLogout" runat="server" CssClass="ButtonStyle" Height="50" Font-Size="X-Large" Text="Log Out" OnClick="btnPopupLogout_Click" />
                    <asp:Label ID="Label3" runat="server" Text="" Width="130px"></asp:Label>    
                </div>
            </asp:Panel>
</div>
        <div align="center">
            <br><br><br>
            <div class="HeadingStyle" style="text-align: center; width: 650px; font-weight: bold; font-size: larger; font: caption">SEARCH FILES HERE</div>
            <tr>
                <td>
                    <asp:TextBox ID="txtSearch" Height="32px" Width="250px" Font-Size="Larger" placeholder="    Search Here" CssClass="TextBoxStyle" runat="server"></asp:TextBox>
                    <asp:DropDownList CssClass="ButtonStyle"  ID="DropDownListSearchCategory" runat="server">
                        <asp:ListItem>Choose a category</asp:ListItem>
                        <asp:ListItem>Image</asp:ListItem>
                        <asp:ListItem>Video</asp:ListItem>
                        <asp:ListItem>Music</asp:ListItem>
                        <asp:ListItem>Document</asp:ListItem>
                        <asp:ListItem>Executable</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:ImageButton ID="btnSearch" ImageAlign="AbsBottom" ImageUrl="~/Styles/Images/SearchButton.png" Height="40px" Width="80px" runat="server" OnClick="btnSearch_Click1" />
                </td>
            </tr>
        </table>
        <br>
        <asp:Panel ID="PanelAdrotator" Visible="false" CssClass="PanelAlignLeft" runat="server">
            <div align="center">
            <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer>
            <br><br><br><br>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <br>
                <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/App_Data/Advertisements.xml" Height="20%" Width="20%" KeywordFilter="ITLeaders" />
                &nbsp; &nbsp;&nbsp; &nbsp;
                <asp:AdRotator ID="AdRotator2" runat="server" AdvertisementFile="~/App_Data/Advertisements.xml" Height="20%" Width="20%" KeywordFilter="Food" />
                &nbsp; &nbsp;&nbsp; &nbsp;
                <asp:AdRotator ID="AdRotator3" runat="server" AdvertisementFile="~/App_Data/Advertisements.xml" Height="20%" Width="20%" KeywordFilter="SB" />
            </ContentTemplate>
        </asp:UpdatePanel>
            <br><br>
        </div>
        </asp:Panel>
        
        <asp:Panel ID="PanelSearch" Visible="true" runat="server" CssClass="BodyStyle" BorderColor="DarkBlue" BorderWidth="2px" Width="70%">
            <br>
        <asp:Label ID="lblSearchResultNo" CssClass="BodyStyle" BorderWidth="2" BorderColor="LightBlue" runat="server"></asp:Label><br>
        <div align="left">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </div>
            </asp:Panel>

    </div>
    </form>
</body>
</html>
