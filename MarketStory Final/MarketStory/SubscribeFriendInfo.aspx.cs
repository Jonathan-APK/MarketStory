using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Entities;
using MySql.Data.MySqlClient;
using System.Data;

namespace MarketStory
{
    public partial class SubscribeFriendInfo : System.Web.UI.Page
    {
        string connectionString = "";

        private string retrieveSubscriptionListID(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
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

        private string retrieveProfilePicture(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "SELECT * FROM users WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string imagePath = "";

            try
            {
                while (dr.Read() == true)
                {
                    imagePath = dr["profilePicture"].ToString();
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

            return imagePath;
        }

        private string retrieveName(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "SELECT * FROM users WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string name = "";

            try
            {
                while (dr.Read() == true)
                {
                    name = dr["name"].ToString();
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

            return name;
        }

        private string retrieveInfo(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "SELECT * FROM users WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string info = "";

            try
            {
                while (dr.Read() == true)
                {
                    info = dr["information"].ToString();
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

            return info;
        }

        private void updateSubscriptionList(int userID, int targetID)
        {
            string str = retrieveSubscriptionListID(userID);
            str += ";" + targetID;

            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "UPDATE users SET subscriptionList = @list WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", userID);
            cmd.Parameters.AddWithValue("@list", str);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        private string retrieveGender(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "SELECT * FROM users WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string gender = "";

            try
            {
                while (dr.Read() == true)
                {
                    gender = dr["gender"].ToString();
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

            return gender;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userID"] != null)
                {
                    string stringID = Request.QueryString["profileID"];
                    int profileID = Convert.ToInt32(stringID);

                    string imagePath = retrieveProfilePicture(profileID);
                    ImageProfilePicture.ImageUrl = imagePath;
                    LabelProfileUsername.Text = HttpUtility.HtmlEncode(retrieveName(profileID));
                    TextBoxInfo.Text = retrieveInfo(profileID);
                    LabelGender.Text = HttpUtility.HtmlEncode("Gender: " + retrieveGender(profileID));
                    User u1 = new User();
                    u1 = u1.retrieveUser(profileID);
                    int temp = u1.getRepPoints();
                    LabelRepPoints.Text = "Reputation: " + temp.ToString();

                    Session["profileID"] = profileID;
                }
                else
                {
                    Session["login"] = false;
                    Response.Redirect("~/MainPage.aspx");
                }
            }
        }

        protected void ButtonSubscribe_Click(object sender, EventArgs e)
        {
            int userID2 = Convert.ToInt32(Session["userID"]);
            int profileID = Convert.ToInt32(Session["profileID"]);
            updateSubscriptionList(userID2, profileID);

            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Subscription success!');window.open('ViewFriend.aspx','_self');", true);
        }
    }
}