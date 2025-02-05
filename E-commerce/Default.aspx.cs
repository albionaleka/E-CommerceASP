using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Product> products = GetProducts();
                productRepeater.DataSource = products;
                productRepeater.DataBind();

                List<Models.Category> categories = csDefault.getCategories();
                categoryRepeater.DataSource = categories;
                categoryRepeater.DataBind();
            }
        }

        public class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string ImageURL { get; set; }
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            csObject objekti = new csObject();
            string query = "SELECT TOP 6 * FROM tblProduktet";
            DataSet ds = objekti.RunQuery(query, "Products");

            foreach (DataRow row in ds.Tables["Products"].Rows)
            {
                products.Add(new Product
                {
                    ProductID = Convert.ToInt32(row["ID_Produkti"]),
                    ProductName = row["Emri_Prod"].ToString(),
                    Description = row["Pershkrimi"].ToString(),
                    Price = Math.Round(Convert.ToDecimal(row["Cmimi"]), 2),
                    ImageURL = row["Foto"].ToString()
                });
            }

            return products;
        }

        protected void btnCategory_Click(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            int category = Convert.ToInt32(clicked.CommandArgument);

            Response.Redirect($"~/Products.aspx?category={category}");
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
                    Response.Write("<script>alert('There was an error adding product to cart.')</script>");
                }
            }
        }
    }
}