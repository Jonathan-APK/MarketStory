using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Entities;
using MySql.Data.MySqlClient;

namespace MarketStory
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                Label1.Text = Request.QueryString["value"];

                if (Request.QueryString["type"] == "Users")
                {
                    productList.Visible = false;
                    userList.Visible = true;
                    searchUsersButton.ImageUrl = "~/Images/SearchResults/searchUserButtonSelected.PNG";
                    searchProductsButton.ImageUrl = "~/Images/SearchResults/searchProductButton.PNG";
                }
                else if (Request.QueryString["type"] == "Products")
                {
                    productList.Visible = true;
                    userList.Visible = false;
                    searchProductsButton.ImageUrl = "~/Images/SearchResults/searchProductButtonSelected.PNG";
                    searchUsersButton.ImageUrl = "~/Images/SearchResults/searchUserButton.PNG";
                }

                SqlDataSource1.SelectCommand = "SELECT userID, profilePicture, username, name, RepPoints FROM users WHERE username LIKE '%' ? '%' AND userID not in (?, 1)";
                SqlDataSource2.SelectCommand = "SELECT p.productID, p.photo, p.productName, p.price, p.information, p.availableQuantity, b.boothName FROM products p INNER JOIN booths b ON p.boothID = b.boothID WHERE productName LIKE '%' ? '%'";
            }
            else
            {
                Session["login"] = false;
                Response.Redirect("MainPage.aspx");
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            userList.ItemCommand += new EventHandler<ListViewCommandEventArgs>(userList_ItemCommand);
            productList.ItemCommand += new EventHandler<ListViewCommandEventArgs>(productList_ItemCommand);
        }

        private void userList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "viewProfile":
                    {
                        viewProfileButton_Click(e);
                        break;
                    }
            }
        }

        private void productList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "viewProduct":
                    {
                        viewProductButton_Click(e);
                        break;
                    }
            }
        }

        protected void searchUsersButton_Click(object sender, ImageClickEventArgs e)
        {
            productList.Visible = false;
            userList.Visible = true;
            searchUsersButton.ImageUrl = "~/Images/SearchResults/searchUserButtonSelected.PNG";
            searchProductsButton.ImageUrl = "~/Images/SearchResults/searchProductButton.PNG";
        }

        protected void searchProductsButton_Click(object sender, ImageClickEventArgs e)
        {
            productList.Visible = true;
            userList.Visible = false;
            searchProductsButton.ImageUrl = "~/Images/SearchResults/searchProductButtonSelected.PNG";
            searchUsersButton.ImageUrl = "~/Images/SearchResults/searchUserButton.PNG";
        }

        protected void viewProfileButton_Click(ListViewCommandEventArgs e)
        {
            User user = new User();
            List<User> list = new List<User>();

            int profileID = Convert.ToInt32(Session["userID"]);

            string str = retrieveSubscriptionListID(profileID);
            str = str.Remove(0, 1);
            string[] strArray = str.Split(new char[] { ';' });

            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Equals(e.CommandArgument))
                {
                    Session["profileID"] = e.CommandArgument;
                    Response.Redirect("~/ViewFriendInfo.aspx?", true);
                }
            }

            Response.Redirect("~/SubscribeFriendInfo.aspx?profileID=" + e.CommandArgument, true);
        }

        protected void viewProductButton_Click(ListViewCommandEventArgs e)
        {
            Session["productID"] = e.CommandArgument;
            Response.Redirect("~/ProductInfo.aspx", true);
        }

        private string retrieveSubscriptionListID(int id)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            string Query = "SELECT * FROM users WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string subscriptionID = "";

            try
            {
                while (dr.Read() == true)
                {
                    subscriptionID = dr["subscriptionList"].ToString();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                dr.Close();
                conn.Close();
            }

            return subscriptionID;
        }
    }
}