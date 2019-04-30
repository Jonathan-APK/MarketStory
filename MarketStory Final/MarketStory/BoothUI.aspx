<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BoothUI.aspx.cs" Inherits="MarketStory.Market.Market" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div style="width: 100%;" align="center">
        <asp:Panel ID="Panel1" runat="server" Height="500" Width="650" BackImageUrl="~/Images/Market/BoothBG.png" Visible="true">
            <table width="100%">
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="Label29" runat="server" Text="Click on the product's image to view more information!" Font-Names="Calibri" Font-Bold="true" Font-Size="Small"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td width="25%">
                        <table width="100%">
                            <tr>
                                <td align="center">
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Image ID="Image1" runat="server" Height="126px" Width="132px" />
                                    <br />
                                    <br />
                                    <asp:Label ID="Label2" runat="server" Text="Seller username" Font-Names="Calibri"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="0" Font-Names="Calibri"></asp:Label>
                                    <asp:Image ID="Image19" runat="server" ImageUrl="~/Images/repPointsIconSelected.PNG" Width="20px"/>
                                    <br />
                                    <br />
                                    <asp:Label ID="Label3" runat="server" Text="Seller boothname" Font-Names="Calibri"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Button ID="Button2" runat="server" Text="View profile" Width="110px" Font-Names="Calibri" OnClick="Button2_Click"/>
                                    <br />
                                    <br />
                                    <asp:Button ID="Button1" runat="server" Text="Exit from booth" Font-Names="Calibri" OnClick="Button1_Click" Width="110px"/>
                                    <br />
                                    <br />
                                    <br />

                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="75%">
                        <table width="100%">
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr width="100%">
                                            <td width="50%">
                                                <table>
                                                    <tr>
                                                        <td width="100px">
                                                            <asp:ImageButton ID="ImageButton9" runat="server" Height="87px" Width="96px" Visible="False" OnClick="ImageButton9_Click"/>
                                                        </td>
                                                        <td width="100px">
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
                                                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/addCart.jpg" Visible="False" OnClick="ImageButton1_Click" />
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
                                                        <td width="100px">
                                                            <asp:ImageButton ID="ImageButton13" runat="server" Height="87px" Width="96px" Visible="False" OnClick="ImageButton13_Click" />
                                                        </td>
                                                        <td width="100px">
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
                                                                        <asp:ImageButton ID="ImageButton2" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/addCart.jpg" Visible="False" OnClick="ImageButton2_Click" />
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
                                                        <td width="100px">
                                                            <asp:ImageButton ID="ImageButton10" runat="server" Height="87px" Width="96px" Visible="False" OnClick="ImageButton10_Click" />
                                                        </td>
                                                        <td width="100px">
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
                                                                        <asp:ImageButton ID="ImageButton3" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/addCart.jpg" Visible="False" OnClick="ImageButton3_Click" />
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
                                                        <td width="100px">
                                                            <asp:ImageButton ID="ImageButton14" runat="server" Height="87px" Width="96px" Visible="False" OnClick="ImageButton14_Click" />
                                                        </td>
                                                        <td width="100px">
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
                                                                        <asp:ImageButton ID="ImageButton4" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/addCart.jpg" Visible="False" OnClick="ImageButton4_Click" />
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
                                                        <td width="100px">
                                                            <asp:ImageButton ID="ImageButton11" runat="server" Height="87px" Width="96px" Visible="False" OnClick="ImageButton11_Click" />
                                                        </td>
                                                        <td width="100px">
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
                                                                        <asp:ImageButton ID="ImageButton5" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/addCart.jpg" Visible="False" OnClick="ImageButton5_Click" />
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
                                                        <td width="100px">
                                                            <asp:ImageButton ID="ImageButton15" runat="server" Height="87px" Width="96px" Visible="False" OnClick="ImageButton15_Click" />
                                                        </td>
                                                        <td width="100px">
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
                                                                        <asp:ImageButton ID="ImageButton6" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/addCart.jpg" Visible="False" OnClick="ImageButton6_Click" />
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
                                                        <td width="100px">
                                                            <asp:ImageButton ID="ImageButton12" runat="server" Height="87px" Width="96px" Visible="False" OnClick="ImageButton12_Click" />
                                                        </td>
                                                        <td width="100px">
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
                                                                        <asp:ImageButton ID="ImageButton7" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/addCart.jpg" Visible="False" OnClick="ImageButton7_Click" />
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
                                                        <td width="100px">
                                                            <asp:ImageButton ID="ImageButton16" runat="server" Height="87px" Width="96px" Visible="False" OnClick="ImageButton16_Click" />
                                                        </td>
                                                        <td width="100px">
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
                                                                        <asp:ImageButton ID="ImageButton8" runat="server" Height="28px" Width="31px" ImageUrl="~/Images/Market/addCart.jpg" Visible="False" OnClick="ImageButton8_Click" />
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
