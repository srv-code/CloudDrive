<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestPage.aspx.cs" Inherits="TestPage" ValidateRequest="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>     
</head>
<body>
    <form id="form1" runat="server" >
        <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>
        <div align="center">
            Enter name: <asp:TextBox ID="txtName" runat="server" Height="16px" Width="73px" style="margin-left: 0px" ></asp:TextBox>
            <ajax:AutoCompleteExtender 
                ID="ac1" runat="server" 
                CompletionInterval="1"
                EnableCaching="true"
                CompletionListCssClass="" CompletionListItemCssClass="" CompletionListHighlightedItemCssClass=""
                TargetControlID="txtName" 
                ServiceMethod="getDBFilesSuggestionList"  
                ServicePath="WebService.asmx" 
                MinimumPrefixLength="1">
            </ajax:AutoCompleteExtender>
            &nbsp;<asp:Button ID="Button2" runat="server" Text="Search" OnClick="Button2_Click" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br>
            <asp:TextBox ID="TextBox1" TextMode="MultiLine" runat="server" Height="124px" Width="913px"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>        
        
    </form>
</body>
</html>
