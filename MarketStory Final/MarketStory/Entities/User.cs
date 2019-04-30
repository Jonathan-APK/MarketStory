using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace MarketStory.Entities
{
    public class User
    {
        private int userID;
        private string username;
        private string passwordHash;
        private string name;
        private char gender;
        private string birthday;
        private string email;
        private string information;
        private int handphone;
        private string friendList;
        private string subscriptionList;
        private string profilePicture;
        private int MSPoints;
        private int RepPoints;
        private double accountBalance;
        private bool ban;
        private string bookmarks;
	public string friendUsername;

        public User()
        {
        }

        public User retrieveUser(int userID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            User user = new User();

            string Query = "SELECT * FROM users WHERE userID = @userID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@userID", userID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    user.userID = userID;
                    user.MSPoints = (int)dr["MSPoints"];
                    user.RepPoints = (int)dr["RepPoints"];
                    user.email = dr["email"].ToString();
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

            return user;
        }

        public void updateUserMSPoints(int userID, int MSPointsToAddOrDeduct)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            User user = new User();

            string Query = "SELECT MSPoints FROM users WHERE userID = @userID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@userID", userID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    user.userID = userID;
                    user.MSPoints = (int)dr["MSPoints"];
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

            Query = "UPDATE users SET MSPoints = @MSpoints WHERE userID = @userID";
            conn = new MySqlConnection(connectionString);
            cmd = new MySqlCommand(Query, conn);
            conn.Open();

            int updatedMSPoints = user.MSPoints + MSPointsToAddOrDeduct;

            cmd.Parameters.AddWithValue("@MSPoints", updatedMSPoints);
            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void updateUserRepPoints(int userID, int repPointsToAddOrDeduct)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            User user = new User();

            string Query = "SELECT RepPoints FROM users WHERE userID = @userID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@userID", userID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    user.userID = userID;
                    user.RepPoints = (int)dr["RepPoints"];
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

            Query = "UPDATE users SET RepPoints = @RepPoints WHERE userID = @userID";
            conn = new MySqlConnection(connectionString);
            cmd = new MySqlCommand(Query, conn);
            conn.Open();

            int updatedRepPoints = user.RepPoints + repPointsToAddOrDeduct;

            cmd.Parameters.AddWithValue("@RepPoints", updatedRepPoints);
            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public User retrieveUserAccountBalance(int userID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            User user = new User();

            string Query = "SELECT accountBalance FROM users WHERE userID = @userID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@userID", userID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    user.userID = userID;
                    user.accountBalance = (int)dr["accountBalance"];
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

            return user;
        }

        public void updateUserAccountBalance(int userID, double amount)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            User user = new User();

            string Query = "SELECT accountBalance FROM users WHERE userID = @userID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@userID", userID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    user.userID = userID;
                    user.accountBalance = (int)dr["accountBalance"];
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

            Query = "UPDATE users SET accountBalance = @accountBalance WHERE userID = @userID";
            conn = new MySqlConnection(connectionString);
            cmd = new MySqlCommand(Query, conn);
            conn.Open();

            double updatedAccountBalance = user.accountBalance + amount;

            cmd.Parameters.AddWithValue("@accountBalance", updatedAccountBalance);
            cmd.Parameters.AddWithValue("@userID", userID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

	    public User retrieveFriendInfo(int userID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            User user = new User();

            string Query = "SELECT profilePicture, username FROM users WHERE userID = @userID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@userID", userID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    user.userID = userID;
                    user.profilePicture = dr["profilePicture"].ToString();
                    user.friendUsername = dr["username"].ToString();
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

            return user;
        }

        public User retrieveBoothOwnerInfo(int userID)
        {
            DBController db = new DBController();
            string connectionString = db.getConnectionString();
            User user = new User();

            string Query = "SELECT RepPoints, username, profilePicture, accountBalance FROM users WHERE userID = @userID";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@userID", userID);

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read() == true)
                {
                    user.userID = userID;
                    user.RepPoints = (int)dr["RepPoints"];
                    user.profilePicture = dr["profilePicture"].ToString();
                    user.username = dr["username"].ToString();
                    user.accountBalance = (double)dr["accountBalance"];
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

            return user;
        }

        public int getUserID()
        {
            return userID;
        }

        public int getMSPoints()
        {
            return MSPoints;
        }

        public int getRepPoints()
        {
            return RepPoints;
        }

        public double getAccountBalance()
        {
            return accountBalance;
        }

        public string getEmail()
        {
            return email;
        }

        public string getUsername()
        {
            return username;
        }

        public string getProfilePicture()
        {
            return profilePicture;
        }

        public string getFriendUsername()
        {
            return friendUsername;
        }
    }
}