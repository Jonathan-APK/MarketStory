using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Entities;

namespace MarketStory.Market
{
    public partial class Cart : System.Web.UI.Page
    {
        int userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                Button1.Attributes.Add("onclick", "window.close();");
                userID = Convert.ToInt32(Session["userID"]);
                User user = new User();
                user = user.retrieveBoothOwnerInfo(userID);
                Image1.ImageUrl = HttpUtility.HtmlEncode(user.getProfilePicture());
                Label2.Text = HttpUtility.HtmlEncode(user.getUsername());

                List<OrderedProduct> cartItems = new List<OrderedProduct>();
                cartItems = (List<OrderedProduct>)(Session["cartItems"]);

                try
                {
                    if (cartItems.Count != 0)
                    {
                        if (cartItems.Count == 1)
                        {
                            displayProduct1(cartItems[0]);
                        }
                        if (cartItems.Count == 2)
                        {
                            displayProduct1(cartItems[0]);
                            displayProduct2(cartItems[1]);
                        }
                        if (cartItems.Count == 3)
                        {
                            displayProduct1(cartItems[0]);
                            displayProduct2(cartItems[1]);
                            displayProduct3(cartItems[2]);
                        }
                        if (cartItems.Count == 4)
                        {
                            displayProduct1(cartItems[0]);
                            displayProduct2(cartItems[1]);
                            displayProduct3(cartItems[2]);
                            displayProduct4(cartItems[3]);
                        }
                        if (cartItems.Count == 5)
                        {
                            displayProduct1(cartItems[0]);
                            displayProduct2(cartItems[1]);
                            displayProduct3(cartItems[2]);
                            displayProduct4(cartItems[3]);
                            displayProduct5(cartItems[4]);
                        }
                        if (cartItems.Count == 6)
                        {
                            displayProduct1(cartItems[0]);
                            displayProduct2(cartItems[1]);
                            displayProduct3(cartItems[2]);
                            displayProduct4(cartItems[3]);
                            displayProduct5(cartItems[4]);
                            displayProduct6(cartItems[5]);
                        }
                        if (cartItems.Count == 7)
                        {
                            displayProduct1(cartItems[0]);
                            displayProduct2(cartItems[1]);
                            displayProduct3(cartItems[2]);
                            displayProduct4(cartItems[3]);
                            displayProduct5(cartItems[4]);
                            displayProduct6(cartItems[5]);
                            displayProduct7(cartItems[6]);
                        }
                        if (cartItems.Count == 8)
                        {
                            displayProduct1(cartItems[0]);
                            displayProduct2(cartItems[1]);
                            displayProduct3(cartItems[2]);
                            displayProduct4(cartItems[3]);
                            displayProduct5(cartItems[4]);
                            displayProduct6(cartItems[5]);
                            displayProduct7(cartItems[6]);
                            displayProduct8(cartItems[7]);
                        }
                    }
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "CartEmptyScript", "alert('No items in cart.');", true);
                }
            }
            else
            {
                Session["login"] = false;
                Response.Redirect("~/MainPage.aspx");
            }
        }

        protected void displayProduct1(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            ImageButton9.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton9.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label4.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label5.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label6.Text = HttpUtility.HtmlEncode("Quantity wanted: " + Convert.ToString(op.getProductOrderedQuantity()));
            ImageButton9.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            ImageButton1.Visible = true;
        }

        protected void displayProduct2(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            ImageButton13.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton13.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label7.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label8.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label9.Text = HttpUtility.HtmlEncode("Quantity wanted: " + Convert.ToString(op.getProductOrderedQuantity()));
            ImageButton13.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            ImageButton2.Visible = true;
        }

        protected void displayProduct3(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            ImageButton10.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton10.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label10.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label11.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label12.Text = HttpUtility.HtmlEncode("Quantity wanted: " + Convert.ToString(op.getProductOrderedQuantity()));
            ImageButton10.Visible = true;
            Label10.Visible = true;
            Label11.Visible = true;
            Label12.Visible = true;
            ImageButton3.Visible = true;
        }

        protected void displayProduct4(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            ImageButton14.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton14.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label13.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label14.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label15.Text = HttpUtility.HtmlEncode("Quantity wanted: " + Convert.ToString(op.getProductOrderedQuantity()));
            ImageButton14.Visible = true;
            Label13.Visible = true;
            Label14.Visible = true;
            Label15.Visible = true;
            ImageButton4.Visible = true;
        }

        protected void displayProduct5(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            ImageButton11.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton11.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label16.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label17.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label18.Text = HttpUtility.HtmlEncode("Quantity wanted: " + Convert.ToString(op.getProductOrderedQuantity()));
            ImageButton11.Visible = true;
            Label16.Visible = true;
            Label17.Visible = true;
            Label18.Visible = true;
            ImageButton5.Visible = true;
        }

        protected void displayProduct6(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            ImageButton15.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton15.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label19.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label20.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label21.Text = HttpUtility.HtmlEncode("Quantity wanted: " + Convert.ToString(op.getProductOrderedQuantity()));
            ImageButton15.Visible = true;
            Label19.Visible = true;
            Label20.Visible = true;
            Label21.Visible = true;
            ImageButton6.Visible = true;
        }

        protected void displayProduct7(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            ImageButton12.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton12.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label23.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label24.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label25.Text = HttpUtility.HtmlEncode("Quantity wanted: " + Convert.ToString(op.getProductOrderedQuantity()));
            ImageButton12.Visible = true;
            Label22.Visible = true;
            Label23.Visible = true;
            Label24.Visible = true;
            ImageButton7.Visible = true;
        }

        protected void displayProduct8(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            ImageButton16.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton16.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label25.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label26.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label27.Text = HttpUtility.HtmlEncode("Quantity wanted: " + Convert.ToString(op.getProductOrderedQuantity()));
            ImageButton16.Visible = true;
            Label25.Visible = true;
            Label26.Visible = true;
            Label27.Visible = true;
            ImageButton8.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> { self.close() }</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<OrderedProduct> cartItems = new List<OrderedProduct>();
            cartItems = (List<OrderedProduct>)(Session["cartItems"]);

            if (cartItems.Count != 0)
            {
                Response.Redirect("~/Temp2.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "CartEmptyScript", "alert('Cart Empty!');window.open('Panaroma.aspx', '_self');", true);
            }
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            Session["productID"] = HttpUtility.HtmlEncode(ImageButton9.CommandName);
            ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('ProductInfo.aspx', '_newtab');", true);
        }

        protected void ImageButton13_Click(object sender, ImageClickEventArgs e)
        {
            Session["productID"] = HttpUtility.HtmlEncode(ImageButton13.CommandName);
            ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('ProductInfo.aspx', '_newtab');", true);
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            Session["productID"] = HttpUtility.HtmlEncode(ImageButton10.CommandName);
            ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('ProductInfo.aspx', '_newtab');", true);
        }

        protected void ImageButton14_Click(object sender, ImageClickEventArgs e)
        {
            Session["productID"] = HttpUtility.HtmlEncode(ImageButton14.CommandName);
            ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('ProductInfo.aspx', '_newtab');", true);
        }

        protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
        {
            Session["productID"] = HttpUtility.HtmlEncode(ImageButton11.CommandName);
            ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('ProductInfo.aspx', '_newtab');", true);
        }

        protected void ImageButton12_Click(object sender, ImageClickEventArgs e)
        {
            Session["productID"] = HttpUtility.HtmlEncode(ImageButton12.CommandName);
            ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('ProductInfo.aspx', '_newtab');", true);
        }

        protected void ImageButton15_Click(object sender, ImageClickEventArgs e)
        {
            Session["productID"] = HttpUtility.HtmlEncode(ImageButton15.CommandName);
            ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('ProductInfo.aspx', '_newtab');", true);
        }

        protected void ImageButton16_Click(object sender, ImageClickEventArgs e)
        {
            Session["productID"] = HttpUtility.HtmlEncode(ImageButton16.CommandName);
            ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('ProductInfo.aspx', '_newtab');", true);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<OrderedProduct> cartItems = (List<OrderedProduct>)(Session["cartItems"]);

                for (int i = 0; i < cartItems.Count; i++)
                {
                    int productID = Convert.ToInt32(ImageButton9.CommandName);

                    if (cartItems[i].getProductID() == productID)
                    {
                        cartItems.RemoveAt(i);
                        Session["cartItems"] = cartItems;
                        Response.Redirect("~/Cart.aspx");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<OrderedProduct> cartItems = (List<OrderedProduct>)(Session["cartItems"]);

                for (int i = 0; i < cartItems.Count; i++)
                {
                    int productID = Convert.ToInt32(ImageButton13.CommandName);

                    if (cartItems[i].getProductID() == productID)
                    {
                        cartItems.RemoveAt(i);
                        Session["cartItems"] = cartItems;
                        Response.Redirect("~/Cart.aspx");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<OrderedProduct> cartItems = (List<OrderedProduct>)(Session["cartItems"]);

                for (int i = 0; i < cartItems.Count; i++)
                {
                    int productID = Convert.ToInt32(ImageButton10.CommandName);

                    if (cartItems[i].getProductID() == productID)
                    {
                        cartItems.RemoveAt(i);
                        Session["cartItems"] = cartItems;
                        Response.Redirect("~/Cart.aspx");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<OrderedProduct> cartItems = (List<OrderedProduct>)(Session["cartItems"]);

                for (int i = 0; i < cartItems.Count; i++)
                {
                    int productID = Convert.ToInt32(ImageButton14.CommandName);

                    if (cartItems[i].getProductID() == productID)
                    {
                        cartItems.RemoveAt(i);
                        Session["cartItems"] = cartItems;
                        Response.Redirect("~/Cart.aspx");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<OrderedProduct> cartItems = (List<OrderedProduct>)(Session["cartItems"]);

                for (int i = 0; i < cartItems.Count; i++)
                {
                    int productID = Convert.ToInt32(ImageButton11.CommandName);

                    if (cartItems[i].getProductID() == productID)
                    {
                        cartItems.RemoveAt(i);
                        Session["cartItems"] = cartItems;
                        Response.Redirect("~/Cart.aspx");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<OrderedProduct> cartItems = (List<OrderedProduct>)(Session["cartItems"]);

                for (int i = 0; i < cartItems.Count; i++)
                {
                    int productID = Convert.ToInt32(ImageButton15.CommandName);

                    if (cartItems[i].getProductID() == productID)
                    {
                        cartItems.RemoveAt(i);
                        Session["cartItems"] = cartItems;
                        Response.Redirect("~/Cart.aspx");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<OrderedProduct> cartItems = (List<OrderedProduct>)(Session["cartItems"]);

                for (int i = 0; i < cartItems.Count; i++)
                {
                    int productID = Convert.ToInt32(ImageButton12.CommandName);

                    if (cartItems[i].getProductID() == productID)
                    {
                        cartItems.RemoveAt(i);
                        Session["cartItems"] = cartItems;
                        Response.Redirect("~/Cart.aspx");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<OrderedProduct> cartItems = (List<OrderedProduct>)(Session["cartItems"]);

                for (int i = 0; i < cartItems.Count; i++)
                {
                    int productID = Convert.ToInt32(ImageButton16.CommandName);

                    if (cartItems[i].getProductID() == productID)
                    {
                        cartItems.RemoveAt(i);
                        Session["cartItems"] = cartItems;
                        Response.Redirect("~/Cart.aspx");
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}