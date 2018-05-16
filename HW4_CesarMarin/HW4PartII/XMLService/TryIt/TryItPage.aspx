<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItPage.aspx.cs" Inherits="TryIt.TryItPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Text="XML Verification &amp; XPath Query TryIt"></asp:Label>
        </div>
        <p>
            XML Document URL:</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Width="266px">Hotels.xml</asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            Schema XSD Document URL:</p>
        <p>
&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server" Width="232px">Hotels.xsd</asp:TextBox>
&nbsp;
            <asp:Button ID="Button3" runat="server" BackColor="#009900" ForeColor="White" OnClick="Button3_Click" Text="Verify with Schema" Width="176px" />
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="output"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            XPath Query String:</p>
        <p>
            <asp:TextBox ID="TextBox3" runat="server" Width="245px">/Hotels/Hotel</asp:TextBox>
&nbsp;
            <asp:Button ID="Button2" runat="server" BackColor="#009900" ForeColor="White" OnClick="Button2_Click" Text="Query XML" Width="145px" />
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="output"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
