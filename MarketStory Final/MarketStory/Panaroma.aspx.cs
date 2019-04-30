using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarketStory
{
    public partial class Panaroma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {

            }
            else
            {
                Session["login"] = false;
                Response.Redirect("MainPage.aspx");
            }
        }

        protected void createBoothButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateBooth.aspx");
        }

        protected void manageBoothButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SellerManageBooth.aspx");
        }
    }
}