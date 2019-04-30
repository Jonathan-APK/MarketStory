<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="MarketStory.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script type="text/javascript">
        if (parent.frames.length > 0) {
            parent.location.href = self.document.location;
        }
    </script>
    <link rel='stylesheet' href='css/master.css' />
    <style type="text/css">
        BODY {
            margin-top: 0px;
        }
    </style>
    <title>MarketStory</title>
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
                        <span>Already a member?</span>
                        <h1>Sign in below</h1>
                    </div>

                    <span class="activeTabArrow">
                        <!-- -->
                    </span>
                </li>
                <li class="inactiveTab" id="signUpTab">
                    <div class="signUpTabContent">
                        <span>Don't have an account?</span>
                        <h1>Create one now</h1>
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
                        <label for="login-username">Your Username:</label>
                        <asp:TextBox ID="TextBoxLogin1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVLoginUsername" runat="server"
                            ControlToValidate="TextBoxLogin1" Display="Dynamic"
                            ErrorMessage="Enter a username to login" ForeColor="Red"
                            ValidationGroup="login">Username Required</asp:RequiredFieldValidator>
                    </p>
                    <br />
                    <p>
                        <label for="login-password">Your Password:</label>
                        <asp:TextBox ID="TextBoxLogin2" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVLoginPassword" runat="server"
                            ControlToValidate="TextBoxLogin2" Display="Dynamic"
                            ErrorMessage="Enter a password to login" ForeColor="Red"
                            ValidationGroup="login">Password Required</asp:RequiredFieldValidator>
                    </p>
                    <br />
                    <asp:Button ID="ButtonLogin" runat="server" Text="Sign In"
                        ValidationGroup="login"
                        OnClick="ButtonLogin_Click" />

                    <div class="formExtra">
                        <p><strong>Trouble signing in?</strong></p>
                        <p><a href="RecoveryPage.aspx">Recover your password</a> or <a href="MainPage.aspx">Create an account</a></p>
                    </div>

                </div>

            </div>
            <!-- end signIn -->

            <!-- Sign Up Tab Content -->
            <div id="signUp" class="clearfix toggleTab">

                <div class="cleanForm" id="signUpForm">

                    <p>
                        <label for="name">Name: <span class="requiredField">*</span></label>
                        <asp:TextBox ID="TextBoxName" runat="server" Width="250px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator
                            ID="RFVName" runat="server" ForeColor="Red"
                            Display="Dynamic" ControlToValidate="TextBoxName"
                            ErrorMessage="Enter name">Name Required</asp:RequiredFieldValidator>
                        <em>Enter your name.</em>
                    </p>

                    <p>
                        <label for="username">Username: <span class="requiredField">*</span></label>
                        <asp:TextBox ID="TextBoxUsername" runat="server" Width="250px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator
                            ID="RFVUsername" runat="server" ForeColor="Red" Display="Dynamic"
                            ControlToValidate="TextBoxUsername"
                            ErrorMessage="Enter a username">Username Required</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                ID="REVUsername" runat="server" ForeColor="Red" Display="None" ControlToValidate="TextBoxUsername"
                                ErrorMessage="Username should be 4 to 15 letters &amp; Space not allowed"
                                ValidationExpression="\S{4,15}">Username</asp:RegularExpressionValidator>
                        <em>Between 4 and 15 characters & Space not allowed</em>
                    </p>

                    <p>
                        <label for="password">Password: <span class="requiredField">*</span></label>
                        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator
                            ID="RFVPassword" runat="server" ForeColor="Red"
                            Display="Dynamic" ControlToValidate="TextBoxPassword"
                            ErrorMessage="Enter password">Password Required</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            ID="REVPassword" runat="server" Display="None"
                            ControlToValidate="TextBoxPassword" ErrorMessage="Password should be 4 to 15 letters & Space not allowed"
                            ValidationExpression="\S{4,15}" ForeColor="Red">Password</asp:RegularExpressionValidator>
                        <em>Between 4 and 15 characters & Space not allowed</em>
                    </p>

                    <p>
                        <label for="re-password">Retype password: <span class="requiredField">*</span></label>
                        <asp:TextBox ID="TextBoxRePassword"
                            runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator
                            ID="RFVRePassword" runat="server" ForeColor="Red"
                            Display="Dynamic" ControlToValidate="TextBoxRePassword"
                            ErrorMessage="Retype password">Retype password Required</asp:RequiredFieldValidator>
                        <asp:CompareValidator
                            ID="CVRePassword" runat="server" Display="None" ControlToValidate="TextBoxRePassword"
                            ErrorMessage="Re-type Password doesn't match"
                            ControlToCompare="TextBoxPassword" ForeColor="Red">RePassword</asp:CompareValidator>
                        <asp:RegularExpressionValidator
                            ID="REVRePassword" runat="server" Display="None" ControlToValidate="TextBoxRePassword"
                            ErrorMessage="Retype password should be 4 to 15 letters &amp; Space not allowed"
                            ValidationExpression="\S{4,15}" ForeColor="Red">RePassword</asp:RegularExpressionValidator>
                        <em>Between 4 and 15 characters & Space not allowed</em>
                    </p>

                    <p>
                        <label for="email">Email Address: <span class="requiredField">*</span></label>
                        <asp:TextBox ID="TextBoxEmail" runat="server" Width="250px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator
                            ID="RFVEmail" runat="server" ForeColor="Red" Display="Dynamic"
                            ControlToValidate="TextBoxEmail"
                            ErrorMessage="Enter a valid email address">Email Required</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            ID="REVEmail" runat="server" ForeColor="Red" Display="None" ControlToValidate="TextBoxEmail"
                            ErrorMessage="Enter valid email address"
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Email</asp:RegularExpressionValidator>
                        <em>Must be a valid email address. E.g. example@marketstory.com</em>
                    </p>

                    <p>
                        <label for="phone">Phone Number: <span class="requiredField">*</span></label>
                        <asp:TextBox ID="TextBoxHp" runat="server" Width="250px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator
                            ID="RFVHp" runat="server" ForeColor="Red" Display="Dynamic"
                            ControlToValidate="TextBoxHp"
                            ErrorMessage="Enter a valid mobile number">Mobile Required</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            ID="REVHp" runat="server" ForeColor="Red" Display="None" ControlToValidate="TextBoxHp"
                            ErrorMessage="Enter valid mobile number"
                            ValidationExpression="[0-9]+">Mobile</asp:RegularExpressionValidator>
                        <em>Must be a valid phone number. E.g. 91234567</em>
                    </p>

                    <p>
                        <label for="gender">Gender:</label>
                        <asp:DropDownList ID="ListGender" runat="server" AutoPostBack="False" Height="40px">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </p>

                    <asp:Button ID="ButtonRegister" runat="server" Text="Register"
                        Width="170px" CssClass="flashit" Font-Bold="true" Font-Size="14pt"
                        OnClick="ButtonRegister_Click" />

                    <div class="formExtra">
                        <p><strong>Note: </strong>Fields marked with <span class="requiredField">*</span> are required.</p>
                    </div>


                </div>

                <!-- Sidebar -->
                <div id="sidebar">
                    <h3>Benefits for signing up</h3>

                    <ul>
                        <li>Connect with people around the world</li>
                        <li>Exclusive prices on products</li>
                        <li>Redeem items with points</li>
                    </ul>
                </div>
                <!-- end sidebar -->

            </div>
            <!-- end signUp -->

        </div>
        <!-- end pageContainer -->

        <!-- Include the JS files -->
        <script src="js/jquery.min.js"></script>
        <script src="js/functions.js"></script>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Check entries:"
            ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
    </form>
</body>
</html>
