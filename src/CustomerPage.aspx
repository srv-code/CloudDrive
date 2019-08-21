<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerPage.aspx.cs" Inherits="CustomerPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CloudDrive: Welcome User</title>
    <link rel="icon" type="image/png" href="Styles/Images/SiteLogo.png"/>
    <link rel="stylesheet" href="~/Styles/Global_Styles.css" type="text/css" />

    <style>
        .roundBorders { border-radius: 3px; }
        .LabelShowSharedUserName { font-family:'Century Gothic'; font-weight: bold; }
        .lblUsed
        { 
            border-radius: 3px;
            float: left;
            text-align: center;
            font-family: 'Agency FB';
            font-weight: bolder;
            font-size: larger;
        }
        .lblUnused
        {             
            padding-bottom: 2px;
            padding-top: 2px;
            padding-left: 15px;
            border-radius: 3px;
            float: left;
            text-align: left;
            font-family: 'Agency FB';
            font-weight: bolder;
            font-size: larger;
        }
        .InvisibleButtonStyle
        {
            background-color: white; color: white;
            border-color: white; border-width: 0px;
        }
        .BorderRadiusStyle
        {
            background-color: white; opacity: 1.0; border-radius: 5px;
        }
        .imgPopupCancel
        {
            float: right;
        }
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
            text-align: center;            
        }
        #AlignLeft
        {
            float: left; 
            width: 20%;
        }
        #AlignRight
        {
            float: right; 
            width: 80%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>

<!--***************** HEADING PART [ Contains: Page Heading, Menu, Profile Picture ] *****************************************************************************************************-->
        <div align="center">
        <h1><asp:Label ID="Label1" CssClass="HeadingStyle" Width="98%" runat="server"></asp:Label></h1>
            <asp:Menu ID="Menu1" runat="server" BackColor="#507CD1" DynamicHorizontalOffset="2" Font-Names="Segoe UI" Font-Size="12pt" ForeColor="White" Orientation="Horizontal" StaticSubMenuIndent="10px" OnMenuItemClick="Menu1_MenuItemClick" Width="100%" BorderStyle="Solid" BorderWidth="0px" ItemWrap="True" Font-Bold="True">
                <DynamicHoverStyle BackColor="#3366FF" ForeColor="Lime" Font-Bold="True" Font-Names="Segoe UI" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" BackColor="#507CD1" />
                <DynamicMenuStyle BackColor="#507CD1" />
                <DynamicSelectedStyle BackColor="#507CD1" ForeColor="Lime" />
                <Items>
                    <asp:MenuItem NavigateUrl="~/Homepage.aspx?s=1" Text="Home" Value="Home"></asp:MenuItem>
                    <asp:MenuItem Text="Notifications" Value="Notifications"></asp:MenuItem>
                    <asp:MenuItem Target="Test" Text="Upload File" Value="Upload File"></asp:MenuItem>
                    <asp:MenuItem Text="My Uploads" Value="My Uploads"></asp:MenuItem>
                    <asp:MenuItem Text="Account" Value="Account">
                        <asp:MenuItem Text="Change password" Value="Change password"></asp:MenuItem>
                        <asp:MenuItem Text="Change Profile Picture" Value="Change Profile Picture"></asp:MenuItem>
                        <asp:MenuItem Text="Change account information" Value="Change account information" NavigateUrl="~/UserAccInfoPage.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Delete account" Value="Delete account"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Contact Us" Value="Contact Us"></asp:MenuItem>
                    <asp:MenuItem Text="About Us" Value="About Us"></asp:MenuItem>
                    <asp:MenuItem Text="Our Terms &amp; Policies" Value="Our Terms &amp; Policies"></asp:MenuItem>
                    <asp:MenuItem Text="Sign Out" Value="Sign Out"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#3366FF" ForeColor="Lime" />
                <StaticMenuItemStyle HorizontalPadding="20px" VerticalPadding="10px" />
                <StaticSelectedStyle BackColor="#507CD1" />
            </asp:Menu>
        </div>
            <br><br>
            <div id="AlignLeft">
                <asp:Image ID="ImageProfilePic" runat="server" Height="200px" Width="200px"/>
                <asp:Button ID="ButtonChangeProfilePicture" BackColor="DarkRed" Width="200px" runat="server" Text="Change profile picture" CssClass="ButtonStyle" Font-Bold="True" OnClick="ButtonChangeProfilePicture_Click" />
            </div>
<!--xxxxxxxxxxxxxxxxxx HEADING PART [ Contains: Page Heading, Menu, Profile Picture ] xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx-->


<!--***************** PANEL : UPLOAD FILE  ***************************************************************************************************************************************-->
        <asp:Panel ID="PanelUploadFile" Visible="false" runat="server">

            <div>
                <div align="center">				
	                <div id="AlignRight" align="center">
                        <h2 class="BodyStyle">Upload your files here....</h2>
                        <asp:DropDownList ID="DropDownListUploadMode" runat="server" AutoPostBack="True" CssClass="ButtonStyle" OnSelectedIndexChanged="DropDownListUploadMode_SelectedIndexChanged">
                            <asp:ListItem>Choose an upload mode</asp:ListItem>
                            <asp:ListItem>General Mode</asp:ListItem>
                            <asp:ListItem>Secure Archive Mode</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DropDownListSearchCategory" runat="server" CssClass="ButtonStyle">
                            <asp:ListItem>Choose a category</asp:ListItem>
                            <asp:ListItem>Image</asp:ListItem>
                            <asp:ListItem>Video</asp:ListItem>
                            <asp:ListItem>Music</asp:ListItem>
                            <asp:ListItem>Document</asp:ListItem>
                            <asp:ListItem>Executable</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="ButtonStyle" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnUploadFile" runat="server" CssClass="ButtonStyle" OnClick="btnUploadFile_Click" Text="Upload File" />
                        <br>
                        <br>
                        <asp:Label ID="lblUploadStatus" runat="server" BorderWidth="0px" CssClass="BodyStyle"></asp:Label>                      
                    </div>

        </asp:Panel>
<!--xxxxxxxxxxxxxxxxx PANEL : UPLOAD FILE xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx-->


<!--***************** PANEL : VIEW, DELETE, SHARE UPLOADED FILES  *********************************************************************************************************************-->
        <div>
        <div align="center">
        <asp:Panel ID="PanelUploadedFiles" Font-Names="Century Gothic" Font-Bold="true" Visible="false" runat="server">
                        
            <h2><asp:Label ID="Label3" Width="70%" runat="server" Text="List of your uploaded file(s)" CssClass="BodyStyle"></asp:Label></h2>
            <div align="center">
                <asp:Label ID="lblFileDeletion" runat="server" CssClass="BodyStyle" BorderWidth="1px" BorderColor="DarkBlue"></asp:Label>
                <br />
                <br />
                <div align="right">
                    <div style="float: left; font-family: 'Agency FB'; font-weight: bolder; font-size: larger;">
                        <h3>
                            <asp:Label ID="Label4" runat="server" Text="Usage:"></asp:Label>
                        </h3>
                    </div>
                    &nbsp;&nbsp;
                    <asp:Panel ID="PanelUsageInfo" runat="server" BackColor="LightGray" BorderColor="DarkGray" BorderWidth="2" CssClass="roundBorders" Height="30px" HorizontalAlign="Center" Width="1000px">
                        <asp:Label ID="lblSpaceUsedInfo" runat="server" CssClass="lblSpaceUsed"></asp:Label>
                        <asp:Label ID="lblUsed" runat="server" BackColor="Violet" CssClass="lblUsed" Height="30px" Width="0px"></asp:Label>
                        <asp:Label ID="lblUnused" runat="server" CssClass="lblUnused" Height="30px" Width="0px"></asp:Label>
                    </asp:Panel>
                </div>
                <br>
                <div align="center">
                    <div align="center" style="padding-left: 80px;">
                        <asp:Panel ID="PanelShareWith" runat="server" BorderColor="LightBlue" BorderWidth="2" CssClass="BorderRadiusStyle" Visible="false" Width="70%">
                            &nbsp;
                            <br>
                            <asp:Label ID="Label5" runat="server" BorderWidth="0" CssClass="BodyStyle" Font-Size="Large" Text="Search and select the users to share your selected files with:"></asp:Label>
                            <br>
                            <br>
                            <asp:Panel ID="Panel2" runat="server">
                                <div align="center">
                                    <asp:TextBox ID="txtSearchUser" runat="server" CssClass="TextBoxStyle" Font-Size="Large" Height="30px" placeholder="Enter the name of the user to search" Width="608px"></asp:TextBox>
                                    <asp:AutoCompleteExtender 
                                        ID="ac1" runat="server" 
                                        CompletionInterval="1"
                                        EnableCaching="true"
                                        CompletionListCssClass="AutoSuggestionListStyle"
                                        CompletionListItemCssClass="AutoSuggestionListItemStyle"
                                        CompletionListHighlightedItemCssClass="AutoSuggestionListHighlightedItemStyle"
                                        TargetControlID="txtSearchUser" 
                                        ServiceMethod="getUserInfosSuggestionList" 
                                        ServicePath="WebService.asmx" 
                                        MinimumPrefixLength="1">
                                    </asp:AutoCompleteExtender>
                                    <asp:Button ID="btnSearchUser" runat="server" CssClass="ButtonStyle" OnClick="btnSearchUser_Click" Text="Search User" />
                                    <br />
                                    &nbsp;
                                    <br>
                                    <asp:Button ID="btnSendRequestsToUsers" runat="server" CssClass="ButtonStyle" Enabled="false" OnClick="btnSendRequestsToUsers_Click" Text="Send sharing requests" />
                                    &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnCancelFileSharing" runat="server" CssClass="ButtonStyle" OnClick="btnCancelFileSharing_Click" Text="Cancel" />
                                    <br />
                                    <br />
                                    <div align="center" style="float:left;padding-left:5px;padding-right:5px; width:45%;">
                                        <asp:Label ID="lblSearchUserErrorMessage" runat="server"></asp:Label>
                                        <br>
                                        <asp:GridView ID="GridViewSearchedUsers" runat="server" CellPadding="4" Font-Size="Smaller" ForeColor="#333333" GridLines="None" OnRowCommand="GridViewSearchedUsers_RowCommand">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnUserProPic" runat="server" Height="35" Width="35" />
                                                        <asp:Button ID="btnAddUser" runat="server" CommandName="AddUserInNewGroup" Height="35" Text="Add User" Width="70" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EditRowStyle BackColor="#2461BF" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EFF3FB" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                        </asp:GridView>
                                        </br>
                                    </div>
                                    <div align="center" style="float:right; padding-right:5px; width:50%;">
                                        <asp:Label ID="lblUsersAddedCounter" runat="server"></asp:Label>
                                        <br />
                                        <asp:GridView ID="GridViewAddedUsers" runat="server" CellPadding="4" Font-Size="Smaller" ForeColor="#333333" GridLines="None" OnRowCommand="GridViewAddedUsers_RowCommand">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnUserProPic0" runat="server" Height="35" Width="35" />
                                                        <asp:Button ID="btnRemoveUser" runat="server" CommandName="RemoveUserFromNewGroup" Height="35" Text="Remove User" Width="95" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EditRowStyle BackColor="#2461BF" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EFF3FB" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                        </asp:GridView>
                                    </div>
                                    <br></br>
                                    </br>
                                </div>
                            </asp:Panel>
                            <br></br>
                            </br>
                            </br>
                            </br>
                        </asp:Panel>
                    </div>
                </div>
                <br />
                <asp:Label ID="lblFileSharingErrorMessage" runat="server" BorderWidth="0px" CssClass="BodyStyle" ForeColor="Red"></asp:Label>
                <br />
                <asp:GridView ID="GridViewUploadedFiles" runat="server" BorderColor="DarkGray" BorderWidth="2" CellPadding="4" Font-Bold="true" Font-Size="Small" ForeColor="#333333" GridLines="None" OnRowCommand="GridViewUploadedFiles_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRow" runat="server" />
                                <asp:LinkButton ID="lnkbtnViewContent" runat="server" CommandName="View" OnClientClick="window.document.forms[0].target='_blank'" Text="View"></asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnDownloadContent" runat="server" CommandName="Download" Text="Download"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <br>
                <asp:CheckBox ID="CheckBoxSelectAll" runat="server" AutoPostBack="true" BorderWidth="0px" CssClass="BodyStyle" OnCheckedChanged="CheckBoxSelectAll_CheckedChanged" Text="Select All" />
                <br>
                <asp:Button ID="ButtonDeleteFile" runat="server" CssClass="ButtonStyle" OnClick="ButtonDeleteFile_Click" Text="Delete File(s)" />
                &nbsp;&nbsp;
                <asp:Button ID="ButtonShareWith" runat="server" CssClass="ButtonStyle" OnClick="ButtonShareWith_Click" Text="Share File(s) With Another User(s)" />
                <br>
                <div align="center">
                    <asp:ModalPopupExtender ID="ModalPopupExtenderDeleteFiles" runat="server" BackgroundCssClass="ModalBackgroundStyle" CancelControlID="btnDeleteNo" DropShadow="true" PopupControlID="PanelDeleteFiles" TargetControlID="ButtonDeleteFile">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="PanelDeleteFiles" runat="server" BorderColor="LightBlue" BorderWidth="2" CssClass="BorderRadiusStyle" Height="120px" Visible="false" Width="500px">
                        <asp:Label ID="lblDeleteFilesConfirmation" runat="server" CssClass="HeadingStyle" Font-Size="Large" Width="470px"></asp:Label>
                        <div align="center">
                            <br>
                            <asp:Button ID="btnDeleteYes" runat="server" CssClass="ButtonStyle" Height="40px" OnClick="btnDeleteYes_Click" Text="Yes" Width="100px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnDeleteNo" runat="server" CssClass="ButtonStyle" Height="40px" OnClick="btnDeleteNo_Click" Text="No" Width="100px" />
                            </br>
                        </div>
                    </asp:Panel>
                </div>
                <br>
                <br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
            </asp:Panel>
        </div>
        </div>
        </div>        
        </div>

<!--xxxxxxxxxxxxxxxxxx PANEL : VIEW, DELETE, SHARE UPLOADED FILES  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx-->


<!--***************** PANEL : CHANGE PASSWORD  *****************************************************************************************-->
        <div align="center" style="width: 80%; float: right;">
            <asp:Panel ID="PanelChangePassword" Visible="false" runat="server">
                <h2 class="BodyStyle">Change your old password</h2>
                <asp:Label ID="lblChangePasswordWarning" BackColor="DarkRed" ForeColor="Yellow" runat="server"></asp:Label>
                <h2 class="BodyStyle" style="border-width: 0px;"><b>Enter your current password:</b> &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtCurrentPassword" Font-Size="X-Large" placeholder="Current Password" CssClass="TextBoxStyle" TextMode="Password" runat="server"/><br>
                <b>Enter your new password:</b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtNewPassword1" Font-Size="X-Large" placeholder="New Password" TextMode="Password" CssClass="TextBoxStyle" runat="server"/><br>
                <b>Re-enter your new password:</bb> &nbsp;&nbsp;<asp:TextBox ID="txtNewPassword2" Font-Size="X-Large" placeholder="New Password" CssClass="TextBoxStyle" TextMode="Password" runat="server"/><br>
                <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CssClass="ButtonStyle" OnClick="btnChangePassword_Click" /></h2>
                <br>
                <br></br>
                </b>
                </br>
            </asp:Panel>
<!--xxxxxxxxxxxxxxxxxx PANEL : CHANGE PASSWORD  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx-->


<!--***************** PANEL : CHANGE PROFILE PICTURE  *****************************************************************************************-->
        <div style="float: right;">
            <div align="center">
            <asp:Panel ID="PanelChangeProfilePicture" Width="70%" Visible="false" runat="server">
                <br><br><h2 class="BodyStyle">Change your profile picture here...</h2>
                <asp:FileUpload ID="FileUploadChangeProfilePicture" CssClass="ButtonStyle" runat="server" /> &nbsp; &nbsp; &nbsp;
                <asp:Button ID="btnRemoveProfilePicture" CssClass="ButtonStyle" runat="server" Text="Remove Picture" OnClick="btnRemoveProfilePicture_Click" /> &nbsp; &nbsp; &nbsp;
                <asp:Button ID="btnChangeProfilePicture" CssClass="ButtonStyle" runat="server" Text="Change Picture" OnClick="btnChangeProfilePicture_Click" /><br>
                <asp:Label ID="lblWarningUploadingProPic" CssClass="BodyStyle" BorderWidth="0px" runat="server"></asp:Label>
                </asp:Panel>                
            </div>
        </div>
<!--xxxxxxxxxxxxxxxxxx PANEL : CHANGE PROFILE PICTURE  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx-->

<!--***************** PANEL : DELETE ACCOUNT  *****************************************************************************************-->
        <asp:Button ID="ButtonAccountDeletePanelPopup" runat="server" Visible="true" Text="" CssClass="InvisibleButtonStyle" OnClick="ButtonAccountDeletePanelPopup_Click" />
        
            <div>
                <asp:ModalPopupExtender ID="ModalPopupExtenderDeleteAccount" PopupControlID="PanelDeleteAccountPopup" TargetControlID="ButtonAccountDeletePanelPopup" CancelControlID="btnTest" DropShadow="true" BackgroundCssClass="ModalBackgroundStyle" runat="server"></asp:ModalPopupExtender>
            
                <asp:Panel ID="PanelDeleteAccountPopup" CssClass="BorderRadiusStyle" Visible="false" BorderColor="LightBlue" 
                    BorderWidth="2" runat="server" Width="500px" Height="440px" >
                <div align="center">				
	            <asp:Label ID="lblUsernameDeleteAccount" Width="470px" Font-Size="X-Large" CssClass="HeadingStyle" runat="server"></asp:Label>
                </div>
                <div align="center">
                <asp:Panel ID="PanelProPicOnly" runat="server">
                        <br><asp:Image ID="ImageProfilePictureDeleteAccount" runat="server" Height="180px" Width="180px" /><br>
                </asp:Panel>
                </div>
                <div align="center">
                <asp:Panel ID="PanelLabelNButtons" runat="server">
                    <div style="padding-top: 10px;">
                        <b><asp:Label ID="Label2" CssClass="BodyStyle" BorderWidth="0px" runat="server" Text="Deleting your account will erase all your saved informations permanently till date from our database. And if you want to join again then you have to refill all your informations by yourself!"></asp:Label></b>
                        <br>
                        <asp:Button ID="btnDeleteAccConfirmYes" runat="server" Width="100px" Height="40px" CssClass="ButtonStyle" OnClick="btnDeleteAccConfirmYes_Click" Text="Yes" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Button ID="btnDeleteAccConfirmNo" Width="100px" Height="40px" runat="server" CssClass="ButtonStyle" OnClick="btnDeleteAccConfirmNo_Click" Text="No" />
                    </div>
                </asp:Panel>
                </div>
                </asp:Panel>
                <asp:Button ID="btnTest" runat="server" CssClass="InvisibleButtonStyle" Text="TestButton" />
            </div>
<!--xxxxxxxxxxxxxxxx PANEL : DELETE ACCOUNT  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx-->

        
    </form>
</body>
</html>
