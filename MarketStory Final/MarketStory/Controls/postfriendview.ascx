<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="postfriendview.ascx.cs" Inherits="MarketStory.Controls.postfriendview" %>

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

                                        <img align="middle" src='<%# HttpUtility.HtmlEncode(getSRC(Container.DataItem))%>' border="0" width="80px" />

                                        <br />

                                        <div style="font-weight: bold">
                                            <%# HttpUtility.HtmlEncode(DataBinder.Eval(Container.DataItem, "name"))%>
                                        </div>
                                    </td>



                                    <td align="left" width="62%">
                                        <div align="justify">
                                           <%# HttpUtility.HtmlEncode(DataBinder.Eval(Container.DataItem, "content"))%>
                                        </div>
                                    </td>

                                    <td class="td1" width="20%" VALIGN="buttom" >
                                        <div>
                                          
                                            
                                             
                                        </div>
                                     
                                        <div valign="buttom">
                                            <asp:Label ID="Label2" runat="server" Text='<%# HttpUtility.HtmlEncodeDataBinder.Eval(Container.DataItem, "timestamp")) %>'></asp:Label>

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