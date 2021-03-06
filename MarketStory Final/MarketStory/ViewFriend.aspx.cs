﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Entities;
using MySql.Data.MySqlClient;
using System.Data;
using MarketStory.Controls;

namespace MarketStory
{
    public partial class ViewFriend : System.Web.UI.Page
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