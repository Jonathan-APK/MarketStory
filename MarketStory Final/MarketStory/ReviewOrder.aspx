<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReviewOrder.aspx.cs" Inherits="MarketStory.ReviewOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <br />
    <script type="text/javascript">
        function confirmDelivery() {
            if (confirm('Confirm delivery of selected item?') == true) {
                document.getElementById("<%= HiddenField1.ClientID %>").value = "Yes";
            }
            else {
                document.getElementById("<%= HiddenField1.ClientID %>").value = "No";
            }
        }

        function txt_onblur(txt) {
            var len = txt.value.length;

            if (len <= 0) {
                txt.value = "Fill up your review here . . .";
            }
        }

        function txt_onfocus(txt) {
            var val = txt.value;

            if (val == "Fill up your review here . . .") {
                txt.value = "";
            }
        }
    </script>
    <asp:HiddenField ID="HiddenField1" runat="server"/>
    <div style="width: 100%;" align="center">
        <table width="70%">
            <tr>
                <td width="5%"></td>
                <td width="90%">
                    <br />
                    <div style="float:left">
                    <asp:Label ID="Header" runat="server" Text="Review order" Font-Names="Calibri" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                    </div>
                    <div style="float:right">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" ImageUrl="~/Images/Orders/backToOrders.png" OnClick="ImageButton1_Click"/>
                    </div>
                    <br />
                    <br />
                    <br />
                    <asp:Image ID="Image1" runat="server" ImageAlign="Top" ImageUrl="~/Images/dividerLine.PNG" Width="100%" align="left" />
                    <br />
                    <br />
                    <!--                                ListView for displaying the contents in the selected order ID                                   -->
                    <asp:ListView ID="orderedContentList" runat="server" DataSourceID="SqlDataSource1">
                        <EmptyDataTemplate>
                            <table id="Table1" runat="server">
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        <font face="Calibri">
                                        Error connecting to the database. Please try again later. 
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
                                <table width="105%">
                                    <tr>
                                        <td>
                                            <br />
                                            <table width="100%">
                                                <b>
                                                    <tr>
                                                        <td width="18%" style="vertical-align: top;">
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("sellerID")%>'></asp:HiddenField>
                                                            <image src='<%# Eval("photo")%>' width="100" height="100" />
                                                        </td>
                                                        <td width="65%">
                                                            <b><font face="Calibri">
                                                                Product: &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<asp:Label ID = "displayProductName" runat="server" Font-Underline="true" Text='<%# Eval("productName")%>'></asp:Label>
                                                                <br />
                                                                <br />
                                                                Price: &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&nbsp;&emsp;&emsp;<u>$<asp:Label ID = "displayPrice" runat="server" Text='<%# Eval("price")%>' Font-Underline="true"></asp:Label>/ Item</u>
                                                                <br />
                                                                <br />
                                                                Description/Details: &emsp;&emsp;&emsp;&emsp;&emsp;&nbsp;&emsp;&emsp;<u><%# Eval("information")%></u><br /><br />Ordered Quantity: &emsp;&emsp;&emsp;&emsp;&emsp;&nbsp;&nbsp;&nbsp;&emsp;&emsp;<asp:Label ID = "displayOrderedQuantity" runat="server" Text='<%# Eval("productOrderedQuantity")%>' Font-Underline="true"></asp:Label><br /><br />Product Delivery Status: &emsp;&emsp;&emsp;&nbsp;&emsp;&emsp;<font color="red"><u><%# Eval("productDeliveryStatus")%></u></font><br /><br />Tracking Information: 
                                                                <br />  
                                                                <asp:TextBox ID="displayTrackingInfo" runat="server" Text='<%# Eval("trackingInformation")%>' Enabled="false"/>  
                                                                <br />
                                                                <br />
                                                                Additional Comments from Seller: 
                                                                <br />
                                                                <asp:TextBox ID="displayAdditionalComments" TextMode="multiline" runat="server" Text='<%# Eval("additionalComments")%>' rows="5" columns="50" Enabled="false" Font-Names="Calibri"/>
                                                            </font></b>
                                                        </td>
                                                        <td width="17%" style="vertical-align: bottom;">
                                                            <asp:ImageButton ID="writeReviewButton" runat="server" ImageUrl="~/Images/Orders/writeReviewButton.PNG" align="center" CommandArgument='<%# Eval("productID") + ";" + Eval("orderedProductsID") %>' CommandName="writeReview" />
                                                            <asp:ImageButton ID="confirmDeliveryButton" runat="server" ImageUrl="~/Images/Orders/confirmDeliveryButton.PNG" align="center" CommandArgument='<%# Eval("orderedProductsID") %>' CommandName="confirmDelivery" OnClientClick="confirmDelivery()"/>
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
                                <table width="105%" bgcolor="#E3E4FA">
                                    <tr>
                                        <td>
                                            <br />
                                            <table width="100%">
                                                <b>
                                                    <tr>
                                                        <td width="18%" style="vertical-align: top;">
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("sellerID")%>'></asp:HiddenField>
                                                            <image src='<%# Eval("photo")%>' width="100" height="100" />
                                                        </td>
                                                        <td width="65%">
                                                            <b><font face="Calibri">
                                                                Product: &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<asp:Label ID = "displayProductName" runat="server" Font-Underline="true" Text='<%# Eval("productName")%>'></asp:Label>
                                                                <br />
                                                                <br />
                                                                Price: &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&nbsp;&emsp;&emsp;<u>$<asp:Label ID = "displayPrice" runat="server" Text='<%# Eval("price")%>' Font-Underline="true"></asp:Label>/ Item</u>
                                                                <br />
                                                                <br />
                                                                Description/Details: &emsp;&emsp;&emsp;&emsp;&emsp;&nbsp;&emsp;&emsp;<u><%# Eval("information")%></u><br /><br />Ordered Quantity: &emsp;&emsp;&emsp;&emsp;&emsp;&nbsp;&nbsp;&nbsp;&emsp;&emsp;<asp:Label ID = "displayOrderedQuantity" runat="server" Text='<%# Eval("productOrderedQuantity")%>' Font-Underline="true"></asp:Label><br /><br />Product Delivery Status: &emsp;&emsp;&emsp;&nbsp;&emsp;&emsp;<font color="red"><u><%# Eval("productDeliveryStatus")%></u></font><br /><br />Tracking Information: 
                                                                <br />  
                                                                <asp:TextBox ID="displayTrackingInfo" runat="server" Text='<%# Eval("trackingInformation")%>' Enabled="false"/>  
                                                                <br />
                                                                <br />
                                                                Additional Comments from Seller: 
                                                                <br />
                                                                <asp:TextBox ID="displayAdditionalComments" TextMode="multiline" runat="server" Text='<%# Eval("additionalComments")%>' rows="5" columns="50" Enabled="false" Font-Names="Calibri"/>
                                                            </font></b>
                                                        </td>
                                                        <td width="17%" style="vertical-align: bottom;">
                                                            <asp:ImageButton ID="writeReviewButton" runat="server" ImageUrl="~/Images/Orders/writeReviewButton.PNG" align="center" CommandArgument='<%# Eval("productID") + ";" + Eval("orderedProductsID") %>' CommandName="writeReview" />
                                                            <asp:ImageButton ID="confirmDeliveryButton" runat="server" ImageUrl="~/Images/Orders/confirmDeliveryButton.PNG" align="center" CommandArgument='<%# Eval("orderedProductsID") %>' CommandName="confirmDelivery" OnClientClick="confirmDelivery()"/>
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
                                <table width="105%" bgcolor="#C1E1A6">
                                    <tr>
                                        <td>
                                            <br />
                                            <table width="100%">
                                                <b>
                                                    <tr>
                                                        <td width="18%" style="vertical-align: top;">
                                                            <image src='<%# Eval("photo")%>' width="80" height="80" />
                                                        </td>
                                                        <td width="65%">
                                                            <b><font face="Calibri">
                                                                Product: &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<asp:Label ID = "displayProductName" runat="server" Font-Underline="true" Text='<%# Eval("productName")%>'></asp:Label>
                                                                <br />
                                                                <br />
                                                                Price: &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&nbsp;&emsp;&emsp;<u>$<%# Eval("price")%>/ Item</u>
                                                                <br />
                                                                <br />
                                                                Description/Details: &emsp;&emsp;&emsp;&emsp;&emsp;&nbsp;&emsp;&emsp;<u><%# Eval("information")%></u></font></b></td>
                                                        <td width="17%" style="vertical-align: bottom;">

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="vertical-align: top">
                                                            <b><font face="Calibri">
                                                            <br />
                                                            <br />
                                                            How did you find the seller's product / service?: 
                                                            &nbsp;&emsp;&emsp;&emsp;&emsp;&nbsp;
                                                            <asp:ImageButton ID="upRepPointsButton" runat="server" ImageUrl="~/Images/repPointsIcon.PNG" CommandName="upRepPoints" CommandArgument='<%# Eval("sellerID") %>' Width="25px"/>
                                                            Excellent!
                                                            &nbsp;
                                                            <asp:ImageButton ID="downRepPointsButton" runat="server" ImageUrl="~/Images/repPointsIconInverted.PNG" CommandName="downRepPoints" CommandArgument='<%# Eval("sellerID") %>' Width="25px"/>
                                                            Bad...
                                                            <br />
                                                            <br />
                                                            Your review: 
                                                            <br />
                                                            <asp:TextBox ID="reviewTextbox" runat="server" TextMode="multiline" Text="Fill up your review here . . ." rows="10" columns="80" Font-Names="Calibri" onblur="txt_onblur(this)" onfocus="txt_onfocus(this)" ></asp:TextBox>
                                                            </font></b>
                                                        </td>
                                                        <td width="17%">
                                                            <asp:Button ID="postReviewButton" runat="server" Text="Post Review!" CommandName="postReview" CommandArgument='<%# Eval("productID") %>'/>
                                                            <br />
                                                            <br />
                                                            <asp:Button ID="cancelButton" runat="server" Text="Cancel" CommandName="Cancel" />
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

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:marketstoryConnectionString %>" ProviderName="<%$ ConnectionStrings:marketstoryConnectionString.ProviderName %>">
                        <SelectParameters>
                            <asp:SessionParameter Name="orderID" SessionField="orderID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                </td>
                <td width="5%">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
