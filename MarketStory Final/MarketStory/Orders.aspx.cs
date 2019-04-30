using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Entities;

namespace MarketStory
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                SqlDataSource1.SelectCommand = "SELECT op.orderedProductsID, op.productOrderedQuantity, op.recipientAddress, op.productDeliveryStatus, op.trackingInformation, op.additionalComments, p.productName, p.photo, o.buyerID from orderedproducts op INNER JOIN products p on op.productID = p.productID INNER JOIN orders o on op.orderID = o.orderID WHERE sellerID = ? ORDER BY length(op.productDeliveryStatus)";
                SqlDataSource1.UpdateCommand = "UPDATE orderedProducts SET productDeliveryStatus=@productDeliveryStatus, trackingInformation=@trackingInformation, additionalComments=@additionalComments WHERE orderedProductsID=@orderedproductsID";
                SqlDataSource2.SelectCommand = "SELECT orderID, subtotal, timestamp FROM orders WHERE buyerID = ? ORDER BY orderID DESC";
            }
            else
            {
                Session["login"] = false;
                Response.Redirect("MainPage.aspx");
            }
        }

        protected void orderRequestsButton_Click(object sender, ImageClickEventArgs e)
        {
            orderRequestList.Visible = true;
            myOrdersList.Visible = false;
            orderRequestsButton.ImageUrl = "~/Images/Orders/orderRequestsButtonSelected.PNG";
            myOrdersButton.ImageUrl = "~/Images/Orders/myOrdersButton.PNG";
        }

        protected void myOrdersButton_Click(object sender, ImageClickEventArgs e)
        {
            orderRequestList.Visible = false;
            myOrdersList.Visible = true;
            orderRequestsButton.ImageUrl = "~/Images/Orders/orderRequestsButton.PNG";
            myOrdersButton.ImageUrl = "~/Images/Orders/myOrdersButtonSelected.PNG";
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            orderRequestList.ItemCommand += new EventHandler<ListViewCommandEventArgs>(List_ItemCommand);
            myOrdersList.ItemCommand += new EventHandler<ListViewCommandEventArgs>(List_ItemCommand);
        }

        private void List_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "updateRequest":
                    {
                        int i = Convert.ToInt32(e.CommandArgument);

                        OrderedProduct op = new OrderedProduct();

                        if (op.checkDeliveryStatusSent(i) == true)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(string), "updateRequestFailedScript", "alert('You have already sent the item on delivery!');", true);
                        }
                        else if (op.checkDeliveryStatusConfirmed(i) == true)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(string), "updateRequestFailedScript", "alert('The buyer has already confirmed the delivery!');", true);
                        }
                        else
                        {
                            ((ListView)sender).SelectedIndex = e.Item.DisplayIndex;
                            orderRequestList.SetEditItem(((ListView)sender).SelectedIndex);
                        }
                        break;
                    }
                case "updateOrderedProduct":
                    {
                        updateOrderedProduct(Convert.ToString(e.CommandArgument), e);
                        break;
                    }
                case "reviewOrder":
                    {
                        int i = Convert.ToInt32(e.CommandArgument);
                        reviewOrder(i);
                        break;
                    }
            }
        }

        private void updateOrderedProduct(string orderedProductsID, ListViewCommandEventArgs e)
        {
            if (((DropDownList)e.Item.FindControl("productDeliveryStatus")).SelectedValue == "CANCELLED" && ((TextBox)e.Item.FindControl("additionalComments")).Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "requestCancelledScript", "alert('Please leave your reason for cancellation of the order request in the Additional Comments section!');", true);
            }
            else
            {
                SqlDataSource1.UpdateParameters.Add("@productDeliveryStatus", ((DropDownList)e.Item.FindControl("productDeliveryStatus")).SelectedValue);
                SqlDataSource1.UpdateParameters.Add("@trackingInformation", ((TextBox)e.Item.FindControl("trackingInformation")).Text);
                SqlDataSource1.UpdateParameters.Add("@orderedProductsID", orderedProductsID);
                SqlDataSource1.UpdateParameters.Add("@additionalCOmments", ((TextBox)e.Item.FindControl("additionalComments")).Text);
                SqlDataSource1.Update();

                if (((DropDownList)e.Item.FindControl("productDeliveryStatus")).SelectedValue == "On Delivery")
                {
                    User buyer = new User();
                    buyer = buyer.retrieveUser(Convert.ToInt32(((HiddenField)e.Item.FindControl("HiddenField1")).Value));
                    GmailSMTP smtp = new GmailSMTP();
                    string itemName = ((Label)e.Item.FindControl("displayProductName")).Text;
                    string itemOrderedQuantity = ((Label)e.Item.FindControl("displayOrderedQuantity")).Text;
                    string itemSentOnDelivery = "Item: " + itemName + "\nQuantity you ordered: " + itemOrderedQuantity + "\nDelivery sent on: " + DateTime.Now.ToString() + "\n\nPlease login to MarketStory to find out the tracking information(if any)\n\nThank you for using MarketStory";
                    smtp.Send(buyer.getEmail(), "MarketStory Item On Delivery", "The following item has been sent on delivery by the seller: \n\n" + itemSentOnDelivery, true);
                }
                else if (((DropDownList)e.Item.FindControl("productDeliveryStatus")).SelectedValue == "CANCELLED")
                {
                    User buyer = new User();
                    buyer = buyer.retrieveUser(Convert.ToInt32(((HiddenField)e.Item.FindControl("HiddenField1")).Value));
                    GmailSMTP smtp = new GmailSMTP();
                    string itemName = ((Label)e.Item.FindControl("displayProductName")).Text;
                    string itemOrderedQuantity = ((Label)e.Item.FindControl("displayOrderedQuantity")).Text;
                    string itemDeliveryCancelled = "Item: " + itemName + "\nQuantity you ordered: " + itemOrderedQuantity + "\nOrder cancelled on: " + DateTime.Now.ToString() + "\n\nPlease login to MarketStory to find out the reason of the seller's cancellation\n\nThank you for using MarketStory";
                    smtp.Send(buyer.getEmail(), "MarketStory Item Delivery CANCELLED", "The following item has been cancelled by the seller: \n\n" + itemDeliveryCancelled, true);
                }

                orderRequestList.EditIndex = -1;
                orderRequestList.DataBind();
            }
        }

        private void reviewOrder(int orderIDSelected)
        {
            Session["orderID"] = orderIDSelected;
            Response.Redirect("~/ReviewOrder.aspx");
        }
    }
}