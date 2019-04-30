<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountActivation.aspx.cs" Inherits="MarketStory.AccountActivation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel='stylesheet' href='css/master.css' />
    <style type="text/css">
        BODY {
            margin-top: 0px;
        }
    </style>
    <title>Account Activation</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="templatemo_header_wrapper">

            <div id="templatemo_header">

                <div id="site_title">
                    <asp:Image ID="ImageLogo" runat="server" Height="68px" Width="180px"
                        ImageUrl="~/Images/SiteMaster/MSLogo.png" />

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
                        <span>Account activation</span>
                        <h1>Activate your account</h1>
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
                        <label for="activation-code">Activation Code:</label>
                        <asp:TextBox ID="TextBoxCode" runat="server"></asp:TextBox>
                    </p>
                    
                    <asp:Button ID="ButtonCode" runat="server" Text="Submit"
                        OnClick="ButtonCode_Click" />
                    <br />
                    <br />
                    <asp:Button ID="ButtonResend" runat="server" OnClick="ButtonResend_Click"
                        Text="Request new code" />
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
