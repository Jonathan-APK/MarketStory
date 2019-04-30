<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoveryPage.aspx.cs" Inherits="MarketStory.RecoveryPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel='stylesheet' href='css/master.css' />
    <style type="text/css">
        BODY {
            margin-top: 0px;
        }
    </style>
    <title>Account Recovery</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="templatemo_header_wrapper">

            <div id="templatemo_header">

                <div id="site_title" style= "width:100%">
                       <asp:Image ID="Image1" runat="server" Height="68px" Width="180px"
                            ImageUrl="~/Images/SiteMaster/MSLogo.png" />
                    <a href="MainPage.aspx" style= "position:absolute; right:20%; top:10%; color:white; font-size:medium">Login</a>

                       </div>

                <div class="cleaner"></div>
            </div>
        </div>
        <!-- end of header -->

        <div id="pageContainer">

            <!-- Tabs -->
            <ul id="tabs" class="clearfix">
                <li class="activeTab" id="signInTab">
                    <div class="signInTabContent">
                        <span>Account Recovery</span>
                        <h1>Recover Your Account</h1>
                    </div>

                    <span class="activeTabArrow">
                        <!-- -->
                    </span>
                </li>
            </ul>

            <!-- Sign In Tab Content -->
            <div id="signIn" class="toggleTab">

                <div class="cleanForm">

                    <p>
                        <label for="username">Username:</label>
                        <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
                    </p>
                    <br />
                    <asp:Button ID="ButtonRecovery" runat="server" Text="Recover" OnClick="ButtonRecovery_Click" />
                    <br />
                    <br />
                </div>

            </div>
            <!-- end signIn -->

        </div>
        <!-- end pageContainer -->

        <!-- Include the JS files -->
        <script src="js/jquery.min.js"></script>
    </form>
</body>
</html>
