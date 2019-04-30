<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoveryVerification.aspx.cs" Inherits="MarketStory.RecoveryVerification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel='stylesheet' href='css/master.css' />
    <style type="text/css">
        BODY {
            margin-top: 0px;
        }
    </style>
    <title>Recovery Verification</title>
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
                        <span>Recovery Verfication</span>
                        <h1>One-time Password & Email Code</h1>
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
                        <asp:Button ID="ButtonResendOTP" runat="server" Text="Request new otp" OnClick="ButtonResendOTP_Click" />
                    </p>
                    <p>
                        <label for="email code">Email Code:</label>
                        <asp:TextBox ID="TextBoxEmailCode" runat="server"></asp:TextBox>
                        <asp:Button ID="ButtonResendEmailCode" runat="server" Text="Request new code" OnClick="ButtonResendEmailCode_Click" />
                    </p>
                    
                    <asp:Button ID="ButtonRecovery" runat="server" Text="Submit" OnClick="ButtonRecovery_Click" />
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
