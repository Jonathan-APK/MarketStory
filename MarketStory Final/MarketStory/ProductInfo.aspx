<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductInfo.aspx.cs" Inherits="MarketStory.ProductInfo" %>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <style>
        #div1 {
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: 1px dashed;
            background-color: lightcyan;
            width: 95%;
        }

        #div2 {
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: 1px dashed;
            background-color: #CCEBEB;
            width: 95%;
        }
    </style>
    <br />
    <div style="width: 100%;" align="center">
        <table width="70%">
            <tr>
                <td width="5%"></td>
                <td width="90%">
                    <asp:Label ID="Header" runat="server" Text="Product Information" Font-Names="Calibri" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:Image ID="Image1" runat="server" ImageAlign="Top" ImageUrl="~/Images/dividerLine.PNG" Width="100%" align="left" />
                    <br />
                    <br />
                    <br />
                    <table align="center">
                        <tr>
                            <td width="30%" style="vertical-align: top">
                                <asp:Image ID="productPhoto" runat="server" Width="100" Height="100"/>
                            </td>

                            <td width="70%" style="vertical-align: bottom">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="productName" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Product: "></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                        <td>
                                            <asp:Label ID="displayName" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Underline ="True"></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="productPrice" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Price: "></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                        <td>
                                            <asp:Label ID="displayPrice" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Underline ="True"></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="boothName" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Belongs to Booth: "></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                        <td>
                                            <asp:Label ID="displayBoothName" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Underline ="True"></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top">
                                            <asp:Label ID="productInformation" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Description/Details: "></asp:Label>
                                            <br />
                                            <br />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="displayInformation" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Underline ="True" TextMode="MultiLine" Enabled="False" Wrap="true" ReadOnly="True" BorderStyle="None" BorderWidth="0" Font-Size="Medium" style="resize: none"></asp:TextBox>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <div id ="div2">
                                &emsp;<asp:Label ID="productReviews" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Reviews: "></asp:Label>
                                <br />
                                <br />
                                <div id ="div1">
                                <asp:Table ID="displayReviews" runat="server">

                                </asp:Table>
                                </div><br /></div>
                            </td>
                        </tr> 
                    </table>
                </td>
                <td width="5%"></td>
            </tr>
        </table>
    </div>
</asp:Content>