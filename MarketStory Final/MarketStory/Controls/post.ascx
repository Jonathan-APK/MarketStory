<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="post.ascx.cs" Inherits="MarketStory.Controls.post" %>

<script src="/PopUpBtn.js" type="text/javascript"></script>
<STYLE TYPE="text/css">

td.td1{font-size:90%;}

</STYLE>


<table cellpadding="0" cellspacing="1" border="1" width="100%">
    <tr>
        <td colspan="3" width="100%">
            <asp:GridView ID="GridViewUserPost" ItemStyle-VerticalAlign="Top" AutoGenerateColumns="False"
                GridLines="None" Width="100%" ShowHeader="False" runat="server" AlternatingRowStyle-BackColor="#A5A5A5"
                CellPadding="4" ForeColor="#333333">

                <Columns>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <table align="left" cellpadding="1" cellspacing="2" width="100%">
                                <tr>
                                    <td width="18%" align="center">

                                        <img align="middle" src='<%#getSRC(Container.DataItem)%>' border="0" width="80px" />

                                        <br />

                                        <div style="font-weight: bold">
                                            <%#getName(Container.DataItem)%>
                                        </div>
                                    </td>



                                    <td align="left">
                                        <div align="justify">
                                            <%#getContent(Container.DataItem)%>
                                        </div>
                                    </td>

                                    <td class="td1" width="20%" align="right">
                                        <div>
                                          
                                            
                                            <asp:ImageButton ID="Button1" runat="server" src="/Images/Profile/icons/menu/menu-settings.png" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' OnClick="Button1_Click"/>
                                             
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <div>
                                            <asp:Label ID="Label2" runat="server" Text='<%#getTime(Container.DataItem)%>'></asp:Label>

                                        </div>
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
                                <asp:Panel BackColor="WhiteSmoke" BorderStyle="groove" BorderWidth="5px" runat="server" ID="myPostDialogBox1" Style="position: fixed; top: 52%; left: 39%; width: 300px; height: 100px;" Visible="false">
                                 <br />
                                <p align="center">What Do You Wish To Do With Your Post?</p>
                                <div align="center">
                                 
                                    <asp:Button runat="server" ID="btnDelete" Text="Delete" OnClick="btnDelete_Click"/>
                                    &nbsp;&nbsp;
                                    <asp:Button runat="server" ID="btnHidePost" Text="Hide" OnClick="btnHide_Click" />
                                    &nbsp;&nbsp;
                                    <asp:Button runat="server" ID="btnCancel1" Text="Cancel" OnClick="btnCancel_Click"/>
                                </div>
                            </asp:Panel>

                            <asp:Panel BackColor="WhiteSmoke" BorderStyle="groove" BorderWidth="5px" runat="server" ID="friendPostDialogBox1" Style="position: fixed; top: 52%; left: 39%; width: 257px; height: 85px;" Visible="false">
                                 <br />
                                <p align="center">Do You Want To Hide This Post?</p>
                                <div align="center">
                                    
                                    <asp:Button runat="server" ID="ButtonHideFriendPost" Text="Yes" OnClick="btnHideFriend_Click"/>
                                    &nbsp;&nbsp;
                                    <asp:Button runat="server" ID="btnCancel2" Text="No" OnClick="btnCancel_Click" />
                                </div>
                            </asp:Panel>

                            <asp:Panel BackColor="WhiteSmoke" BorderStyle="groove" BorderWidth="5px" runat="server" ID="myPostDialogBox2" Style="position: fixed; top: 52%; left: 39%; width: 300px; height: 100px;" Visible="false">
                          <br />
                                <p align="center">What Do You Wish To Do With Your Post?</p>
                                <div align="center">
                                   
                                    <asp:Button runat="server" ID="ButtonUnHidePost" Text="Unhide" OnClick="btnUnhide_Click"/>
                                    &nbsp;&nbsp;
                                    <asp:Button runat="server" ID="btnCancel3" Text="Cancel" OnClick="btnCancel_Click" />
                                </div>
                            </asp:Panel>

                            <asp:Panel BackColor="WhiteSmoke" BorderStyle="groove" BorderWidth="5px" runat="server" ID="friendPostDialogBox2" Style="position: fixed; top: 52%; left: 39%; width: 300px; height: 100px;" Visible="false">
                                 <br />
                                <p align="center">Do You Wish To Unhide This Post?</p>
                                <div align="center">
                                    
                                    <asp:Button runat="server" ID="ButtunHideFriendPost" Text="Yes" OnClick="btnUnhideFriend_Click"/>
                                    &nbsp;&nbsp;
                                    <asp:Button runat="server" ID="btnCancel4" Text="No" OnClick="btnCancel_Click" />
                                </div>
                            </asp:Panel>