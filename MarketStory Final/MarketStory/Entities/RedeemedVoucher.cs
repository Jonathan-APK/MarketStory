using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace MarketStory.Entities
{
    public class RedeemedVoucher
    {
        private int redeemedVouchersID;
        private int redemptionID;
        private int voucherID;
        private int voucherRedeemedQuantity;
        private int redeemerID;
        private int availableQuantity;

        public RedeemedVoucher()
        {
        }

        public RedeemedVoucher(int voucherID, int voucherRedeemedQuantity)
        {
            this.voucherID = voucherID;
            this.voucherRedeemedQuantity = voucherRedeemedQuantity;
        }

        public void createRedeemedVoucher(int redeemerID, int redemptionID, int voucherID, int voucherRedeemedQuantity)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            string Query = "INSERT into redeemedVouchers(redeemerID, redemptionID, voucherID, voucherRedeemedQuantity, availableQuantity) values (@redeemerID, @redemptionID, @voucherID, @voucherRedeemedQuantity, @voucherRedeemedQuantity)";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@redeemerID", redeemerID);
            cmd.Parameters.AddWithValue("@redemptionID", redemptionID);
            cmd.Parameters.AddWithValue("@voucherID", voucherID);
            cmd.Parameters.AddWithValue("@voucherRedeemedQuantity", voucherRedeemedQuantity);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public RedeemedVoucher retrieveRedeemedVoucherQuantity(int redeemerID, int voucherID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            RedeemedVoucher r1 = new RedeemedVoucher();

            string Query = "SELECT availableQuantity FROM redeemedvouchers WHERE redeemerID = @redeemerID and voucherID = @voucherID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@redeemerID", redeemerID);
            cmd.Parameters.AddWithValue("@voucherID", voucherID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    r1.availableQuantity = r1.availableQuantity += (int)dr["availableQuantity"];
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

            return r1;
        }

        public int retrieveRedeemedVoucherID(int redeemerID, int voucherID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            int redeemedVouchersID = 0;

            string Query = "SELECT redeemedVouchersID FROM redeemedvouchers WHERE redeemerID = @redeemerID AND voucherID = @voucherID AND availableQuantity > 0";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@redeemerID", redeemerID);
            cmd.Parameters.AddWithValue("@voucherID", voucherID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    redeemedVouchersID = (int)dr["redeemedVouchersID"];
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
            return redeemedVouchersID;
        }

        public void updateRedeemedVoucherQuantity(int redeemedVouchersID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            int availableQuantity = 0;

            string Query = "SELECT availableQuantity FROM redeemedvouchers WHERE redeemedVouchersID = @redeemedVouchersID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@redeemedVouchersID", redeemedVouchersID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    availableQuantity = (int)dr["availableQuantity"];
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

            availableQuantity = availableQuantity - 1;

            Query = "UPDATE redeemedvouchers SET availableQuantity = @availableQuantity WHERE redeemedVouchersID = @redeemedVouchersID";
            conn = new MySqlConnection(connectionString);
            cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@availableQuantity", availableQuantity);
            cmd.Parameters.AddWithValue("@redeemedVouchersID", redeemedVouchersID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public int getRedeemedVouchersID()
        {
            return redeemedVouchersID;
        }

        public int getRedemptionID()
        {
            return redemptionID;
        }

        public int getVoucherID()
        {
            return voucherID;
        }

        public int getVoucherRedeemedQuantity()
        {
            return voucherRedeemedQuantity;
        }

        public void setVoucherRedeemedQuantity(int voucherRedeemedQuantity)
        {
            this.voucherRedeemedQuantity = voucherRedeemedQuantity;
        }

        public int getRedeemerID()
        {
            return redeemerID;
        }

        public int getAvailableQuantity()
        {
            return availableQuantity;
        }
    }
}