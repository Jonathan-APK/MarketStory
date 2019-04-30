<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminpage.aspx.cs" Inherits="MarketStory.adminpage" %>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Admin Panel</title>
    <link rel="stylesheet" href="css/style.css" />
     </head>

        <body>
            <div id="content">
                <div class="page-full-width cf">

                    <div class="side-menu fl" >

                        <h3 style="font-size: 1em">Admin Panel</h3>

                             <div align="center">
                                <asp:Image ID="adminPic" Height="180px" runat="server" />
                            </div>

                            <br />


                            <div align="center" style="font-size: 1em">
                                <asp:Label Font-Bold="true" Font-name="Helvetica" ForeColor="White" Font-Size="Larger" ID="adminName" runat="server" align="center" ></asp:Label>
                            </div>

                             <br />
                        <ul style="margin:0; padding:0" >
                            <li><a href="LoginHistory.aspx" target="frame" style="font-size: 1em" onclick="document.getElementById('adminhead').innerHTML ='Admin Activity Log';">Admin Activity Log</a></li>
                            <li><a href="ViewReport.aspx" target="frame" style="font-size: 1em" onclick="document.getElementById('adminhead').innerHTML ='View User Report';">View User Report</a></li>
                            <li><a href="ManageUserPost.aspx" target="frame" style="font-size: 1em" onclick="document.getElementById('adminhead').innerHTML ='Manage User Post';">Manage User Post</a></li>
                            <li><a href="ManageStore.aspx" target="frame" style="font-size: 1em" onclick="document.getElementById('adminhead').innerHTML ='Manage Booth';">Manage Booth</a></li>
                            <li><a href="AccountManagement.aspx" target="frame" style="font-size: 1em" onclick="document.getElementById('adminhead').innerHTML ='Ban/UnBan User';">Ban/UnBan User</a></li>
                            <li><a href="GenerateCashCard.aspx" target="frame" style="font-size: 1em" onclick="document.getElementById('adminhead').innerHTML ='Generate Store Card';">Generate Store Card</a></li>
                            <li><a href="TopUpLogPage.aspx" target="frame" style="font-size: 1em" onclick="document.getElementById('adminhead').innerHTML ='Generate Store Card';">User Top-up History</a></li>
                        </ul>

                    </div> <!-- end of side menu -->

                    <div class="side-content fr">

                        <div class="content-module">

                            <div class="content-module-heading" style="height:50px" >
                                <br />
                                <h3 id="adminhead" style="font-size: 1em">Admin Activity Log</h3>
                              

                            </div>

                            <div class="content-module-main">

                                <iframe src="LoginHistory.aspx" name="frame" style="width: 100%; height: 460px"></iframe>

                            </div>

                        </div>

                    </div><!-- end of side content -->

                </div>
            </div>
        </body>

        </html>
</asp:Content>



