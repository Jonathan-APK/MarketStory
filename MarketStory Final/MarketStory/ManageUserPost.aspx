<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUserPost.aspx.cs" Inherits="MarketStory.ManageUserPost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
  
        <asp:TextBox ID="TextBoxUserName" runat="server" Placeholder="Enter Username..."></asp:TextBox>

        <asp:Button ID="SearchUser" runat="server" Text="Submit" onclick="SearchUser_Click" />
  
  <table cellpadding="0" cellspacing="1" border="1" width="100%">
    <tr>
        <td colspan="3" align="left">
            <asp:GridView ID="GridViewUserPost" ItemStyle-VerticalAlign="Top" AutoGenerateColumns="False"
                GridLines="None" Width="100%" ShowHeader="False" runat="server" AlternatingRowStyle-BackColor="#A5A5A5"
                CellPadding="4" ForeColor="#333333">
               
                <Columns>
               
                    <asp:TemplateField>
                        <ItemTemplate>

                         <asp:ImageButton ID="DeleteButton" src="/Images/Profile/icons/table/actions-delete.png" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ID")%>' OnClick="DeleteButton_Click" OnClientClick="return confirm('Are you sure you want to delete this post?');" ImageAlign="Right" />

                                <table align="left" cellpadding="1" cellspacing="2">
                                <tr>
                                    <td>
                                         <img align="middle" src='<%#getSRC(Container.DataItem)%>' border="0" width="80px" />

                                    </td>
                                    <td>

                                        &nbsp;</td>
                                </tr>

                                <tr>
                                    <td align="center">
                                         <b><%# DataBinder.Eval(Container.DataItem,"name")%></b>

                                    </td>
                                </tr>

                            </table>
                            <br />
                            
                            <div align="justify">
                                <%# DataBinder.Eval(Container.DataItem,"content")%>
                                <br />
                                <br />
                                <br />
                            </div>
                            <span class="SmallBlackText">Posted On: &nbsp;</span>
                            <asp:Label ID="lblSendDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"timestamp")%>'></asp:Label>
                            </span>

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