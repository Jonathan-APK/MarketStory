using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace MarketStory
{
    public partial class AccountActivation : System.Web.UI.Page
    {
        string connectionString = "";

        private int retrieveCode(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "SELECT * FROM verifications WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            int code = 0;

            try
            {
                while (dr.Read() == true)
                {
                    code = (int)dr["activationCode"];
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

            return code;
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

        private void insertActivationSuccess(int id)
        {
            string Query = "UPDATE verifications SET activationSuccess = True WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        private void insertActivationCount(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "SELECT * FROM verifications WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            int count = 0;

            try
            {
                while (dr.Read() == true)
                {
                    count = (int)dr["activationCount"];
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

            count++;

            string Query2 = "UPDATE verifications SET activationCount = @count WHERE userID = @id2";
            MySqlConnection conn2 = new MySqlConnection(connectionString);
            MySqlCommand cmd2 = new MySqlCommand(Query2, conn2);
            conn2.Open();

            cmd2.Parameters.AddWithValue("@id2", id);
            cmd2.Parameters.AddWithValue("@count", count);

            cmd2.ExecuteNonQuery();

            conn2.Close();
        }

        private int retrieveActivationCount(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "SELECT * FROM verifications WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            int count = 0;

            try
            {
                while (dr.Read() == true)
                {
                    count = (int)dr["activationCount"];
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

            return count;
        }

        private void updateCode(int id, int activationCode)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "UPDATE verifications SET activationCode = @code WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@code", activationCode);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        private void resetActivationCount(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "UPDATE verifications SET activationCount = 0 WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Successfully Registered\\n\\An email has been sent to your registered email address\\n\\Enter the code found in the email in the box provided');", true);

                string stringID = Request.QueryString["@"];
                int userID = Convert.ToInt32(stringID);

                int activationCode = retrieveCode(userID);
                string activationCodeSend = activationCode.ToString();

                string registeredEmail = retrieveEmail(userID);

                GmailSMTP smtp = new GmailSMTP();
                smtp.Send(registeredEmail, "MarketStory Activation Code", "Activation Code: " + activationCodeSend, true);
            }
        }

        protected void ButtonCode_Click(object sender, EventArgs e)
        {
            string stringID2 = Request.QueryString["@"];
            int userID2 = Convert.ToInt32(stringID2);

            int activationCode2 = retrieveCode(userID2);
            string activationCodeVerify = activationCode2.ToString();

            if (activationCodeVerify.Equals(TextBoxCode.Text))
            {
                int count = retrieveActivationCount(userID2);
                if (count <= 3)
                {
                    insertActivationSuccess(userID2);
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Successfully Activated\\n\\The account can now be used to login');window.open('MainPage.aspx','_self');", true);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Activation code expired\\n\\Please request for a new code');", true);
                }
            }
            else
            {
                insertActivationCount(userID2);
                int count = retrieveActivationCount(userID2);

                if (count <= 3)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Invalid Code\\n\\Please re-enter the activation code');", true);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Activation code expired\\n\\Please request for a new code');", true);
                }
            }
        }

        protected void ButtonResend_Click(object sender, EventArgs e)
        {
            string stringID = Request.QueryString["@"];
            int userID = Convert.ToInt32(stringID);

            Random rand = new Random((int)DateTime.Now.Ticks);
            int RandomNumber;
            RandomNumber = rand.Next(100000, 999999);
            updateCode(userID, RandomNumber);
            string newCode = RandomNumber.ToString();

            string registeredEmail = retrieveEmail(userID);

            GmailSMTP smtp = new GmailSMTP();
            smtp.Send(registeredEmail, "MarketStory Activation Code", "Activation Code: " + newCode, true);

            resetActivationCount(userID);
        }
    }
}