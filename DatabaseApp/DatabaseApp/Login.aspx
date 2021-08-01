<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DatabaseApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="margin: auto; border: 5px solid white">
                <tr>
                    <td style="text-align: right;">
                        <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <asp:Label ID="Label2" runat="server" Text="Hasło"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Zaloguj się" OnClick="btnLogin_Click"></asp:Button>
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
                        <asp:Label ID="errLabelMessage" runat="server" Text="Nieprawidłowe dane" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSortAZ" runat="server" OnClick="btnSortAZ_Click" Text="A-Z" />
                        <asp:Button ID="btnSortZA" runat="server" OnClick="btnSortZA_Click" Text="Z-A" />
                        <asp:Button ID="btnSortPriceAsc" runat="server" OnClick="btnSortPriceAsc_Click" Text="Cena rosnąco" />
                        <asp:Button ID="btnSortPriceDesc" runat="server" OnClick="btnSortPriceDesc_Click" Text="Cena malejąco" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Cena brutto:
                        więcej niż
                    </td>
                    <td>
                        <asp:TextBox ID="Cena1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">mniej niż</td>
                    <td>
                        <asp:TextBox ID="Cena2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <asp:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click" Text="Filtruj" />
                        </td>
                    <td>
                <asp:Label ID="errInput" runat="server" Text="Nieprawidłowe dane" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>                   
                    <td colspan="2">
                        <asp:GridView ID="dgv1" runat="server" HorizontalAlign="Center" ShowHeaderWhenEmpty="true">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
