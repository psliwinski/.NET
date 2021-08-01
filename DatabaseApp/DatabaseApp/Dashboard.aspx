<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DatabaseApp.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUserDetails" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnLogout" runat="server" Text="Wyloguj się" OnClick="btnLogout_Click"></asp:Button>
        </div>
    </form>
</body>
</html>
