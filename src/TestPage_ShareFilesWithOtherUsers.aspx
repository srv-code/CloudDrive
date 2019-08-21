<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestPage_ShareFilesWithOtherUsers.aspx.cs" Inherits="TestPage_ShareFilesWithOtherUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .WarningStyle {
            color: red;
        }
        .ShareMessageStyle {
            color: blue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <h1>TestPage_ShareFilesWithOtherUsers.aspx</h1>
        <br> <asp:TextBox ID="TextBox1" TextMode="MultiLine" runat="server" Height="131px" Width="283px"></asp:TextBox>
        <br><asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
