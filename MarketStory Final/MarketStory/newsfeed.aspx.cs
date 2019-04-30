using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using MarketStory.Controls;
using MarketStory.Entities;

namespace MarketStory
{
    public partial class newsfeed : System.Web.UI.Page
    {
        DataAccess dbClass = new DataAccess();
        public DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {

            }
            else
            {
                Session["login"] = false;
                Response.Redirect("MainPage.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (textPost.Text.Trim() == String.Empty)
            {
                System.Windows.Forms.MessageBox.Show("Please enter your post messages");
            }
            else
            {
                int id = Convert.ToInt32(Session["userID"]);
                DateTime now = DateTime.Now;
                String time = now.ToString("MMM") + " " + now.ToString("dd") + ", " + now.ToString("hh") + ":" + now.ToString("mm") + now.ToString("tt");
                String content = textPost.Text;
                string postScrap = "INSERT INTO posts (userId,timestamp,content) VALUES(@id,@timestamp,@content)";
                dbClass.ConnectDataBaseToInsert(postScrap, time, content, id);
                Response.Redirect("newsfeed.aspx");
            }
        }
    }
}