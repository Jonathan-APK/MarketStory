using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Controls;
using System.Data;
using MarketStory.Entities;

namespace MarketStory
{
    public partial class AccountManagement : System.Web.UI.Page
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
                        GetBanLog();
                    }
                    catch (Exception)
                    {
                        Response.Redirect("Mainpage.aspx");
                    }
                }
            }

        }
        public void GetBanLog()
        {
            string getBanLog = "SELECT Ban FROM BanLog ORDER BY ID DESC";
            dt = da.ConnectDataBaseReturnDT(getBanLog);
            if (dt.Rows.Count > 0)
            {
                GridViewBanLog.DataSource = HttpUtility.HtmlEncode(dt);
                GridViewBanLog.DataBind();
            }
        }

        protected void BanButton_Click(object sender, EventArgs e)
        {
            if (TextBoxBan.Text.Trim() == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Please Enter A UserName');", true);
            }

            else if (da.checkUser(TextBoxBan.Text) == false)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Invalid Name');", true);
            }

            else if (TextBoxBan.Text.Equals("Sam21") == true)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('You cannot ban admin');", true);
            }

            else if (da.getBanCount(TextBoxBan.Text) == 1)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('This user s already banned');", true);
            }
            else
            {
                da.banUser(TextBoxBan.Text);
                da.banLog(TextBoxBan.Text);
                da.adminBanLog(1, userid, TextBoxBan.Text);
                Response.Redirect("AccountManagement.aspx");
            }

        }

        protected void UnBanButton_Click(object sender, EventArgs e)
        {
            if (TextBoxUnban.Text.Trim() == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Please Enter A UserName');", true);
            }
            else if (da.checkUser(TextBoxUnban.Text) == false)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('Invalid Name');", true);
            }
            else if (da.getBanCount(TextBoxUnban.Text) == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "ThanksPopScript", "alert('This user is not banned');", true);
            }
            else
            {
                da.unBanUser(TextBoxUnban.Text);
                da.unBanLog(TextBoxUnban.Text);
                da.adminBanLog(0, userid, TextBoxUnban.Text);
                Response.Redirect("AccountManagement.aspx");
            }
        }

    }
}