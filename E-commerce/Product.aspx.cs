using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_commerce.Models;

namespace E_commerce
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ID"] == null)
                {
                    Response.Redirect("~/Login");
                }

                int productID = Convert.ToInt32(Request.QueryString["product"]);
                List<ProductModel> product = csProduct.GetProduct(productID);

                int category = 0;

                if (product != null)
                {
                    category = Convert.ToInt32(product[0].CategoryID);
                    productRepeater.DataSource = product;
                    productRepeater.DataBind();
                } else
                {
                    Response.Redirect("~/NotFound");
                }

                List<ProductModel> recommended = csProduct.GetRecommended(productID, category);
                if (recommended != null)
                {
                    if (recommended.Count > 0)
                    {
                        repeaterRecommended.DataSource = recommended;
                        repeaterRecommended.DataBind();
                    } else
                    {
                        lblRecommended.Text = "No products found in the same category!";
                        linkProducts.Visible = true;
                    }
                    
                }
            }
        }

        protected void productRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int productID = Convert.ToInt32(e.CommandArgument);
                int userID = Convert.ToInt32(Session["ID"]);

                int success = csAddToCart.addToCart(productID, userID);

                if (success == 1)
                {
                    Response.Redirect("Cart.aspx");
                }
                else
                {
                    Response.Write("<script>There was an error adding product to cart.</script>");
                }
            }
        }

        protected void repeaterRecommended_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int productID = Convert.ToInt32(e.CommandArgument);
                int userID = Convert.ToInt32(Session["ID"]);

                int success = csAddToCart.addToCart(productID, userID);

                if (success == 1)
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