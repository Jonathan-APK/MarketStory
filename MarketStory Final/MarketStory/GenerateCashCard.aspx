<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateCashCard.aspx.cs" Inherits="MarketStory.GenerateCashCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Text="Number of MSCashCards to generate:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Quantity cannot be empty" Font-Names="Calibri" ControlToValidate="TextBox1" ValidationGroup="quantityInvalid"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;
            <br />
            <asp:Button ID="Button1" runat="server" Font-Names="Calibri" Text="Generate" OnClick="Button1_Click" ValidationGroup="quantityInvalid"/>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Text="Cash value: S$"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
                <asp:ListItem>100</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Export to desktop" OnClick="Button2_Click" Font-Names="Calibri" />
            <br />
            <br />
            <asp:Table ID="Table1" runat="server">
                <asp:TableHeaderRow ID="Table1HeaderRow">
                    <asp:TableHeaderCell>Count</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Serial Number</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Security Code</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
