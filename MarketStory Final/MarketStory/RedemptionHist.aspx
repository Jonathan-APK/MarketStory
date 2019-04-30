<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RedemptionHist.aspx.cs" Inherits="MarketStory.RedemptionHist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <br />
    <div style="width: 100%;" align="center">
        <table width="70%" frame="vsides" rules="none" border="2">
            <%--<tr>--%>
                <td width="5%"></td>
                <td width="90%">
                    <asp:Label ID="Header" runat="server" Text="Redemption History" Font-Names="Calibri" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                    <br />
                    <br />
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/dividerLine.PNG" Width="100%" align="left" />
                    <br />
                    <asp:ListView ID="vouchersList" runat="server" DataSourceID="SqlDataSource1" GroupItemCount="2">
                        <EmptyDataTemplate>
                            <table id="Table1" runat="server">
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        <font face="Calibri">
                                        You have not redeemed any vouchers in the past.
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
                                        <table width="100%">        
                                            <tr>                  
                                                <td>
                                                    <br />
                                                    <table width="100%"><b>
                                                        <tr>
                                                            <td width="15%">
                                                                <image src='<%# Eval("photo")%>'width="150" height="100"/>  
                                                                <br />
                                                                <b><font face="Calibri">
                                                                <%# Eval("voucherName")%>
                                                                </font></b>
                                                                <br /><br />
                                                            </td>
                                                            <td width="5%"></td>
                                                            <td width="80%">
                                                                <b><font face="Calibri">
                                                                Redemption ID: <%# Eval("redemptionID")%>
                                                                <br /><br />
                                                                Redeemed Quantity: <%# Eval("voucherRedeemedQuantity")%>
                                                                <br /><br />
                                                                Available Quantity: <font color="red"><%# Eval("availableQuantity")%>/<%# Eval("voucherRedeemedQuantity")%></font><br /><br />Total points spent: <%# Eval("subtotalPoints")%> MSPoints
                                                                <br />
                                                                </font></b>
                                                            </td>
                                                        </tr> 
                                                    </b></table>      
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
                    <br />
                    <div style="width: 100%;" align="center">
                        <table width="90%" frame="box" rules="none" border="2">
                            <br />
                            <br />
                            <asp:HyperLink ID="footerTextHyperLink" runat="server" Font-Names="Calibri" Font-Bold="true" NavigateUrl="~/RedemptionStore.aspx">Click here to redeem more vouchers!</asp:HyperLink>
                        </table>
                    </div>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:marketstoryConnectionString %>" ProviderName="<%$ ConnectionStrings:marketstoryConnectionString.ProviderName %>"
                        SelectCommand="SELECT rh.redemptionID, rh.subtotalPoints, rv.voucherRedeemedQuantity, rv.availableQuantity, v.photo, v.voucherName FROM redemptionHistory rh INNER JOIN redeemedVouchers rv ON rh.redemptionID = rv.redemptionID INNER JOIN vouchers v ON rv.voucherID = v.voucherID WHERE rh.redeemerID = ?">
                        <SelectParameters>
                            <asp:SessionParameter Name="redeemerID" SessionField="userID" Type="Int32" />
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

