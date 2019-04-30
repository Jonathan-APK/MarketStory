using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Entities;

namespace MarketStory
{
    public partial class TopUpLogPage : System.Web.UI.Page
    {
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

                        List<String> topUpLogList = TopUpLog.retrieveFullTopUpLog();

                        try
                        {
                            for (int i = 0; i <= topUpLogList.Count; i++)
                            {
                                if (topUpLogList[i].Trim() != "")
                                {
                                    var row = new TableRow();
                                    var reviewCell = new TableCell();
                                    reviewCell.Font.Bold = true;
                                    reviewCell.Font.Name = "Calibri";
                                    reviewCell.BorderWidth = 1;
                                    reviewCell.BorderStyle = BorderStyle.Dotted;
                                    reviewCell.Width = 600;
                                    reviewCell.Text = "</br>" + HttpUtility.HtmlEncode(topUpLogList[i]) + "</br></br>";
                                    row.Controls.Add(reviewCell);
                                    Table1.Controls.Add(row);
                                }
                                else
                                {
                                    if (topUpLogList[i] == "")
                                    {
                                        var row = new TableRow();
                                        var reviewCell = new TableCell();
                                        reviewCell.Font.Bold = true;
                                        reviewCell.Font.Name = "Calibri";
                                        reviewCell.BorderWidth = 1;
                                        reviewCell.BorderStyle = BorderStyle.Dotted;
                                        reviewCell.Width = 600;
                                        reviewCell.Text = "</br>" + "There are no existing top-ups yet!" + "</br></br>";
                                        row.Controls.Add(reviewCell);
                                        Table1.Controls.Add(row);
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
                            reviewCell.Width = 600;
                            reviewCell.Text = "</br>" + "There are no existing top-ups yet!" + "</br></br>";
                            row.Controls.Add(reviewCell);
                            Table1.Controls.Add(row);
                        }

                    }
                    catch (Exception)
                    {
                        Response.Redirect("Mainpage.aspx");
                    }

                }
            }
        }
    }
}