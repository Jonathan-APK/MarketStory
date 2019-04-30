using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using MarketStory.Controls;
using MarketStory.Entities;

namespace MarketStory
{
    public partial class LoginHistory : System.Web.UI.Page
    {
        DataAccess dbClass = new DataAccess();
        public DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                if (!Page.IsPostBack)
                {
                    try
                    {
                        int userid = Convert.ToInt32(Session["userID"]);
                        GetAdminLog(userid);
                    }
                    catch (Exception)
                    {
                        Response.Redirect("Mainpage.aspx");
                    }
                }

            }
            else
            {
                Session["login"] = false;
                Response.Redirect("MainPage.aspx");
            }

        }

        public void GetAdminLog(int Id)
        {
            string getAdminLog = "SELECT LogInfo FROM AdminLog where AdminId="+Id+" ORDER BY ID DESC";
            dt = dbClass.ConnectDataBaseReturnDT(getAdminLog,Id);
            if (dt.Rows.Count > 0)
            {
                GridViewLoginHistory.DataSource = HttpUtility.HtmlEncode(dt);
                GridViewLoginHistory.DataBind();


            }
        }
    }
}