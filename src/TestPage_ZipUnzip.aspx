<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestPage_ZipUnzip.aspx.cs" Inherits="TestPage_ZipUnzip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 align="center">
            TestPage_ZipUnzip.aspx
        </h1>

        <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnTest" runat="server" Text="Test Button" OnClick="btnTest_Click" />
        <br />
        <br>

        <asp:Panel ID="Panel1" BorderColor="Black" BorderWidth="2" runat="server">
            <br>
            <asp:Button ID="btnGridViewUploadedFiles" runat="server" Text="Load Gridview" OnClick="btnGridViewUploadedFiles_Click" />
            <br>
            <br>
            <asp:DropDownList ID="DropDownListUploadMode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListUploadMode_SelectedIndexChanged">
                <%--<asp:ListItem>Choose an upload mode</asp:ListItem>--%>
                <asp:ListItem>General Mode</asp:ListItem>
                <%--<asp:ListItem>Secure Archive Mode</asp:ListItem>--%>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownListSearchCategory" runat="server">
                <%--<asp:ListItem>Choose a category</asp:ListItem>--%>
                <asp:ListItem>Image</asp:ListItem>
                <%--<asp:ListItem>Video</asp:ListItem>
                <asp:ListItem>Music</asp:ListItem>
                <asp:ListItem>Document</asp:ListItem>
                <asp:ListItem>Executable</asp:ListItem>--%>
            </asp:DropDownList>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnUploadFile" runat="server" OnClick="btnUploadFile_Click" Text="Upload File" />
            <br>
            <br>
            <asp:Label ID="lblFileDeletion" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblUploadStatus" runat="server" ></asp:Label>
            <br>
            <br>
            <asp:GridView ID="GridViewUploadedFiles" runat="server" OnRowCommand="GridViewUploadedFiles_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="View/Download">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnViewContent" OnClientClick = "window.document.forms[0].target='_blank'" CommandName="View" runat="server" Text="View"></asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnDownloadContent" CommandName="Download" runat="server" Text="Download"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br>
        </asp:Panel>
        
    &nbsp;</div>
    </form>
</body>
</html>
