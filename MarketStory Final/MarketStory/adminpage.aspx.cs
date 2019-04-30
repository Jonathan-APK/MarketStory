using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Controls;
using MySql.Data.MySqlClient;
using MarketStory.Entities;

namespace MarketStory
{
    public partial class adminpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userID"] != null)
            {

                if ((int)Session["userID"] == 1)
                {
                    if (!Page.IsPostBack)
                    {

                        try
                        {
                            DataAccess a = new DataAccess();
                            adminName.Text = HttpUtility.HtmlEncode("Admin " + a.getAdminName(Convert.ToInt32(Session["userID"])));
                            adminPic.ImageUrl = a.getAdminPic(Convert.ToInt32(Session["userID"]));
                        }
                        catch (Exception)
                        {
                            Response.Redirect("MainPage.aspx");
                        }

                    }
                }
                else
                {
                    //Session["userID"] = "";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('This page can only be accesed by admin');window.open('MainPage.aspx', '_self');", true);
                }

            }
            else
            {
                Session["login"] = false;
                Response.Redirect("MainPage.aspx");
            }


        }




    }
}