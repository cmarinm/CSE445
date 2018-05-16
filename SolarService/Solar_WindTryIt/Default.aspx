<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Solar_WindTryIt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Solar Service &amp; Wind Service TryIt</h1>
        <p>This one service will serve as a tryIt page for both an annual average solar iradiance index service, and an annual average wind speed at 50m service.</p>
        <p>Enter a Latitude (integer from -90 to 89)</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server">40</asp:TextBox>
        </p>
        <p>Enter a Longitude (integer from -180 to 179)</p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server">-105</asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" BackColor="#009900" ForeColor="Black" OnClick="Button1_Click" Text="TryIt!" />
        </p>
        <p>Solar Index:</p>
        <p>
            <asp:Label ID="Label2" runat="server" Font-Italic="True" Text="Label"></asp:Label>
        </p>
        <p>Wind Index:</p>
        <p>
            <asp:Label ID="Label1" runat="server" Font-Italic="True" Text="Label"></asp:Label>
        </p>
    </div>

</asp:Content>
