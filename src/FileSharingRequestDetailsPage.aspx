<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileSharingRequestDetailsPage.aspx.cs" Inherits="FileSharingRequestDetailsPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CloudDrive: View your file sharing requests</title>
    <link rel="icon" type="image/png" href="Styles/Images/SiteLogo.png"/>
    <link rel="stylesheet" href="~/Styles/Global_Styles.css" type="text/css" />
    <style>
        .BorderRadiusStyle
        {
            background-color: white; opacity: 1.0; border-radius: 5px;
        }
        .ModalBackgroundStyle__TEST {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div align="center">
        
        <br>
            <asp:Label ID="lblHeading" CssClass="HeadingStyle" Width="98%" Font-Size="XX-Large" runat="server" Text="CloudDrive: File Sharing Requests of "></asp:Label>
    <br>
            <br />
            <br>
            <asp:Label ID="lblFileSharedMessage" CssClass="BodyStyle" runat="server"></asp:Label>
            <br>
            <br />
                <asp:GridView ID="GridViewSharedFilesDetails" BorderColor="DarkGray" BorderWidth="2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Bold="true" Font-Size="Small" Font-Names="Century Gothic" OnRowCommand="GridViewSharedFilesDetails_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRow" runat="server" />
                                <asp:LinkButton ID="lnkbtnViewContent" OnClientClick = "window.document.forms[0].target='_blank'" CommandName="View" runat="server" Text="View"></asp:LinkButton>
                                <asp:LinkButton ID="lnkbtnDownloadContent" CommandName="Download" runat="server" Text="Download"></asp:LinkButton>
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
            <!--For testing purpose-->
            <!-- <br> <asp:Button ID="btnTest" runat="server" Text="Test Button" OnClick="btnTest_Click" /> -->
            <!--For testing purpose-->
                <br><br>
            <asp:Button ID="btnAddFiles" runat="server" CssClass="ButtonStyle" Text="Add file(s)" OnClick="btnAddFiles_Click" />   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnRejectFiles" runat="server" CssClass="ButtonStyle" Text="Reject File(s)" OnClick="btnRejectFiles_Click" />
            <br>
            <div align="center">
                <asp:ModalPopupExtender ID="ModalPopupExtenderShareFilesConfirmation" PopupControlID="PanelShareFilesConfirmation"
				DropShadow="true" TargetControlID="btnAddFiles" Enabled="True" CancelControlID="btnShareNo"
				BackgroundCssClass="ModalBackgroundStyle__TEST" runat="server"></asp:ModalPopupExtender>

            <asp:Panel ID="PanelShareFilesConfirmation" Height="130px" Width="500px" Visible="False"
                 BorderWidth="2" BorderColor="LightBlue" runat="server" CssClass="BorderRadiusStyle" >
                <center><asp:Label ID="lblShareFilesConfirmation" Font-Size="Large" CssClass="HeadingStyle" Width="470px" runat="server"></asp:Label></center>
                <div align="center">
                    <br><asp:Button ID="btnShareYes" CssClass="ButtonStyle" Width="100px" Height="40px" runat="server" Text="Yes" OnClick="btnShareYes_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnShareNo" CssClass="ButtonStyle" Width="100px" Height="40px" runat="server" Text="No" OnClick="btnShareNo_Click" />    
                    </div>   
            </asp:Panel>            
            </asp:Panel>
        </div>
            <br><br><br><br>
            <a href="Homepage.aspx?s=1" class="HyperlinkStyle"><img src="Styles/Images/Navigation Buttons/GoBack.png" height="40px" width="40px"/>&nbsp;&nbsp; Go back to homepage</a>
            <br />
        <asp:LinkButton ID="linkGoBackToCustomerPage" CssClass="HyperlinkStyle" runat="server" OnClick="linkGoBackToCustomerPage_Click"><img src="Styles/Images/Navigation Buttons/GoBack.png" height="40px" width="40px"/>&nbsp;&nbsp; Go back to your account</asp:LinkButton>
        <br>
        
    </div>
    </form>
</body>
</html>
