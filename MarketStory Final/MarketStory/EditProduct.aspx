<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="MarketStory.Market.EditProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div style="width: 100%;" align="center">
            <script type="text/javascript">
                function confirmUpdate() {
                    if (confirm('Confirm product update?') == true) {
                        document.getElementById("<%= HiddenField1.ClientID %>").value = "Yes";
                    }
                    else {
                        document.getElementById("<%= HiddenField1.ClientID %>").value = "No";
                    }
                }
            </script>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:Panel ID="Panel1" runat="server" Height="240px" Width="768px" Visible="true" Style="top: 20%;">
                <table width="100%">
                    <tr>
                        <td width="70%">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr width="100%">
                                                <td width="35%" style="vertical-align:top">
                                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Product photo:"></asp:Label>
                                                    <br />
                                                    <br />
                                                </td>
                                                <td align="left" style="vertical-align:bottom">
                                                    &nbsp;&nbsp;
                                                    <asp:FileUpload ID="fileuploadimages" runat="server" Width="300px" />
                                                    <br />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr width="100%">
                                                <td width="35%" style="vertical-align:top">
                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Product name: "></asp:Label>
                                                    <br />
                                                </td>
                                                <td align="left" style="vertical-align:bottom">
                                                    &nbsp;
                                                    <asp:TextBox ID="TextBox1" runat="server" style="margin-right: 0px" MaxLength="15"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Product name cannot be empty" Font-Names="Calibri" ForeColor="red" ControlToValidate="TextBox1" ValidationGroup="editProduct"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr width="100%">
                                                <td width="35%" style="vertical-align:top">
                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Price: "></asp:Label>
                                                    <br />
                                                </td>
                                                <td align="left" style="vertical-align:bottom">
                                                    &nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Font-Names="Calibri" Text="$"></asp:Label>
                                                    <asp:TextBox ID="TextBox2" runat="server" Width="40px"></asp:TextBox>
                                                    <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Text="/Item"></asp:Label>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Product price cannot be empty!" Font-Names="Calibri" ForeColor="red" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                                                    &nbsp;
                                                    <br />
                                                    &nbsp;
                                                    <asp:RegularExpressionValidator id="RegularExpressionValidator1" ControlToValidate="TextBox2" ValidationExpression="(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?$" Display="Static" ValidationGroup="editProduct" EnableClientScript="true" ErrorMessage="* Please enter whole numbers only" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="Red"/>
                                                </td>
                                            </tr>
                                            <tr width="100%">
                                                <td width="35%" style="vertical-align:top">
                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Available Quantity:"></asp:Label>
                                                    <br />
                                                </td>
                                                <td align="left" style="vertical-align:bottom">
                                                    &nbsp;&nbsp;
                                                    <asp:TextBox ID="TextBox3" runat="server" Width="50px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Product quantity cannot be empty!" Font-Names="Calibri" ForeColor="red" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                                                    <br />
                                                    &nbsp;
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox3" Display="Static" EnableClientScript="true" ValidationGroup="editProduct" ErrorMessage="* Please enter whole numbers only" Font-Names="Calibri" Font-Size="Small" ForeColor="Red" ValidationExpression="\d+" />
                                                </td>
                                            </tr>
                                            <tr width="100%">
                                                <td width="35%" style="vertical-align:top">
                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Description: "></asp:Label>
                                                    <br />
                                                </td>
                                                <td align="left" style="vertical-align:bottom">
                                                    &nbsp;
                                                    <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please provide a description of your product!" Font-Names="Calibri" ForeColor="red" ControlToValidate="TextBox4" ValidationGroup="editProduct"></asp:RequiredFieldValidator>
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
                <asp:Button ID="Button1" runat="server" Text="Confirm" Font-Names="Calibri" OnClick="Button1_Click" OnClientClick="confirmUpdate()"/>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
