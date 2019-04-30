<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewFriend.aspx.cs" Inherits="MarketStory.ViewFriend" %>

<%@ Register Src="~/Controls/postfriendview.ascx" TagName="Post2" TagPrefix="uc2" %>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Friend's Posts</title>
        <link rel="stylesheet" href="css/style.css" />
    </head>

    <body>
         <asp:Panel BackColor="WhiteSmoke" BorderStyle="groove" BorderWidth="10px" runat="server" ID="reportBox" style="position: fixed; top: 15%; left: 37%; width: 300px; height: 207px;" visible="false">
        <h2 align="center">What do you want to report about this user?</h2>
        


            <asp:RadioButton ID="scamButton" runat="server" Text="Scamming" GroupName="radiobtn" />
            <br />
            <asp:RadioButton ID="harassmentButton" runat="server" Text="Harassment" GroupName="radiobtn" />
            <br />
            <asp:RadioButton ID="violenceButton" runat="server" Text="Violence or harmful post " GroupName="radiobtn" />
            <br />
            <asp:RadioButton ID="spamButton" runat="server" Text="Spamming of post" GroupName="radiobtn" />
            <br />
            <asp:RadioButton ID="sexualButton" runat="server" Text="Posting sexually explicit content" GroupName="radiobtn" />
            <br />
            <br />
            <div align="right">
                <asp:Button runat="server" ID="submitbutton" Text="Submit" OnClick="sumitbutton_Click" />

                <asp:Button runat="server" ID="cancelbutton" Text="Cancel" OnClick="cancelbutton_Click" />
            
        </div>
    </asp:Panel>
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
                        <br />
                        <br />
                        <asp:Button ID="ButtonReport" runat="server" Font-Bold="True"
                            Text="Report" align="right" OnClick="ButtonReport_Click" />
                    </div>

                    <br />
                    <ul style="margin: 0; padding: 0">
                        <li><a href="ViewFriendInfo.aspx" target="_self" style="font-size: 1em">Information</a></li>
                        <li><a href="ViewFriend.aspx" target="_self" style="font-size: 1em">Posts</a></li>
                        <li><a href="ViewFriendSubscriptions.aspx" target="_self" style="font-size: 1em">Subscriptions</a></li>
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

                            <uc2:Post2 ID="Post" runat="server" />

                        </div>

                    </div>

                </div>
                <!-- end of side content -->

            </div>
        </div>
       
    </body>
    </html>

    
</asp:Content>
