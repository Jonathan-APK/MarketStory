<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="MarketStory.Market.AddToCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div style="width: 100%;" align="center">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="200" Width="650" Visible="true" Style="top: 20%;">
                <table width="100%">
                    <tr>
                        <td width="70%">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr width="100%">
                                                <td width="50%">Product name:</td>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr width="100%">
                                                <td width="50%">Product price:</td>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr width="100%">
                                                <td width="50%">Available quantity:</td>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <!--get buyer to input quantity of purchase-->
                                            <tr width="100%">
                                                <td width="50%">Quantity of purchase:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="5" Width="50px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button1" runat="server" Text="Confirm" Font-Names="Calibri" OnClick="Button1_Click" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
