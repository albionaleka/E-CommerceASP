using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["ID"] == null || Session["UserType"].ToString() == "Business")
                {
                    Response.Redirect("~/Login");
                }

                bindData();
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(Session["ID"]);

            Response.Write("<script>alert('Checkout initiated');</script>");

            int success = csCart.placeOrder(UserID);

            Response.Write($"<script>alert('Success value: {success}');</script>");

            if (success == 1)
            {
                Response.Redirect("~/Orders.aspx");
            } else
            {
                Response.Write("<script>Error placing order. Please try again.</script>");
            }
        }

        protected void cartRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "UpdateQuantity")
            {
                int product = Convert.ToInt32(e.CommandArgument);
                TextBox txtQuantity = (TextBox)e.Item.FindControl("txtQuantity");
                int quantity = Convert.ToInt32(txtQuantity.Text);
                int userID = Convert.ToInt32(Session["ID"]);

                Console.WriteLine($"ProductID: {product}, Quantity: {quantity}");


                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Quantity", quantity),
                    new SqlParameter("@ProductID", product),
                    new SqlParameter("@UserID", userID)
                };

                csObject csObject = new csObject();
                int success;

                if (quantity > 0)
                {
                    success = csObject.runProcedure("updateQuantity", parameters);
                } else
                {
                    SqlParameter[] deleteParameters = new SqlParameter[]
                    {
                        new SqlParameter("@ProductID", product),
                        new SqlParameter("@UserID", userID)
                    };

                    success = csObject.runProcedure("deleteFromCart", deleteParameters);
                }
                

                if (success == 1)
                {
                    bindData();
                } else
                {
                    Response.Write("<script>Couldn't update product quantity!</script>");
                }   
            } else if (e.CommandName == "DeleteFromCart")
            {
                int product = Convert.ToInt32(e.CommandArgument);
                int userID = Convert.ToInt32(Session["ID"]);

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ProductID", product),
                    new SqlParameter("@UserID", userID)
                };

                csObject csObject = new csObject();
                int success = csObject.runProcedure("deleteFromCart", parameters);

                if (success == 1)
                {
                    bindData();
                }
            }
        }

        private void bindData()
        {
            List<CartItem> items = csCart.getCartItems(Convert.ToInt32(Session["ID"]));
            cartRepeater.DataSource = items;
            cartRepeater.DataBind();

            List<PaymentDetails> paymentDetails = csCart.getPaymentDetails(Convert.ToInt32(Session["ID"]));

            decimal total = 0;

            foreach (PaymentDetails item in paymentDetails)
            {
                total += item.Total;
            }

            decimal totalCost = Convert.ToDecimal(total);
            decimal tax = Math.Round((totalCost * 0.18m), 2);

            decimal beforeTax = Math.Round((totalCost - tax), 2);

            lblTotal.Text = (Math.Round(total, 2)).ToString();
            lblTax.Text = tax.ToString();
            lblBeforeTax.Text = beforeTax.ToString();

            paymentInfoRepeater.DataSource = items;
            paymentInfoRepeater.DataBind();
        }
    }
}