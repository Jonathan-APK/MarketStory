using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace MarketStory.Entities
{
    public class Booth
    {
        private int boothID;
        private int sellerID;
        private string boothName;

        public Booth() 
        {
        }

        public Booth retrieveBoothByProduct(int productID) 
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            Booth booth = new Booth();

            string Query = "SELECT b.boothName, b.boothID FROM booths b INNER JOIN products p ON p.boothID = b.boothID WHERE p.productID = @productID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@productID", productID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    booth.boothID = (int)dr["boothID"];
                    booth.boothName = dr["boothName"].ToString();
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

            return booth;
        }

        public Booth retrieveBooth(int userID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            Booth booth = new Booth();

            string Query = "SELECT boothID, boothName FROM booths WHERE sellerID = @userID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@userID", userID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    booth.boothID = (int)dr["boothID"];
                    booth.boothName = dr["boothName"].ToString();
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
            return booth;
        }

        public static int retrieveSellerID(int boothID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            int sellerID = 0;

            string Query = "SELECT sellerID FROM booths WHERE boothID = @boothID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@boothID", boothID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    sellerID = (int)dr["sellerID"];
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
            return sellerID;
        }

        public bool checkBoothExists(int userID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            bool exists = false;

            string Query = "SELECT * FROM booths WHERE sellerID = @userID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@userID", userID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    exists = true;
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
            return exists;
        }

        public void createBooth(int userID, string boothName) 
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            string Query = "INSERT INTO booths(sellerID, boothName) VALUES(@sellerID, @boothName)";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void updateBoothName(int boothID, string boothName)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            string Query = "UPDATE booths SET boothName = @boothName WHERE boothID = @boothID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@boothID", boothID);
            cmd.Parameters.AddWithValue("@boothName", boothName);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteBooth(int boothID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            string Query = "DELETE from booths WHERE boothID = @boothID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@boothID", boothID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public int getBoothID() {
            return boothID;
        }

        public string getBoothName() {
            return boothName;
        }
    }
}