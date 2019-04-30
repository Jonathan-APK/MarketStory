<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopUpLogPage.aspx.cs" Inherits="MarketStory.TopUpLogPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Text="Users Top-up History" Font-Bold="True" Font-Size="Larger"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Table ID="Table1" runat="server">
                <asp:TableHeaderRow ID="Table1HeaderRow">
                    <asp:TableHeaderCell>Top-up history log</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
