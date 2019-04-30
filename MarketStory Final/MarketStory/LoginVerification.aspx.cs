using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Net;
using MarketStory.Entities;

namespace MarketStory
{
    public partial class LoginVerification : System.Web.UI.Page
    {
        DataAccess da = new DataAccess();
        string connectionString = "";

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string stringID = Request.QueryString["@"];
                int userID = Convert.ToInt32(stringID);

                if (stringID != null)
                {
                    int otp = retrieveOtp(userID);
                    string otpSend = otp.ToString();

                    int registeredMobile = retrieveMobile(userID);
                    TextBoxOTP.Text = Convert.ToString(otp);
                    string url = "http://gateway.onewaysms.sg:10002/api.aspx?apiusername=APIRBRI6I1ZYE&apipassword=APIRBRI6I1ZYERBRI6&mobileno=65" + registeredMobile + "&senderid=MarketStory&languagetype=1&message=OTP: " + otpSend;

                    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    //request.Method = "GET";
                    //request.ContentType = "application/x-www-form-urlencoded";
                    //request.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

                    //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                }
                else
                {
                    Session["login"] = false;
                    Response.Redirect("~/MainPage.aspx");
                }
            }
        }

        protected void ButtonOTP_Click(object sender, EventArgs e)
        {
            string stringID2 = Request.QueryString["@"];
            int userID2 = Convert.ToInt32(stringID2);

            int otp2 = retrieveOtp(userID2);
            string otpVerify = otp2.ToString();

            if (otpVerify.Equals(TextBoxOTP.Text))
            {
                int count = retrieveOtpCount(userID2);
                if (count <= 3)
                {
                    Session["userID"] = userID2;

                    if (userID2 == 1)
                    {
                        da.adminlogin(userID2);
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Admin Login Success');window.open('adminpage.aspx','_self');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Login Success');window.open('newsfeed.aspx','_self');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('OTP expired\\n\\Please request for a new code');", true);
                }
            }
            else
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
        }

        protected void ButtonResend_Click(object sender, EventArgs e)
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
    }
}