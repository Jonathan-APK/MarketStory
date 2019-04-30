using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using MarketStory.Entities;

namespace MarketStory.Controls
{
    public partial class post : System.Web.UI.UserControl
    {
        DataAccess dbClass = new DataAccess();
        private DataTable dt;
        private static int id;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userID"] != null)
            {
                if (!Page.IsPostBack)
                {
                    id = Convert.ToInt32(Session["userID"]);
                    GetUserPost(Convert.ToInt32(Session["userID"]));
                }

            }
            else
            {
                Session["login"] = false;
                Response.Redirect("MainPage.aspx");
            }

        }



        public void GetUserPost(int Id)
        {

            string str = dbClass.retrieveFriendListID(Id);
            if (str != null)
            {
                string formatedString = str.Replace(";", ",");
                formatedString = formatedString + "," + Id;
                formatedString = formatedString.Remove(0, 1);
                string getUserPost = "SELECT p.ID,p.content,p.timestamp,p.userId,u.name,u.profilePicture,p.blockedByFriend FROM posts p INNER JOIN users u ON p.userId = u.userId WHERE p.userId IN (@formatedString) AND p.ID NOT IN (SELECT ID FROM posts Where blockedByUser = 1 AND userId !=@Id) ORDER BY p.ID DESC";
                dt = dbClass.ConnectDataBaseReturnDT(getUserPost, formatedString, Id);
                if (dt.Rows.Count > 0)
                {
                    GridViewUserPost.DataSource = HttpUtility.HtmlEncode(dt);
                    GridViewUserPost.DataBind();
                }
            }
            else
            {
                string formatedString = str.Replace(";", ",");
                formatedString = formatedString + "" + Id;
                formatedString = formatedString.Remove(0, 1);
                string getUserPost = "SELECT p.ID,p.content,p.timestamp,p.userId,u.name,u.profilePicture,p.blockedByFriend FROM posts p INNER JOIN users u ON p.userId = u.userId WHERE p.userId IN (@formatedString) AND p.ID NOT IN (SELECT ID FROM posts Where blockedByUser = 1 AND userId !=@Id) ORDER BY p.ID DESC";
                dt = dbClass.ConnectDataBaseReturnDT(getUserPost, formatedString, Id);
                if (dt.Rows.Count > 0)
                {
                    GridViewUserPost.DataSource = HttpUtility.HtmlEncode(dt);
                    GridViewUserPost.DataBind();
                }
            }
        }

        public string getContent(object contents)
        {
            DataRowView dRView = (DataRowView)contents;
            string postID = dRView["ID"].ToString();
            string blocked = dRView["blockedByFriend"].ToString();
            List<string> blockedID = new List<string>();
            List<string> blockByFriend = blocked.Split(',').ToList();
            blockedID = dbClass.getblockedPostByUser(Convert.ToInt32(Session["userID"]));
            int testCount = 0;
            int testBlocked = 0;
            for (int i = 0; i < blockedID.Count; i++) // Loop through List with for
            {
                if (blockedID[i] == postID)
                {
                    testCount = 1;
                }
            }

            for (int i = 0; i < blockByFriend.Count; i++) // Loop through List with for
            {
                if (blockByFriend[i] == Session["userID"].ToString())
                {
                    testBlocked = 1;
                }
            }

            if (testCount == 1 || testBlocked == 1)
            {
                return ("You Have Hidden This Post");
            }
            else
            {
                return (HttpUtility.HtmlEncode(dRView["content"].ToString()));
            }
        }

        public string getName(object name)
        {
            DataRowView dRView = (DataRowView)name;
            string postID = dRView["ID"].ToString();
            string blocked = dRView["blockedByFriend"].ToString();
            List<string> blockedID = new List<string>();
            List<string> blockByFriend = blocked.Split(',').ToList();
            blockedID = dbClass.getblockedPostByUser(Convert.ToInt32(Session["userID"]));
            int testCount = 0;
            int testBlocked = 0;
            for (int i = 0; i < blockedID.Count; i++) // Loop through List with for
            {
                if (blockedID[i] == postID)
                {
                    testCount = 1;
                }
            }

            for (int i = 0; i < blockByFriend.Count; i++) // Loop through List with for
            {
                if (blockByFriend[i] == Session["userID"].ToString())
                {
                    testBlocked = 1;
                }
            }

            if (testCount == 1 || testBlocked == 1)
            {
                return "";
            }
            else
            {
                return (HttpUtility.HtmlEncode(dRView["name"].ToString()));
            }
        }

        public string getTime(object time)
        {
            DataRowView dRView = (DataRowView)time;
            string postID = dRView["ID"].ToString();
            string blocked = dRView["blockedByFriend"].ToString();
            List<string> blockedID = new List<string>();
            List<string> blockByFriend = blocked.Split(',').ToList();
            blockedID = dbClass.getblockedPostByUser(Convert.ToInt32(Session["userID"]));
            int testCount = 0;
            int testBlocked = 0;
            for (int i = 0; i < blockedID.Count; i++) // Loop through List with for
            {
                if (blockedID[i] == postID)
                {
                    testCount = 1;
                }
            }

            for (int i = 0; i < blockByFriend.Count; i++) // Loop through List with for
            {
                if (blockByFriend[i] == Session["userID"].ToString())
                {
                    testBlocked = 1;
                }
            }

            if (testCount == 1 || testBlocked == 1)
            {
                return "";
            }
            else
            {
                return (HttpUtility.HtmlEncode(dRView["timestamp"].ToString()));
            }
        }

