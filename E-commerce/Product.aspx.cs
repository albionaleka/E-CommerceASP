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
                int productID = Convert.ToInt32(Request.QueryString["product"]);
                List<productModel> product = getProduct(productID);

                int category = 0;

                if (product != null)
                {
                    category = Convert.ToInt32(product[0].Category);
                    productRepeater.DataSource = product;
                    productRepeater.DataBind();
                }

                List<productModel> recommended = getRecommended(productID, category);
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

        protected List<productModel> getProduct(int id)
        {
            csObject produkti = new csObject();
            string query = "SELECT * FROM tblProduktet WHERE ID_Produkti=@ID";
            SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@ID", id)
                };

            DataSet ds = produkti.RunQuery(query, "tblProduktet", parameter);
            List<productModel> product = new List<productModel>();

            if (ds.Tables["tblProduktet"].Rows.Count > 0)
            {
                DataRow row = ds.Tables["tblProduktet"].Rows[0];

                product.Add(new productModel
                {
                    ProductID = Convert.ToInt32(row["ID_Produkti"]),
                    ProductName = row["Emri_Prod"].ToString(),
                    Description = row["Pershkrimi"].ToString(),
                    Price = Math.Round(Convert.ToDecimal(row["Cmimi"]), 2),
                    ImageURL = row["Foto"].ToString(),
                    Category = Convert.ToInt32(row["ID_Kategoria"])
                });

                return product;
            }
            else
            {
                return null;
            }
        }

        protected List<productModel> getRecommended(int id, int category=0)
        {
            string query;
            SqlParameter[] parameter = null;

            if (category != 0)
            {
                query = "SELECT TOP 3 * FROM tblProduktet WHERE ID_Kategoria=@Kategoria";
                parameter = new SqlParameter[]
                {
                    new SqlParameter("@Kategoria", category)
                };
            } else
            {
                query = "SELECT TOP 3 * FROM tblProduktet";
            }
            

            csObject recommended = new csObject();

            DataSet ds = new DataSet();

            if (parameter != null)
            {
                ds = recommended.RunQuery(query, "tblProduktet", parameter);
            } else
            {
                ds = recommended.RunQuery(query, "tblProduktet");
            }

            List<productModel> products = new List<productModel>();

            if (ds.Tables["tblProduktet"].Rows.Count > 0)
            {
                foreach (DataRow product in ds.Tables["tblProduktet"].Rows)
                {
                    if (Convert.ToInt32(product["ID_Produkti"]) != id)
                    {
                        products.Add(new productModel
                        {
                            ProductID = Convert.ToInt32(product["ID_Produkti"]),
                            ProductName = product["Emri_Prod"].ToString(),
                            Description = product["Pershkrimi"].ToString(),
                            Price = Math.Round(Convert.ToDecimal(product["Cmimi"]), 2),
                            ImageURL = product["Foto"].ToString(),
                            Category = Convert.ToInt32(product["ID_Kategoria"])
                        });
                    } 
                }
                
                return products;
            }
            else
            {
                return null;
            }
        }
    }
}