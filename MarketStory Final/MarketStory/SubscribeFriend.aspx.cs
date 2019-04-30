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
    public partial class SubscribeFriend : System.Web.UI.Page
    {
        string connectionString = "";
        DataAccess dbClass = new DataAccess();
        public DataTable dt;

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userID"] != null)
                {
                    int profileID = Convert.ToInt32(Session["profileID"]);

                    string imagePath = retrieveProfilePicture(profileID);
                    ImageProfilePicture.ImageUrl = imagePath;
                    LabelProfileUsername.Text = HttpUtility.HtmlEncode(retrieveName(profileID));

                    User user = new User();
                    List<User> list = new List<User>();

                    try
                    {
                        string str = retrieveSubscriptionListID(profileID);
                        str = str.Remove(0, 1);
                        string[] strArray = str.Split(new char[] { ';' });

                        for (int i = 0; i < strArray.Length; i++)
                        {
                            User temp = user.retrieveFriendInfo(Convert.ToInt32(strArray[i]));
                            list.Add(temp);
                        }
                    }
                    catch (Exception)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('This person does not have any subscriptions');window.open('SubscribeFriendInfo.aspx','_self');", true);
                    }

                    ListView1.DataSource = HttpUtility.HtmlEncode(list);
                    ListView1.DataBind();
                }
                else
                {
                    Session["login"] = false;
                    Response.Redirect("~/MainPage.aspx");
                }
            }
        }

        public string getFriendUsername(User u)
        {
            return u.getFriendUsername();
        }

        public string getFriendProfilePicture(User u)
        {
            return u.getProfilePicture();
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