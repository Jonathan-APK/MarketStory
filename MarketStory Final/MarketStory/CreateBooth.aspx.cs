using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Entities;

namespace MarketStory.Market
{
    public partial class CreateBooth : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["userID"] != null)
                {
                    int userID = Convert.ToInt32(Session["userID"]);
                    User user = new User();
                    Booth booth = new Booth();
                    ViewState["userID"] = userID;
                }
                else
                {
                    Session["login"] = false;
                    Response.Redirect("~/MainPage.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Booth b = new Booth();
            if (b.checkBoothExists(Convert.ToInt32(ViewState["userID"])) == false)
            {
                b.createBooth(Convert.ToInt32(ViewState["userID"]), TextBox1.Text);
                ScriptManager.RegisterStartupScript(this, typeof(string), "CreateBoothSuccessScript", "alert('Booth created successfully');window.open('SellerManageBooth.aspx', '_self');", true);
                System.Windows.Forms.MessageBox.Show("Booth created successfully");
                Response.Redirect("~/SellerManageBooth.aspx");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("You already own a booth! Redirecting you to Market page");
                Response.Redirect("~/Panaroma.aspx");
            }
        }
    }
}