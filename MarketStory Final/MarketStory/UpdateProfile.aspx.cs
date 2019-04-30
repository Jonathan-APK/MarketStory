using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace MarketStory
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        string connectionString = "";

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

        private void insertInfo(int id, string info)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "UPDATE users SET information = @info WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@info", info);

            cmd.ExecuteNonQuery();

            conn.Close();
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

        //public static string CreatePasswordHash(string pwd)
        //{
            //string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "sha1");
            //return hashedPwd;
        //}

        private string retrievePassword(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "SELECT * FROM users WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string passwordHash = "";

            try
            {
                while (dr.Read() == true)
                {
                    passwordHash = dr["passwordHash"].ToString();
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

            return passwordHash;
        }

        private void updatePassword(int id, string pwHash)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "UPDATE users SET passwordHash = @pwHash WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@pwHash", pwHash);

            cmd.ExecuteNonQuery();

            conn.Close();
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

        private string retrieveMobile(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "SELECT * FROM users WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string mobile = "";

            try
            {
                while (dr.Read() == true)
                {
                    mobile = dr["handphone"].ToString();
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

            return mobile;
        }

        private void updateEmail(int id, string email)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "UPDATE users SET email = @email WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@email", email);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        private void updateMobile(int id, string mobile)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "UPDATE users SET handphone = @mobile WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@mobile", mobile);

            cmd.ExecuteNonQuery();

            conn.Close();
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userID"] != null)
                {
                    int userID = Convert.ToInt32(Session["userID"]);

                    LabelProfileUsername.Text = HttpUtility.HtmlEncode(retrieveName(userID));
                    string imagePath = retrieveProfilePicture(userID);
                    ImageProfilePicture.ImageUrl = imagePath;
                    ImageProfilePicture.ImageUrl = imagePath;
                    string email = retrieveEmail(userID);
                    TextBoxCurrentEmail.Text = email;
                    string mobile = retrieveMobile(userID);
                    TextBoxCurrentMobile.Text = mobile;
                    TextBoxInfo.Text = retrieveInfo(userID);
                }
                else
                {
                    Session["login"] = false;
                    Response.Redirect("~/MainPage.aspx");
                }
            }
        }

        protected void ButtonPassword_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(Session["userID"]);
            string pwHash = retrievePassword(userID);
            string genPwHash;
            //genPwHash = CreatePasswordHash(TextBoxCurrentPassword.Text);

            /*if (pwHash.Equals(genPwHash))
            {
                if (TextBoxPassword.Text.Equals(TextBoxRePassword.Text))
                {
                    //string newPwHash = CreatePasswordHash(TextBoxPassword.Text);
                    //updatePassword(userID, newPwHash);
                    TextBoxCurrentPassword.Text = "";
                    TextBoxPassword.Text = "";
                    TextBoxRePassword.Text = "";
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Password successfully updated');", true);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Password does not match');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Incorrect current password');", true);
            }*/
        }

        protected void ButtonEmail_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(Session["userID"]);
            if (TextBoxEmail.Text.Equals(TextBoxReEmail.Text))
            {
                updateEmail(userID, TextBoxEmail.Text);
                TextBoxCurrentEmail.Text = TextBoxEmail.Text;
                TextBoxEmail.Text = "";
                TextBoxReEmail.Text = "";
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Email address successfully updated');", true);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Email address does not match');", true);
            }
        }

        protected void ButtonMobile_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(Session["userID"]);
            if (TextBoxMobile.Text.Equals(TextBoxReMobile.Text))
            {
                updateMobile(userID, TextBoxMobile.Text);
                TextBoxCurrentMobile.Text = TextBoxMobile.Text;
                TextBoxMobile.Text = "";
                TextBoxReMobile.Text = "";
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Mobile number successfully updated');", true);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Mobile number does not match');", true);
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            /*int userID = Convert.ToInt32(Session["userID"]);
            string filename = Path.GetFileName(ProfilePictureUpload.PostedFile.FileName);
            ProfilePictureUpload.SaveAs(Server.MapPath("/Uploads/ProfilePictures/" + filename));
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            string Query = "UPDATE users SET profilePicture = @picture WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", userID);
            cmd.Parameters.AddWithValue("@picture", "/Uploads/ProfilePictures/" + filename);

            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("~/UpdateProfile.aspx");*/
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(Session["userID"]);
            insertInfo(userID, TextBoxInfo.Text);

        }
    }
}