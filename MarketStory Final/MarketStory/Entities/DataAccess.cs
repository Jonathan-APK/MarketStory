using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using MySql.Data.MySqlClient;


namespace MarketStory.Entities
{
    public class DataAccess
    {
        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DBController db = new DBController();

        public DataAccess()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void insertReport(string reportType, string user, string reporter, string time)
        {
            DBController db = new DBController();
            string cnnString = db.getConnectionString();
            string Query = "INSERT INTO report (reportType,reportedUser,reporter,timestamp) VALUES(@reportType,@user,@reporter,@time)";
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand(Query, con);
            con.Open();
            com.Parameters.AddWithValue("@reportType", reportType);
            com.Parameters.AddWithValue("@user", user);
            com.Parameters.AddWithValue("@reporter", reporter);
            com.Parameters.AddWithValue("@time", time);
            com.ExecuteNonQuery();
            con.Close();
        }

        public Boolean checkUser(string Username)
        {


            string cnnString = db.getConnectionString();
            string Query = "SELECT * FROM users WHERE username = @username";
            MySqlConnection conn = new MySqlConnection(cnnString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@username", Username);

            MySqlDataReader dr = cmd.ExecuteReader();
            string user = "";


            try
            {
                while (dr.Read() == true)
                {

                    user = dr["username"].ToString();

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

            if (user.Equals(Username))
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        public int getUserID(int id)
        {
            string cnnString = db.getConnectionString();

            string Query = "SELECT userId FROM posts WHERE ID = @id";
            MySqlConnection conn = new MySqlConnection(cnnString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            int userid = 0;


            try
            {
                while (dr.Read() == true)
                {
                    userid = Convert.ToInt32(dr["userId"]);


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
            return userid;
        }

        public string getPost(int id)
        {
            string cnnString = db.getConnectionString();

            string Query = "SELECT content FROM posts WHERE userId = @id";
            MySqlConnection conn = new MySqlConnection(cnnString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string content ="";


            try
            {
                while (dr.Read() == true)
                {
                    content = dr["content"].ToString();


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
            return content;
        }

        public string retrieveFriendListID(int id)
        {

            string cnnString = db.getConnectionString();
            string Query = "SELECT * FROM users WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(cnnString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string friendID = "";

            try
            {
                while (dr.Read() == true)
                {
                    friendID = dr["subscriptionList"].ToString();

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
            return friendID;
        }


        public string getUserName(int id)
        {
            DBController db = new DBController();
            string cnnString = db.getConnectionString();

            string Query = "SELECT username FROM users WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(cnnString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string userName = "";


            try
            {
                while (dr.Read() == true)
                {
                    userName = dr["username"].ToString();


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
            return userName;
        }



        public int getID(string username)
        {
            string cnnString = db.getConnectionString();

            string Query = "SELECT * FROM users WHERE username = @username";
            MySqlConnection conn = new MySqlConnection(cnnString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@username", username);

            MySqlDataReader dr = cmd.ExecuteReader();

            int getid = 0;


            try
            {
                while (dr.Read() == true)
                {
                    getid = Convert.ToInt32(dr["userID"]);


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
            return getid;
        }

        public int getBlockedByUser(int id)
        {
            string cnnString = db.getConnectionString();

            string Query = "SELECT blockedByUser FROM posts WHERE ID = @id";
            MySqlConnection conn = new MySqlConnection(cnnString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            int blockedUser = 0;


            try
            {
                while (dr.Read() == true)
                {
                    blockedUser = Convert.ToInt32(dr["blockedByUser"]);


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
            return blockedUser;
        }


        public string getBlockedByFriend(int id)
        {
            string cnnString = db.getConnectionString();

            string Query = "SELECT blockedByFriend FROM posts WHERE ID = @id";
            MySqlConnection conn = new MySqlConnection(cnnString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string blockedByFriend = "";


            try
            {
                while (dr.Read() == true)
                {
                    blockedByFriend = dr["blockedByFriend"].ToString();


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
            return blockedByFriend;
        }

        public List<string> getblockedPostByUser(int id)
        {
            string cnnString = db.getConnectionString();

            string Query = "SELECT ID FROM posts Where blockedByUser =1 AND userId =@id";
            MySqlConnection conn = new MySqlConnection(cnnString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            List<string> blockedPostId = new List<string>();


            try
            {
                while (dr.Read())
                {
                    blockedPostId.Add(dr["ID"].ToString());


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
            
            return blockedPostId;

        }

        public string getAdminPic(int id)
        {
            DBController db = new DBController();
            string cnnString = db.getConnectionString();

            string Query = "SELECT profilePicture FROM users WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(cnnString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string adminPic = "";


            try
            {
                while (dr.Read() == true)
                {
                    adminPic = dr["profilePicture"].ToString();


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
            return adminPic;
        }

        public string getAdminName(int id)
        {
            DBController db = new DBController();
            string cnnString = db.getConnectionString();
           
            string Query = "SELECT name FROM users WHERE userID = @id";
            MySqlConnection conn = new MySqlConnection(cnnString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string adminName = "";
          

            try
            {
                while (dr.Read() == true)
                {
                    adminName = dr["name"].ToString();
                    
                   
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
            return adminName;
        }

        public void banLog(String name)
        {

            string cnnString = db.getConnectionString();
            string Query = "Insert BanLog Set Ban = @name";
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand(Query, con);
            con.Open();
            com.Parameters.AddWithValue("@name", name);
            com.ExecuteNonQuery();
            con.Close();
        }

        public void banUser(String username)
        {

            string cnnString = db.getConnectionString();
            string Query = "Update users Set ban =" + 1 + " Where username = @username";
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand(Query, con);
            con.Open();
            com.Parameters.AddWithValue("@username", username);
            com.ExecuteNonQuery();
            con.Close();
        }

        public void unBanLog(String name)
        {

            string cnnString = db.getConnectionString();
            string Query = "Delete From BanLog Where Ban= @name";
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand(Query, con);
            con.Open();
            com.Parameters.AddWithValue("@name", name);
            com.ExecuteNonQuery();
            con.Close();
        }


        public void unBanUser(String username)
        {
            
            string cnnString = db.getConnectionString(); 
            string Query = "Update Users Set ban =" + 0 + " Where username = @username";
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand(Query, con);
            con.Open();
            com.Parameters.AddWithValue("@username", username);
            com.ExecuteNonQuery();
            con.Close();
        }

        public void ConnectDataBaseToInsert(string Query, String time, String content, int id)
        {

            
            string cnnString = db.getConnectionString();
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand(Query, con);
            con.Open();
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@timestamp", time);
            com.Parameters.AddWithValue("@content", content);
            com.ExecuteNonQuery();
            con.Close();


        }


        public DataTable ConnectDataBaseReturnDT(string query, string formatedString,int Id)
        {
            
            string cnnString = db.getConnectionString();
            dt = new DataTable();

            using (var cnn = new MySqlConnection(cnnString))
            {
                cnn.Open();

                using (var da = new MySqlDataAdapter())
                {

                    da.SelectCommand = new MySqlCommand(
                        query, cnn);
                    da.SelectCommand.Parameters.AddWithValue("@formatedString", formatedString);
                    da.SelectCommand.Parameters.AddWithValue("@Id", Id);
                 
                     HttpUtility.HtmlEncode(da.Fill(dt));
                    cnn.Close();
                }
            }

            return dt;
        }

        public DataTable ConnectDataBaseReturnDT(string query,string username)
        {

            string cnnString = db.getConnectionString();
            dt = new DataTable();

            using (var cnn = new MySqlConnection(cnnString))
            {
                cnn.Open();

                using (var da = new MySqlDataAdapter())
                {

                    da.SelectCommand = new MySqlCommand(
                        query, cnn);
                    da.SelectCommand.Parameters.AddWithValue("@username", username);
                    HttpUtility.HtmlEncode(da.Fill(dt));
                    cnn.Close();
                }
            }

            return dt;
        }

        public DataTable ConnectDataBaseReturnDT(string query, int Id)
        {


            string cnnString = db.getConnectionString();
            dt = new DataTable();

            using (var cnn = new MySqlConnection(cnnString))
            {
                cnn.Open();
                using (var da = new MySqlDataAdapter())
                {

                    da.SelectCommand = new MySqlCommand(
                        query, cnn);
                    da.SelectCommand.Parameters.AddWithValue("@Id", Id);
                    // Populate the DataTable 
                    HttpUtility.HtmlEncode(da.Fill(dt));
                    cnn.Close();
                }
            }

            return dt;
        }

        public DataTable ConnectDataBaseReturnDT(string query)
        {


            string cnnString = db.getConnectionString();
            dt = new DataTable();

            using (var cnn = new MySqlConnection(cnnString))
            {
                cnn.Open();
                using (var da = new MySqlDataAdapter())
                {

                    da.SelectCommand = new MySqlCommand(
                        query, cnn);

                    // Populate the DataTable 
                    HttpUtility.HtmlEncode(da.Fill(dt));
                    cnn.Close();
                }
            }

            return dt;
        }

        public void adminCardLog(int num,int amount, int userid)
        {
            
            DateTime now = DateTime.Now;
            String time = now.ToString("MMM") + " " + now.ToString("dd") + ", " + now.ToString("hh") + ":" + now.ToString("mm") + now.ToString("tt");
            string logInfo = "Generated " + num + " $"+amount+" cash card at " + time;
            string cnnString = db.getConnectionString();
            string query = "INSERT INTO adminlog (LogInfo,AdminId) VALUES(@logInfo,@userid)";
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@logInfo", logInfo);
            com.Parameters.AddWithValue("@userid", userid);
            com.ExecuteNonQuery();
            con.Close();
        }

        public void adminStoreLog(string name, int storeid, int userid)
        {
           
            DateTime now = DateTime.Now;
            String time = now.ToString("MMM") + " " + now.ToString("dd") + ", " + now.ToString("hh") + ":" + now.ToString("mm") + now.ToString("tt");
            string storeLogInfo = "Deleted " + name + " store product, id:" + storeid + " at " + time;
            string cnnString = db.getConnectionString();
            string query = "INSERT INTO adminlog (LogInfo,AdminId) VALUES(@logInfo,@userid)";
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@logInfo", storeLogInfo);
            com.Parameters.AddWithValue("@userid", userid);
            com.ExecuteNonQuery();
            con.Close();
        }

        public void adminPostLog(string name, int postid, int userid)
        {
         
            DateTime now = DateTime.Now;
            String time = now.ToString("MMM") + " " + now.ToString("dd") + ", " + now.ToString("hh") + ":" + now.ToString("mm") + now.ToString("tt");
            string logInfo = "Deleted " + name + " post, id:" + postid + " at " + time;
            string cnnString = db.getConnectionString();
            string query = "INSERT INTO adminlog (LogInfo,AdminId) VALUES(@logInfo,@userid)";
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@logInfo", logInfo);
            com.Parameters.AddWithValue("@userid", userid);
            com.ExecuteNonQuery();
            con.Close();
        }

        public void adminBanLog(int count, int userid, string name)
        {
           
            string query;
            DateTime now = DateTime.Now;
            String time = now.ToString("MMM") + " " + now.ToString("dd") + ", " + now.ToString("hh") + ":" + now.ToString("mm") + now.ToString("tt");

            if (count == 1)
            {
                string banInfo = "Ban User " + name + " at " + time;
                string cnnString = db.getConnectionString();
                query = "INSERT INTO adminlog (LogInfo,AdminId) VALUES(@banInfo,@userid)";
                MySqlConnection con = new MySqlConnection(cnnString);
                MySqlCommand com = new MySqlCommand(query, con);
                con.Open();
                com.Parameters.AddWithValue("@banInfo", banInfo);
                com.Parameters.AddWithValue("@userid", userid);
                com.ExecuteNonQuery();
                con.Close();
            }
            else if (count == 0)
            {
                string banInfo = "Unban User " + name + " at " + time;
                string cnnString = db.getConnectionString();
                query = "INSERT INTO adminlog (LogInfo,AdminId) VALUES(@banInfo,@userid)";
                MySqlConnection con = new MySqlConnection(cnnString);
                MySqlCommand com = new MySqlCommand(query, con);
                con.Open();
                com.Parameters.AddWithValue("@banInfo", banInfo);
                com.Parameters.AddWithValue("@userid", userid);
                com.ExecuteNonQuery();
                con.Close();
            }
        }

        public void adminlogin(int userid)
        {
            
            string query;
            DateTime now = DateTime.Now;
            String time = now.ToString("MMM") + " " + now.ToString("dd") + ", " + now.ToString("hh") + ":" + now.ToString("mm") + now.ToString("tt");

                string loginInfo = "Login at " + time;
                string cnnString = db.getConnectionString();
                query = "INSERT INTO adminlog (LogInfo,AdminId) VALUES(@loginInfo,@userid)";
                MySqlConnection con = new MySqlConnection(cnnString);
                MySqlCommand com = new MySqlCommand(query, con);
                con.Open();
                com.Parameters.AddWithValue("@loginInfo", loginInfo);
                com.Parameters.AddWithValue("@userid", userid);
                com.ExecuteNonQuery();
                con.Close();
            
        
        }

        public int getSellerId(int id)
        {
            DBController db = new DBController();
            string cnnString = db.getConnectionString();

            string Query = "SELECT * FROM booths WHERE boothID = @id";
            MySqlConnection conn = new MySqlConnection(cnnString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            int sellerid = 0;


            try
            {
                while (dr.Read() == true)
                {
                    sellerid = Convert.ToInt32(dr["sellerID"]);


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
            return sellerid;
        }

        public string getBoothName(int id)
        {
            DBController db = new DBController();
            string cnnString = db.getConnectionString();

            string Query = "SELECT * FROM booths WHERE sellerID = @id";
            MySqlConnection conn = new MySqlConnection(cnnString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            string boothname ="";


            try
            {
                while (dr.Read() == true)
                {
                    boothname = dr["boothName"].ToString();


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
            return boothname;
        }

      

        public int getBoothId(int id)
        {
            DBController db = new DBController();
            string cnnString = db.getConnectionString();

            string Query = "SELECT * FROM products WHERE productID = @id";
            MySqlConnection conn = new MySqlConnection(cnnString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            int boothid=0;


            try
            {
                while (dr.Read() == true)
                {
                    boothid = Convert.ToInt32(dr["boothID"]);


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
            return boothid;
        }

        public int getBanCount(string username)
        {
            string cnnString = db.getConnectionString();

            string Query = "SELECT * FROM users WHERE username = @username";
            MySqlConnection conn = new MySqlConnection(cnnString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@username", username);

            MySqlDataReader dr = cmd.ExecuteReader();

            int bancount = 0;


            try
            {
                while (dr.Read() == true)
                {
                    bancount = Convert.ToInt32(dr["ban"]);


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
            return bancount;
        }

    }
}