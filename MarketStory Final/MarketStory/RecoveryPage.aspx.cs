using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace MarketStory
{
    public partial class RecoveryPage : System.Web.UI.Page
    {
        string connectionString = "";

        private Boolean checkUsername(string inUsername)
        {
            string Query = "SELECT * FROM users WHERE username = @username";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@username", inUsername);

            MySqlDataReader dr = cmd.ExecuteReader();

            int userID = 0;

            try
            {
                while (dr.Read() == true)
                {
                    userID = (int)dr["userID"];
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

            if (userID == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private int retrieveUserID(string inUsername)
        {
            string Query = "SELECT * FROM users WHERE username = @username";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@username", inUsername);

            MySqlDataReader dr = cmd.ExecuteReader();

            int userID = 0;

            try
            {
                while (dr.Read() == true)
                {
                    userID = (int)dr["userID"];
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

            return userID;
        }

        private void insertCode(int id, int emailCode)
        {
            string Query = "UPDATE verifications SET emailCode = @code, emailCodeCount = 0 WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@code", emailCode);

            cmd.ExecuteNonQuery();

            conn.Close();
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

        protected void Page_Load(object sender, EventArgs e)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
        }

        protected void ButtonRecovery_Click(object sender, EventArgs e)
        {
            if (checkUsername(TextBoxUsername.Text))
            {
                int userID = retrieveUserID(TextBoxUsername.Text);

                Random rand = new Random((int)DateTime.Now.Ticks);
                int RandomNumber;
                RandomNumber = rand.Next(100000, 999999);

                insertCode(userID, RandomNumber);

                Random rand2 = new Random((int)DateTime.Now.Ticks);
                int RandomNumber2;
                RandomNumber2 = rand2.Next(100000, 999999);

                insertOtp(userID, RandomNumber2);

                string temp = "~/RecoveryVerification.aspx?@=" + HttpUtility.HtmlEncode(userID);
                Response.Redirect(temp);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Username invalid');", true);
            }
        }
    }
}