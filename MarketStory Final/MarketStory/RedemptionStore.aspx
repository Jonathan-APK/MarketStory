<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RedemptionStore.aspx.cs" Inherits="MarketStory.RedemptionStore" %>

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
                    <div align="left">
                        <asp:Label ID="Header" runat="server" Text="Redemption Store" Font-Names="Calibri" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <div align="right">
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Click here to view your redemption history" Font-Names="Calibri" ForeColor="Black" Font-Bold="true" OnClick="LinkButton1_Click"></asp:LinkButton>
                    </div>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/dividerLine.PNG" Width="100%" align="left" />
                    <br />
                    <div align="right">
                        <b><font face="Calibri">Your MS Points Balance: </font></b>
                        <asp:Label ID="userMSPointsLabel" runat="server" Font-Names="Calibri" Text="" Font-Bold="true"></asp:Label>
                    </div>
                    <asp:ListView ID="vouchersList" runat="server" DataSourceID="SqlDataSource1" GroupItemCount="5">
                        <EmptyDataTemplate>
                            <table id="Table1" runat="server">
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        <font face="Calibri">
                                            There are no available vouchers for redemption yet.
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
                                <table width="120%" id="itemTemplateTable">
                                    <tr>
                                        <td>
                                            <br />
                                            <table width="100%">
                                                <b>
                                                    <tr>
                                                        <td width="20%">
                                                            <image src='<%# Eval("photo")%>' width="140" height="80" />
                                                            &emsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            <b><font face="Calibri">
                                                                <asp:Label ID="voucherIDLabel" runat="server" Text='<%# Eval("voucherID")%>' Visible="false"></asp:Label><u><%# Eval("voucherName")%></u>
                                                            </font></b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            <b><font face="Calibri">
                                                                Points Required: <asp:Label ID="pointsRequiredLabel" runat="server" Text='<%# Eval("pointsRequired")%>'></asp:Label>
                                                            </font></b>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr height="90">
                                                        <td width="20%">
                                                            <asp:ImageButton ID="checkBoxButton" runat="server" CommandArgument='<%# Eval("voucherID")%>' CommandName="checkBoxCheck" Width="15" Height="15" ImageUrl="~/Images/RedemptionStore/checkBox_unchecked.PNG" />
                                                            &nbsp;<asp:Label ID="checkBoxTickedTextLabel" runat="server" Text="I want this voucher!" Font-Names="Calibri" Visible="false"></asp:Label>
                                                            <br />
                                                            <br />
                                                            <asp:Label ID="quantityLabel" runat="server" Text="Quantity: " Font-Names="Calibri" Visible="false" Font-Size="Smaller"></asp:Label>
                                                            <asp:TextBox ID="quantityTextBox" runat="server" Width="25" ReadOnly="true" CommandArgument='<%# Eval("voucherID")%>' Visible="false" Text="0"></asp:TextBox>
                                                            <asp:ImageButton ID="plusButton" runat="server" Width="20" Height="20" ImageUrl="~/Images/RedemptionStore/plusButton.PNG" onmouseout="this.src='/Images/RedemptionStore/plusButton.PNG'" onmouseover="this.src='/Images/RedemptionStore/plusButtonHovered.PNG'" Visible="false" CommandName="plusButtonClick" />
                                                            <asp:ImageButton ID="minusButton" runat="server" Width="21" Height="21" ImageUrl="~/Images/RedemptionStore/minusButton.PNG" onmouseout="this.src='/Images/RedemptionStore/minusButton.PNG'" onmouseover="this.src='/Images/RedemptionStore/minusButtonHovered.PNG'" Visible="false" CommandName="minusButtonClick" />
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

                    <div align="right">
                        <b><font face="Calibri">
                            MarketStory Points needed: 
                        </font></b>
                        <asp:Label ID="MSPointsNeededLabel" runat="server" Font-Names="Calibri" Text="0"></asp:Label>
                        <br />
                        <asp:ImageButton ID="redeemVouchersButton" runat="server" OnClick="redeemVouchersButton_Clicked" ImageUrl="~/Images/RedemptionStore/redeemVouchersButton.PNG" onmouseout="this.src='/Images/RedemptionStore/redeemVouchersButton.PNG'" onmouseover="this.src='/Images/RedemptionStore/redeemVouchersButtonHovered.PNG'" />
                    </div>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:marketstoryConnectionString %>" ProviderName="<%$ ConnectionStrings:marketstoryConnectionString.ProviderName %>"
                        SelectCommand="SELECT v.voucherID, v.voucherName, v.information, v.photo, v.pointsRequired FROM vouchers v"></asp:SqlDataSource>

                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:marketstoryConnectionString %>" ProviderName="<%$ ConnectionStrings:marketstoryConnectionString.ProviderName %>"
                        SelectCommand="SELECT u.voucherID, u.MSPoints FROM users u"></asp:SqlDataSource>
                </td>
                <td width="5%"></td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
