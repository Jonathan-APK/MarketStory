using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Entities;

namespace MarketStory.Market
{
    public partial class ProductInfo : System.Web.UI.Page
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

                seller = seller.retrieveBoothOwnerInfo(sellerID);
                booth = booth.retrieveBooth(sellerID);
                Image1.ImageUrl = HttpUtility.HtmlEncode(seller.getProfilePicture());
                Label2.Text = HttpUtility.HtmlEncode(seller.getUsername());
                Label1.Text = HttpUtility.HtmlEncode(Convert.ToString(seller.getRepPoints()));
                Label3.Text = HttpUtility.HtmlEncode(booth.getBoothName());

                int productID = Convert.ToInt32(Request.QueryString["product"]);
                Product p = new Product();
                p.retrieveProduct(productID);
                Label4.Text = HttpUtility.HtmlEncode(p.getProductName());
                Label5.Text = HttpUtility.HtmlEncode(Convert.ToString(p.getPrice()));
                Label6.Text = HttpUtility.HtmlEncode(Convert.ToString(p.getAvailableQuantity()));
                TextBox1.Text = HttpUtility.HtmlEncode(p.getInformation());

            }
            else
            {
                Session["login"] = false;
                Response.Redirect("~/MainPage.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int boothID = Convert.ToInt32(Request.QueryString["booth"]);
            string temp = "~/BoothUI.aspx?booth=" + HttpUtility.HtmlEncode(boothID);
            Response.Redirect(temp);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["productID"] = Request.QueryString["product"];
            Response.Redirect("~/ProductInfo.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/newsfeed.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["profileID"] = sellerID;
            ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('ViewFriend.aspx', '_newtab');", true);
        }
    }
}