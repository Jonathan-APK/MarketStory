using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MarketStory.Entities;

namespace MarketStory.Market
{
    public partial class Temp2 : System.Web.UI.Page
    {
        double subtotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                int userID = Convert.ToInt32(Session["userID"]);
                ViewState["userID"] = userID;
                User user = new User();
                user = user.retrieveBoothOwnerInfo(userID);

                Image1.ImageUrl = HttpUtility.HtmlEncode(user.getProfilePicture());
                Label2.Text = HttpUtility.HtmlEncode(user.getUsername());
                Label1.Text = HttpUtility.HtmlEncode(Convert.ToString(user.getAccountBalance()));

                List<OrderedProduct> cartItems = new List<OrderedProduct>();
                cartItems = (List<OrderedProduct>)(Session["cartItems"]);

                //ViewState["cartItems"] = cartItems;

                Label31.Text = Convert.ToString(subtotal);

                try
                {
                    if (cartItems.Count != 0)
                    {
                        if (cartItems.Count == 1)
                        {
                            displayProduct1(cartItems[0]);
                        }
                        if (cartItems.Count == 2)
                        {
                            displayProduct1(cartItems[0]);
                            displayProduct2(cartItems[1]);
                        }
                        if (cartItems.Count == 3)
                        {
                            displayProduct1(cartItems[0]);
                            displayProduct2(cartItems[1]);
                            displayProduct3(cartItems[2]);
                        }
                        if (cartItems.Count == 4)
                        {
                            displayProduct1(cartItems[0]);
                            displayProduct2(cartItems[1]);
                            displayProduct3(cartItems[2]);
                            displayProduct4(cartItems[3]);
                        }
                        if (cartItems.Count == 5)
                        {
                            displayProduct1(cartItems[0]);
                            displayProduct2(cartItems[1]);
                            displayProduct3(cartItems[2]);
                            displayProduct4(cartItems[3]);
                            displayProduct5(cartItems[4]);
                        }
                        if (cartItems.Count == 6)
                        {
                            displayProduct1(cartItems[0]);
                            displayProduct2(cartItems[1]);
                            displayProduct3(cartItems[2]);
                            displayProduct4(cartItems[3]);
                            displayProduct5(cartItems[4]);
                            displayProduct6(cartItems[5]);
                        }
                        if (cartItems.Count == 7)
                        {
                            displayProduct1(cartItems[0]);
                            displayProduct2(cartItems[1]);
                            displayProduct3(cartItems[2]);
                            displayProduct4(cartItems[3]);
                            displayProduct5(cartItems[4]);
                            displayProduct6(cartItems[5]);
                            displayProduct7(cartItems[6]);
                        }
                        if (cartItems.Count == 8)
                        {
                            displayProduct1(cartItems[0]);
                            displayProduct2(cartItems[1]);
                            displayProduct3(cartItems[2]);
                            displayProduct4(cartItems[3]);
                            displayProduct5(cartItems[4]);
                            displayProduct6(cartItems[5]);
                            displayProduct7(cartItems[6]);
                            displayProduct8(cartItems[7]);
                        }
                    }

                    if (Convert.ToInt32(ViewState["voucherUsedID"]) == 1)
                    {
                        subtotal = subtotal - 1;
                    }
                    else if (Convert.ToInt32(ViewState["voucherUsedID"]) == 2)
                    {
                        subtotal = subtotal - 2;

                    }
                    else if (Convert.ToInt32(ViewState["voucherUsedID"]) == 3)
                    {
                        subtotal = subtotal - 3;

                    }
                    else if (Convert.ToInt32(ViewState["voucherUsedID"]) == 4)
                    {
                        subtotal = subtotal - 5;

                    }
                    else if (Convert.ToInt32(ViewState["voucherUsedID"]) == 5)
                    {
                        subtotal = subtotal - 10;
                    }

                    ViewState["subtotal"] = subtotal;

                    Label31.Text = HttpUtility.HtmlEncode(Convert.ToString(ViewState["subtotal"])); ;

                    RedeemedVoucher r1 = new RedeemedVoucher();
                    r1 = r1.retrieveRedeemedVoucherQuantity(userID, 1);
                    Label42.Text = HttpUtility.HtmlEncode(Convert.ToString(r1.getAvailableQuantity()));

                    RedeemedVoucher r2 = new RedeemedVoucher();
                    r2 = r2.retrieveRedeemedVoucherQuantity(userID, 2);
                    Label43.Text = HttpUtility.HtmlEncode(Convert.ToString(r2.getAvailableQuantity()));

                    RedeemedVoucher r3 = new RedeemedVoucher();
                    r3 = r3.retrieveRedeemedVoucherQuantity(userID, 3);
                    Label44.Text = HttpUtility.HtmlEncode(Convert.ToString(r3.getAvailableQuantity()));

                    RedeemedVoucher r4 = new RedeemedVoucher();
                    r4 = r4.retrieveRedeemedVoucherQuantity(userID, 4);
                    Label45.Text = HttpUtility.HtmlEncode(Convert.ToString(r4.getAvailableQuantity()));

                    RedeemedVoucher r5 = new RedeemedVoucher();
                    r5 = r5.retrieveRedeemedVoucherQuantity(userID, 5);
                    Label46.Text = HttpUtility.HtmlEncode(Convert.ToString(r5.getAvailableQuantity()));

                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "CartEmptyScript", "alert('Cart empty. Failed to check out');window.open('~/BoothUI.aspx?booth=1', '_self');", true);
                }
            }
            else
            {
                Session["login"] = false;
                Response.Redirect("~/MainPage.aspx");
            }
        }

        protected void displayProduct1(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            Image18.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            Label4.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label5.Text = HttpUtility.HtmlEncode(Convert.ToString(p.getPrice()));
            Label6.Text = HttpUtility.HtmlEncode(Convert.ToString(op.getProductOrderedQuantity()));
            Image18.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            subtotal += Convert.ToDouble(Label5.Text) * Convert.ToInt32(Label6.Text);
        }

        protected void displayProduct2(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            Image2.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            Label7.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label8.Text = HttpUtility.HtmlEncode(Convert.ToString(p.getPrice()));
            Label9.Text = HttpUtility.HtmlEncode(Convert.ToString(op.getProductOrderedQuantity()));
            Image2.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            subtotal += Convert.ToDouble(Label8.Text) * Convert.ToInt32(Label9.Text);
        }

        protected void displayProduct3(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            Image3.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            Label10.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label11.Text = HttpUtility.HtmlEncode(Convert.ToString(p.getPrice()));
            Label12.Text = HttpUtility.HtmlEncode(Convert.ToString(op.getProductOrderedQuantity()));
            Image3.Visible = true;
            Label10.Visible = true;
            Label11.Visible = true;
            Label12.Visible = true;
            subtotal += Convert.ToDouble(Label11.Text) * Convert.ToInt32(Label12.Text);
        }

        protected void displayProduct4(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            Image4.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            Label13.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label14.Text = HttpUtility.HtmlEncode(Convert.ToString(p.getPrice()));
            Label15.Text = HttpUtility.HtmlEncode(Convert.ToString(op.getProductOrderedQuantity()));
            Image4.Visible = true;
            Label13.Visible = true;
            Label14.Visible = true;
            Label15.Visible = true;
            subtotal += Convert.ToDouble(Label14.Text) * Convert.ToInt32(Label15.Text);
        }

        protected void displayProduct5(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            Image5.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            Label16.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label17.Text = HttpUtility.HtmlEncode(Convert.ToString(p.getPrice()));
            Label18.Text = HttpUtility.HtmlEncode(Convert.ToString(op.getProductOrderedQuantity()));
            Image5.Visible = true;
            Label16.Visible = true;
            Label17.Visible = true;
            Label18.Visible = true;
            subtotal += Convert.ToDouble(Label17.Text) * Convert.ToInt32(Label18.Text);
        }

        protected void displayProduct6(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            Image6.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            Label19.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label20.Text = HttpUtility.HtmlEncode(Convert.ToString(p.getPrice()));
            Label21.Text = HttpUtility.HtmlEncode(Convert.ToString(op.getProductOrderedQuantity()));
            Image6.Visible = true;
            Label19.Visible = true;
            Label20.Visible = true;
            Label21.Visible = true;
            subtotal += Convert.ToDouble(Label20.Text) * Convert.ToInt32(Label21.Text);
        }

        protected void displayProduct7(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            Image7.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            Label22.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label23.Text = HttpUtility.HtmlEncode(Convert.ToString(p.getPrice()));
            Label24.Text = HttpUtility.HtmlEncode(Convert.ToString(op.getProductOrderedQuantity()));
            Image7.Visible = true;
            Label22.Visible = true;
            Label23.Visible = true;
            Label24.Visible = true;
            subtotal += Convert.ToDouble(Label23.Text) * Convert.ToInt32(Label24.Text);
        }

        protected void displayProduct8(OrderedProduct op)
        {
            Product p = OrderedProduct.retrieveOrderedProductDetails(op.getProductID());
            Image8.ImageUrl = HttpUtility.HtmlEncode(p.getPhoto());
            Label25.Text = HttpUtility.HtmlEncode(p.getProductName());
            Label26.Text = HttpUtility.HtmlEncode(Convert.ToString(p.getPrice()));
            Label27.Text = HttpUtility.HtmlEncode(Convert.ToString(op.getProductOrderedQuantity()));
            Image8.Visible = true;
            Label25.Visible = true;
            Label26.Visible = true;
            Label27.Visible = true;
            subtotal += Convert.ToDouble(Label26.Text) * Convert.ToInt32(Label27.Text);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            Button6.Enabled = true;
            Button7.Enabled = true;
            Button8.Enabled = true;
            Button9.Enabled = true;
            Button10.Enabled = true;
            ViewState["voucherUsedID"] = 0;
            Panel1.Visible = false;
            Panel2.Visible = true;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(Label42.Text);
            if (quantity != 0)
            {
                Label42.Text = Convert.ToString(quantity - 1);
                Button6.Enabled = false;
                Button7.Enabled = false;
                Button8.Enabled = false;
                Button9.Enabled = false;
                Button10.Enabled = false;
                ScriptManager.RegisterStartupScript(this, typeof(string), "CheckUsageScript", "confirm('You can only use 1 voucher for each order\n, confirm use of $1 voucher?!');", true);
                ViewState["voucherUsedID"] = 1;
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(Label43.Text);
            if (quantity != 0)
            {
                Label43.Text = HttpUtility.HtmlEncode(Convert.ToString(quantity - 1));
                Button6.Enabled = false;
                Button7.Enabled = false;
                Button8.Enabled = false;
                Button9.Enabled = false;
                Button10.Enabled = false;
                ScriptManager.RegisterStartupScript(this, typeof(string), "CheckUsageScript", "confirm('You can only use 1 voucher for each order\n, confirm use of $2 voucher?!');", true);
                ViewState["voucherUsedID"] = 2;
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(Label44.Text);
            if (quantity != 0)
            {
                Label44.Text = HttpUtility.HtmlEncode(Convert.ToString(quantity - 1));
                Button6.Enabled = false;
                Button7.Enabled = false;
                Button8.Enabled = false;
                Button9.Enabled = false;
                Button10.Enabled = false;
                ScriptManager.RegisterStartupScript(this, typeof(string), "CheckUsageScript", "confirm('You can only use 1 voucher for each order\n, confirm use of $3 voucher?!');", true);
                ViewState["voucherUsedID"] = 3;
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(Label45.Text);
            if (quantity != 0)
            {
                Label45.Text = HttpUtility.HtmlEncode(Convert.ToString(quantity - 1));
                Button6.Enabled = false;
                Button7.Enabled = false;
                Button8.Enabled = false;
                Button9.Enabled = false;
                Button10.Enabled = false;
                ScriptManager.RegisterStartupScript(this, typeof(string), "CheckUsageScript", "confirm('You can only use 1 voucher for each order\n, confirm use of $5 voucher?!');", true);
                ViewState["voucherUsedID"] = 4;
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(Label46.Text);
            if (quantity != 0)
            {
                Label46.Text = HttpUtility.HtmlEncode(Convert.ToString(quantity - 1));
                Button6.Enabled = false;
                Button7.Enabled = false;
                Button8.Enabled = false;
                Button9.Enabled = false;
                Button10.Enabled = false;
                ScriptManager.RegisterStartupScript(this, typeof(string), "CheckUsageScript", "confirm('You can only use 1 voucher for each order\n, confirm use of $10 voucher?!');", true);
                ViewState["voucherUsedID"] = 5;
            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Button6.Enabled = true;
            Button7.Enabled = true;
            Button8.Enabled = true;
            Button9.Enabled = true;
            Button10.Enabled = true;
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            Panel2.Visible = false;
        }

        protected void Button5_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/BoothUI.aspx?booth=2");
        }

        protected void Button19_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(Label1.Text) < Convert.ToDouble(Label31.Text))
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "InsufficientBalanceScript", "alert('You do not have insufficient money!');", true);
            }
            else
            {
                Order order = new Order();
                order.createOrder(Convert.ToInt32(ViewState["userID"]), Convert.ToDouble(ViewState["subtotal"]), DateTime.Now.ToString("MMMM dd, yyyy H:mm:ss tt"));
                int orderID = order.retrieveLastOrder(Convert.ToInt32(ViewState["userID"]));

                OrderedProduct op = new OrderedProduct();
                List<OrderedProduct> cartItems = new List<OrderedProduct>();
                cartItems = (List<OrderedProduct>)(Session["cartItems"]);
                string address = TextBox1.Text;
                for (int i = 0; i < cartItems.Count; i++)
                {
                    op.createOrderedProduct(orderID, cartItems[i].getProductID(), cartItems[i].getProductOrderedQuantity(), address);
                }

                RedeemedVoucher rv = new RedeemedVoucher();
                int redeemedVouchersID = rv.retrieveRedeemedVoucherID(Convert.ToInt32(ViewState["userID"]), Convert.ToInt32(ViewState["voucherUsedID"]));
                rv.updateRedeemedVoucherQuantity(redeemedVouchersID);

                User user = new User();
                user.updateUserAccountBalance(Convert.ToInt32(ViewState["userID"]), -Convert.ToDouble(ViewState["subtotal"]));
                user.updateUserAccountBalance(1, +Convert.ToDouble(ViewState["subtotal"]));

                Session["cartItems"] = null;

                ScriptManager.RegisterStartupScript(this, typeof(string), "OrderSuccessScript", "alert('Order has been created! Press OK to continue.');window.open('~/Orders.aspx', '_self');", true);
            }
        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            TextBox1.Text = HttpUtility.HtmlEncode("");
            Panel2.Visible = true;
        }
    }
}