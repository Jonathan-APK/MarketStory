<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditBoothName.aspx.cs" Inherits="MarketStory.Market.EditBoothName" %>

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
            <asp:Panel ID="Panel1" runat="server" Height="142px" Width="650px" Visible="true" Style="top: 20%;">
                <table width="100%">
                    <tr>
                        <td width="70%">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr width="100%">
                                                <td width="50%">
                                                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Text="New Booth Name: "></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBox1" runat="server" Font-Names="Calibri"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Confirm" Font-Names="Calibri" OnClick="Button1_Click" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
