<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProfilePosts.aspx.cs" Inherits="MarketStory.ProfilePosts" %>

<%@ Register Src="~/Controls/post.ascx" TagName="Post1" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Profile Posts</title>
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
                        <li><a href="UpdateProfile.aspx" target="_self" style="font-size: 1em">Update Profile</a></li>
                        <li><a href="ProfilePosts.aspx" target="_self" style="font-size: 1em">Posts</a></li>
                        <li><a href="ProfileSubscriptions.aspx" target="_self" style="font-size: 1em">Subscriptions</a></li>
                    </ul>

                </div>
                <!-- end of side menu -->

                <div class="side-content fr">

                    <div class="content-module">

                        <div class="content-module-heading" style="height: 50px">
                            <br />
                            <h3 style="font-size: 1em">Posts</h3>


                        </div>

                        <div class="content-module-main">

                            <uc1:Post1 ID="Post1" runat="server" />

                        </div>

                    </div>

                </div>
                <!-- end of side content -->

            </div>
        </div>
    </body>
    </html>
</asp:Content>
