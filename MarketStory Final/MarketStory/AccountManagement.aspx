<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountManagement.aspx.cs" Inherits="MarketStory.AccountManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
    <asp:TextBox ID="TextBoxBan" runat="server" Placeholder="Enter Username..."></asp:TextBox>

        <asp:Button ID="BanButton" runat="server" Text="Ban" OnClick="BanButton_Click" OnClientClick="return confirm('Are you sure you want to ban this user?');"/>
        <br />
        <br />
        <asp:TextBox ID="TextBoxUnban" runat="server" Placeholder="Enter Username..."></asp:TextBox>
        <asp:Button ID="UnBanButton" runat="server" Text="UnBan" OnClick="UnBanButton_Click" OnClientClick="return confirm('Are you sure you want to unban this user?');"/>
        
    </div>
    <br />

    <table cellpadding="1" cellspacing="2" width="100%" style="border:1px solid black;background-color:#585858;font-weight:bold;color:white">
        <tr width="100%">
            <td align="center">
                <asp:Label ID="Label1" runat="server" Text ="List Of Banned User"/>
            </td>

        </tr>
    <tr>
        <td colspan="3" align="left">
            <asp:GridView ID="GridViewBanLog" ItemStyle-VerticalAlign="Top" AutoGenerateColumns="False"
                GridLines="None" Width="100%" ShowHeader="False" runat="server" AlternatingRowStyle-BackColor="#A5A5A5"
                CellPadding="5" ForeColor="#333333"  >
               
                <Columns>
               
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table align="left" cellpadding="1" cellspacing="2" width="100%">
                                <tr>
                                    <td width="40%" align="center">
                                        <asp:Label ID="lblSendDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Ban")%>'></asp:Label>
                                     
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
</form>
</body>
</html>
