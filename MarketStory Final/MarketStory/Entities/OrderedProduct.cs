using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace MarketStory.Entities
{
    public class OrderedProduct
    {
        private int orderedProductsID;
        private int orderID;
        private int sellerID;
        private int productID;
        private string recipientAddreess;
        private int productOrderedQuantity;
        private string productDeliveryStatus;
        private string trackingInformation;
        private string additionalComments;

        public OrderedProduct()
        {
        }

        public OrderedProduct(int productID, int productOrderedQuantity)
        {
            this.productID = productID;
            this.productOrderedQuantity = productOrderedQuantity;
        }

        public void updateDeliveryStatus(int orderedProductsID, string productDeliveryStatus)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            User user = new User();

            string Query = "UPDATE orderedProducts SET productDeliveryStatus = @productDeliveryStatus WHERE orderedProductsID = @orderedProductsID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@productDeliveryStatus", productDeliveryStatus);
            cmd.Parameters.AddWithValue("@orderedProductsID", orderedProductsID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool checkDeliveryStatusConfirmed(int orderedProductsID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            OrderedProduct od = new OrderedProduct();
            bool check = false;

            string Query = "SELECT productDeliveryStatus FROM orderedproducts WHERE orderedproductsID = @orderedProductsID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@orderedProductsID", orderedProductsID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    od.productDeliveryStatus = dr["productDeliveryStatus"].ToString();
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

            if (od.productDeliveryStatus == "Delivery Confirmed")
            {
                check = true;
            }

            return check;
        }

        public bool checkDeliveryStatusSent(int orderedProductsID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            OrderedProduct od = new OrderedProduct();
            bool check = false;

            string Query = "SELECT productDeliveryStatus FROM orderedproducts WHERE orderedproductsID = @orderedProductsID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@orderedProductsID", orderedProductsID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    od.productDeliveryStatus = dr["productDeliveryStatus"].ToString();
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

            if (od.productDeliveryStatus == "On Delivery")
            {
                check = true;
            }

            return check;
        }

        public bool checkDeliveryStatusPending(int orderedProductsID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            OrderedProduct od = new OrderedProduct();
            bool check = false;

            string Query = "SELECT productDeliveryStatus FROM orderedproducts WHERE orderedproductsID = @orderedProductsID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@orderedProductsID", orderedProductsID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    od.productDeliveryStatus = dr["productDeliveryStatus"].ToString();
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

            if (od.productDeliveryStatus == "Pending")
            {
                check = true;
            }

            return check;
        }

        public void createOrderedProduct(int orderID, int productID, int productOrderedQuantity, string recipientAddress)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            Product p = new Product();
            int sellerID = p.retrieveSellerID(productID);

            string Query = "INSERT INTO orderedproducts(orderID, sellerID, productID, productOrderedQuantity, recipientAddress) VALUES(@orderID, @sellerID, @productID, @productOrderedQuantity, @recipientAddress)";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@orderID", orderID);
            cmd.Parameters.AddWithValue("@sellerID", sellerID);
            cmd.Parameters.AddWithValue("@productID", productID);
            cmd.Parameters.AddWithValue("@productOrderedQuantity", productOrderedQuantity);
            cmd.Parameters.AddWithValue("@recipientAddress", recipientAddress);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static Product retrieveOrderedProductDetails(int productID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            Product product = new Product();

            string Query = "SELECT * FROM products WHERE productID = @productID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@productID", productID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    product.setProductID(Convert.ToInt32(dr["productID"]));
                    product.setProductName(Convert.ToString(dr["productName"]));
                    product.setPrice(Convert.ToDouble(dr["price"]));
                    product.setPhoto(Convert.ToString(dr["photo"]));
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

            return product;
        }

        public int getProductID()
        {
            return productID;
        }

        public int getProductOrderedQuantity()
        {
            return productOrderedQuantity;
        }

        public void setProductOrderedQuantity(int orderedQuantity)
        {
            this.productOrderedQuantity = orderedQuantity;
        }
    }
}