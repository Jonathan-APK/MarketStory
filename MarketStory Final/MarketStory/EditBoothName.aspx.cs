using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Entities;

namespace MarketStory.Market
{
    public partial class EditBoothName : System.Web.UI.Page
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

                    booth = booth.retrieveBooth(userID);
                    ViewState["editBoothNameID"] = booth.getBoothID();
                    string boothName = booth.getBoothName();
                    TextBox1.Text = boothName;
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
            b.updateBoothName(Convert.ToInt32(ViewState["editBoothNameID"]), TextBox1.Text);
            ScriptManager.RegisterStartupScript(this, typeof(string), "EditBoothSuccessScript", "alert('Booth name updated successfully!');window.open('SellerManageBooth.aspx', '_self');", true);
        }
    }
}