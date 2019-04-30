using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using MarketStory.Controls;
using MarketStory.Entities;


namespace MarketStory
{
    public partial class ManageStore : System.Web.UI.Page
    {
        DataAccess da = new DataAccess();
        public DataTable dt;
        public static int userid;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userID"] != null)
            {
                if (!Page.IsPostBack)
                {
                    try
                    {
                        userid = Convert.ToInt32(Session["userID"]);
                        GetStoreItem(sellerName.Text);
                    }
                    catch (Exception)
                    {
                        Response.Redirect("Mainpage.aspx");
                    }
                }
            }
        }

        public void GetStoreItem(string username)
        {
            string getstoreitem = "SELECT p.productID,p.photo,p.price,p.availableQuantity,p.productName,u.username FROM products p INNER JOIN booths b ON p.boothID = b.boothID INNER JOIN users u ON b.sellerID = u.userID WHERE u.username=@username";
            dt = da.ConnectDataBaseReturnDT(HttpUtility.HtmlEncode(getstoreitem),HttpUtility.HtmlEncode(username));
            if (dt.Rows.Count > 0)
            {
                GridViewStoreItem.DataSource = HttpUtility.HtmlEncode(dt);
                GridViewStoreItem.DataBind();
            }
        }

        public string getSRC(object imgSRC)
        {
            DataRowView dRView = (DataRowView)imgSRC;
            string ImageName = dRView["photo"].ToString();
            if (ImageName == "")
            {
                return ResolveUrl("/Images/image_missing.gif");
            }
            else
            {
                return ResolveUrl(dRView["photo"].ToString());
            }
        }

        protected void searchSellerButton_Click(object sender, EventArgs e)
        {
            if (sellerName.Text.Trim() == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Please Enter A UserName');", true);
            }
            else if (da.checkUser(sellerName.Text) == false)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Invalid Name');", true);
            }
            else if (da.getBoothName(da.getID(sellerName.Text)) == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('This user have no store');", true);
            }

            else
            {
                GetStoreItem(sellerName.Text);

            }

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

            ImageButton btn = (ImageButton)sender;
            string commandArgument = btn.CommandArgument;
            int a = Convert.ToInt32(commandArgument);
            DBController db = new DBController();
            string cnnString = db.getConnectionString();
            MySqlConnection con = new MySqlConnection(cnnString);
            MySqlCommand com = new MySqlCommand("Delete from products where productID=@a", con);
            con.Open();
            com.Parameters.AddWithValue("@a", a);
            com.ExecuteNonQuery();
            con.Close();
            int boothid = da.getBoothId(a);
            int sellerid = da.getSellerId(boothid);
            string sellername = da.getUserName(sellerid);
            da.adminStoreLog(sellername, a, userid);
            GetStoreItem(sellerName.Text);

        }
    }
}