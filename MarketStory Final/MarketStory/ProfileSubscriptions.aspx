<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProfileSubscriptions.aspx.cs" Inherits="MarketStory.ProfileSubscriptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Profile Subscriptions</title>
        <link rel="stylesheet" href="css/style.css" />
    </head>

    <body>
        <div id="content">
            <div class="page-full-width cf">

                <div class="side-menu fl">

                    <h3 style="font-size: 1em">Profile</h3>

                    <div align="center">
                        <asp:Image ID="ImageProfilePicture" runat="server" Height="80%" Width="80%" Style="margin-bottom: 0px" />
                    </div>

                    <br />


                    <div align="center" style="font-size: 1em; color: white">
                        <asp:Label ID="LabelProfileUsername" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                    </div>

                    <br />
                    <ul style="margin: 0; padding: 0">
                        <li><a href="UpdateProfile.aspx" target="_self"" style="font-size: 1em">Update Profile</a></li>
                        <li><a href="ProfilePosts.aspx" target="_self"" style="font-size: 1em">Posts</a></li>
                        <li><a href="ProfileSubscriptions.aspx" target="_self"" style="font-size: 1em">Subscriptions</a></li>
                    </ul>

                </div>
                <!-- end of side menu -->

                <div class="side-content fr">

                    <div class="content-module">

                        <div class="content-module-heading" style="height: 50px">
                            <br />
                            <h3 style="font-size: 1em">Subscriptions</h3>


                        </div>

                        <div class="content-module-main" style="height:348px">

                            <asp:ListView ID="ListView1" runat="server" GroupItemCount="2" GroupPlaceholderID="groupPlaceholder1" ItemPlaceholderID="itemPlaceholder1">
                                <LayoutTemplate>
                                    <div>
                                        <div id="groupPlaceholder1" runat="server">
                                        </div>
                                    </div>
                                    </table>
                                </LayoutTemplate>
                                <GroupTemplate>
                                    <div style="clear: both">
                                        <div id="itemPlaceholder1" runat="server">
                                        </div>
                                    </div>
                                </GroupTemplate>
                                <ItemTemplate>
                                    <table align="left" cellpadding="1" cellspacing="2">
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="ImageButton1" runat="server" Style="width: 80px" align="middle" src='<%# getFriendProfilePicture((MarketStory.Entities.User)Container.DataItem) %>' CommandArgument='<%# getUserID((MarketStory.Entities.User)Container.DataItem) %>' CommandName="viewProfile" />
                                            </td>
                                            <td valign="bottom">
                                                <b>
                                                    <asp:Label ID="Label1" runat="server" Text="<%# getFriendUsername((MarketStory.Entities.User)Container.DataItem) %>" Width="75px"></asp:Label></b>
                                            </td>
                                            <td>
                                                <asp:Button ID="Button1" runat="server" Text='Delete' CommandArgument='<%# getUserID((MarketStory.Entities.User)Container.DataItem) %>' CommandName="deleteSubscription" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <EmptyItemTemplate></EmptyItemTemplate>
                                <AlternatingItemTemplate>
                                    <table align="right" cellpadding="1" cellspacing="2">
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="ImageButton1" runat="server" Style="width: 80px" align="middle" src='<%# getFriendProfilePicture((MarketStory.Entities.User)Container.DataItem) %>' CommandArgument='<%# getUserID((MarketStory.Entities.User)Container.DataItem) %>' CommandName="viewProfile" />
                                            </td>
                                            <td valign="bottom">
                                                <b>
                                                    <asp:Label ID="Label2" runat="server" Text="<%# getFriendUsername((MarketStory.Entities.User)Container.DataItem) %>" Width="75px"></asp:Label></b>
                                            </td>
                                            <td>
                                                <asp:Button ID="Button1" runat="server" Text='Delete' CommandArgument='<%# getUserID((MarketStory.Entities.User)Container.DataItem) %>' CommandName="deleteSubscription" />
                                            </td>
                                        </tr>
                                    </table>
                                </AlternatingItemTemplate>
                                <GroupSeparatorTemplate>
                                </GroupSeparatorTemplate>
                            </asp:ListView>

                        </div>

                    </div>

                </div>
                <!-- end of side content -->

            </div>
        </div>
    </body>
    </html>
</asp:Content>
