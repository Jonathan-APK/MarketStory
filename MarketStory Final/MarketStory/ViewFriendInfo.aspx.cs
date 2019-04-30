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
    public partial class ViewFriendInfo : System.Web.UI.Page
    {
        string connectionString = "";

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

        private string retrieveUsername(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "SELECT * FROM users WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string username = "";

            try
            {
                while (dr.Read() == true)
                {
                    username = dr["username"].ToString();
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

            return username;
        }

        private string retrieveEmail(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "SELECT * FROM users WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string email = "";

            try
            {
                while (dr.Read() == true)
                {
                    email = dr["email"].ToString();
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

            return email;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userID"] != null)
                {
                    int userID = Convert.ToInt32(Session["profileID"]);

                    string imagePath = retrieveProfilePicture(userID);
                    ImageProfilePicture.ImageUrl = imagePath;
                    LabelProfileUsername.Text = HttpUtility.HtmlEncode(retrieveName(userID));
                    LabelUsername.Text = HttpUtility.HtmlEncode("Username: " + retrieveUsername(userID));
                    LabelEmail.Text = HttpUtility.HtmlEncode("Email: " + retrieveEmail(userID));
                    LabelGender.Text = HttpUtility.HtmlEncode("Gender: " + retrieveGender(userID));
                    User u1 = new User();
                    u1 = u1.retrieveUser(userID);
                    int temp = u1.getRepPoints();
                    LabelRepPoints.Text = "Reputation: " + temp.ToString();
                    TextBoxInfo.Text = retrieveInfo(userID);

                }
                else
                {
                    Session["login"] = false;
                    Response.Redirect("~/MainPage.aspx");
                }
            }
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            reportBox.Visible = true;
        }


        protected void sumitbutton_Click(object sender, EventArgs e)
        {

            DataAccess a = new DataAccess();
            if (scamButton.Checked == true)
            {

                DateTime now = DateTime.Now;
                string time = now.ToString("MMM") + " " + now.ToString("dd") + ", " + now.ToString("hh") + ":" + now.ToString("mm") + now.ToString("tt");
                string user = a.getUserName(Convert.ToInt32(Session["userID"]));
                string reportedUser = LabelProfileUsername.Text;
                a.insertReport("scamming", user, reportedUser, time);
                System.Windows.Forms.MessageBox.Show("Report successfully submitted");
            }
            else if (harassmentButton.Checked == true)
            {

                DateTime now = DateTime.Now;
                String time = now.ToString("MMM") + " " + now.ToString("dd") + ", " + now.ToString("hh") + ":" + now.ToString("mm") + now.ToString("tt");
                string user = a.getUserName(Convert.ToInt32(Session["userID"]));
                string reportedUser = LabelProfileUsername.Text;
                a.insertReport("harassment", user, reportedUser, time);
                System.Windows.Forms.MessageBox.Show("Report successfully submitted");
            }
            else if (violenceButton.Checked == true)
            {
                DateTime now = DateTime.Now;
                String time = now.ToString("MMM") + " " + now.ToString("dd") + ", " + now.ToString("hh") + ":" + now.ToString("mm") + now.ToString("tt");
                string user = a.getUserName(Convert.ToInt32(Session["userID"]));
                string reportedUser = LabelProfileUsername.Text;
                a.insertReport("violence or harmful post", user, reportedUser, time);
                System.Windows.Forms.MessageBox.Show("Report successfully submitted");
            }
            else if (spamButton.Checked == true)
            {
                DateTime now = DateTime.Now;
                String time = now.ToString("MMM") + " " + now.ToString("dd") + ", " + now.ToString("hh") + ":" + now.ToString("mm") + now.ToString("tt");
                string user = a.getUserName(Convert.ToInt32(Session["userID"]));
                string reportedUser = LabelProfileUsername.Text;
                a.insertReport("spamming of post", user, reportedUser, time);
                System.Windows.Forms.MessageBox.Show("Report successfully submitted");
            }
            else if (sexualButton.Checked == true)
            {
                DateTime now = DateTime.Now;
                String time = now.ToString("MMM") + " " + now.ToString("dd") + ", " + now.ToString("hh") + ":" + now.ToString("mm") + now.ToString("tt");
                string user = a.getUserName(Convert.ToInt32(Session["userID"]));
                string reportedUser = LabelProfileUsername.Text;
                a.insertReport("posting sexually explicit content", user, reportedUser, time);
                System.Windows.Forms.MessageBox.Show("Report successfully submitted");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please Select An Option");
            }


        }

        protected void cancelbutton_Click(object sender, EventArgs e)
        {
            reportBox.Visible = false;
        }
    }
}