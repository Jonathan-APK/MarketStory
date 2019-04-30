using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace MarketStory.Entities
{
    public class Product
    {
        private int productID;
        private int boothID;
        private string productName;
        private string information;
        private double price;
        private string reviews;
        private int availableQuantity;
        private string photo;

        public Product()
        {
        }

        public bool checkReviewWritten(int userID, int productID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            Product prod = new Product();
            bool check = false;

            string Query = "SELECT reviews FROM products WHERE productID = @productID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@productID", productID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read() == true)
                {
                    prod.reviews = dr["reviews"].ToString();
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

                string[] reviewsArray = prod.reviews.Split(new char[] { '¿' });

                for (int i = 0; i < reviewsArray.Length; i++)
                {
                    string reviewFromUser = reviewsArray[i];
                    string[] reviewFromIndividualUser = reviewFromUser.Split(new char[] { ';' });
                    if (reviewFromIndividualUser[0] != "")
                    {
                        if (Convert.ToInt32(reviewFromIndividualUser[0]) == userID)
                        {
                            check = true;
                        }
                    }
                }
            return check;
        }

        public void writeReview(int productID, string review)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            Product prod = new Product();

            string Query = "SELECT reviews FROM products WHERE productID = @productID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@productID", productID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    prod.reviews = dr["reviews"].ToString();
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

            prod.reviews = prod.reviews + "¿" + review;

            Query = "UPDATE products SET reviews = @reviews WHERE productID = @productID";
            conn = new MySqlConnection(connectionString);
            cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@reviews", prod.reviews);
            cmd.Parameters.AddWithValue("@productID", productID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void retrieveProduct(int productID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

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
                    productName = dr["productName"].ToString();
                    information = dr["information"].ToString();
                    price = (double)dr["price"];
                    photo = dr["photo"].ToString();
                    reviews = dr["reviews"].ToString();
                    reviews = reviews.Remove(0, 1);
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

            try
            {
                string[] reviewsArray = reviews.Split(new char[] { '¿' });
                string reviewsSorted = "";

                for (int i = 0; i < reviewsArray.Length; i++)
                {
                    string reviewFromUser = reviewsArray[i];
                    string[] reviewFromIndividualUser = reviewFromUser.Split(new char[] { ';' });
                    reviewsSorted += reviewFromIndividualUser[1] + ";";
                }
                reviews = reviewsSorted;
            }
            catch (Exception)
            {
            }
        }

        public static List<Product> retrieveProductsFromBooth(int boothID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            List<Product> productList = new List<Product>();

            string Query = "SELECT * FROM products WHERE boothID = @boothID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@boothID", boothID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    Product product = new Product();
                    product.productID = Convert.ToInt32(dr["productID"]);
                    product.productName = Convert.ToString(dr["productName"]);
                    product.price = Convert.ToDouble(dr["price"]);
                    product.availableQuantity = Convert.ToInt32(dr["availableQuantity"]);
                    product.photo = Convert.ToString(dr["photo"]);
                    productList.Add(product);
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

            return productList;
        }

        public Product retrieveProductDetails(int productID)
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
                    product.productID = Convert.ToInt32(dr["productID"]);
                    product.productName = Convert.ToString(dr["productName"]);
                    product.price = Convert.ToDouble(dr["price"]);
                    product.availableQuantity = Convert.ToInt32(dr["availableQuantity"]);
                    product.photo = Convert.ToString(dr["photo"]);
                    product.information = Convert.ToString(dr["information"]);
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

        public void updateProduct(int productID, string productName, string information, double price, int availableQuantity, string photo)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            string Query = "UPDATE products SET productName = @productName, information = @information, price = @price, availableQuantity = @availableQuantity, photo = @photo WHERE productID = @productID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);

            conn.Open();

            cmd.Parameters.AddWithValue("@productID", productID);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@information", information);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@availableQuantity", availableQuantity);
            cmd.Parameters.AddWithValue("@photo", photo);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteProduct(int productID) 
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            string Query = "DELETE FROM products WHERE productID = @productID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);

            conn.Open();

            cmd.Parameters.AddWithValue("@productID", productID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void createProduct(int boothID, string productName, string information, double price, int availableQuantity, string photo)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            string Query = "INSERT INTO products(boothID, productName, information, price, availableQuantity, photo) VALUES(@boothID, @productName, @information, @price, @availableQuantity, @photo)";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);

            conn.Open();

            cmd.Parameters.AddWithValue("@boothID", boothID);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@information", information);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@availableQuantity", availableQuantity);
            cmd.Parameters.AddWithValue("@photo", photo);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public int retrieveSellerID(int productID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            int sellerID = 0;

            string Query = "SELECT b.sellerID FROM products p INNER JOIN booths b ON p.boothID = b.boothID WHERE productID = @productID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@productID", productID);

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

        public void deductProductQuantity(int productID, int quantityLeft) 
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            string Query = "UPDATE products SET pavailableQuantity = @availableQuantity WHERE productID = @productID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);

            conn.Open();

            cmd.Parameters.AddWithValue("@productID", productID);
            cmd.Parameters.AddWithValue("@availableQuantity", availableQuantity);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public int getProductID()
        {
            return productID;
        }

        public string getProductName()
        {
            return productName;
        }

        public string getInformation()
        {
            return information;
        }

        public double getPrice()
        {
            return price;
        }

        public string getReviews()
        {
            return reviews;
        }

        public string getPhoto()
        {
            return photo;
        }

        public int getAvailableQuantity()
        {
            return availableQuantity;
        }

        public void setPhoto(string photo)
        {
            this.photo = photo;
        }

        public void setPrice(double price)
        {
            this.price = price;
        }

        public void setProductName(string productName)
        {
            this.productName = productName;
        }

        public void setProductID(int productID)
        {
            this.productID = productID;
        }
    }
}