        public string getSRC(object imgSRC)
        {
            DataRowView dRView = (DataRowView)imgSRC;
            string ImageName = dRView["profilePicture"].ToString();
            string blocked = dRView["blockedByFriend"].ToString();
            string postID = dRView["ID"].ToString();
            List<string> blockedID = new List<string>();
            List<string> blockByFriend = blocked.Split(',').ToList();
            blockedID = dbClass.getblockedPostByUser(Convert.ToInt32(Session["userID"]));
            int testCount = 0;
            int testBlocked = 0;
            for (int i = 0; i < blockedID.Count; i++) // Loop through List with for
            {
                if (blockedID[i] == postID)
                {
                    testCount = 1;
                }
            }

            for (int i = 0; i < blockByFriend.Count; i++) // Loop through List with for
            {
                if (blockByFriend[i] == Session["userID"].ToString())
                {
                    testBlocked = 1;
                }
            }

            if (testCount == 1 || testBlocked == 1)
            {
                return "";
            }
            else
            {
                return ResolveUrl(HttpUtility.HtmlEncode(dRView["profilePicture"].ToString()));
            }
        }

        protected void btnUnhideFriend_Click(object sender, EventArgs e)
        {
            string blockedlist = dbClass.getBlockedByFriend(id);
            List<string> blockByFriend = blockedlist.Split(',').ToList();
            string updatedlist;
            for (int i = 0; i < blockByFriend.Count; i++) // Loop through List 
            {
                if (blockByFriend[i] == Session["userID"].ToString())
                {
                    blockByFriend.RemoveAt(i); ;
                }
            }

            updatedlist = string.Join(",", blockByFriend.ToArray());

            DBController db = new DBController();
            string cnnString = db.getConnectionString();
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand("Update posts Set blockedByFriend= @updatedlist where ID=@id", con);
            con.Open();
            com.Parameters.AddWithValue("@updatedlist", updatedlist);
            com.Parameters.AddWithValue("@id", id);
            com.ExecuteNonQuery();
            con.Close();
            Response.Redirect("newsfeed.aspx");
        }

        protected void btnHideFriend_Click(object sender, EventArgs e)
        {
            String blockedlist = dbClass.getBlockedByFriend(id);
            String updatedlist = blockedlist + "," + Session["userID"].ToString();
            DBController db = new DBController();
            string cnnString = db.getConnectionString();
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand("Update posts Set blockedByFriend=@updatedlist where ID=@id", con);
            con.Open();
            com.Parameters.AddWithValue("@updatedlist", updatedlist);
            com.Parameters.AddWithValue("@id", id);
            com.ExecuteNonQuery();
            con.Close();
            Response.Redirect("newsfeed.aspx");
        }

        protected void btnUnhide_Click(object sender, EventArgs e)
        {

            DBController db = new DBController();
            string cnnString = db.getConnectionString();
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand("Update posts Set blockedByUser=0 where ID=@id", con);
            con.Open();
            com.Parameters.AddWithValue("@id", id);
            com.ExecuteNonQuery();
            con.Close();
            Response.Redirect("newsfeed.aspx");
        }

        protected void btnHide_Click(object sender, EventArgs e)
        {

            DBController db = new DBController();
            string cnnString = db.getConnectionString();
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand("Update posts Set blockedByUser=1 where ID=@id", con);
            con.Open();
            com.Parameters.AddWithValue("@id", id);
            com.ExecuteNonQuery();
            con.Close();
            Response.Redirect("newsfeed.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            DBController db = new DBController();
            string cnnString = db.getConnectionString();
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand("Delete from posts where ID=@id", con);
            con.Open();
            com.Parameters.AddWithValue("@id", id);
            com.ExecuteNonQuery();
            con.Close();
            Response.Redirect("newsfeed.aspx");
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {

            myPostDialogBox1.Visible = false;
            friendPostDialogBox1.Visible = false;
            myPostDialogBox2.Visible = false;
            friendPostDialogBox2.Visible = false;
        }

        public int IdNo { get; set; }

        protected void Button1_Click(object sender, EventArgs e)
        {

            ImageButton btn = (ImageButton)sender;

            string commandArgument = btn.CommandArgument;
            int argument = Convert.ToInt32(commandArgument);
            id = argument;
            int userid = dbClass.getUserID(argument);
            int blockUser = dbClass.getBlockedByUser(argument);
            string blocked = dbClass.getBlockedByFriend(argument);
            List<string> blockByFriend = blocked.Split(',').ToList();


            if (userid == Convert.ToInt32(Session["userID"]) && blockUser == 0)
            {
                myPostDialogBox1.Visible = true;
            }
            else if (userid == Convert.ToInt32(Session["userID"]) && blockUser == 1)
            {
                myPostDialogBox2.Visible = true;
            }
            else if (userid != Convert.ToInt32(Session["userID"]))
            {
                int testCount = 0;
                for (int i = 0; i < blockByFriend.Count; i++) // Loop through List with for
                {
                    if (blockByFriend[i] == Session["userID"].ToString())
                    {
                        testCount = 1;
                    }
                }

                if (testCount == 0)
                {
                    friendPostDialogBox1.Visible = true;
                }
                else if (testCount == 1)
                {
                    friendPostDialogBox2.Visible = true;
                }

            }

        }


    }

}
