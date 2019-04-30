using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Entities;
using System.IO;
using System.Windows.Forms;

namespace MarketStory
{
    public partial class GenerateCashCard : System.Web.UI.Page
    {
        DataAccess da = new DataAccess();
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

                    }
                    catch (Exception)
                    {
                        Response.Redirect("Mainpage.aspx");
                    }

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(TextBox1.Text);

            for (int i = 0; i < quantity; i++)
            {
                string lastSerialNumber = CashCard.retrieveLastCashCard();
                string lastCardSeries = lastSerialNumber.Substring(0, 4);
                int lastSeriesNumber = Convert.ToInt32(lastSerialNumber.Substring(4));

                string newCardSeries = null;
                int newCardSeriesNumber = 0;
                string newSerialNumber = null;

                if (lastCardSeries == "ABCD")
                {
                    if (lastSeriesNumber != 99999999)
                    {
                        newCardSeries = "ABCD";
                        Random rand = new Random((int)DateTime.Now.Ticks);
                        int randomNum = rand.Next(1, 99);
                        newCardSeriesNumber = lastSeriesNumber + randomNum;
                        newSerialNumber = newCardSeries.Substring(0, 2) + newCardSeriesNumber + newCardSeries.Substring(2);
                    }
                    else
                    {
                        newCardSeries = "CDEF";
                        Random rand = new Random((int)DateTime.Now.Ticks);
                        int randomNum = rand.Next(12345678, 99999999);
                        newCardSeriesNumber = randomNum;
                        newSerialNumber = newCardSeries.Substring(0, 2) + newCardSeriesNumber + newCardSeries.Substring(2);
                    }
                }
                else if (lastCardSeries == "CDEF")
                {
                    newCardSeries = "CDEF";
                    Random rand = new Random((int)DateTime.Now.Ticks);
                    int randomNum = rand.Next(1, 99);
                    newCardSeriesNumber = lastSeriesNumber + randomNum;
                    newSerialNumber = newCardSeries.Substring(0, 2) + newCardSeriesNumber + newCardSeries.Substring(2);

                }

                CashCard cc = new CashCard();
                string newSecurityCode = cc.generateSecurityCode();
                int cashValue = Convert.ToInt32(DropDownList1.SelectedValue);

                cc.createCashCard(newSerialNumber, cc.generateSecurityCodeHash(newSecurityCode), cashValue);

                var row = new TableRow();
                var countCell = new TableCell();
                countCell.Text = HttpUtility.HtmlEncode(Convert.ToString(i + 1));
                var serialNumCell = new TableCell();
                serialNumCell.Text = HttpUtility.HtmlEncode(newSerialNumber);
                var securityCodeCell = new TableCell();
                securityCodeCell.Text = HttpUtility.HtmlEncode(newSecurityCode);
                row.Controls.Add(countCell);
                row.Controls.Add(serialNumCell);
                row.Controls.Add(securityCodeCell);
                Table1.Controls.Add(row);

                Session["TableContent"] = Table1;
                da.adminCardLog(quantity, cashValue, userid);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Table table1 = (Table)Session["TableContent"];

            try
            {
                TextWriter textWriter = new StreamWriter("C:\\OOPPJ\\MSCashCards Report.txt");
                for (int i = 0; i < table1.Rows.Count; i++)
                {
                    textWriter.Write(table1.Rows[i].Cells[0].Text + "\t" + table1.Rows[i].Cells[1].Text + "\t" + table1.Rows[i].Cells[2].Text + "\r\n");
                }

                textWriter.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}