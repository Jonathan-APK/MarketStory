using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Web.Security;

namespace MarketStory
{
    public partial class MainPage : System.Web.UI.Page
    {
        string connectionString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();

            if (Session["login"] != null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Please proceed to login');", true);
            }
        }

        public static string CreatePasswordHash(string pwd)
        {
            string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "sha1");
            return hashedPwd;
        }

        private Boolean retrieveInfo(string inUsername)
        {
            string Query = "SELECT * FROM users WHERE username = @username";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@username", inUsername);

            MySqlDataReader dr = cmd.ExecuteReader();

            string password = "";

            try
            {
                while (dr.Read() == true)
                {
                    password = dr["passwordHash"].ToString();
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

            if (password.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void insertCode(int id, int activationCode)
        {
            string Query = "INSERT into verifications(userID, activationCode, activationCount, activationSuccess) VALUES (@id, @code, 0, False)";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@code", activationCode);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        private int retrieveUserID(string inputUsername)
        {
            string Query = "SELECT * FROM users WHERE username = @username";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@username", inputUsername);

            MySqlDataReader dr = cmd.ExecuteReader();

            int id = 0;

            try
            {
                while (dr.Read() == true)
                {
                    id = (int)dr["userID"];
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

            return id;
        }

        private void insertOtp(int id, int otp)
        {
            string Query = "UPDATE verifications SET otp = @otp, otpCount = 0 WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@otp", otp);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "INSERT into users(username, passwordHash, email, handphone, name, gender, ban) VALUES (@username, @passwordHash, @email, @handphone, @name, @gender, False)";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            string pwHash;
            pwHash = CreatePasswordHash(TextBoxPassword.Text);

            cmd.Parameters.AddWithValue("@username", TextBoxUsername.Text);
            cmd.Parameters.AddWithValue("@passwordHash", pwHash);
            cmd.Parameters.AddWithValue("@email", TextBoxEmail.Text);
            cmd.Parameters.AddWithValue("@handphone", TextBoxHp.Text);
            cmd.Parameters.AddWithValue("@name", TextBoxName.Text);
            cmd.Parameters.AddWithValue("@gender", ListGender.SelectedValue);

            if (retrieveInfo(TextBoxUsername.Text))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Username taken');", true);
            }
            else
            {
                cmd.ExecuteNonQuery();
                Random rand = new Random((int)DateTime.Now.Ticks);
                int RandomNumber;
                RandomNumber = rand.Next(100000, 999999);

                int userID = retrieveUserID(TextBoxUsername.Text);

                insertCode(userID, RandomNumber);

                string temp = "~/AccountActivation.aspx?@=" + HttpUtility.HtmlEncode(userID);
                Response.Redirect(temp);
            }

            conn.Close();
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "SELECT * FROM users WHERE username = @username";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@username", TextBoxLogin1.Text);

            MySqlDataReader dr = cmd.ExecuteReader();

            string username = "";
            string pwHash = "";
            string genPwHash;
            genPwHash = CreatePasswordHash(TextBoxLogin2.Text);
            int userID = 0;
            Boolean ban = false;

            try
            {
                while (dr.Read() == true)
                {
                    userID = (int)dr["userID"];
                    username = dr["username"].ToString();
                    pwHash = dr["passwordHash"].ToString();
                    ban = Convert.ToBoolean(dr["ban"]);
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

            string Query2 = "SELECT * FROM verifications WHERE userID = @userid";
            MySqlConnection conn2 = new MySqlConnection(connectionString);
            MySqlCommand cmd2 = new MySqlCommand(Query2, conn2);
            conn2.Open();

            cmd2.Parameters.AddWithValue("@userid", userID);

            MySqlDataReader dr2 = cmd2.ExecuteReader();

            Boolean activationSuccess = false;

            try
            {
                while (dr2.Read() == true)
                {
                    activationSuccess = Convert.ToBoolean(dr2["activationSuccess"]);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                dr2.Close();
                conn2.Close();
            }

            if (pwHash.Equals(genPwHash) && username.Equals(TextBoxLogin1.Text) && ban == false && activationSuccess == true)
            {
                Random rand = new Random((int)DateTime.Now.Ticks);
                int RandomNumber;
                RandomNumber = rand.Next(100000, 999999);

                insertOtp(userID, RandomNumber);
                string temp = "~/LoginVerification.aspx?@=" + HttpUtility.HtmlEncode(userID);
                Response.Redirect(temp);
            }
            else if (ban == true)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('The account is banned');", true);
            }
            else if (activationSuccess == false)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('The account has not been activated');", true);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Incorrect username or password');", true);
            }
        }
    }
}