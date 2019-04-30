<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellerManageBooth.aspx.cs" Inherits="MarketStory.Market.SellerManageBooth" %>

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
                    <td colspan="2" align="center">
                        <asp:Label ID="Label29" runat="server" Text="Manage booth!" Font-Names="Calibri" Font-Bold="true" Font-Size="Small"></asp:Label>
                        <br />
                    </td>
                </tr>
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
                                    <asp:Image ID="Image19" runat="server" ImageUrl="~/Images/repPointsIconSelected.PNG" Width="20px" />
                                    <br />
                                    <br />
                                    <asp:Label ID="Label3" runat="server" Text="Seller boothname" Font-Names="Calibri"></asp:Label>
                                    <asp:ImageButton ID="ImageButton9" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/EditField.jpg" Visible="False" OnClick="ImageButton9_Click" />
                                    <br />
                                    <br />
                                    <asp:Button ID="Button1" runat="server" Text="Exit from booth" Font-Names="Calibri" OnClick="Button1_Click"/>
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
                                                <table>
                                                    <tr>
                                                        <td width="50%" align="left">
                                                            <asp:Image ID="Image18" runat="server" Height="87px" Width="96px" Visible="False" />
                                                        </td>
                                                        <td width="50%">
                                                            <table>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label4" runat="server" Text="Product 1" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label5" runat="server" Text="Price" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label6" runat="server" Text="Quantity left" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/EditField.jpg" OnClick="ImageButton1_Click" Visible="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="50%">
                                                <table>
                                                    <tr>
                                                        <td width="50%" align="left">
                                                            <asp:Image ID="Image2" runat="server" Height="87px" Width="96px" Visible="False" />
                                                        </td>
                                                        <td width="50%">
                                                            <table>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label7" runat="server" Text="Product 1" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label8" runat="server" Text="Price" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label9" runat="server" Text="Quantity left" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:ImageButton ID="ImageButton2" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/EditField.jpg" OnClick="ImageButton2_Click" Visible="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr width="100%">
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td width="50%" align="left">
                                                            <asp:Image ID="Image3" runat="server" Height="87px" Width="96px" Visible="False" />
                                                        </td>
                                                        <td width="50%">
                                                            <table>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label10" runat="server" Text="Product 1" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label11" runat="server" Text="Price" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label12" runat="server" Text="Quantity left" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:ImageButton ID="ImageButton3" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/EditField.jpg" OnClick="ImageButton3_Click" Visible="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td width="50%" align="left">
                                                            <asp:Image ID="Image4" runat="server" Height="87px" Width="96px" Visible="False" />
                                                        </td>
                                                        <td width="50%">
                                                            <table>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label13" runat="server" Text="Product 1" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label14" runat="server" Text="Price" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label15" runat="server" Text="Quantity left" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:ImageButton ID="ImageButton4" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/EditField.jpg" OnClick="ImageButton4_Click" Visible="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr width="100%">
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td width="50%" align="left">
                                                            <asp:Image ID="Image5" runat="server" Height="87px" Width="96px" Visible="False" />
                                                        </td>
                                                        <td width="50%">
                                                            <table>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label16" runat="server" Text="Product 1" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label17" runat="server" Text="Price" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label18" runat="server" Text="Quantity left" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:ImageButton ID="ImageButton5" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/EditField.jpg" OnClick="ImageButton5_Click" Visible="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td width="50%" align="left">
                                                            <asp:Image ID="Image6" runat="server" Height="87px" Width="96px" Visible="False" />
                                                        </td>
                                                        <td width="50%">
                                                            <table>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label19" runat="server" Text="Product 1" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label20" runat="server" Text="Price" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label21" runat="server" Text="Quantity left" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:ImageButton ID="ImageButton6" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/EditField.jpg" OnClick="ImageButton6_Click" Visible="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr width="100%">
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td width="50%" align="left">
                                                            <asp:Image ID="Image7" runat="server" Height="87px" Width="96px" Visible="False" />
                                                        </td>
                                                        <td width="50%">
                                                            <table>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label22" runat="server" Text="Product 1" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label23" runat="server" Text="Price" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label24" runat="server" Text="Quantity left" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:ImageButton ID="ImageButton7" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/EditField.jpg" OnClick="ImageButton7_Click" Visible="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td width="50%" align="left">
                                                            <asp:Image ID="Image8" runat="server" Height="87px" Width="96px" Visible="False" />
                                                        </td>
                                                        <td width="50%">
                                                            <table>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label25" runat="server" Text="Product 1" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label26" runat="server" Text="Price" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label27" runat="server" Text="Quantity left" Font-Names="Calibri" Visible="False"></asp:Label>
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:ImageButton ID="ImageButton8" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/EditField.jpg" OnClick="ImageButton8_Click" Visible="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
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
