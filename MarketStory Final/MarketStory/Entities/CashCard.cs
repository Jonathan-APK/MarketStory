using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace MarketStory.Entities
{
    public class CashCard
    {
        private int cashCardID;
        private string serialNumber;
        private string securityCode;
        private int cashValue;
        private bool checkUsed;

        public CashCard()
        {
        }

        public void createCashCard(string serialNumber, string securityCodeHash, int cashValue)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            string Query = "INSERT into cashCards(serialNumber, securityCode, cashValue) values (@serialNumber, @securityCode, @cashValue)";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@serialNumber", serialNumber);
            cmd.Parameters.AddWithValue("@securityCode", securityCodeHash);
            cmd.Parameters.AddWithValue("@cashValue", cashValue);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static string retrieveLastCashCard()
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            string serialNumber = "";

            string Query = "SELECT serialNumber FROM cashcards ORDER BY cashCardID DESC LIMIT 1";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    serialNumber = dr["serialNumber"].ToString();
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

            string cardSeries1 = serialNumber.Substring(0, 2);
            string cardSeries2 = serialNumber.Substring(10);
            string cardSeries = cardSeries1 + cardSeries2;
            serialNumber = serialNumber.Substring(2, 8);

            return cardSeries + serialNumber;
        }

        public string generateSecurityCode()
        {
            string securityCode = System.Guid.NewGuid().ToString();

            securityCode = securityCode.Replace("-", string.Empty);
            securityCode = securityCode.ToUpper();

            return securityCode.Substring(0, 12);
        }

        public string generateSecurityCodeHash(string securityCode)
        {
            string securityCodeHash;

            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(securityCode));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                securityCodeHash = sBuilder.ToString();

                return securityCodeHash;
            }
        }

        public bool checkCashCardAvailability(string serialNumber)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            bool check = false;

            string Query = "SELECT checkUsed FROM cashcards WHERE serialNumber = @serialNumber";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@serialNumber", serialNumber);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    check = (bool)dr["checkUsed"];
                    if (check == false)
                    {
                        check = true;
                    }
                    else if (check == true)
                    {
                        check = false;
                    }
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

            return check;
        }

        public bool validateCashCard(string serialNumber, string securityCode)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            string securityCodeHash = null;
            bool check = false;

            string Query = "SELECT securityCode FROM cashcards WHERE serialNumber = @serialNumber";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@serialNumber", serialNumber);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    securityCodeHash = dr["securityCode"].ToString();
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

            if (generateSecurityCodeHash(securityCode) == securityCodeHash)
            {
                check = true;
            }

            return check;
        }

        public void updateCashCardUsed(string serialNumber)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            User user = new User();

            string Query = "UPDATE cashcards SET checkUsed = true WHERE serialNumber = @serialNumber";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@serialNumber", serialNumber);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public int retrieveCashValue(string serialNumber)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            int cashValue = 0;

            string Query = "SELECT cashValue FROM cashcards WHERE serialNumber = @serialNumber";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@serialNumber", serialNumber);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    cashValue = (int)dr["cashValue"];
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

            return cashValue;
        }
    }
}