<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectStats.aspx.cs"  Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <h1>Project Statistics</h1>
        <asp:Label ID="lblPasswordErrorMessage" runat="server"></asp:Label>
        <br>
        <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="Password to get started" runat="server" Width="224px"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <br />
        
        <br />
        <br />
        <asp:Panel ID="PanelStatistics" Width="90%" Visible="false" BackColor="LightBlue" runat="server">
            <div align="left">
                <asp:Label ID="lblPageHits" runat="server"></asp:Label> <br>
                <br>
                <asp:Button ID="btnResetPageHitCounter" runat="server" Text="Reset Page Hit Counter" OnClick="btnResetPageHitCounter_Click" />
                &nbsp;&nbsp;
                <asp:Label ID="lblResetPageHitCounterMessage" runat="server"></asp:Label>
                <br>
                <asp:Button ID="btnFetchAllData" runat="server" OnClick="btnFetchAllData_Click" Text="Fetch All Data" />
                &nbsp;&nbsp;
                <asp:Button ID="btnTest" runat="server" OnClick="btnTest_Click" Text="Test Button" />
                <br>
                <asp:TextBox ID="txtAllDataFetched" runat="server" Height="16px" ReadOnly="true" TextMode="MultiLine" Width="264px"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtOldPassword" runat="server" placeholder="Old password" TextMode="Password"></asp:TextBox>
                <asp:TextBox ID="txtNewPassword1" runat="server" placeholder="New password" TextMode="Password"></asp:TextBox>
                <asp:TextBox ID="txtNewPassword2" runat="server" placeholder="New password again" TextMode="Password"></asp:TextBox>
                <asp:Button ID="btnChangePassword" runat="server" OnClick="btnChangePassword_Click" Text="Change Password" />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblPasswordChangeErrorMessage" runat="server"></asp:Label>
                <br>
                
            </div>            
        </asp:Panel>
    </div>
    </form>
</body>
</html>
