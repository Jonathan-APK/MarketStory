using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Entities;

namespace MarketStory.Market
{
    public partial class Market : System.Web.UI.Page
    {
        int sellerID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                int boothID = Convert.ToInt32(Request.QueryString["booth"]);
                sellerID = Booth.retrieveSellerID(boothID);
                User seller = new User();
                Booth booth = new Booth();
                List<Product> productList = new List<Product>();
                seller = seller.retrieveBoothOwnerInfo(sellerID);
                booth = booth.retrieveBooth(sellerID);
                productList = Product.retrieveProductsFromBooth(boothID);

                Image1.ImageUrl = HttpUtility.HtmlEncode(seller.getProfilePicture());
                Label2.Text = HttpUtility.HtmlEncode(seller.getUsername());
                Label1.Text = HttpUtility.HtmlEncode(Convert.ToString(seller.getRepPoints()));
                Label3.Text = HttpUtility.HtmlEncode(booth.getBoothName());

                if (productList.Count != 0)
                {
                    if (productList.Count == 1)
                    {
                        displayProduct1(productList[0]);
                    }
                    if (productList.Count == 2)
                    {
                        displayProduct1(productList[0]);
                        displayProduct2(productList[1]);
                    }
                    if (productList.Count == 3)
                    {
                        displayProduct1(productList[0]);
                        displayProduct2(productList[1]);
                        displayProduct3(productList[2]);
                    }
                    if (productList.Count == 4)
                    {
                        displayProduct1(productList[0]);
                        displayProduct2(productList[1]);
                        displayProduct3(productList[2]);
                        displayProduct4(productList[3]);
                    }
                    if (productList.Count == 5)
                    {
                        displayProduct1(productList[0]);
                        displayProduct2(productList[1]);
                        displayProduct3(productList[2]);
                        displayProduct4(productList[3]);
                        displayProduct5(productList[4]);
                    }
                    if (productList.Count == 6)
                    {
                        displayProduct1(productList[0]);
                        displayProduct2(productList[1]);
                        displayProduct3(productList[2]);
                        displayProduct4(productList[3]);
                        displayProduct5(productList[4]);
                        displayProduct6(productList[5]);
                    }
                    if (productList.Count == 7)
                    {
                        displayProduct1(productList[0]);
                        displayProduct2(productList[1]);
                        displayProduct3(productList[2]);
                        displayProduct4(productList[3]);
                        displayProduct5(productList[4]);
                        displayProduct6(productList[5]);
                        displayProduct7(productList[6]);
                    }
                    if (productList.Count == 8)
                    {
                        displayProduct1(productList[0]);
                        displayProduct2(productList[1]);
                        displayProduct3(productList[2]);
                        displayProduct4(productList[3]);
                        displayProduct5(productList[4]);
                        displayProduct6(productList[5]);
                        displayProduct7(productList[6]);
                        displayProduct8(productList[7]);
                    }
                }
            }
            else
            {
                Session["login"] = false;
                Response.Redirect("~/MainPage.aspx");
            }
        }

        protected void displayProduct1(Product p)
        {
            ImageButton9.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton9.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label4.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label5.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label6.Text = HttpUtility.HtmlEncode("Quantity: " + Convert.ToString(p.getAvailableQuantity()));
            ImageButton9.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            ImageButton1.Visible = true;
        }

        protected void displayProduct2(Product p)
        {
            ImageButton13.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton13.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label7.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label8.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label9.Text = HttpUtility.HtmlEncode("Quantity: " + Convert.ToString(p.getAvailableQuantity()));
            ImageButton13.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            ImageButton2.Visible = true;
        }

        protected void displayProduct3(Product p)
        {
            ImageButton10.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton10.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label10.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label11.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label12.Text = HttpUtility.HtmlEncode("Quantity: " + Convert.ToString(p.getAvailableQuantity()));
            ImageButton10.Visible = true;
            Label10.Visible = true;
            Label11.Visible = true;
            Label12.Visible = true;
            ImageButton3.Visible = true;
        }

        protected void displayProduct4(Product p)
        {
            ImageButton14.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton14.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label13.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label14.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label15.Text = HttpUtility.HtmlEncode("Quantity: " + Convert.ToString(p.getAvailableQuantity()));
            ImageButton14.Visible = true;
            Label13.Visible = true;
            Label14.Visible = true;
            Label15.Visible = true;
            ImageButton4.Visible = true;
        }

        protected void displayProduct5(Product p)
        {
            ImageButton11.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton11.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label16.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label17.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label18.Text = HttpUtility.HtmlEncode("Quantity: " + Convert.ToString(p.getAvailableQuantity()));
            ImageButton11.Visible = true;
            Label16.Visible = true;
            Label17.Visible = true;
            Label18.Visible = true;
            ImageButton5.Visible = true;
        }

        protected void displayProduct6(Product p)
        {
            ImageButton15.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton15.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label19.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label20.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label21.Text = HttpUtility.HtmlEncode("Quantity: " + Convert.ToString(p.getAvailableQuantity()));
            ImageButton15.Visible = true;
            Label19.Visible = true;
            Label20.Visible = true;
            Label21.Visible = true;
            ImageButton6.Visible = true;
        }

        protected void displayProduct7(Product p)
        {
            ImageButton12.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton12.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label22.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label23.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label24.Text = HttpUtility.HtmlEncode("Quantity: " + Convert.ToString(p.getAvailableQuantity()));
            ImageButton12.Visible = true;
            Label22.Visible = true;
            Label23.Visible = true;
            Label24.Visible = true;
            ImageButton7.Visible = true;
        }

        protected void displayProduct8(Product p)
        {
            ImageButton16.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            ImageButton16.CommandName = HttpUtility.HtmlEncode(Convert.ToString(p.getProductID()));
            Label25.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label26.Text = HttpUtility.HtmlEncode("Price: S$" + Convert.ToString(p.getPrice()) + "/Item");
            Label27.Text = HttpUtility.HtmlEncode("Quantity: " + Convert.ToString(p.getAvailableQuantity()));
            ImageButton16.Visible = true;
            Label25.Visible = true;
            Label26.Visible = true;
            Label27.Visible = true;
            ImageButton8.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["profileID"] = sellerID;
            ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('ViewFriend.aspx', '_newtab');", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Panaroma.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            string productID = HttpUtility.HtmlEncode(ImageButton10.CommandName);
            Response.Redirect("~/AddToCart.aspx");
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            string productID = HttpUtility.HtmlEncode(ImageButton9.CommandName);
            int boothID = Convert.ToInt32(Request.QueryString["booth"]);
            string temp = "~/ProductInf.aspx?booth=" + HttpUtility.HtmlEncode(boothID) + "&product=" + HttpUtility.HtmlEncode(productID);
            Response.Redirect(temp);
        }

        protected void ImageButton13_Click(object sender, ImageClickEventArgs e)
        {
            string productID = HttpUtility.HtmlEncode(ImageButton13.CommandName);
            int boothID = Convert.ToInt32(Request.QueryString["booth"]);
            string temp = "~/ProductInf.aspx?booth=" + HttpUtility.HtmlEncode(boothID) + "&product=" + HttpUtility.HtmlEncode(productID);
            Response.Redirect(temp);
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            string productID = HttpUtility.HtmlEncode(ImageButton10.CommandName);
            int boothID = Convert.ToInt32(Request.QueryString["booth"]);
            string temp = "~/ProductInf.aspx?booth=" + HttpUtility.HtmlEncode(boothID) + "&product=" + HttpUtility.HtmlEncode(productID);
            Response.Redirect(temp);
        }

        protected void ImageButton14_Click(object sender, ImageClickEventArgs e)
        {
            string productID = HttpUtility.HtmlEncode(ImageButton14.CommandName);
            int boothID = Convert.ToInt32(Request.QueryString["booth"]);
            string temp = "~/ProductInf.aspx?booth=" + HttpUtility.HtmlEncode(boothID) + "&product=" + HttpUtility.HtmlEncode(productID);
            Response.Redirect(temp);
        }

        protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
        {
            string productID = HttpUtility.HtmlEncode(ImageButton11.CommandName);
            int boothID = Convert.ToInt32(Request.QueryString["booth"]);
            string temp = "~/ProductInf.aspx?booth=" + HttpUtility.HtmlEncode(boothID) + "&product=" + HttpUtility.HtmlEncode(productID);
            Response.Redirect(temp);
        }

        protected void ImageButton12_Click(object sender, ImageClickEventArgs e)
        {
            string productID = HttpUtility.HtmlEncode(ImageButton12.CommandName);
            int boothID = Convert.ToInt32(Request.QueryString["booth"]);
            string temp = "~/ProductInf.aspx?booth=" + HttpUtility.HtmlEncode(boothID) + "&product=" + HttpUtility.HtmlEncode(productID);
            Response.Redirect(temp);
        }

        protected void ImageButton15_Click(object sender, ImageClickEventArgs e)
        {
            string productID = HttpUtility.HtmlEncode(ImageButton15.CommandName);
            int boothID = Convert.ToInt32(Request.QueryString["booth"]);
            string temp = "~/ProductInf.aspx?booth=" + HttpUtility.HtmlEncode(boothID) + "&product=" + HttpUtility.HtmlEncode(productID);
            Response.Redirect(temp);
        }

        protected void ImageButton16_Click(object sender, ImageClickEventArgs e)
        {
            string productID = HttpUtility.HtmlEncode(ImageButton16.CommandName);
            int boothID = Convert.ToInt32(Request.QueryString["booth"]);
            string temp = "~/ProductInf.aspx?booth=" + HttpUtility.HtmlEncode(boothID) + "&product=" + HttpUtility.HtmlEncode(productID);
            Response.Redirect(temp);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["productID"] = HttpUtility.HtmlEncode(ImageButton9.CommandName);
            Response.Redirect("~/AddToCart.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Session["productID"] = HttpUtility.HtmlEncode(ImageButton13.CommandName);
            Response.Redirect("~/AddToCart.aspx");
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Session["productID"] = HttpUtility.HtmlEncode(ImageButton14.CommandName);
            Response.Redirect("~/AddToCart.aspx");
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            Session["productID"] = HttpUtility.HtmlEncode(ImageButton11.CommandName);
            Response.Redirect("~/AddToCart.aspx");
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            Session["productID"] = HttpUtility.HtmlEncode(ImageButton15.CommandName);
            Response.Redirect("~/AddToCart.aspx");
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            Session["productID"] = HttpUtility.HtmlEncode(ImageButton12.CommandName);
            Response.Redirect("~/AddToCart.aspx");
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            Session["productID"] = HttpUtility.HtmlEncode(ImageButton16.CommandName);
            Response.Redirect("~/AddToCart.aspx");
        }
    }
}