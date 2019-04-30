<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageStore.aspx.cs" Inherits="MarketStory.ManageStore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:TextBox ID="sellerName" runat="server" Placeholder="Enter Seller's Name..."></asp:TextBox>   &nbsp;
        <asp:Button ID="searchSellerButton" runat="server" Text="Search Seller" OnClick="searchSellerButton_Click" />
        <br />
        <br />

           <table align="left" cellpadding="1" cellspacing="2" width="100%" style="height: 80%;border:1px solid black;background-color:#585858;font-weight:bold;color:white">     
                     <tr>
                                        <td width="20%" align="center">ProductID</td>
                                        <td align="center">Product Image</td>
                                        <td width="18%" align="center">ProductName</td>
                                        <td width="16%" align="center">Price (SGD)</td>
                                        <td width="27%" align="center">Quantity</td>
                                    </tr>
                </table>
        <br />
         <br />
        
        <table cellpadding="0" cellspacing="1" border="1" width="100%">
    <tr>
        <td colspan="3" align="left">
            <asp:GridView ID="GridViewStoreItem" ItemStyle-VerticalAlign="Top" AutoGenerateColumns="False"
                GridLines="None" Width="100%" ShowHeader="False" runat="server" AlternatingRowStyle-BackColor="#A5A5A5"
                CellPadding="5" ForeColor="#333333"  >
              
                <Columns>
                         <asp:TemplateField>
                        <ItemTemplate>

                        <asp:ImageButton ID="DeleteButton" src="/Images/Profile/icons/table/actions-delete.png" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"productID")%>' OnClick="DeleteButton_Click" OnClientClick="return confirm('Are you sure you want to delete this item?');" ImageAlign="Right"/>

                            <table align="left" cellpadding="1" cellspacing="2" width="100%">
                                 <tr>
                                    <td width="20%" align="center">
                                        <asp:Label ID="productid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"productID")%>'></asp:Label>
                                    </td>
                                   
                                    <td>
                                    
                                    <img align="center" src='<%#getSRC(Container.DataItem)%>' border="0" width="80px" />   
                                                                      
                                    </td>

                                    <td width="18%" align="center">
                                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"productName")%>'></asp:Label>
                                    </td>

                                    <td width="16%" align="center">
                                        <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"price")%>'></asp:Label>
                                    </td>

                                    <td width="27%" align="center">
                                        <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"availableQuantity")%>'></asp:Label>
                                    </td>                 
                                </tr>

                            
                           </table>

                        </ItemTemplate>
                    </asp:TemplateField>

                 
                </Columns>
              
                <RowStyle BackColor="#EFF3FB" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="white" />
            </asp:GridView>
        </td>
    </tr>
</table>

    </div>
    </form>
</body>
</html>
