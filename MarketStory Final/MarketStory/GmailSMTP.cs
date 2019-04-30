using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using MySql.Data.MySqlClient;

namespace MarketStory
{
    public class GmailSMTP
    {

        public void Send(string to, string subject, string message, bool isHtml)
        {
            // Create a new message
            var mail = new MailMessage();

            // Set the to and from addresses.
            // The from address must be your GMail account
            mail.From = new MailAddress("vongolaxxxth@gmail.com");
            mail.To.Add(new MailAddress(to));

            // Define the message
            mail.Subject = subject;
            mail.IsBodyHtml = false;
            mail.Body = message;

            // Create a new Smpt Client using Google's servers
            var mailclient = new SmtpClient();
            mailclient.Host = "smtp.gmail.com";
            mailclient.Port = 587;

            // This is the critical part, you must enable SSL
            mailclient.EnableSsl = true;

            // Specify your authentication details
            mailclient.Credentials = new System.Net.NetworkCredential("vongolaxxxth@gmail.com", retrievePassword());
            mailclient.Send(mail);
        }

        public string retrievePassword()
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            string password = null;

            string Query = "SELECT * FROM password";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();


            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    password = dr["password"].ToString();
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

            return password;
        }
    }
}