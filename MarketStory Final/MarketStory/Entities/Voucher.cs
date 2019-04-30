using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace MarketStory.Entities
{
    public class Voucher
    {
        private int voucherID;
        private string voucherName;
        private string information;
        private string photo;
        private int pointsRequired;
        private int availableQuantity;

        public Voucher()
        {
        }

        public Voucher(int voucherID, string voucherName, string information, string photo, int pointsRequired, int availableQuantity)
        {
            this.voucherID = voucherID;
            this.voucherName = voucherName;
            this.information = information;
            this.photo = photo;
            this.pointsRequired = pointsRequired;
            this.availableQuantity = availableQuantity;
        }

        public List<Voucher> retrieveVouchers()
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            List<Voucher> voucherList = new List<Voucher>();

            string Query = "SELECT * FROM vouchers";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    Voucher v1 = new Voucher();
                    v1.voucherID = (int)dr["voucherID"];
                    v1.voucherName = dr["voucherName"].ToString();
                    v1.information = dr["information"].ToString();
                    v1.photo = dr["photo"].ToString();
                    v1.pointsRequired = (int)dr["pointsRequired"];
                    v1.availableQuantity = (int)dr["availableQuantity"];
                    voucherList.Add(v1);
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

            return voucherList;
        }

        public int getVoucherID()
        {
            return voucherID;
        }

        public string getVoucherName()
        {
            return voucherName;
        }

        public string getInformation()
        {
            return information;
        }

        public string getPhoto()
        {
            return photo;
        }

        public int getPointsRequired()
        {
            return pointsRequired;
        }

        public int getAvailableQuantity()
        {
            return availableQuantity;
        }
    }
}