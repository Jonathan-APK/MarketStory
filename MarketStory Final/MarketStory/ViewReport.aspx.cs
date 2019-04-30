using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Controls;
using MySql.Data.MySqlClient;
using System.Data;
using MarketStory.Entities;


namespace MarketStory
{
    public partial class ViewReport : System.Web.UI.Page
    {
        DataAccess da = new DataAccess();
        public DataTable dt;
        DBController db = new DBController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetReport();
            }
        }



        public void GetReport()
        {
            string getReport = "SELECT * FROM Report ORDER BY reportId DESC";
            dt = da.ConnectDataBaseReturnDT(getReport);
            if (dt.Rows.Count > 0)
            {
                GridViewReport.DataSource = HttpUtility.HtmlEncode(dt);
                GridViewReport.DataBind();


            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            string commandArgument = btn.CommandArgument;
            int a = Convert.ToInt32(commandArgument);
            string cnnString = db.getConnectionString();
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand("Delete from Report where reportId=@a", con);
            con.Open();
            com.Parameters.AddWithValue("@a", a);
            com.ExecuteNonQuery();
            con.Close();
            GetReport();
        }

        protected void Marker_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string id = btn.CommandArgument;
            string text = btn.Text;
            if (text == "Unread")
            {

                string cnnString = db.getConnectionString();
                MySqlConnection con = new MySqlConnection(cnnString);
                String query = "Update Report Set reportMarker='Read' Where reportId=@id";
                MySqlCommand com = new MySqlCommand(query, con);
                con.Open();
                com.Parameters.AddWithValue("@id", id);
                com.ExecuteNonQuery();
                con.Close();
                GetReport();
            }
            else
            {
                string cnnString = db.getConnectionString();
                MySqlConnection con = new MySqlConnection(cnnString);
                String query = "Update Report Set reportMarker='Unread' Where reportId=@id";
                MySqlCommand com = new MySqlCommand(query, con);
                con.Open();
                com.Parameters.AddWithValue("@id", id);
                com.ExecuteNonQuery();
                con.Close();
                GetReport();
            }
        }

    }
}