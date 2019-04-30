using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Controls;
using MySql.Data.MySqlClient;
using System.Data;
using MarketStory.Entities;


namespace MarketStory
{
    public partial class ManageUserPost : System.Web.UI.Page
    {
        DataAccess da = new DataAccess();
        public DataTable dt;
        public static int userid;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userID"] != null)
            {
                if (!Page.IsPostBack)
                {

                    try
                    {
                        userid = Convert.ToInt32(Session["userID"]);
                        GetUserPost(TextBoxUserName.Text);

                    }
                    catch (Exception)
                    {
                        Response.Redirect("Mainpage.aspx");
                    }
                }
            }

        }
        public void GetUserPost(String username)
        {
            string getUserPost = "SELECT p.ID,p.content,p.timestamp,p.userId,u.name,u.profilePicture FROM posts p INNER JOIN users u ON p.userId = u.userId WHERE u.username=@username ORDER BY p.ID DESC";
            dt = da.ConnectDataBaseReturnDT(HttpUtility.HtmlEncode(getUserPost),HttpUtility.HtmlEncode(username));
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
            if (ImageName == "NoImage")
            {
                return ResolveUrl("/Images/image_missing.jpg");
            }
            else
            {
                return ResolveUrl(dRView["profilePicture"].ToString());
            }
        }

        protected void SearchUser_Click(object sender, EventArgs e)
        {
            if (TextBoxUserName.Text.Trim() == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Please Enter A UserName');", true);

            }
            else if (da.checkUser(TextBoxUserName.Text) == false)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Invalid Name');", true);
            }
            else if (da.getPost(da.getID(TextBoxUserName.Text)) == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('This user have no post');", true);
            }
            else
            {
                GetUserPost(TextBoxUserName.Text);
            }

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            string commandArgument = btn.CommandArgument;
            int a = Convert.ToInt32(commandArgument);
            DBController db = new DBController();
            string cnnString = db.getConnectionString();
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand("Delete from posts where ID=@a", con);
            con.Open();
            com.Parameters.AddWithValue("@a", a);
            com.ExecuteNonQuery();
            con.Close();
            int iduser = da.getUserID(a);
            string name = da.getUserName(iduser);
            da.adminPostLog(name, a, userid);
            GetUserPost(TextBoxUserName.Text);

        }


    }
}