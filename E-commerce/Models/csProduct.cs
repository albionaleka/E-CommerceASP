using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_commerce.Models
{
    public class csProduct
    {
        public static List<ProductModel> GetProduct(int id)
        {
            List<ProductModel> product = new List<ProductModel>();
            string query = "SELECT prod.ID_Produkti AS ID, prod.Emri_Prod AS Emri, prod.Foto AS Foto, prod.ID_Kategoria AS ID_Kategoria, prod.Cmimi AS Price, prod.Pershkrimi AS Pershkrimi, business.Emri AS Biznesi, cat.Kategoria AS Kategoria FROM tblProduktet prod \r\n\tINNER JOIN tblBizneset business ON business.ID_Biznesi = prod.ID_Biznesi INNER JOIN tblKategorite cat ON prod.ID_Kategoria = cat.ID_Kategoria WHERE prod.ID_Produkti = @ID";

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@ID", id)
            };

            csObject display = new csObject();
            DataSet ds = display.RunQuery(query, "Products", parameter);

            foreach (DataRow row in ds.Tables["Products"].Rows)
            {
                product.Add(new ProductModel
                {
                    ProductID = Convert.ToInt32(row["ID"]),
                    ProductName = row["Emri"].ToString(),
                    Description = row["Pershkrimi"].ToString(),
                    Price = Math.Round(Convert.ToDecimal(row["Price"]), 2),
                    ImageURL = row["Foto"].ToString(),
                    Category = row["Kategoria"].ToString(),
                    Business = row["Biznesi"].ToString(),
                    CategoryID = Convert.ToInt32(row["ID_Kategoria"])
                });
            }

            return product;
        }

        public static List<ProductModel> GetRecommended(int id, int category = 0)
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
            }
            else
            {
                query = "SELECT TOP 3 * FROM tblProduktet";
            }

            csObject recommended = new csObject();

            DataSet ds;

            if (parameter != null)
            {
                ds = recommended.RunQuery(query, "tblProduktet", parameter);
            }
            else
            {
                ds = recommended.RunQuery(query, "tblProduktet");
            }

            List<ProductModel> products = new List<ProductModel>();

            if (ds.Tables["tblProduktet"].Rows.Count > 0)
            {
                foreach (DataRow product in ds.Tables["tblProduktet"].Rows)
                {
                    if (Convert.ToInt32(product["ID_Produkti"]) != id)
                    {
                        products.Add(new ProductModel
                        {
                            ProductID = Convert.ToInt32(product["ID_Produkti"]),
                            ProductName = product["Emri_Prod"].ToString(),
                            Description = product["Pershkrimi"].ToString(),
                            Price = Math.Round(Convert.ToDecimal(product["Cmimi"]), 2),
                            ImageURL = product["Foto"].ToString(),
                            CategoryID = Convert.ToInt32(product["ID_Kategoria"])
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