<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginVerification.aspx.cs" Inherits="MarketStory.LoginVerification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel='stylesheet' href='css/master.css' />
    <style type="text/css">
        BODY {
            margin-top: 0px;
        }
    </style>
    <title>Login Verification</title>
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
                        <span>Login Verfication</span>
                        <h1>One-time Password</h1>
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
                        <label for="one-time password">OTP:</label>
                        <asp:TextBox ID="TextBoxOTP" runat="server"></asp:TextBox>
                    </p>
                    <br />
                    <asp:Button ID="ButtonOTP" runat="server" Text="Submit" OnClick="ButtonOTP_Click" />
                    <br />
                    <br />
                    <asp:Button ID="ButtonResend" runat="server" OnClick="ButtonResend_Click" Text="Request new otp" />

                    <div class="formExtra">
                        <p><strong>Trouble with verification?</strong></p>
                        <p><a href="RecoveryPage.aspx">Recover your account</a></p>
                    </div>
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
