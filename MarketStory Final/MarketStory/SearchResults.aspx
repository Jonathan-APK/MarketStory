<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="MarketStory.SearchResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <br />
        <div style="width: 100%;" align="center">
            <table width="70%" frame="vsides" rules="none" border="2">
                <tr>
                    <td width="2%">
                    </td>
                    <td width="90%">
                        <table width="100%">
                            <tr><td>
                                <b><font face="Calibri">
                                <br />
                                &emsp;<asp:Label ID="Label2" runat="server" Text='Search Results for "' Font-Names="Calibri" Font-Size="X-Large" Font-Bold="true"></asp:Label><asp:Label ID="Label1" runat="server" Text="" Font-Names="Calibri" Font-Size="X-Large" Font-Bold="true"></asp:Label><asp:Label ID="Label3" runat="server" Text='" :' Font-Names="Calibri" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                                <br />
                                <br />
                                <br />
                                <asp:Image ID="Image2" runat="server" ImageAlign="Top" ImageUrl="~/Images/dividerLine.PNG" Width="100%"/>
                                <br />
                                </font></b>
                            </td></tr>

                            <tr><td>
                                &nbsp;
                                <asp:ImageButton ID="searchUsersButton" runat="server" OnClick="searchUsersButton_Click" ImageUrl="~/Images/SearchResults/searchUserButtonSelected.PNG" />
                                <asp:ImageButton ID="searchProductsButton" runat="server" OnClick="searchProductsButton_Click" ImageUrl="~/Images/SearchResults/searchProductButton.PNG" />
                            </td></tr>

                            <tr><td>
                            <!--                                ListView for displaying Users                                   -->
                            <asp:ListView ID="userList" runat="server" DataSourceID="SqlDataSource1">
                                <EmptyDataTemplate>      
                                    <table id="Table1" runat="server" width="100%">        
                                        <tr>          
                                            <td>
                                                <br />
                                                <font face="Calibri">
                                                There are no search results returned.
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
                                    <td id="Td1" runat="server" width="100%"/>  
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
                                                                <asp:ImageButton ID="viewProfileButton" runat="server" ImageUrl='<%# Eval("profilePicture")%>' width="120" height="120" CommandArgument='<%# Eval("userID") %>' CommandName="viewProfile" />
                                                                <br /><br />
                                                            </td>
                                                            <td width="5%"></td>
                                                            <td width="80%">
                                                                <b><font face="Calibri">
                                                                <%# Eval("username")%>
                                                                <br /><br />
                                                                Name: "<%# Eval("name")%>"
                                                                <br /><br />
                                                                Reputation Points: <%# Eval("RepPoints")%>&nbsp;<asp:Image ID="repPointsIcon" runat="server" ImageUrl="~/Images/repPointsIconSelected.PNG" Width="15px"/>
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
                                <AlternatingItemTemplate>
                                    <td id="Td2" runat="server">      
                                        <table width="100%" bgcolor="#E3E4FA">        
                                            <tr>                  
                                                <td>
                                                    <br />
                                                    <table width="100%"><b>
                                                        <tr>
                                                            <td width="15%">
                                                                <asp:ImageButton ID="viewProfileButton" runat="server" ImageUrl='<%# Eval("profilePicture")%>' width="120" height="120" CommandArgument='<%# Eval("userID") %>' CommandName="viewProfile" />
                                                                <br /><br />
                                                            </td>
                                                            <td width="5%"></td>
                                                            <td width="80%">
                                                                <b><font face="Calibri">
                                                                <%# Eval("username")%>
                                                                <br /><br />
                                                                Name: "<%# Eval("name")%>"
                                                                <br /><br />
                                                                Reputation Points: <%# Eval("RepPoints")%>&nbsp;<asp:Image ID="repPointsIcon" runat="server" ImageUrl="~/Images/repPointsIconSelected.PNG" Width="15px"/>
                                                                <br />
                                                                </font></b>
                                                            </td>
                                                        </tr> 
                                                    </b></table>       
                                                </td>        
                                            </tr>      
                                        </table>    
                                    </td>  
                                </AlternatingItemTemplate>
                                <LayoutTemplate>    
                                    <table id="Table2" runat="server" width="100%">      
                                        <tr id="Tr1" runat="server">        
                                            <td id="Td3" runat="server">          
                                                <table ID="groupPlaceholderContainer" runat="server" width="100%">            
                                                    <tr ID="groupPlaceholder" runat="server"></tr>          
                                                </table>        
                                            </td>      
                                        </tr>      
                                        <tr id="Tr2" runat="server"><td id="Td4" runat="server"></td></tr>    
                                    </table>  
                                </LayoutTemplate>
                            </asp:ListView>
                            <!--                                ListView for displaying Products                                   -->
                            <asp:ListView ID="productList" runat="server" DataSourceID="SqlDataSource2" Visible="False">
                                <EmptyDataTemplate>      
                                    <table id="Table1" runat="server" width="100%">        
                                        <tr>          
                                            <td>
                                                <br />
                                                <font face="Calibri">
                                                There are no search results returned.
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
                                    <td id="Td1" runat="server" width="100%"/>  
                                </EmptyItemTemplate>  
                                <GroupTemplate>    
                                    <tr ID="itemPlaceholderContainer" runat="server">      
                                        <td ID="itemPlaceholder" runat="server"></td>    
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
                                                                <asp:ImageButton ID="viewProductButton" runat="server" ImageUrl='<%# Eval("photo")%>' width="120" height="120" CommandArgument='<%# Eval("productID") %>' CommandName="viewProduct" />
                                                                <br /><br />
                                                            </td>
                                                            <td width="5%"></td>
                                                            <td width="80%">
                                                                <b><font face="Calibri">
                                                                Product Name: <%# Eval("productName")%>
                                                                <br /><br />
                                                                Price: $<%# Eval("price")%>SGD
                                                                <br /><br />
                                                                Description: <%# Eval("information")%>
                                                                <br /><br />
                                                                Belongs to Booth: "<%# Eval("boothName")%>"
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
                                <AlternatingItemTemplate>    
                                    <td id="Td2" runat="server"> 
                                        <table width="100%" bgcolor="#E3E4FA">        
                                            <tr>                  
                                                <td>
                                                    <br />
                                                    <table width="100%"><b>
                                                        <tr>
                                                            <td width="15%">
                                                                <image src='<%# Eval("photo")%>'width="120" height="120"/>  
                                                                <br /><br />
                                                            </td>
                                                            <td width="5%"></td>
                                                            <td width="80%">
                                                                <b><font face="Calibri">
                                                                Product Name: <%# Eval("productName")%>
                                                                <br /><br />
                                                                Price: $<%# Eval("price")%>SGD
                                                                <br /><br />
                                                                Description: <%# Eval("information")%>
                                                                <br /><br />
                                                                Belongs to Booth: "<%# Eval("boothName")%>"
                                                                <br />
                                                                </font></b>
                                                            </td>
                                                        </tr> 
                                                    </b></table>      
                                                </td>        
                                            </tr>      
                                        </table>         
                                    </td>  
                                </AlternatingItemTemplate>  
                                <LayoutTemplate>    
                                    <table id="Table2" runat="server" width="100%">      
                                        <tr id="Tr1" runat="server">        
                                            <td id="Td3" runat="server">          
                                                <table ID="groupPlaceholderContainer" runat="server" width="100%">            
                                                    <tr ID="groupPlaceholder" runat="server"></tr>          
                                                </table>        
                                            </td>      
                                        </tr>      
                                        <tr id="Tr2" runat="server"><td id="Td4" runat="server"></td></tr>    
                                    </table>  
                                </LayoutTemplate>
                            </asp:ListView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:marketstoryConnectionString %>" ProviderName="<%$ ConnectionStrings:marketstoryConnectionString.ProviderName %>">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="userName" QueryStringField="value" Type="String" />
                                    <asp:SessionParameter Name="userID" SessionField="userID" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:marketstoryConnectionString %>" ProviderName="<%$ ConnectionStrings:marketstoryConnectionString.ProviderName %>">
                                <SelectParameters>
                                    <asp:QueryStringParameter Name="productName" QueryStringField="value" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td></tr>
                    </table>
                </td>
                <td width="2%">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>

