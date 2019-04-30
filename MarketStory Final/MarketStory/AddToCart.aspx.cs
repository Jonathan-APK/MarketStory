using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Entities;

namespace MarketStory.Market
{
    public partial class AddToCart : System.Web.UI.Page
    {
        int productID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                productID = Convert.ToInt32(Session["productID"]);
                Product product = new Product();
                product = product.retrieveProductDetails(productID);
                Label1.Text = HttpUtility.HtmlEncode(product.getProductName());
                Label2.Text = HttpUtility.HtmlEncode(Convert.ToString(product.getPrice()));
                Label3.Text = HttpUtility.HtmlEncode(Convert.ToString(product.getAvailableQuantity()));
                Response.Write(productID);
            }
            else
            {
                Session["login"] = false;
                Response.Redirect("~/MainPage.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<OrderedProduct> cartItems;

            if (Session["cartItems"] == null)
                cartItems = new List<OrderedProduct>();
            else
                cartItems = (List<OrderedProduct>)Session["cartItems"];

            bool itemExists = false;

            for (int i = 0; i < cartItems.Count; i++)
            {
                if (cartItems[i].getProductID() == productID)
                {
                    itemExists = true;

                    if (Convert.ToInt32(TextBox1.Text) > 0)
                    {
                        Product p = new Product();
                        p.deductProductQuantity(productID, Convert.ToInt32(Label3.Text) - Convert.ToInt32(TextBox1.Text));
                        cartItems[i].setProductOrderedQuantity(Convert.ToInt32(TextBox1.Text));
                        Session["cartItems"] = cartItems;
                    }
                }
                else if (cartItems[i].getProductID() != productID)
                {
                    itemExists = false;
                }
            }

            if (itemExists == false)
            {
                OrderedProduct op = new OrderedProduct(productID, Convert.ToInt32(TextBox1.Text));
                cartItems.Add(op);
                Session["cartItems"] = cartItems;
            }

            Response.Redirect("~/Cart.aspx");
        }
    }
}