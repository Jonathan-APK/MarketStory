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
    public partial class postfriendview : System.Web.UI.UserControl
    {
        DataAccess dbClass = new DataAccess();
        private DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                if (!Page.IsPostBack)
                {

                    GetUserPost(Convert.ToInt32(Session["profileID"]));
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
            string formatedString = str.Replace(";", ",");
            formatedString = formatedString + "," + Id;
            string getUserPost = "SELECT p.ID,p.content,p.timestamp,p.userId,u.name,u.profilePicture,p.blockedByFriend FROM posts p INNER JOIN users u ON p.userId = u.userId WHERE p.userId=" + Id + " ORDER BY p.ID DESC";
            dt = dbClass.ConnectDataBaseReturnDT(getUserPost, Id);
            if (dt.Rows.Count > 0)
            {
                GridViewUserPost.DataSource = HttpUtility.HtmlEncode(dt);
                GridViewUserPost.DataBind();

            }
        }

        public string getSRC(object imgSRC)
        {
            DataRowView dRView = (DataRowView)imgSRC;
            string ImageName = dRView["profilePicture"].ToString();

            return ResolveUrl(HttpUtility.HtmlEncode(dRView["profilePicture"].ToString()));
        }
    }
}