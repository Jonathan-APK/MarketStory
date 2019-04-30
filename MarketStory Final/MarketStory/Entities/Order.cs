using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace MarketStory.Entities
{
    public class Order
    {
        private int orderID;
        private int buyerID;
        private double subtotal;
        private string timestamp;

        public Order()
        {
        }

        public double retrieveOverallExpenditure(int userID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            double totalExpenditure = 0.0;

            string Query = "SELECT SUM(subtotal) FROM orders WHERE buyerID = @buyerID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@buyerID", userID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    totalExpenditure = Convert.ToDouble(dr["SUM(subtotal)"]);
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
            return totalExpenditure;
        }

        public void createOrder(int userID, double subtotal, string timestamp)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            string Query = "INSERT INTO orders(buyerID, subtotal, timestamp) VALUES(@buyerID, @subtotal, @timestamp)";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@buyerID", userID);
            cmd.Parameters.AddWithValue("@subtotal", subtotal);
            cmd.Parameters.AddWithValue("@timestamp", timestamp);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public int retrieveLastOrder(int buyerID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            int orderID = 0;

            string Query = "SELECT orderID FROM orders WHERE buyerID = @buyerID ORDER BY orderID DESC LIMIT 1";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@buyerID", buyerID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    orderID = (int)dr["orderID"];
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

            return orderID;
        }
    }
}