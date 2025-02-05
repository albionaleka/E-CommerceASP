using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Order> orders = csOrders.getOrderDetails(Convert.ToInt32(Session["ID"]));
                orderRepeater.DataSource = orders;
                orderRepeater.DataBind();
            }
        }

        protected void orderDetailsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int productID = Convert.ToInt32(e.CommandArgument);
                int userID = Convert.ToInt32(Session["ID"]);

                int success = csAddToCart.addToCart(productID, userID);

                if (success > 0)
                {
                    Response.Redirect("Cart.aspx");
                }
                else
                {
                    Response.Write("<script>There was an error adding product to cart.</script>");
                }
            }
        }
    }
}