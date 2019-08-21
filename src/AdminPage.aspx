<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CloudDrive: Admin Page</title>
    <link rel="icon" type="image/png" href="Styles/Images/SiteLogo.png"/>
    <link rel="stylesheet" href="~/Styles/Global_Styles.css" type="text/css" />
    <style>
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
        .roundBorders { border-radius: 3px; }
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
        .lblStyle
        {
            font-size: larger;
            padding: 7px;
            font-family: 'Century Gothic';
            font-weight: bold;
            color: darkblue;
        }
        .SearchlblStyle
        {
            padding: 1px;
	        font-family: 'Century Gothic'; font-weight: bold;
            color: darkblue;
            font-size: small;
        }
        .SearchResultsStyle
        {
            padding: 1px;
	        font-family: 'Century Gothic'; font-weight: bold;
            color: darkblue;
            font-size: larger;
        }
        .BodyStyle
        {
            padding: 5px;
            border-style: solid;
            border-color: darkblue;
            border-radius: 2px;
            border-width: 0px;
            font-family: 'Century Gothic';
            font-weight: bold;
            color: darkblue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <h1 style="width: 98%" class="HeadingStyle">CloudDrive: Welcome Admin
            <div style="float: right">
                <asp:Image ID="ImageAdminPic" ImageUrl="~/Images/NotificationImages/AdminPic.png" Height="45px" Width="45px" BorderWidth="0" runat="server" />
                <asp:Button ID="btnAdminLogout" Text="Logout" CssClass="LoginButtonStyle" runat="server" OnClick="btnAdminLogout_Click" />                
            </div>
        </h1>
    </div>
        <br>
        <div align="center">
            
            <asp:Button ID="btnCheckNewUsers" CssClass="ButtonStyle" runat="server" Text="Check for new user(s) since last Admin logout" OnClick="btnCheckNewUsers_Click1" />
            <asp:Panel ID="PanelCheckNewUsers" Width="80%" CssClass="BodyStyle" BorderColor="DarkBlue" Font-Size="Small" BorderWidth="2px" Visible="false" runat="server">
                <asp:Label ID="lblUnnoticedUsers" CssClass="BodyStyle" BorderColor="DarkBlue" BorderWidth="1px" runat="server" Text=""></asp:Label>    <br><br>
                
                <asp:GridView ID="GridViewNewUsers" runat="server" Font-Bold="true" Font-Size="Small" BorderColor="DarkGray" BorderWidth="2" CellPadding="4" ForeColor="#333333" GridLines="None" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLinkNewUsers" Target="_blank" runat="server">View user</asp:HyperLink>
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
            </asp:Panel>
            
            <br><br>
            
            <asp:Button ID="btnCheckNewFiles" CssClass="ButtonStyle" runat="server" Text="Check for new file(s) since last Admin logout" OnClick="btnCheckNewFiles_Click" />
            <asp:Panel ID="PanelCheckNewFiles" Width="80%" CssClass="BodyStyle" BorderColor="DarkBlue" BorderWidth="2px" Font-Size="Small" Visible="false" runat="server">
                <asp:Label ID="lblUnnoticedFilesUploaded" CssClass="BodyStyle" BorderColor="DarkBlue" BorderWidth="1px" runat="server" Text=""></asp:Label>    <br><br>
                <asp:GridView ID="GridViewNewFiles" runat="server" Font-Bold="true" Font-Size="Small" BorderColor="DarkGray" BorderWidth="2" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView_RowCommand" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnViewContentNewFiles" OnClientClick = "window.document.forms[0].target='_blank'" CommandName="View" runat="server" Text="View Content"></asp:LinkButton>
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
            </asp:Panel>

            <br><br>

            <asp:Button ID="btnViewUsers" runat="server" CssClass="ButtonStyle" Text="View all registered users" OnClick="btnViewUsers_Click" />
            <asp:Panel ID="PanelRegisteredUser" Width="80%" CssClass="BodyStyle" BorderColor="DarkBlue" BorderWidth="2px" Visible="false" runat="server">
                <asp:Label ID="lblRegisteredUsersNo" CssClass="BodyStyle" BorderColor="DarkBlue" BorderWidth="1px" runat="server" Text=""></asp:Label> <br>
                <div align="left">
                    <asp:PlaceHolder ID="PlaceHolderRegisteredUsers" runat="server"></asp:PlaceHolder> <br><br>
                </div>
            </asp:Panel>

            <br><br>
            <asp:Button ID="btnSearchAllFiles" CssClass="ButtonStyle" runat="server" Text="Search All Files" OnClick="btnSearchAllFiles_Click" />
            <asp:Panel ID="PanelSearchAllFiles" Visible="false" Width="80%" CssClass="BodyStyle" Font-Size="Small" BorderColor="DarkBlue" BorderWidth="2px" Font-Bold="true" runat="server">
                <div align="center">
                    <asp:Label ID="Label5" runat="server" Font-Bold="true" Font-Size="X-Large" Text="Search for all files irrespective of their categories"></asp:Label>
                    <div align="right">
                    <div style="float: left; font-family: 'Agency FB'; font-weight: bolder; font-size: larger;">
                        <h3>
                            <asp:Label ID="Label4" runat="server" Text="Usage:"></asp:Label>
                        </h3>
                    </div>
                    &nbsp;&nbsp;
                    <asp:Panel ID="PanelUsageInfo" runat="server" BackColor="LightGray" BorderColor="DarkGray" BorderWidth="2" CssClass="roundBorders" Height="25px" Width="1000px" HorizontalAlign="Center">
                        <asp:Label ID="lblSpaceUsedInfo" CssClass="lblSpaceUsed" runat="server"></asp:Label>

                        <asp:Label ID="lblUsed" runat="server" BackColor="Violet" CssClass="lblUsed" Height="25px" Width="0px"></asp:Label>
                        <asp:Label ID="lblUnused" runat="server" CssClass="lblUnused" Height="25px" Width="0px"></asp:Label>
                    </asp:Panel>
                </div>
                    <br>
                    <asp:TextBox ID="txtSearch" CssClass="TextBoxStyle" placeholder="  Search Here" Height="32px" Width="250px" Font-Size="Larger" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="btnSearch" ImageAlign="AbsBottom" ImageUrl="~/Styles/Images/SearchButton.png" Height="37px" Width="80px" runat="server" runat="server" Text="Search" OnClick="btnSearch_Click"/>
                    <br>
                    <asp:Label ID="lblDeleteFilesWarning" CssClass="BodyStyle" Font-Size="Large" ForeColor="Red" runat="server"></asp:Label>
                    <br>
                    <asp:Label ID="lblSearchResultNo" CssClass="BodyStyle" BorderColor="LightBlue" BorderWidth="2px" Font-Size="Large" runat="server"></asp:Label>
                    <br>
                    <div>
                        <br>
                        <asp:GridView ID="GridViewUploadedFiles" runat="server" BorderColor="DarkGray" BorderWidth="2" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="true" Font-Size="Small" OnRowCommand="GridView_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnViewContentUploadedFiles" OnClientClick = "window.document.forms[0].target='_blank'" CommandName="View" runat="server" Text="View Content"></asp:LinkButton>
                                <asp:CheckBox ID="chkRow" runat="server" />
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
                <asp:CheckBox ID="CheckBoxSelectAll" runat="server" AutoPostBack="true" BorderWidth="0px" CssClass="BodyStyle" Text="Select All" OnCheckedChanged="CheckBoxSelectAll_CheckedChanged" />
                <br>
                <asp:Button ID="ButtonDeleteFile" runat="server" CssClass="ButtonStyle" Text="Delete File(s)" OnClick="ButtonDeleteFile_Click" />
                        <br>
                    </div>
                 </div>
            </asp:Panel>
            <br><br>
            <asp:Button ID="btnShowAdminChangeCredentialsPanel" runat="server" CssClass="ButtonStyle" Text="Change present Admin credentials" OnClick="btnShowAdminChangeCredentialsPanel_Click" /><br>
            <asp:Panel ID="PanelUpdateAdminInfo" Width="80%" CssClass="BodyStyle" BorderColor="DarkBlue" BorderWidth="2px" Visible="false" runat="server">
                <div class="BodyStyle">
                <h2><asp:Label ID="Label1" runat="server" Text="Change present Admin credentials"></asp:Label></h2>
                    <asp:Label ID="Label2" CssClass="lblStyle" Font-Size="Larger" runat="server" Text="Username:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtAdminUsername" placeholder="Admin Username" CssClass="TextBoxStyle" Height="30px" Width="200px" Font-Size="Larger" runat="server"></asp:TextBox><br>
                    <asp:Label ID="Label3" CssClass="lblStyle" Font-Size="Larger" runat="server" Text="Password:"></asp:Label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtAdminPassword" placeholder="Admin Password" CssClass="TextBoxStyle" Height="30px" Width="200px" Font-Size="Larger" runat="server"></asp:TextBox><br>
                <asp:Button ID="btnChangeAdminCredentials" runat="server" Text="Commit Changes" CssClass="ButtonStyle" OnClick="btnChangeAdminCredentials_Click" />
                    <br />
                    <br />
                <asp:Label ID="lblConfirmAdminCredentialsChange" CssClass="BodyStyle" runat="server"></asp:Label><br>
            </div>
            </asp:Panel>
            <br><br><br>
            <a href="Homepage.aspx?s=1" class="HyperlinkStyle"><img src="Styles/Images/Navigation Buttons/GoBack.png" height="40px" width="40px"/>&nbsp;&nbsp; Go back to homepage</a>
        </div>
    </form>
</body>
</html>
