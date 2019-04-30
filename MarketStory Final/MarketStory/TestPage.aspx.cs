using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MySql.Data.MySqlClient;

namespace MarketStory
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            /*string filename = Path.GetFileName(fileuploadimages.PostedFile.FileName);
            fileuploadimages.SaveAs(Server.MapPath("Uploads/" + filename));
            DBController db = new DBController();
            string connectionString = db.getConnectionString();

            string Query = "INSERT into products(productName, photo) values (@productName, @photo)";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@productName", filename);
            cmd.Parameters.AddWithValue("@photo", "Images/" + filename);

            cmd.ExecuteNonQuery();
            conn.Close();*/

            Response.Redirect("~/ProductInfo.aspx");
        }
    }
}