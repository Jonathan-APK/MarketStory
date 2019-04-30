<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="MarketStory.UpdateProfile" %>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Update Profile</title>
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
                            <h3 style="font-size: 1em">Update</h3>


                        </div>

                        <div class="content-module-main">

                            <div>
                                <table>
                                    <tr>
                                        <td colspan="3" align="left">

                                            <asp:FileUpload ID="ProfilePictureUpload" runat="server" />
                                            <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" Text="Submit" ValidationGroup="0" Font-Names="Calibri" Font-Size="Medium" />
                                            <asp:RequiredFieldValidator
                                                ID="RFVProfilePicture" runat="server" ForeColor="Red"
                                                Display="None" ControlToValidate="ProfilePictureUpload"
                                                ErrorMessage="Specify the location of the image file" ValidationGroup="0">ProfilePicture</asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="35%">
                                            <br />
                                            <asp:Label ID="LabelCurrentPassword" runat="server" Text="Enter current password:"></asp:Label>
                                            <br />
                                            <asp:Label ID="LabelPassword" runat="server" Text="Enter new password: "></asp:Label>
                                            <br />
                                            <asp:Label ID="LabelRePassword" runat="server" Text="Retype new password: "></asp:Label>
                                            <br />
                                        </td>
                                        <td align="left" width="20%">
                                            <br />
                                            <asp:TextBox ID="TextBoxCurrentPassword" runat="server" ValidationGroup="1" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="RFVCurrentPassword" runat="server" ForeColor="Red"
                                                Display="None" ControlToValidate="TextBoxCurrentPassword"
                                                ErrorMessage="Enter current password" ValidationGroup="1">CurrentPassword</asp:RequiredFieldValidator>
                                            <br />
                                            <asp:TextBox ID="TextBoxPassword" runat="server" ValidationGroup="1" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="RFVPassword" runat="server" ForeColor="Red"
                                                Display="None" ControlToValidate="TextBoxPassword"
                                                ErrorMessage="Enter new password" ValidationGroup="1">Password</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator
                                                ID="REVPassword" runat="server" Display="None"
                                                ControlToValidate="TextBoxPassword" ErrorMessage="Password should be 4 to 15 letters & Space not allowed"
                                                ValidationExpression="\S{4,15}" ForeColor="Red" ValidationGroup="1">Password</asp:RegularExpressionValidator>
                                            <br />
                                            <asp:TextBox ID="TextBoxRePassword" runat="server" ValidationGroup="1" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="RFVRePassword" runat="server" ForeColor="Red"
                                                Display="None" ControlToValidate="TextBoxRePassword"
                                                ErrorMessage="Retype new password" ValidationGroup="1">RePassword</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator
                                                ID="REVRePassword" runat="server" Display="None" ControlToValidate="TextBoxRePassword"
                                                ErrorMessage="Retype password should be 4 to 15 letters &amp; Space not allowed"
                                                ValidationExpression="\S{4,15}" ForeColor="Red" ValidationGroup="1">RePassword</asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center">
                                            <br />
                                            <asp:Button ID="ButtonPassword" runat="server" Text="Update Password" OnClick="ButtonPassword_Click" ValidationGroup="1" Font-Names="Calibri" Font-Size="Medium" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="20%">
                                            <br />
                                            <asp:Label ID="LabelCurrentEmail" runat="server" Text="Current email address: "></asp:Label>
                                            <br />
                                            <asp:Label ID="LabelEmail" runat="server" Text="Enter new email: "></asp:Label>
                                            <br />
                                            <asp:Label ID="LabelReEmail" runat="server" Text="Retype new email: "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <br />
                                            <asp:TextBox ID="TextBoxCurrentEmail" runat="server" Enabled="False"></asp:TextBox>
                                            <br />
                                            <asp:TextBox ID="TextBoxEmail" runat="server" ValidationGroup="2"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="RFVEmail" runat="server" ForeColor="Red"
                                                Display="None" ControlToValidate="TextBoxEmail"
                                                ErrorMessage="Enter new email address" ValidationGroup="2">Email</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator
                                                ID="REVEmail" runat="server" ForeColor="Red" Display="None" ControlToValidate="TextBoxEmail"
                                                ErrorMessage="Enter valid email address"
                                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="2">Email</asp:RegularExpressionValidator>
                                            <br />
                                            <asp:TextBox ID="TextBoxReEmail" runat="server" ValidationGroup="2"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="RFVReEmail" runat="server" ForeColor="Red"
                                                Display="None" ControlToValidate="TextBoxReEmail"
                                                ErrorMessage="Retype new email address" ValidationGroup="2">ReEmail</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator
                                                ID="REVReEmail" runat="server" ForeColor="Red" Display="None" ControlToValidate="TextBoxReEmail"
                                                ErrorMessage="Retype valid email address"
                                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="2">ReEmail</asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center">
                                            <br />
                                            <asp:Button ID="ButtonEmail" runat="server" Text="Update Email" ValidationGroup="2" OnClick="ButtonEmail_Click" Font-Names="Calibri" Font-Size="Medium" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <br />
                                            <asp:Label ID="LabelCurrentMobile" runat="server" Text="Current mobile no: "></asp:Label>
                                            <br />
                                            <asp:Label ID="LabelMobile" runat="server" Text="Enter new mobile no: "></asp:Label>
                                            <br />
                                            <asp:Label ID="LabelReMobile" runat="server" Text="Retype new mobile no: "></asp:Label>
                                            <br />
                                        </td>
                                        <td align="left">
                                            <br />
                                            <asp:TextBox ID="TextBoxCurrentMobile" runat="server" Enabled="False"></asp:TextBox>
                                            <br />
                                            <asp:TextBox ID="TextBoxMobile" runat="server" ValidationGroup="3"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="RFVMobile" runat="server" ForeColor="Red" Display="None"
                                                ControlToValidate="TextBoxMobile"
                                                ErrorMessage="Enter new mobile number" ValidationGroup="3">Mobile</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator
                                                ID="REVMobile" runat="server" ForeColor="Red" Display="None" ControlToValidate="TextBoxMobile"
                                                ErrorMessage="Enter valid mobile number"
                                                ValidationExpression="[0-9]+" ValidationGroup="3">Mobile</asp:RegularExpressionValidator>
                                            <br />
                                            <asp:TextBox ID="TextBoxReMobile" runat="server" ValidationGroup="3"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="RFVReMobile" runat="server" ForeColor="Red" Display="None"
                                                ControlToValidate="TextBoxReMobile"
                                                ErrorMessage="Retype new mobile number" ValidationGroup="3">Mobile</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator
                                                ID="REVReMobile" runat="server" ForeColor="Red" Display="None" ControlToValidate="TextBoxReMobile"
                                                ErrorMessage="Retype valid mobile number"
                                                ValidationExpression="[0-9]+" ValidationGroup="3">Mobile</asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center">
                                            <br />
                                            <asp:Button ID="ButtonMobile" runat="server" Text="Update Mobile" ValidationGroup="3" OnClick="ButtonMobile_Click" Font-Names="Calibri" Font-Size="Medium" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <br />
                                            <asp:TextBox ID="TextBoxInfo" runat="server" Enabled="True" Height="80px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            <br />
                                            <asp:Button ID="ButtonUpdate" runat="server" Font-Bold="False" OnClick="ButtonUpdate_Click" Text="Update" Visible="True" Font-Names="Calibri" Font-Size="Medium" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:ValidationSummary ID="ValidationSummary0" runat="server" HeaderText="Check entries:"
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="0"></asp:ValidationSummary>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Check entries:"
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="1"></asp:ValidationSummary>
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Check entries:"
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="2"></asp:ValidationSummary>
                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" HeaderText="Check entries:"
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="3"></asp:ValidationSummary>
                                <br />
                            </div>

                        </div>

                    </div>

                </div>
                <!-- end of side content -->

            </div>
        </div>
    </body>
    </html>
    <div style="width: 100%" align="center">
    </div>
</asp:Content>
</asp:Content>
