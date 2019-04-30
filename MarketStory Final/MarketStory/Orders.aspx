<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="MarketStory.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <br />
    <div style="width: 100%;" align="center">
        <table width="70%">
            <tr>
                <td width="5%"></td>
                <td width="90%">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ordersPageHeader.PNG" Height="40px" />
                    <br />
                    <br />
                    <asp:Image ID="Image1" runat="server" ImageAlign="Top" ImageUrl="~/Images/dividerLine.PNG" Width="100%" align="left" />
                    <br />
                    <br />
                    <asp:ImageButton ID="myOrdersButton" runat="server" OnClick="myOrdersButton_Click" ImageUrl="~/Images/Orders/myOrdersButtonSelected.PNG" align="left" />
                    <asp:ImageButton ID="orderRequestsButton" runat="server" OnClick="orderRequestsButton_Click" ImageUrl="~/Images/Orders/orderRequestsButton.PNG" align="left" />
                    <br />
                    <br />

                    <!--                                ListView for displaying Order Requests                                   -->
                    <asp:ListView ID="orderRequestList" runat="server" DataSourceID="SqlDataSource1" Visible="false">
                        <EmptyDataTemplate>
                            <table id="Table1" runat="server">
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        <font face="Calibri">
                                        You have no order requests.
                                         <br />
                                         <br />
                                         <br />
                                         <br />
                                         <br />
                                        </font>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <EmptyItemTemplate>
                            <td id="Td1" runat="server" />
                        </EmptyItemTemplate>
                        <GroupTemplate>
                            <tr id="itemPlaceholderContainer" runat="server">
                                <td id="itemPlaceholder" runat="server"></td>
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td id="Td2" runat="server">
                                <table width="130%">
                                    <tr>
                                        <td>
                                            <br />
                                            <table width="100%">
                                                <b>
                                                    <tr>
                                                        <td width="15%" style="vertical-align: top;">
                                                            <image src='<%# HttpUtility.HtmlEncode(Eval("photo"))%>' width="100" height="100" />
                                                        </td>
                                                        <td width="33%" style="vertical-align: top;">
                                                            <b><font face="Calibri">
                                                                Product: <asp:Label ID = "displayProductName" runat="server" Font-Underline="true" Text='<%# HttpUtility.HtmlEncode(Eval("productName"))%>'></asp:Label>
                                                                <br />
                                                                <br />
                                                                Quantity Needed: <asp:Label ID = "displayOrderedQuantity" runat="server" Text='<%# HttpUtility.HtmlEncode(Eval("productOrderedQuantity"))%>' Font-Underline="true"></asp:Label>
                                                                <br />
                                                                <br />
                                                                Recipient Address: 
                                                                <br />
                                                                <asp:TextBox ID="displayRecipientAddress" TextMode="multiline" runat="server" Text='<%# HttpUtility.HtmlEncode(Eval("recipientAddress"))%>' Enabled="false" Wrap="true" Font-Names="Calibri" ReadOnly="True" BorderStyle="None" BorderWidth="0" style="resize: none"/>                                               
                                                            </font></b>
                                                        </td>
                                                        <td width="40%" style="vertical-align: top;">
                                                            <b><font face="Calibri">
                                                                Product Delivery Status: <font color="red"><u><%# HttpUtility.HtmlEncode(Eval("productDeliveryStatus"))%></u></font>
                                                                <br />    
                                                                <br />
                                                                Tracking Information (if available): 
                                                                <br />
                                                                <asp:TextBox ID="displayTrackingInfo" runat="server" Text='<%# HttpUtility.HtmlEncode(Eval("trackingInformation"))%>' Enabled="false"/>                             
                                                                <br />
                                                                <br />
                                                                Additional Comments: 
                                                                <br />
                                                                <asp:TextBox ID="displayAdditionalComments" TextMode="multiline" runat="server" Text='<%# HttpUtility.HtmlEncode(Eval("additionalComments"))%>' Enabled="false"/>                             
                                                            </font></b>
                                                            &nbsp;<br />
                                                        </td>
                                                        <td width="12%">
                                                            <asp:ImageButton ID="updateRequestButton" runat="server" ImageUrl="~/Images/Orders/updateRequestButton.PNG" align="center" CommandArgument='<%# Eval("orderedProductsID") %>' CommandName="updateRequest" />
                                                        </td>
                                                    </tr>
                                                </b>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <td id="Td2" runat="server">
                                <table width="130%" bgcolor="#E3E4FA">
                                    <tr>
                                        <td>
                                            <br />
                                            <table width="100%">
                                                <b>
                                                    <tr>
                                                        <td width="15%" style="vertical-align: top;">
                                                            <image src='<%# HttpUtility.HtmlEncode(Eval("photo"))%>' width="100" height="100" />
                                                        </td>
                                                        <td width="33%" style="vertical-align: top;">
                                                            <b><font face="Calibri">
                                                                Product: <asp:Label ID = "displayProductName" runat="server" Font-Underline="true" Text='<%# HttpUtility.HtmlEncode(Eval("productName"))%>'></asp:Label>
                                                                <br />
                                                                <br />
                                                                Quantity Needed: <asp:Label ID = "displayOrderedQuantity" runat="server" Text='<%# HttpUtility.HtmlEncode(Eval("productOrderedQuantity"))%>' Font-Underline="true"></asp:Label>
                                                                <br />
                                                                <br />
                                                                Recipient Address: 
                                                                <br />
                                                                <asp:TextBox ID="displayRecipientAddress" TextMode="multiline" runat="server" Text='<%# HttpUtility.HtmlEncode(Eval("recipientAddress"))%>' Enabled="false" Wrap="true" Font-Names="Calibri" ReadOnly="True" BorderStyle="None" BorderWidth="0" style="resize: none"/>                                               
                                                            </font></b>
                                                        </td>
                                                        <td width="40%" style="vertical-align: top;">
                                                            <b><font face="Calibri">
                                                                Product Delivery Status: <font color="red"><u><%# HttpUtility.HtmlEncode(Eval("productDeliveryStatus"))%></u></font>
                                                                <br />    
                                                                <br />
                                                                Tracking Information (if available): 
                                                                <br />
                                                                <asp:TextBox ID="displayTrackingInfo" runat="server" Text='<%# HttpUtility.HtmlEncode(Eval("trackingInformation"))%>' Enabled="false"/>                             
                                                                <br />
                                                                <br />
                                                                Additional Comments: 
                                                                <br />
                                                                <asp:TextBox ID="displayAdditionalComments" TextMode="multiline" runat="server" Text='<%# HttpUtility.HtmlEncode(Eval("additionalComments"))%>' Enabled="false"/>                             
                                                            </font></b>
                                                            &nbsp;<br />
                                                        </td>
                                                        <td width="12%">
                                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/Orders/updateRequestButton.PNG" align="center" CommandArgument='<%# Eval("orderedProductsID") %>' CommandName="updateRequest" />
                                                        </td>
                                                    </tr>
                                                </b>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </AlternatingItemTemplate>
                        <LayoutTemplate>
                            <table id="Table2" runat="server">
                                <tr id="Tr1" runat="server">
                                    <td id="Td3" runat="server">
                                        <table id="groupPlaceholderContainer" runat="server">
                                            <tr id="groupPlaceholder" runat="server"></tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="Tr2" runat="server">
                                    <td id="Td4" runat="server"></td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <EditItemTemplate>
                            <td id="Td2" runat="server">
                                <table width="130%" bgcolor="#C1E1A6">
                                    <tr>
                                        <td>
                                            <br />
                                            <table width="100%">
                                                <b>
                                                    <tr>
                                                        <td width="15%" style="vertical-align: top;">
                                                            <image src='<%# HttpUtility.HtmlEncode(Eval("photo"))%>' width="80" height="80" />
                                                        </td>
                                                        <td width="33%" style="vertical-align: top;">
                                                            <b><font face="Calibri">
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("buyerID")%>'></asp:HiddenField>
                                                                 Product: <asp:Label ID = "displayProductName" runat="server" Font-Underline="true" Text='<%# HttpUtility.HtmlEncode(Eval("productName"))%>'></asp:Label>
                                                                <br />
                                                                <br />
                                                                Quantity Needed: <asp:Label ID = "displayOrderedQuantity" runat="server" Text='<%# HttpUtility.HtmlEncode(Eval("productOrderedQuantity"))%>' Font-Underline="true"></asp:Label>
                                                                <br />
                                                                <br />
                                                                Recipient Address: 
                                                                <br />
                                                                <asp:TextBox ID="displayRecipientAddress" TextMode="multiline" runat="server" Text='<%# HttpUtility.HtmlEncode(Eval("recipientAddress"))%>' Enabled="false" Wrap="true" Font-Names="Calibri" ReadOnly="True" BorderStyle="None" BorderWidth="0" style="resize: none"/>
                                                            </font></b>
                                                        </td>
                                                        <td width="40%" style="vertical-align: top;">
                                                            <b><font face="Calibri">
                                                                Product Delivery Status: 
                                                                    <asp:DropDownList id="productDeliveryStatus" runat="server">
                                                                        <asp:ListItem>Pending</asp:ListItem>
                                                                        <asp:ListItem>On Delivery</asp:ListItem>
                                                                        <asp:ListItem>CANCELLED</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                <br />    
                                                                <br />
                                                                Tracking Information (if available): 
                                                                <br />
                                                                <asp:TextBox ID="trackingInformation" runat="server" Text='<%# HttpUtility.HtmlEncode(Eval("trackingInformation"))%>' />   
                                                                <br />
                                                                <br />
                                                                Additional Comments: 
                                                                <br />
                                                                <asp:TextBox ID="additionalComments" TextMode="multiline" runat="server" Text='<%# HttpUtility.HtmlEncode(Eval("additionalComments"))%>' />                             
                                                            </font></b>
                                                            &nbsp;&nbsp;<br />
                                                        </td>
                                                        <td width="12%">
                                                            <asp:Button ID="Button1" runat="server" Text="Update" CommandName="updateOrderedProduct" CommandArgument='<%# Eval("orderedProductsID") %>'/>
                                                            <br />
                                                            <br />
                                                            <asp:Button ID="Button2" runat="server" Text="Cancel" CommandName="Cancel" />
                                                        </td>
                                                    </tr>
                                                </b>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </EditItemTemplate>
                    </asp:ListView>

                    <!--                                ListView for displaying My Orders                                   -->
                    <asp:ListView ID="myOrdersList" runat="server" DataSourceID="SqlDataSource2" Visible="true">
                        <EmptyDataTemplate>
                            <table id="Table1" runat="server">
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        <font face="Calibri">
                                        You have not made any orders!
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        </font>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <EmptyItemTemplate>
                            <td id="Td1" runat="server" />
                        </EmptyItemTemplate>
                        <GroupTemplate>
                            <tr id="itemPlaceholderContainer" runat="server">
                                <td id="itemPlaceholder" runat="server"></td>
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td id="Td2" runat="server">
                                <table width="130%">
                                    <tr>
                                        <td>
                                            <br />
                                            <table width="100%">
                                                <b>
                                                    <tr>
                                                        <td width="15%">
                                                            <b><font face="Calibri">
                                                            Order ID: <u><%# HttpUtility.HtmlEncode(Eval("orderID"))%></u>
                                                            </font></b>
                                                        </td>
                                                        <td width="33%">
                                                            <b><font face="Calibri">
                                                                Amount Spent: <u>$<%# HttpUtility.HtmlEncode(Eval("subtotal"))%></u></font></b></td>
                                                        <td width="40%">
                                                            <b><font face="Calibri">
                                                                Order created on: <u><%# HttpUtility.HtmlEncode(Eval("timestamp"))%></u>
                                                            </font></b>
                                                            &nbsp;<br />
                                                        </td>
                                                        <td width="12%">
                                                            <asp:ImageButton ID="viewOrderButton" runat="server" ImageUrl="~/Images/Orders/reviewOrderButton.png" align="center" CommandArgument='<%# Eval("orderID") %>' CommandName="reviewOrder" />
                                                        </td>
                                                    </tr>
                                                </b>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <td id="Td2" runat="server">
                                <table width="130%" bgcolor="#E3E4FA">
                                    <tr>
                                        <td>
                                            <br />
                                            <table width="100%">
                                                <b>
                                                    <tr>
                                                        <td width="15%">
                                                            <b><font face="Calibri">
                                                            Order ID: <u><%# HttpUtility.HtmlEncode(Eval("orderID"))%></u>
                                                            </font></b>
                                                        </td>
                                                        <td width="33%">
                                                            <b><font face="Calibri">
                                                                Amount Spent: <u>$<%# HttpUtility.HtmlEncode(Eval("subtotal"))%></u></font></b></td>
                                                        <td width="40%">
                                                            <b><font face="Calibri">
                                                                Order created on: <u><%# HttpUtility.HtmlEncode(Eval("timestamp"))%></u>
                                                            </font></b>
                                                            &nbsp;<br />
                                                        </td>
                                                        <td width="12%">
                                                            <asp:ImageButton ID="viewOrderButton" runat="server" ImageUrl="~/Images/Orders/reviewOrderButton.png" align="center" CommandArgument='<%# Eval("orderID") %>' CommandName="reviewOrder" />
                                                        </td>
                                                    </tr>
                                                </b>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </AlternatingItemTemplate>
                        <LayoutTemplate>
                            <table id="Table2" runat="server">
                                <tr id="Tr1" runat="server">
                                    <td id="Td3" runat="server">
                                        <table id="groupPlaceholderContainer" runat="server">
                                            <tr id="groupPlaceholder" runat="server"></tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="Tr2" runat="server">
                                    <td id="Td4" runat="server"></td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:ListView>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:marketstoryConnectionString %>" ProviderName="<%$ ConnectionStrings:marketstoryConnectionString.ProviderName %>">
                        <SelectParameters>
                            <asp:SessionParameter Name="sellerID" SessionField="userID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:marketstoryConnectionString %>" ProviderName="<%$ ConnectionStrings:marketstoryConnectionString.ProviderName %>">
                        <SelectParameters>
                            <asp:SessionParameter Name="buyerID" SessionField="userID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td width="5%"></td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>

