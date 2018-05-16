<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LoginApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://webstrar11.fulton.asu.edu/Page0/">Back to Main</asp:HyperLink>
            <br />
            Account Create TryIt</div>
        <p>
            Username:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            Password:
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <p>
            First Name:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            Last Name:
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </p>
        <p>
            Email:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </p>
        <p>
            Phone:
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        </p>
        <p>
            Age:
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        </p>
        <p>
            Bday(xx-xx-xx):
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click" Text="Create Account!" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Names="Arial" Text="result"></asp:Label>
        </p>
        <p>
            Account Log-in TryIt</p>
        <p>
            username</p>
        <p>
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
        </p>
        <p>
            password</p>
        <p>
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" Font-Bold="True" OnClick="Button2_Click" Text="Log In" />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="result"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            F to C, C to F service for baking TryIt:</p>
        <p>
            F:<asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="to C" />
        </p>
        <p>
            C:
            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="to F" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            Wind + Solar Services TryIt</p>
        <p>
            enter a latitude (integer from -90 to 89)</p>
        <p>
            <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
        </p>
        <p>
            enter a longitude (integer from -180 to 179)</p>
        <p>
            <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Go!" />
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Solar Result"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Wind Result"></asp:Label>
        </p>
    </form>
</body>
</html>
