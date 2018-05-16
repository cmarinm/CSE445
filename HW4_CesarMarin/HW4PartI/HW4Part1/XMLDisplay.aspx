<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMLDisplay.aspx.cs" Inherits="HW4Part1.XMLDisplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            XML Display</div>
        <p>
            Enter XML URL:</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server">Hotels.xml</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" BackColor="#33CC33" ForeColor="White" OnClick="Button1_Click" Text="Display" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Names="Arial" Font-Size="Small" ForeColor="Black" Text="output"></asp:Label>
        </p>
    </form>
</body>
</html>
