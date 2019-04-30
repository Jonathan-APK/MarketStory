<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewReport.aspx.cs" Inherits="MarketStory.ViewReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title></title>
</head>
<body>
   <form id="form1" runat="server">
    <div>

    <table cellpadding="0" cellspacing="1" border="1" width="100%">
    <tr>
        <td colspan="3" align="left">
            <asp:GridView ID="GridViewReport" ItemStyle-VerticalAlign="Top" AutoGenerateColumns="False"
                GridLines="None" Width="100%" ShowHeader="False" runat="server" AlternatingRowStyle-BackColor="#A5A5A5"
                CellPadding="4" ForeColor="#333333">
               
                <Columns>
               
                    <asp:TemplateField>
                        <ItemTemplate>
                                <table align="left" cellpadding="1" cellspacing="2" width="100%">
  
                                <tr>
                                    <td>

                                          <span class="SmallBlackText">Report ID: &nbsp;</span>
                                     <b><%# DataBinder.Eval(Container.DataItem,"reportId")%></b>

                                    </td>
                                  
                                    <td>
                                        <asp:ImageButton ID="DeleteButton" runat="server" src="/Images/Profile/icons/table/actions-delete.png" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"reportId")%>' OnClick="DeleteButton_Click" ImageAlign="Right"/>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                         <b><%# DataBinder.Eval(Container.DataItem,"reporter")%></b>
                                         <span class="SmallBlackText">reported</span>
                                         <b><%# DataBinder.Eval(Container.DataItem,"reportedUser")%></b>
                                         <span class="SmallBlackText">for</span>
                                        
                                         <b><%# DataBinder.Eval(Container.DataItem,"reportType")%></b>
                                    </td>
                                    <td align="right">              
                                       <asp:Button ID="Marker" runat="server" style="margin-right:40%;" Text='<%# DataBinder.Eval(Container.DataItem,"reportMarker")%>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"reportId")%> ' OnClick="Marker_Click"/>
                                    </td>
                                </tr>
                                   
                                    <tr>
                                        <td>   
                                                          
                                          <asp:Label ID="lblSendDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"timestamp")%>'></asp:Label>
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