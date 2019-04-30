using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using MarketStory.Entities;

namespace MarketStory.Market
{
    public partial class EditProduct : System.Web.UI.Page
    {
        int productID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["userID"] != null)
                {
                    productID = Convert.ToInt32(Session["editProductID"]);
                    ViewState["editProductID"] = productID;
                    Product p = new Product();
                    p = p.retrieveProductDetails(productID);
                    TextBox1.Text = p.getProductName();
                    TextBox2.Text = Convert.ToString(p.getPrice());
                    TextBox3.Text = Convert.ToString(p.getAvailableQuantity());
                    TextBox4.Text = p.getInformation();
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

            if (HiddenField1.Value == "Yes")
            {
                string filename = Path.GetFileName(fileuploadimages.PostedFile.FileName);
                string filePath;

                if (filename != "")
                {
                    fileuploadimages.SaveAs(Server.MapPath("~/Uploads/Products/" + filename));
                    filePath = "/Uploads/Products/" + filename;
                }
                else
                {
                    filePath = "/Images/image_missing.png";
                }
                string productName = TextBox1.Text;
                double price = Convert.ToDouble(TextBox2.Text);
                int availableQuantity = Convert.ToInt32(TextBox3.Text);
                string info = TextBox4.Text;

                Product p = new Product();
                p.updateProduct(Convert.ToInt32(ViewState["editProductID"]), productName, info, price, availableQuantity, filePath);

                ScriptManager.RegisterStartupScript(this, typeof(string), "OrderSuccessScript", "alert('Update success! Press OK to go back to manage booth');window.open('SellerManageBooth.aspx', '_self');", true);
            }
            else if (HiddenField1.Value == "No")
            {
            }
        }
    }
}