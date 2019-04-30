using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using MySql.Data.MySqlClient;

namespace MarketStory
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AutoComplete : System.Web.Services.WebService
    {
        public AutoComplete()
        {
            //Uncomment the following line if using designed components
            //InitializeComponent();
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod]
        public string[] GetCompletionList(string prefixText, int count)
        {
            //ADO.Net
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            List<string> resultsList = new List<string>();
            string result;

            //Compare String From Textbox(searchTerm) AND String From 
            //Column in DataBase(CompanyName)
            //If String from DataBase is equal to String from TextBox(searchTerm) 
            //then add it to return ItemList
            string Query = "SELECT username FROM users WHERE username LIKE '%' @username '%' AND userID not in (@userID, 1)";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@username", prefixText);
            cmd.Parameters.AddWithValue("@userID", Session["userID"]);

            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                result = dr["username"].ToString();
                resultsList.Add(result);
            }

            try
            {
                while (dr.Read() == true)
                {
                    result = dr["username"].ToString();
                    resultsList.Add(result);
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

            string Query2 = "SELECT productName FROM products WHERE productName LIKE '%' @productName '%'";
            MySqlConnection conn2 = new MySqlConnection(connectionString);
            MySqlCommand cmd2 = new MySqlCommand(Query2, conn2);
            conn2.Open();

            cmd2.Parameters.AddWithValue("@productName", prefixText);

            MySqlDataReader dr2 = cmd2.ExecuteReader();

            if (dr2.Read() == true)
            {
                result = dr2["productName"].ToString();
                resultsList.Add(result);
            }

            try
            {
                while (dr2.Read() == true)
                {
                    result = dr2["productName"].ToString();
                    resultsList.Add(result);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                dr2.Close();
                conn2.Close();
            }

            //Then return List of string(resultsList) as result
            return resultsList.ToArray();
        }
    }
}