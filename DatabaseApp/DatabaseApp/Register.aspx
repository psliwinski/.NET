<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DatabaseApp.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfUserID" runat="server" />
            <table style="margin: auto; border: 5px solid white">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Hasło"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                      <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Potwierdź hasło"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtProove" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnRegister" runat="server" Text="Zarejestruj się" OnClick="btnRegister_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnBack" runat="server" Text="Powróć do logowania" OnClick="btnBack_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="scsLabelMessage" runat="server" Text="Rejestracja przebiegła pomyślnie" ForeColor="Green"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="errLabelMessage" runat="server" Text="Podany użytkownik już istnieje" ForeColor="Red"></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
