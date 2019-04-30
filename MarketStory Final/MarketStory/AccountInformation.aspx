<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountInformation.aspx.cs" Inherits="MarketStory.TopUpPage" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %> 
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <style>
        #div1 {
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: 1px dotted;
            background-color: lightcyan;
            width: 95%;
        }

        #div2 {
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: 1px dotted;
            background-color: cadetblue;
            width: 100%;
        }

        #topUpButton
        {
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: 1px dotted;
        }
    </style>
    <br />
    <div style="width: 100%;" align="center">
        <table width="70%" frame="vsides" rules="none" border="2">
                <td width="5%"></td>
                <td width="90%">
                    <asp:Label ID="Label3" runat="server" Text="Top-up MSCash" Font-Names="Calibri" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/dividerLine.PNG" Width="100%" align="left" />
                    <br />
                    <br />
                    <table width="100%">
                        <tr>
                            <td width="50%" style="vertical-align:top">
                                <div align="left" id="div1">
                                    <div style="height:40px">
                                        <asp:Label ID="Header1Label" runat="server" Text="MSCash Top-Up" Font-Names="Calibri" Font-Bold="true" ForeColor="Black" Font-Size="X-Large"></asp:Label>
                                    </div>
                                    <br />
                                    <table>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="Label1" runat="server" Text="Enter your MSCashCard Serial Number and Security Code to proceed: " Font-Names="Calibri" Font-Bold="true"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="30%">
                                                <asp:Label ID="Label2" runat="server" Text="Serial Number: " Font-Names="Calibri" Font-Bold="true"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                            <td width="70%">
                                                <asp:TextBox ID="serialNumberInput" runat="server" Font-Names="Calibri" MaxLength="12" Width="60%"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Required field" ControlToValidate="serialNumberInput" Font-Names="Calibri" Font-Size="Small" ValidationGroup="TopUp" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>                                   
                                        <tr>
                                            <td width="30%">
                                                <asp:Label ID="Label4" runat="server" Text="Security Code: " Font-Names="Calibri" Font-Bold="true"></asp:Label>
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                            <td width="70%">
                                                <asp:TextBox ID="securityCodeInput" runat="server" TextMode="Password" MaxLength="12" Width="60%"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Required field" ControlToValidate="securityCodeInput" Font-Names="Calibri" Font-Size="Small" ValidationGroup="TopUp" ForeColor="Red"></asp:RequiredFieldValidator >
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <cc1:CaptchaControl ID="captcha" runat ="server" CaptchaBackgroundNoise="Low" CaptchaLength="6" CaptchaHeight ="50" CaptchaWidth="200" CaptchaLineNoise="Medium" Width="200px" Height="50" BorderWidth="1" BorderStyle="Solid"/> 
                                                                </td>
                                                                <td style="vertical-align: bottom";>
                                                                    <asp:ImageButton ID="refreshCaptchaButton" runat="server" OnClick="refreshCaptchaButton_Click" ImageUrl="~/Images/AccountInformation/refreshButton.PNG" Height="40px" Width="40px"/>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:TextBox ID="captchaInput" runat="server" Font-Names="Calibri" MaxLength="6"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Required field" ControlToValidate="captchaInput" Font-Names="Calibri" Font-Size="Small" ValidationGroup="TopUp" ForeColor="Red"></asp:RequiredFieldValidator >
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="topUpButton" runat="server" Text="Top Up" Height="30" Width="120" Font-Names="Calibri" ValidationGroup="TopUp" OnClick="topUpButton_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>

                            <td align="right" width="50%" style="vertical-align:top">
                                    <table width="100%">
                                        <tr>
                                            <td>                                
                                                <div align="left" id="div2">
                                                    <div style="height:40px">
                                                        <asp:Label ID="Header2Label" runat="server" Text="Your Account Information: " Font-Names="Calibri" Font-Bold="true" ForeColor="White" Font-Size="X-Large"></asp:Label>
                                                    </div>
                                                    <br />
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="80%" style="vertical-align: bottom";>
                                                                <asp:Label ID="MSCashBalanceLabel" runat="server" Text="Current MSCash Balance: " Font-Names="Calibri" Font-Bold="true" ForeColor="White"></asp:Label> 
                                                            </td>
                                                            <td width="20%" style="vertical-align: bottom";>
                                                                <asp:Label ID="displayUserAccountBalance" runat="server" Font-Names="Calibri" Font-Bold="true" ForeColor="White" Font-Underline="true"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td width="80%" style="vertical-align: bottom";>
                                                                <asp:Label ID="expenditureLabel" runat="server" Text="Overall expenditure on MarketStory: " Font-Names="Calibri" Font-Bold="true" ForeColor="White"></asp:Label>
                                                                <br /> 
                                                                <br />
                                                            </td>
                                                            <td width="20%" style="vertical-align: bottom";>
                                                                <asp:Label ID="displayUserExpenditure" runat="server" Font-Names="Calibri" Font-Bold="true" ForeColor="White" Font-Underline="true"></asp:Label>
                                                                <br />
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr> 
                                                            <td align="right">
                                                                <asp:Button ID="topUpLogButton" runat="server" Text="Top-up History" Height="30" Width="100" Font-Names="Calibri"/>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Button ID="cashOutButton" runat="server" Text="Cash Out" Height="30" Width="100" Font-Names="Calibri" OnClick="cashOutButton_Click" />
                                                            </td>
                                                        </tr> 
                                                        <tr>
                                                            <td colspan="2">
                                                                <br />
                                                                <asp:Label ID="displayAmountToCashOut" runat="server" Text="Amount to Cash Out: " Font-Names="Calibri" Font-Bold="true" ForeColor="White" Visible="false"></asp:Label>
                                                                <br />
                                                                <asp:TextBox ID="cashOutAmountInput" runat="server" Visible="false" Font-Names="Calibri" Width="40%"></asp:TextBox>
                                                                <asp:RegularExpressionValidator id="RegularExpressionValidator1" ControlToValidate="cashOutAmountInput" ValidationExpression="\d+" Display="Static" EnableClientScript="true" ErrorMessage="* Please enter whole numbers only" runat="server" Font-Names="Calibri" Font-Size="Small" ValidationGroup="CashOut" ForeColor="Black"/>
                                                                <br />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Cash out amount cannot be empty" ControlToValidate="cashOutAmountInput" Font-Names="Calibri" Font-Size="Small" ValidationGroup="CashOut" ForeColor="Black"></asp:RequiredFieldValidator >
                                                                <br />
                                                                <asp:Button ID="confirmCashOutButton" runat="server" Text="Confirm Cash Out" Height="30" Width="120" Font-Names="Calibri" OnClick="confirmCashOutButton_Click" Visible="false" ValidationGroup="CashOut"/>
                                                                <asp:Button ID="cancelCashOutButton" runat="server" Text="Cancel" Height="30" Width="100" Font-Names="Calibri" OnClick="cancelCashOutButton_Click" Visible="false"/>
                                                                <br />
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div align="left" id="div2">
                                                    <div style="height:40px">
                                                        <asp:Label ID="Header3Label" runat="server" Text="Instructions for Topping up: " Font-Names="Calibri" Font-Bold="true" ForeColor="White" Font-Size="X-Large"></asp:Label>
                                                    </div>
                                                    <br />
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="90%" style="vertical-align: bottom";>
                                                                <asp:Label ID="instructionLabel1" runat="server" Text="1. Purchase a MSCashCard from any 7-11 retail outlets." Font-Names="Calibri" Font-Bold="true" ForeColor="White"></asp:Label> 
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="90%" style="vertical-align: bottom";>
                                                                <asp:Label ID="instructionLabel2" runat="server" Text="2. Enter the MSCash Code and Security Code. (CAPS Sensitive)" Font-Names="Calibri" Font-Bold="true" ForeColor="White"></asp:Label> 
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="90%" style="vertical-align: bottom";>
                                                                <asp:Label ID="instructionLabel3" runat="server" Text="3. Click on the TOP UP button when done." Font-Names="Calibri" Font-Bold="true" ForeColor="White"></asp:Label> 
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="90%" style="vertical-align: bottom";>
                                                                <asp:Label ID="instructionLabel4" runat="server" Text="4. You will see this pop-up if your MSCash is successfully topped-up into your account." Font-Names="Calibri" Font-Bold="true" ForeColor="White"></asp:Label> 
                                                                <br />
                                                            </td>
                                                        </tr>
                   
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>          
                                    </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="5%"></td>
        </table>
    </div>
    
    <asp:Panel ID="Panel1" runat="server" Width="600" Z-Index="1" BackColor="White">
        <table width="100%" align="center">
            <tr>
                <td width="5%"></td>
                <td>
                    <div align="center">
                        <br />
                        <asp:Label ID="Header" runat="server" Text="Top-up History" Font-Names="Calibri" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                        <br />
                        <br />
                    </div>
                </td>
                <td width="5%" style="vertical-align:top" align="right">
                    <asp:ImageButton ID="closeButton" runat="server" Height="25px" ImageUrl="~/Images/AccountInformation/x-button.png" />
                </td>
            </tr>
            <tr>
                <td>

                </td>
            </tr>
        </table>
        <div>
            <asp:Table ID="displayLog" runat="server">

            </asp:Table>
            <br />
            <br />
            <br />
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="Panel1_ModalPopupExtender" runat="server" Enabled="True" TargetControlID="topUpLogButton" PopupControlID="Panel1" CancelControlID="closeButton">
    </asp:ModalPopupExtender>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
