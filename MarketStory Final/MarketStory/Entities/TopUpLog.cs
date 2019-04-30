using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace MarketStory.Entities
{
    public class TopUpLog
    {
        private int topUpLogID;
        private int userID;
        private string cashCardSerial;
        private string timestamp;

        public TopUpLog()
        {
        }

        public void createTopUpLog(int userID, string cashCardSerial, string timestamp)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            string Query = "INSERT INTO topuplog(userID, cashCardSerial, timestamp) VALUES(@userID, @cashCardSerial, @timestamp)";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@cashCardSerial", cashCardSerial);
            cmd.Parameters.AddWithValue("@timestamp", timestamp);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<String> retrieveTopUpLog(int userID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            List<String> topuplogList = new List<String>();

            string Query = "SELECT t.userID, t.cashCardSerial, t.timestamp, cc.cashValue FROM topuplog t INNER JOIN cashcards cc ON t.cashCardSerial = cc.serialNumber WHERE userID = @userID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@userID", userID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    int userID2 = (int)dr["userID"];
                    string cashCardSerial = dr["cashCardSerial"].ToString();
                    string timestamp = dr["timestamp"].ToString();
                    int cashValue = (int)dr["cashValue"];
                    string s = "You have topped up an amount of " + cashValue + " on " + timestamp + " using serial card " + cashCardSerial;
                    topuplogList.Add(s);
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

            return topuplogList;
        }

        public static List<String> retrieveFullTopUpLog()
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            List<String> topuplogList = new List<String>();

            string Query = "SELECT t.userID, t.cashCardSerial, t.timestamp, cc.cashValue, u.username FROM topuplog t INNER JOIN cashcards cc ON t.cashCardSerial = cc.serialNumber INNER JOIN users u ON t.userID = u.userID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    int userID2 = (int)dr["userID"];
                    string username = dr["username"].ToString();
                    string cashCardSerial = dr["cashCardSerial"].ToString();
                    string timestamp = dr["timestamp"].ToString();
                    int cashValue = (int)dr["cashValue"];
                    string s = username + " have topped up an amount of " + cashValue + " on " + timestamp + " using serial card " + cashCardSerial;
                    topuplogList.Add(s);
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

            return topuplogList;
        }
    }
}