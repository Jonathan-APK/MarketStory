using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MarketStory.Entities;

namespace MarketStory
{
    public partial class RedemptionStore : System.Web.UI.Page
    {
        User user = new User();
        int userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                Voucher v1 = new Voucher();
                List<Voucher> voucherList = v1.retrieveVouchers();
                userID = Convert.ToInt32(Session["userID"]);
                user = user.retrieveUser(userID);
                userMSPointsLabel.Text = Convert.ToString(user.getMSPoints());
            }
            else
            {
                Session["login"] = false;
                Response.Redirect("MainPage.aspx");
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            vouchersList.ItemCommand += new EventHandler<ListViewCommandEventArgs>(ListView1_ItemCommand);
        }

        private void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "checkBoxCheck":
                    {
                        //int i = Convert.ToInt32(e.CommandArgument);
                        checkBoxButton_Clicked(e);
                        break;
                    }
                case "plusButtonClick":
                    {
                        //int i = Convert.ToInt32(e.CommandArgument);
                        plusButton_Clicked(e);
                        break;
                    }
                case "minusButtonClick":
                    {
                        //int i = Convert.ToInt32(e.CommandArgument);
                        minusButton_Clicked(e);
                        break;
                    }
            }
        }

        private void checkBoxButton_Clicked(ListViewCommandEventArgs e)
        {
            if (((ImageButton)e.Item.FindControl("checkBoxButton")).ImageUrl == "~/Images/RedemptionStore/checkBox_unchecked.PNG")
            {
                ((ImageButton)e.Item.FindControl("checkBoxButton")).ImageUrl = "~/Images/RedemptionStore/checkBox_checked.PNG";
                ((Label)e.Item.FindControl("checkBoxTickedTextLabel")).Visible = true;
                ((Label)e.Item.FindControl("quantityLabel")).Visible = true;
                ((TextBox)e.Item.FindControl("quantityTextBox")).Visible = true;
                ((ImageButton)e.Item.FindControl("plusButton")).Visible = true;
                ((ImageButton)e.Item.FindControl("minusButton")).Visible = true;
            }
            else
            {
                string quantityString = ((TextBox)e.Item.FindControl("quantityTextBox")).Text;
                int quantityInt = Convert.ToInt32(quantityString);

                int pointsToDeduct = Convert.ToInt32(((Label)e.Item.FindControl("pointsRequiredLabel")).Text);
                int totalPointsToDeduct = pointsToDeduct * quantityInt;

                string pointsNeededString = MSPointsNeededLabel.Text;
                int pointsNeededInt = Convert.ToInt32(MSPointsNeededLabel.Text);
                pointsNeededInt = pointsNeededInt - totalPointsToDeduct;
                pointsNeededString = Convert.ToString(pointsNeededInt);
                MSPointsNeededLabel.Text = pointsNeededString;

                ((ImageButton)e.Item.FindControl("checkBoxButton")).ImageUrl = "~/Images/RedemptionStore/checkBox_unchecked.PNG";
                ((Label)e.Item.FindControl("checkBoxTickedTextLabel")).Visible = false;
                ((Label)e.Item.FindControl("quantityLabel")).Visible = false;
                ((TextBox)e.Item.FindControl("quantityTextBox")).Visible = false;
                ((TextBox)e.Item.FindControl("quantityTextBox")).Text = "0";
                ((ImageButton)e.Item.FindControl("plusButton")).Visible = false;
                ((ImageButton)e.Item.FindControl("minusButton")).Visible = false;

                List<RedeemedVoucher> redeemedVoucherList;
                int plusButtonClicked;

                redeemedVoucherList = (List<RedeemedVoucher>)Session["redeemedVoucherList"];
                plusButtonClicked = Convert.ToInt32(Session["plusButtonClicked"]);

                for (int i = 0; i < redeemedVoucherList.Count; i++)
                {
                    int voucherID = Convert.ToInt32(((Label)e.Item.FindControl("voucherIDLabel")).Text);

                    if (redeemedVoucherList[i].getVoucherID() == voucherID)
                    {
                        if (Convert.ToInt32(((TextBox)e.Item.FindControl("quantityTextBox")).Text) == 0)
                        {
                            redeemedVoucherList.RemoveAt(i);
                            Session["redeemedVoucherList"] = redeemedVoucherList;

                            if (redeemedVoucherList.Count == 0)
                            {
                                plusButtonClicked = 0;
                                Session["plusButtonClicked"] = plusButtonClicked;
                            }
                        }
                    }
                }

                if (pointsNeededInt > Convert.ToInt32(userMSPointsLabel.Text))
                {
                    MSPointsNeededLabel.ForeColor = System.Drawing.Color.Red;
                }
                else if (pointsNeededInt < Convert.ToInt32(userMSPointsLabel.Text))
                {
                    MSPointsNeededLabel.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    MSPointsNeededLabel.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        private void plusButton_Clicked(ListViewCommandEventArgs e)
        {
            string quantityString = ((TextBox)e.Item.FindControl("quantityTextBox")).Text;
            int quantityInt = Convert.ToInt32(quantityString);
            quantityInt++;
            quantityString = Convert.ToString(quantityInt);
            ((TextBox)e.Item.FindControl("quantityTextBox")).Text = quantityString;

            string pointsNeededString = MSPointsNeededLabel.Text;
            int pointsNeededInt = Convert.ToInt32(pointsNeededString);
            int pointsToAddOn = Convert.ToInt32(((Label)e.Item.FindControl("pointsRequiredLabel")).Text);
            pointsNeededInt = pointsNeededInt + pointsToAddOn;

            if (pointsNeededInt > Convert.ToInt32(userMSPointsLabel.Text))
            {
                MSPointsNeededLabel.ForeColor = System.Drawing.Color.Red;
            }
            else if (pointsNeededInt < Convert.ToInt32(userMSPointsLabel.Text))
            {
                MSPointsNeededLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                MSPointsNeededLabel.ForeColor = System.Drawing.Color.Black;
            }

            pointsNeededString = Convert.ToString(pointsNeededInt);
            MSPointsNeededLabel.Text = pointsNeededString;

            List<RedeemedVoucher> redeemedVoucherList;
            int plusButtonClicked;

            if (Session["plusButtonClicked"] == null)
                plusButtonClicked = 0;
            else
                plusButtonClicked = Convert.ToInt32(Session["plusButtonClicked"]);

            if (Session["redeemedVoucherList"] == null)
                redeemedVoucherList = new List<RedeemedVoucher>();
            else
                redeemedVoucherList = (List<RedeemedVoucher>)Session["redeemedVoucherList"];

            bool voucherExists = false;

            if (plusButtonClicked == 0)
            {
                redeemedVoucherList.Add(new RedeemedVoucher(Convert.ToInt32(((Label)e.Item.FindControl("voucherIDLabel")).Text), Convert.ToInt32(((TextBox)e.Item.FindControl("quantityTextBox")).Text)));
                Session["redeemedVoucherList"] = redeemedVoucherList;
                Session["plusButtonClicked"] = 1;
            }
            else
            {
                for (int i = 0; i < redeemedVoucherList.Count; i++)
                {
                    int voucherID = Convert.ToInt32(((Label)e.Item.FindControl("voucherIDLabel")).Text);

                    if (redeemedVoucherList[i].getVoucherID() == voucherID)
                    {
                        voucherExists = true;

                        if (Convert.ToInt32(((TextBox)e.Item.FindControl("quantityTextBox")).Text) != 0)
                        {
                            redeemedVoucherList[i].setVoucherRedeemedQuantity(Convert.ToInt32(((TextBox)e.Item.FindControl("quantityTextBox")).Text));
                            Session["redeemedVoucherList"] = redeemedVoucherList;
                        }
                    }
                    else if (redeemedVoucherList[i].getVoucherID() != voucherID)
                    {
                        voucherExists = false;
                    }
                }

                if (voucherExists == false)
                {
                    RedeemedVoucher r1 = new RedeemedVoucher(Convert.ToInt32(((Label)e.Item.FindControl("voucherIDLabel")).Text), Convert.ToInt32(((TextBox)e.Item.FindControl("quantityTextBox")).Text));
                    redeemedVoucherList.Add(r1);
                    Session["redeemedVoucherList"] = redeemedVoucherList;
                }
            }
        }

        private void minusButton_Clicked(ListViewCommandEventArgs e)
        {
            string quantityString = ((TextBox)e.Item.FindControl("quantityTextBox")).Text;
            int quantityInt = Convert.ToInt32(quantityString);
            if (quantityInt != 0)
            {
                if (quantityInt == 1)
                {
                    ((ImageButton)e.Item.FindControl("checkBoxButton")).ImageUrl = "~/Images/RedemptionStore/checkBox_unchecked.PNG";
                    ((Label)e.Item.FindControl("checkBoxTickedTextLabel")).Visible = false;
                    ((Label)e.Item.FindControl("quantityLabel")).Visible = false;
                    ((TextBox)e.Item.FindControl("quantityTextBox")).Visible = false;
                    ((ImageButton)e.Item.FindControl("plusButton")).Visible = false;
                    ((ImageButton)e.Item.FindControl("minusButton")).Visible = false;
                }

                quantityInt--;
                quantityString = Convert.ToString(quantityInt);
                ((TextBox)e.Item.FindControl("quantityTextBox")).Text = quantityString;

                string pointsNeededString = MSPointsNeededLabel.Text;
                int pointsNeededInt = Convert.ToInt32(pointsNeededString);
                int pointsToDeduct = Convert.ToInt32(((Label)e.Item.FindControl("pointsRequiredLabel")).Text);
                pointsNeededInt = pointsNeededInt - pointsToDeduct;

                if (pointsNeededInt > Convert.ToInt32(userMSPointsLabel.Text))
                {
                    MSPointsNeededLabel.ForeColor = System.Drawing.Color.Red;
                }
                else if (pointsNeededInt < Convert.ToInt32(userMSPointsLabel.Text))
                {
                    MSPointsNeededLabel.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    MSPointsNeededLabel.ForeColor = System.Drawing.Color.Black;
                }

                pointsNeededString = Convert.ToString(pointsNeededInt);
                MSPointsNeededLabel.Text = pointsNeededString;

                List<RedeemedVoucher> redeemedVoucherList;
                int plusButtonClicked;

                redeemedVoucherList = (List<RedeemedVoucher>)Session["redeemedVoucherList"];

                plusButtonClicked = Convert.ToInt32(Session["plusButtonClicked"]);

                for (int i = 0; i < redeemedVoucherList.Count; i++)
                {
                    int voucherID = Convert.ToInt32(((Label)e.Item.FindControl("voucherIDLabel")).Text);

                    if (redeemedVoucherList[i].getVoucherID() == voucherID)
                    {
                        if (Convert.ToInt32(((TextBox)e.Item.FindControl("quantityTextBox")).Text) != 0)
                        {
                            redeemedVoucherList[i].setVoucherRedeemedQuantity(Convert.ToInt32(((TextBox)e.Item.FindControl("quantityTextBox")).Text));
                            Session["redeemedVoucherList"] = redeemedVoucherList;
                        }
                        else if (Convert.ToInt32(((TextBox)e.Item.FindControl("quantityTextBox")).Text) == 0)
                        {
                            redeemedVoucherList.RemoveAt(i);
                            Session["redeemedVoucherList"] = redeemedVoucherList;

                            if (redeemedVoucherList.Count == 0)
                            {
                                plusButtonClicked = 0;
                                Session["plusButtonClicked"] = plusButtonClicked;
                            }
                        }
                    }
                }
            }
        }

        protected void redeemVouchersButton_Clicked(object sender, ImageClickEventArgs e)
        {
            if (MSPointsNeededLabel.ForeColor == System.Drawing.Color.Red)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "vouchersRedemptionFailedScript", "alert('Insufficient points!');", true);
            }
            else if (MSPointsNeededLabel.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "vouchersRedemptionFailedScript", "alert('No voucher selected!');", true);
            }
            else
            {
                RedemptionHistory rh1 = new RedemptionHistory();
                rh1.createRedemptionHistory(user.getUserID(), Convert.ToInt32(MSPointsNeededLabel.Text));
                int redemptionID = rh1.retrieveLastRedemptionID(user.getUserID());
                List<RedeemedVoucher> redeemedVoucherList = (List<RedeemedVoucher>)Session["redeemedVoucherList"];

                for (int i = 0; i < redeemedVoucherList.Count; i++)
                {
                    RedeemedVoucher r1 = redeemedVoucherList[i];
                    r1.createRedeemedVoucher(userID, redemptionID, r1.getVoucherID(), r1.getVoucherRedeemedQuantity());
                }

                user.updateUserMSPoints(userID, -Convert.ToInt32(MSPointsNeededLabel.Text));

                ScriptManager.RegisterStartupScript(this, typeof(string), "vouchersRedemptionSuccessScript", "alert('Redeemed Successfully!');", true);
                Response.Redirect("RedemptionStore.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RedemptionHist.aspx");
        }
    }
}