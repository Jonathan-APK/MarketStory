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
    public partial class ProfileSubscriptions : System.Web.UI.Page
    {
        string connectionString = "";
        DataAccess dbClass = new DataAccess();
        public DataTable dt;

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

        private string retrieveFriendListID(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "SELECT * FROM users WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string friendID = "";

            try
            {
                while (dr.Read() == true)
                {
                    friendID = dr["subscriptionList"].ToString();
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

            return friendID;
        }

        private void updateSubscriptionList(int id, string list)
        {
            string Query = "UPDATE users SET subscriptionList = @list WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@list", list);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userID"] != null)
                {
                    User user = new User();
                    List<User> list = new List<User>();
                    int userID = Convert.ToInt32(Session["userID"]);
                    string imagePath = retrieveProfilePicture(userID);
                    ImageProfilePicture.ImageUrl = imagePath;
                    LabelProfileUsername.Text = HttpUtility.HtmlEncode(retrieveName(userID));
                    try
                    {
                        string str = retrieveFriendListID(userID);
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
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You do not have subscptions to show\\n\\Subscribe to some people before coming back');window.open('ProfilePosts.aspx','_self');", true);
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

        public int getUserID(User u)
        {
            return u.getUserID();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            ListView1.ItemCommand += new EventHandler<ListViewCommandEventArgs>(ListView1_ItemCommand);
        }

        void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "viewProfile":
                    {
                        Session["profileID"] = Convert.ToInt32(e.CommandArgument);
                        Response.Redirect("~/ViewFriend.aspx");
                        break;
                    }
                case "deleteSubscription":
                    {
                        int deleteID = Convert.ToInt32(e.CommandArgument);

                        int userID = Convert.ToInt32(Session["userID"]);
                        string str = retrieveFriendListID(userID);
                        string[] strArray = str.Split(new char[] { ';' });
                        List<int> strList = new List<int>();

                        for (int i = 0; i < strArray.Length; i++)
                        {
                            strList.Add(Convert.ToInt32(strArray[i]));
                        }

                        for (int i = 0; i < strList.Count; i++)
                        {
                            if (strList[i] == deleteID)
                            {
                                strList.Remove(strList[i]);
                            }
                        }
                        string updatedStr = string.Join(";", strList);
                        updateSubscriptionList(userID, updatedStr);

                        User user = new User();
                        List<User> list = new List<User>();
                        string str2 = retrieveFriendListID(userID);
                        string[] strArray2 = str2.Split(new char[] { ';' });

                        for (int i = 0; i < strArray2.Length; i++)
                        {
                            User temp = user.retrieveFriendInfo(Convert.ToInt32(strArray2[i]));
                            list.Add(temp);
                        }

                        ListView1.DataSource = HttpUtility.HtmlEncode(list);
                        ListView1.DataBind();
                        break;
                    }
            }
        }
    }
}