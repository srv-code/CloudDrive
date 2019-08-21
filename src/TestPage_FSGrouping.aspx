<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestPage_FSGrouping.aspx.cs" Inherits="TestPage_FSGrouping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnCreateNewGroup" runat="server" Text="Create A New Group" OnClick="btnCreateNewGroup_Click1" />
        <br>
        <asp:Panel ID="PanelCreateNewGroup" Visible="false" BorderColor="DarkBlue" BorderWidth="5" runat="server">
            <asp:TextBox ID="txtSearchUser" placeholder="Enter the name of the user to search" runat="server" Width="290px"></asp:TextBox>
            <asp:Button ID="btnSearchUser" runat="server" Text="Search User" OnClick="btnSearchUser_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Load GridViewAddedUsers" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Check Session variables" />
            <br />
            <br />
            <asp:Label ID="lblSearchUserErrorMessage" runat="server"></asp:Label>
            <br />
            <asp:GridView ID="GridViewSearchedUsers" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridViewSearchedUsers_RowCommand" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnUserProPic" Height="35" Width="35" runat="server" />
                            <asp:Button ID="btnAddUser" Height="35" Width="70" runat="server" Text="Add User" CommandName="AddUserInNewGroup"  />
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
            <br />
            <br />
            <br />
            <asp:Label ID="lblUsersAddedCounter" runat="server" ></asp:Label>
            <br />
            <asp:GridView ID="GridViewAddedUsers" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"  OnRowCommand="GridViewAddedUsers_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnUserProPic0" runat="server" Height="35" Width="35" />
                            <asp:Button ID="btnRemoveUser" runat="server" Height="35" Text="Remove User" CommandName="RemoveUserFromNewGroup" Width="95" />
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
            <br /> 
            
        </asp:Panel>
    </div>
        <p>
            &nbsp;</p>
        <asp:Button ID="btnUserSignOut" runat="server" Text="User Sign Out" OnClick="btnUserSignOut_Click" />
    </form>
</body>
</html>
