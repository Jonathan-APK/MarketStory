<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductInf.aspx.cs" Inherits="MarketStory.Market.ProductInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%;" align="center">

            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="500" Width="650" BackImageUrl="~/Images/Market/BoothBG.png" Visible="true" Style="top: 20%;">
                <table width="100%">

                    <tr>
                        <td width="30%">
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <asp:Image ID="Image1" runat="server" Height="126px" Width="132px" />
                                        <br />
                                        <br />
                                        <asp:Label ID="Label2" runat="server" Text="Seller username" Font-Names="Calibri"></asp:Label>
                                        <br />
                                        <br />
                                        <asp:Label ID="Label1" runat="server" Text="Seller reppoints" Font-Names="Calibri"></asp:Label>
                                        <br />
                                        <br />
                                        <asp:Label ID="Label3" runat="server" Text="Seller boothname" Font-Names="Calibri"></asp:Label>
                                        <br />
                                        <br />
                                        <asp:Button ID="Button3" runat="server" Text="View profile" Width="127px" Font-Names="Calibri" OnClick="Button3_Click" />
                                        <br />
                                        <br />
                                        <asp:Button ID="Button2" runat="server" Text="View product" Width="127px" Font-Names="Calibri" OnClick="Button2_Click" />
                                        <br />
                                        <br />
                                        <asp:Button ID="Button1" runat="server" Text="Exit from booth" Font-Names="Calibri" OnClick="Button1_Click" />
                                        <br />
                                        <br />
                                        <br />

                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="70%">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr width="100%">
                                                <td width="50%">
                                                    <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Text="Product Name:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr width="100%">
                                                <td width="50%">
                                                    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Text="Price: "></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr width="100%">
                                                <td width="50%">
                                                    <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Text="Available Quantity: "></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label6" runat="server" Font-Names="Calibri" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr width="100%">
                                                <td width="50%">
                                                    <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Text="Information: "></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Height="30px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <asp:Button ID="Button4" runat="server" Font-Names="Calibri" OnClick="Button4_Click" Text="Read Reviews" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>

