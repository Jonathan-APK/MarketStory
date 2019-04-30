using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using MarketStory.Entities;

namespace MarketStory
{
    public partial class ReviewOrder : System.Web.UI.Page
    {
        int userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                userID = Convert.ToInt32(Session["userID"]);
                SqlDataSource1.SelectCommand = "SELECT op.orderedProductsID, op.productOrderedQuantity, op.productDeliveryStatus, op.trackingInformation, op.additionalComments, op.sellerID, p.productName, p.price, p.photo, p.information, p.productID from orders o INNER JOIN orderedproducts op ON o.orderID = op.orderID INNER JOIN products p on op.productID = p.productID WHERE o.orderID = ?";
            }
            else
            {
                Session["login"] = false;
                Response.Redirect("MainPage.aspx");
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            orderedContentList.ItemCommand += new EventHandler<ListViewCommandEventArgs>(List_ItemCommand);
        }

        private void List_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "writeReview":
                    {
                        string temp = Convert.ToString(e.CommandArgument);
                        string[] tempArray = temp.Split(new char[] { ';' });

                        int productID = Convert.ToInt32(tempArray[0]);
                        int orderedProductsID = Convert.ToInt32(tempArray[1]);

                        Product prod = new Product();
                        OrderedProduct op = new OrderedProduct();
                        if (prod.checkReviewWritten(Convert.ToInt32(Session["userID"]), productID) == true)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(string), "writeReviewFailedScript", "alert('You have already posted a review before!');", true);
                        }
                        else if (op.checkDeliveryStatusConfirmed(orderedProductsID) == false)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(string), "writeReviewFailedScript", "alert('Please confirm the delivery first!');", true);
                        }
                        else
                        {
                            ((ListView)sender).SelectedIndex = e.Item.DisplayIndex;
                            orderedContentList.SetEditItem(((ListView)sender).SelectedIndex);
                        }
                        break;
                    }
                case "confirmDelivery":
                    {
                        int i = Convert.ToInt32(e.CommandArgument);
                        confirmDelivery(i, e);
                        break;
                    }
                case "upRepPoints":
                    {
                        upRepPointsButton_Click(e);
                        break;
                    }
                case "downRepPoints":
                    {
                        downRepPointsButton_Click(e);
                        break;
                    }
                case "postReview":
                    {
                        postReviewButton_Click(e);
                        break;
                    }
            }
        }

        private void confirmDelivery(int orderedProductsID, ListViewCommandEventArgs e)
        {
            OrderedProduct op = new OrderedProduct();
            User seller = new User();

            if (HiddenField1.Value == "Yes")
            {
                if (op.checkDeliveryStatusConfirmed(orderedProductsID) == false)
                {
                    if (op.checkDeliveryStatusPending(orderedProductsID) == true)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "confirmDeliveryFailedScript", "alert('This item is still pending!');", true);
                    }
                    else
                    {
                        op.updateDeliveryStatus(orderedProductsID, "Delivery Confirmed");

                        int sellerID = Convert.ToInt32(((HiddenField)e.Item.FindControl("HiddenField1")).Value);
                        sellerID = 1;
                        int totalPrice = Convert.ToInt32(((Label)e.Item.FindControl("displayPrice")).Text) * Convert.ToInt32(((Label)e.Item.FindControl("displayOrderedQuantity")).Text);
                        seller.updateUserAccountBalance(sellerID, totalPrice);
                        seller.updateUserMSPoints(sellerID, 5);

                        seller = seller.retrieveUser(sellerID);
                        GmailSMTP smtp = new GmailSMTP();
                        string itemName = ((Label)e.Item.FindControl("displayProductName")).Text;
                        string itemOrderedQuantity = ((Label)e.Item.FindControl("displayOrderedQuantity")).Text;
                        string itemDeliveryConfirmed = "Item: " + itemName + "\nQuantity ordered from Buyer: " + itemOrderedQuantity + "\nDelivery confirmed on: " + DateTime.Now.ToString() + "\n\nYour earnings of $" + totalPrice + " has been credited to your account\n\nThank you for using MarketStory";
                        smtp.Send(seller.getEmail(), "MarketStory Item Delivery Confirmed", "The following item has been confirmed to be sent to the buyer: \n\n" + itemDeliveryConfirmed, true);

                        ScriptManager.RegisterStartupScript(this, typeof(string), "confirmDeliverySuccessScript", "alert('Delivery confirmed!');", true);
                        orderedContentList.DataBind();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "confirmDeliveryFailedScript", "alert('This item has already been confirmed of delivery!');", true);
                }
            }
            else if (HiddenField1.Value == "No")
            {
            }
        }

        private void upRepPointsButton_Click(ListViewCommandEventArgs e)
        {
            ((ImageButton)e.Item.FindControl("upRepPointsButton")).ImageUrl = "~/Images/repPointsIconSelected.PNG";
            ((ImageButton)e.Item.FindControl("downRepPointsButton")).ImageUrl = "~/Images/repPointsIconInverted.PNG";
            ((ImageButton)e.Item.FindControl("upRepPointsButton")).Enabled = false;
            ((ImageButton)e.Item.FindControl("downRepPointsButton")).Enabled = false;
        }

        private void downRepPointsButton_Click(ListViewCommandEventArgs e)
        {
            ((ImageButton)e.Item.FindControl("upRepPointsButton")).ImageUrl = "~/Images/repPointsIcon.PNG";
            ((ImageButton)e.Item.FindControl("downRepPointsButton")).ImageUrl = "~/Images/repPointsIconInvertedSelected.PNG";
            ((ImageButton)e.Item.FindControl("upRepPointsButton")).Enabled = false;
            ((ImageButton)e.Item.FindControl("downRepPointsButton")).Enabled = false;
        }

        private void postReviewButton_Click(ListViewCommandEventArgs e)
        {
            if (((TextBox)e.Item.FindControl("reviewTextBox")).Text == "Fill up your review here . . .")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "postReviewFailedScript", "alert('Please fill up the review!');", true);
            }
            else if (((ImageButton)e.Item.FindControl("upRepPointsButton")).Enabled == true || ((ImageButton)e.Item.FindControl("downRepPointsButton")).Enabled == true)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "postReviewFailedScript", "alert('Please rate the product or service!');", true);
            }
            else
            {
                string temp = Convert.ToString(e.CommandArgument);
                string[] tempArray = temp.Split(new char[] { ';' });

                int productID = Convert.ToInt32(tempArray[0]);

                string reviewText = ((TextBox)e.Item.FindControl("reviewTextBox")).Text;
                string review = Convert.ToString(Session["userID"]) + ";" + reviewText;

                Product prod = new Product();
                prod.writeReview(productID, review);

                if (((ImageButton)e.Item.FindControl("upRepPointsButton")).ImageUrl == "~/Images/repPointsIconSelected.PNG")
                {
                    int sellerID = Convert.ToInt32(((ImageButton)e.Item.FindControl("upRepPointsButton")).CommandArgument);
                    User user = new User();
                    user.updateUserRepPoints(sellerID, +1);
                }
                else if (((ImageButton)e.Item.FindControl("downRepPointsButton")).ImageUrl == "~/Images/repPointsIconInvertedSelected.PNG")
                {
                    int sellerID = Convert.ToInt32(((ImageButton)e.Item.FindControl("downRepPointsButton")).CommandArgument);
                    User user = new User();
                    user.updateUserRepPoints(sellerID, -1);
                }

                ScriptManager.RegisterStartupScript(this, typeof(string), "postReviewSuccessScript", "alert('Thank you for the review!');", true);
                orderedContentList.EditIndex = -1;
                orderedContentList.DataBind();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Orders.aspx");
        }
    }
}