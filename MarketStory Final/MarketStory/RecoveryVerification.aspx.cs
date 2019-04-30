using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Net;
using System.Security.Cryptography;
using System.Web.Security;


namespace MarketStory
{
    public partial class RecoveryVerification : System.Web.UI.Page
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
                    code = (int)dr["emailCode"];
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

        private int retrieveOtp(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "SELECT * FROM verifications WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            int otp = 0;

            try
            {
                while (dr.Read() == true)
                {
                    otp = (int)dr["otp"];
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

            return otp;
        }

        private int retrieveMobile(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "SELECT * FROM users WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            int mobile = 0;

            try
            {
                while (dr.Read() == true)
                {
                    mobile = (int)dr["handphone"];
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

        private int retrieveOtpCount(int id)
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
                    count = (int)dr["otpCount"];
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

        private void insertEmailCodeCount(int id)
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
                    count = (int)dr["emailCodeCount"];
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

            string Query2 = "UPDATE verifications SET emailCodeCount = @count WHERE userID = @id2";
            MySqlConnection conn2 = new MySqlConnection(connectionString);
            MySqlCommand cmd2 = new MySqlCommand(Query2, conn2);
            conn2.Open();


            cmd2.Parameters.AddWithValue("@id2", id);
            cmd2.Parameters.AddWithValue("@count", count);

            cmd2.ExecuteNonQuery();

            conn2.Close();
        }

        private int retrieveEmailCodeCount(int id)
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
                    count = (int)dr["emailCodeCount"];
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

        private void insertOtpCount(int id)
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
                    count = (int)dr["otpCount"];
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

            string Query2 = "UPDATE verifications SET otpCount = @count WHERE userID = @id2";
            MySqlConnection conn2 = new MySqlConnection(connectionString);
            MySqlCommand cmd2 = new MySqlCommand(Query2, conn2);
            conn2.Open();

            cmd2.Parameters.AddWithValue("@id2", id);
            cmd2.Parameters.AddWithValue("@count", count);

            cmd2.ExecuteNonQuery();

            conn2.Close();
        }

        private void updateOtp(int id, int otp)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "UPDATE verifications SET otp = @otp WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@otp", otp);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        private void resetOtpCount(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "UPDATE verifications SET otpCount = 0 WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        private void updateCode(int id, int emailCode)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "UPDATE verifications SET emailCode = @code WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@code", emailCode);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        private void resetEmailCodeCount(int id)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "UPDATE verifications SET emailCodeCount = 0 WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        private void updatePassword(int id, string ranGenPwHash)
        {
            DBController db = new DBController();
            connectionString = db.getConnectionString();
            string Query = "UPDATE users SET passwordhash = @genpwhash WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@genpwhash", ranGenPwHash);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public static string CreatePasswordHash(string pwd)
        {
            string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "sha1");
            return hashedPwd;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string stringID = Request.QueryString["@"];
                int userID = Convert.ToInt32(stringID);

                int recoveryCode = retrieveCode(userID);
                string recoveryCodeSend = recoveryCode.ToString();

                string registeredEmail = retrieveEmail(userID);

                GmailSMTP smtp = new GmailSMTP();
                smtp.Send(registeredEmail, "MarketStory Activation Code", "Email Code: " + recoveryCodeSend, true);

                int otp = retrieveOtp(userID);
                string otpSend = otp.ToString();

                int registeredMobile = retrieveMobile(userID);
                Response.Write(otp);
                string url = "http://gateway.onewaysms.sg:10002/api.aspx?apiusername=APIRBRI6I1ZYE&apipassword=APIRBRI6I1ZYERBRI6&mobileno=65" + registeredMobile + "&senderid=MarketStory&languagetype=1&message=OTP: " + otpSend;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
        }

        protected void ButtonRecovery_Click(object sender, EventArgs e)
        {
            string stringID2 = Request.QueryString["@"];
            int userID2 = Convert.ToInt32(stringID2);

            int emailCode2 = retrieveCode(userID2);
            string emailCodeVerify = emailCode2.ToString();

            int otp2 = retrieveOtp(userID2);
            string otpVerify = otp2.ToString();

            if (emailCodeVerify.Equals(TextBoxEmailCode.Text) && otpVerify.Equals(TextBoxOTP.Text))
            {
                int count = retrieveEmailCodeCount(userID2);
                int count2 = retrieveOtpCount(userID2);
                if (count <= 3 && count2 <= 3)
                {
                    RandomPasswordGenerator rpg = new RandomPasswordGenerator();
                    string ranGenPw = rpg.GetRandomPasswordUsingGUID(10);

                    string registeredEmail = retrieveEmail(userID2);

                    GmailSMTP smtp = new GmailSMTP();
                    smtp.Send(registeredEmail, "MarketStory Activation Code", "Your new password is: " + ranGenPw, true);

                    string ranGenPwHash;
                    ranGenPwHash = CreatePasswordHash(ranGenPw);

                    updatePassword(userID2, ranGenPwHash);

                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Successfully Recovered\\n\\A random generated password has been sent to your registered email address');window.open('MainPage.aspx','_self');", true);
                }
                else if (count > 3)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Email code expired\\n\\Please request for a new code');", true);
                }
                else if (count2 > 3)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('OTP expired\\n\\Please request for a new otp');", true);
                }
            }
            else if (!(otpVerify.Equals(TextBoxOTP.Text)))
            {
                insertOtpCount(userID2);
                int count = retrieveOtpCount(userID2);

                if (count <= 3)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Invalid OTP\\n\\Please re-enter the otp');", true);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('OTP expired\\n\\Please request for a new otp');", true);
                }
            }
            else if (!(emailCodeVerify.Equals(TextBoxEmailCode.Text)))
            {
                insertEmailCodeCount(userID2);
                int count = retrieveEmailCodeCount(userID2);

                if (count <= 3)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Invalid Email Code\\n\\Please re-enter the email code');", true);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Email code expired\\n\\Please request for a new code');", true);
                }
            }
        }

        protected void ButtonResendOTP_Click(object sender, EventArgs e)
        {
            string stringID = Request.QueryString["@"];
            int userID = Convert.ToInt32(stringID);

            Random rand = new Random((int)DateTime.Now.Ticks);
            int RandomNumber;
            RandomNumber = rand.Next(100000, 999999);
            updateOtp(userID, RandomNumber);
            string newOtp = RandomNumber.ToString();

            int registeredMobile = retrieveMobile(userID);

            string url = "http://gateway.onewaysms.sg:10002/api.aspx?apiusername=APIRBRI6I1ZYE&apipassword=APIRBRI6I1ZYERBRI6&mobileno=65" + registeredMobile + "&senderid=MarketStory&languagetype=1&message=OTP: " + newOtp;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            resetOtpCount(userID);
        }

        protected void ButtonResendEmailCode_Click(object sender, EventArgs e)
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
            smtp.Send(registeredEmail, "MarketStory Activation Code", "Email Code: " + newCode, true);

            resetEmailCodeCount(userID);
        }
    }
}