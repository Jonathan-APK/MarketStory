using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Entities;

namespace MarketStory
{
    public partial class TopUpPage : System.Web.UI.Page
    {
        User user = new User();
        Order order = new Order();
        TopUpLog topuplog = new TopUpLog();
        int userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                userID = Convert.ToInt32(Session["userID"]);
                user = user.retrieveUserAccountBalance(userID);
                displayUserExpenditure.Text = HttpUtility.HtmlEncode("$" + Convert.ToString(order.retrieveOverallExpenditure(userID)));
                displayUserAccountBalance.Text = HttpUtility.HtmlEncode("$" + Convert.ToString(user.getAccountBalance()));

                List<String> topUpLogList = topuplog.retrieveTopUpLog(1);


                try
                {
                    for (int i = 0; i <= topUpLogList.Count; i++)
                    {
                        if (topUpLogList[i].Trim() != "")
                        {
                            var row = new TableRow();
                            var reviewCell = new TableCell();
                            reviewCell.Font.Bold = true;
                            reviewCell.Font.Name = "Calibri";
                            reviewCell.BorderWidth = 1;
                            reviewCell.BorderStyle = BorderStyle.Dotted;
                            reviewCell.Width = 600;
                            reviewCell.Text = "</br>" + HttpUtility.HtmlEncode(topUpLogList[i]) + "</br></br>";
                            row.Controls.Add(reviewCell);
                            displayLog.Controls.Add(row);
                        }
                        else
                        {
                            if (topUpLogList[i] == "")
                            {
                                var row = new TableRow();
                                var reviewCell = new TableCell();
                                reviewCell.Font.Bold = true;
                                reviewCell.Font.Name = "Calibri";
                                reviewCell.BorderWidth = 1;
                                reviewCell.BorderStyle = BorderStyle.Dotted;
                                reviewCell.Width = 600;
                                reviewCell.Text = "</br>" + "You have not made any top ups yet!" + "</br></br>";
                                row.Controls.Add(reviewCell);
                                displayLog.Controls.Add(row);
                            }
                            else
                            {
                            }
                        }
                    }
                }

                catch (Exception)
                {
                    var row = new TableRow();
                    var reviewCell = new TableCell();
                    reviewCell.Font.Bold = true;
                    reviewCell.Font.Name = "Calibri";
                    reviewCell.BorderWidth = 1;
                    reviewCell.BorderStyle = BorderStyle.Dotted;
                    reviewCell.Width = 600;
                    reviewCell.Text = "</br>" + "You have not made any top ups yet!" + "</br></br>";
                    row.Controls.Add(reviewCell);
                    displayLog.Controls.Add(row);
                }
            }
            else
            {
                Session["login"] = false;
                Response.Redirect("MainPage.aspx");
            }
        }

        protected void refreshCaptchaButton_Click(object sender, EventArgs e)
        {

        }

        protected void topUpButton_Click(object sender, EventArgs e)
        {
            string MSserialNumberInput = serialNumberInput.Text;
            string MSsecurityCodeInput = securityCodeInput.Text;
            CashCard cc = new CashCard();

            if (MSserialNumberInput.Length < 12 || MSsecurityCodeInput.Length < 12)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "topUpFailedScript", "alert('Please double check your Cash Code and Security Code!');", true);
                captchaInput.Text = "";
            }
            else
            {
                try
                {
                    captcha.ValidateCaptcha(captchaInput.Text);

                    if (captcha.UserValidated)
                    {
                        if (cc.checkCashCardAvailability(MSserialNumberInput) == true)
                        {
                            if (cc.validateCashCard(MSserialNumberInput, MSsecurityCodeInput) == true)
                            {
                                cc.updateCashCardUsed(MSserialNumberInput);

                                user = user.retrieveUser(userID);
                                user.updateUserAccountBalance(userID, cc.retrieveCashValue(MSserialNumberInput));

                                TopUpLog topuplog = new TopUpLog();
                                topuplog.createTopUpLog(userID, MSserialNumberInput, DateTime.Now.ToString("MMMM dd, yyyy H:mm:ss tt"));

                                ScriptManager.RegisterStartupScript(this, typeof(string), "topUpSuccessScript", "alert('Top-up success! Please click OK to continue.'); window.location='" + Request.ApplicationPath + "AccountInformation.aspx';", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(string), "topUpFailedScript", "alert('The MSCashCard you provided does not exist or is already used!');", true);
                                captchaInput.Text = "";
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(string), "topUpFailedScript", "alert('The MSCashCard you provided does not exist or is already used!');", true);
                            captchaInput.Text = "";
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "topUpFailedScript", "alert('Incorrect CAPTCHA input!');", true);
                        captchaInput.Text = "";
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        protected void cashOutButton_Click(object sender, EventArgs e)
        {
            if (user.getAccountBalance() < 10)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "cashOutFailedScript", "alert('You need to check out a minimum of $10!');", true);
            }
            else
            {
                displayAmountToCashOut.Visible = true;
                cashOutAmountInput.Visible = true;
                confirmCashOutButton.Visible = true;
                cancelCashOutButton.Visible = true;
                cashOutButton.Visible = false;
            }
        }

        protected void confirmCashOutButton_Click(object sender, EventArgs e)
        {
            int amountToCashOut = Convert.ToInt32(cashOutAmountInput.Text);
            if (amountToCashOut > user.getAccountBalance())
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "cashOutFailedScript", "alert('You cannot cash out more than what you earn!');", true);
            }
            else if (amountToCashOut < 10)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "cashOutFailedScript", "alert('You need to check out a minimum of $10!');", true);
            }
            else if (amountToCashOut <= user.getAccountBalance())
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "cashOutSuccessScript", "alert('Cash out succeeded! Please check your email!');", true);

                user = user.retrieveUser(userID);
                user.updateUserAccountBalance(userID, -amountToCashOut);

                GmailSMTP smtp = new GmailSMTP();
                string cashOutMessage = "You have opted to cash out an amount of $" + HttpUtility.HtmlEncode(amountToCashOut) + " on " + HttpUtility.HtmlEncode(DateTime.Now.ToString());
                cashOutMessage += "\nPlease reply this email with your residential information so we can mail you the cheque";
                cashOutMessage += "\nYou may also provide us with your banking information so we can bank transfer you the money";
                cashOutMessage += "\n\nThank you for using MarketStory";
                smtp.Send(user.getEmail(), "MarketStory Cash Out Success", cashOutMessage, true);

                user = user.retrieveUserAccountBalance(userID);
                displayUserAccountBalance.Text = HttpUtility.HtmlEncode("$" + Convert.ToString(user.getAccountBalance()));

                displayAmountToCashOut.Visible = false;
                cashOutAmountInput.Visible = false;
                confirmCashOutButton.Visible = false;
                cancelCashOutButton.Visible = false;
                cashOutAmountInput.Text = null;
                cashOutButton.Visible = true;
            }
        }

        protected void cancelCashOutButton_Click(object sender, EventArgs e)
        {
            displayAmountToCashOut.Visible = false;
            cashOutAmountInput.Visible = false;
            confirmCashOutButton.Visible = false;
            cancelCashOutButton.Visible = false;
            cashOutAmountInput.Text = null;
            cashOutButton.Visible = true;
        }

        public String getTopUpLog(String s)
        {
            return s;
        }
    }
}