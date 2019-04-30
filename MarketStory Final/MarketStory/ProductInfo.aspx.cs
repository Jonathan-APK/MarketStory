using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Entities;

namespace MarketStory
{
    public partial class ProductInfo : System.Web.UI.Page
    {
        Product p = new Product();
        Booth b = new Booth();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                int productID = Convert.ToInt32(Session["productID"]);
                p.retrieveProduct(productID);
                b = b.retrieveBoothByProduct(productID);

                productPhoto.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());

                displayName.Text = HttpUtility.HtmlEncode(p.getProductName());
                displayPrice.Text = HttpUtility.HtmlEncode("$" + Convert.ToString(p.getPrice()) + " / Item");

                displayBoothName.Text = HttpUtility.HtmlEncode(b.getBoothID() + ", " + b.getBoothName());
                displayInformation.Text = HttpUtility.HtmlEncode(p.getInformation());

                try
                {
                    string[] reviewsList = p.getReviews().Split(new char[] { ';' });

                    for (int i = 0; i < reviewsList.Length; i++)
                    {
                        if (reviewsList[i].Trim() != "")
                        {
                            var row = new TableRow();
                            var reviewCell = new TableCell();
                            reviewCell.Font.Bold = true;
                            reviewCell.Font.Name = "Calibri";
                            reviewCell.BorderWidth = 1;
                            reviewCell.BorderStyle = BorderStyle.Dotted;
                            reviewCell.Width = 800;
                            reviewCell.Text = "</br>" + HttpUtility.HtmlEncode(reviewsList[i]) + "</br></br>";
                            row.Controls.Add(reviewCell);
                            displayReviews.Controls.Add(row);
                        }
                        else
                        {
                            if (reviewsList.Length == 1)
                            {
                                var row = new TableRow();
                                var reviewCell = new TableCell();
                                reviewCell.Font.Bold = true;
                                reviewCell.Font.Name = "Calibri";
                                reviewCell.BorderWidth = 1;
                                reviewCell.BorderStyle = BorderStyle.Dotted;
                                reviewCell.Width = 800;
                                reviewCell.Text = "</br>" + "No reviews have been written for this product yet" + "</br></br>";
                                row.Controls.Add(reviewCell);
                                displayReviews.Controls.Add(row);
                            }
                            else
                            {
                            }
                        }
                    }
                }

                catch (Exception)
                {
                    var row = new TableRow();
                    var reviewCell = new TableCell();
                    reviewCell.Font.Bold = true;
                    reviewCell.Font.Name = "Calibri";
                    reviewCell.BorderWidth = 1;
                    reviewCell.BorderStyle = BorderStyle.Dotted;
                    reviewCell.Width = 800;
                    reviewCell.Text = "</br>" + "No reviews have been written for this product yet" + "</br></br>";
                    row.Controls.Add(reviewCell);
                    displayReviews.Controls.Add(row);
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