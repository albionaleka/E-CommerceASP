using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static E_commerce._Default;

namespace E_commerce
{
    public partial class Products : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Models.Product> products = new List<Models.Product>();
                string search = Request.QueryString["search"];
                int category = Convert.ToInt32(Request.QueryString["category"]);

                if (search == null && category == 0)
                {
                    products = csProducts.GetProducts();
                }
                else
                {
                    if (category != 0)
                    {
                        products = csProducts.GetCategoryProducts(category);
                    }

                    if (search != null)
                    {
                        products = csProducts.GetQueryProducts(search);
                    }
                }

                productsRepeater.DataSource = products;
                productsRepeater.DataBind();
            }
        }

        protected void productsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                if (Session["ID"] == null)
                {
                    Response.Redirect("~/Login");
                }

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

        protected void CategoryPicker_Change (object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("~/Login");
            }

            int categoryID = Convert.ToInt32(CategoryPicker.SelectedValue);

            Response.Redirect($"~/Products.aspx?category={categoryID}");
        }
    }
}