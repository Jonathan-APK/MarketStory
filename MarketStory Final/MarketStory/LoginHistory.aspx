<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginHistory.aspx.cs" Inherits="MarketStory.LoginHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title></title>
</head>
<body>
     <form id="AdminLogForm" runat="server">
      <asp:GridView ID="GridViewLoginHistory" ItemStyle-VerticalAlign="Top" AutoGenerateColumns="False"
                GridLines="None" Width="100%" ShowHeader="False" runat="server" AlternatingRowStyle-BackColor="#A5A5A5"
                CellPadding="5" ForeColor="#333333">
               
                <Columns>
               
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table align="center" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td>
                                         <%#DataBinder.Eval(Container.DataItem, "LogInfo")%>
                                    </td>
                                  </tr> 
                            </table>
                        
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
              
                <RowStyle BackColor="#D0D0D0" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </form>
</body>
</html>