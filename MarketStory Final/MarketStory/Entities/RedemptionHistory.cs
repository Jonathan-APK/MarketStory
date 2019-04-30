using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace MarketStory.Entities
{
    public class RedemptionHistory
    {
        private int redemptionID;
        private int redeemerID;
        private int subtotalPoints;

        public RedemptionHistory()
        {
        }

        public void createRedemptionHistory(int redeemerID, int subtotalPoints)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            string Query = "INSERT into redemptionHistory(redeemerID, subtotalPoints) values (@redeemerID, @subtotalPoints)";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@redeemerID", redeemerID);
            cmd.Parameters.AddWithValue("@subtotalPoints", subtotalPoints);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public int retrieveLastRedemptionID(int redeemerID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            int redemptionID = 0;

            string Query = "SELECT redemptionID FROM redemptionhistory WHERE redeemerID = @redeemerID ORDER BY redemptionID DESC LIMIT 1";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@redeemerID", redeemerID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    redemptionID = (int)dr["redemptionID"];
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

            return redemptionID;
        }

        public List<RedemptionHistory> retrieveRedemptionHistory(int redeemerID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            List<RedemptionHistory> redemptionHistoryList = new List<RedemptionHistory>();

            string Query = "SELECT redemptionID, subtotalPoints FROM redemptionhistory WHERE redeemerID = @redeemerID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@redeemerID", redeemerID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    RedemptionHistory r1 = new RedemptionHistory();
                    r1.redemptionID = (int)dr["redemptionID"];
                    r1.subtotalPoints = (int)dr["subtotalPoints"];
                    redemptionHistoryList.Add(r1);
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

            return redemptionHistoryList;
        }

        public int getRedemptionID()
        {
            return redemptionID;
        }

        public int getRedeemerID()
        {
            return redeemerID;
        }

        public int getSubtotalPoints()
        {
            return subtotalPoints;
        }
    }
}