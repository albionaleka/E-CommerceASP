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
                List<Product> products = new List<Product>();
                string search = Request.QueryString["search"];

                if (search == null)
                {
                    products = GetProducts();
                }
                else
                {
                    products = GetQueryProducts(search);
                }

                productsRepeater.DataSource = products;
                productsRepeater.DataBind();
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

            csObject display = new csObject();
            DataSet ds = display.RunQuery("SELECT * FROM tblProduktet", "Products");

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

        public List<Product> GetQueryProducts(string searchQuery)
        {
            List<Product> products = new List<Product>();

            csObject display = new csObject();

            string query = "SELECT * FROM tblProduktet WHERE Emri_Prod LIKE @Search";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Search", $"%{searchQuery}%")
            };

            DataSet ds = display.RunQuery(query, "Products", parameters);

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
    }
}