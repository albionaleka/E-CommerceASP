using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace E_commerce.Models
{
    public class csProducts
    {
        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            string query = "SELECT prod.ID_Produkti AS ID, prod.Emri_Prod AS Emri, prod.Foto AS Foto, prod.ID_Kategoria AS ID_Kategoria, prod.Cmimi AS Price, prod.Pershkrimi AS Pershkrimi, business.Emri AS Biznesi, cat.Kategoria AS Kategoria FROM tblProduktet prod \r\n\tINNER JOIN tblBizneset business ON business.ID_Biznesi = prod.ID_Biznesi INNER JOIN tblKategorite cat ON prod.ID_Kategoria = cat.ID_Kategoria";

            csObject display = new csObject();
            DataSet ds = display.RunQuery(query, "Products");

            foreach (DataRow row in ds.Tables["Products"].Rows)
            {
                products.Add(new Product
                {
                    ProductID = Convert.ToInt32(row["ID"]),
                    ProductName = row["Emri"].ToString(),
                    Description = row["Pershkrimi"].ToString(),
                    Price = Math.Round(Convert.ToDecimal(row["Price"]), 2),
                    ImageURL = row["Foto"].ToString(),
                    Category = row["Kategoria"].ToString(),
                    Business = row["Biznesi"].ToString()
                });
            }

            return products;
        }

        public static List<Product> GetQueryProducts(string searchQuery)
        {
            List<Product> products = new List<Product>();

            csObject display = new csObject();

            string query = "SELECT prod.ID_Produkti AS ID, prod.Emri_Prod AS Emri, prod.Foto AS Foto, prod.ID_Kategoria AS ID_Kategoria, prod.Cmimi AS Price, prod.Pershkrimi AS Pershkrimi, business.Emri AS Biznesi, cat.Kategoria AS Kategoria FROM tblProduktet prod \r\n\tINNER JOIN tblBizneset business ON business.ID_Biznesi = prod.ID_Biznesi INNER JOIN tblKategorite cat ON prod.ID_Kategoria = cat.ID_Kategoria WHERE prod.Emri_Prod LIKE @Search";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Search", $"%{searchQuery}%")
            };

            DataSet ds = display.RunQuery(query, "Products", parameters);

            foreach (DataRow row in ds.Tables["Products"].Rows)
            {
                products.Add(new Product
                {
                    ProductID = Convert.ToInt32(row["ID"]),
                    ProductName = row["Emri"].ToString(),
                    Description = row["Pershkrimi"].ToString(),
                    Price = Math.Round(Convert.ToDecimal(row["Price"]), 2),
                    ImageURL = row["Foto"].ToString(),
                    Category = row["Kategoria"].ToString(),
                    Business = row["Biznesi"].ToString()
                });
            }

            return products;
        }

        public static List<Product> GetCategoryProducts(int category)
        {
            List<Product> products = new List<Product>();

            csObject display = new csObject();

            string query = "SELECT prod.ID_Produkti AS ID, prod.Emri_Prod AS Emri, prod.Foto AS Foto, prod.ID_Kategoria AS ID_Kategoria, prod.Cmimi AS Price, prod.Pershkrimi AS Pershkrimi, business.Emri AS Biznesi, cat.Kategoria AS Kategoria FROM tblProduktet prod \r\n\tINNER JOIN tblBizneset business ON business.ID_Biznesi = prod.ID_Biznesi INNER JOIN tblKategorite cat ON prod.ID_Kategoria = cat.ID_Kategoria WHERE prod.ID_Kategoria=@Category";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Category", category)
            };

            DataSet ds = display.RunQuery(query, "Products", parameters);

            foreach (DataRow row in ds.Tables["Products"].Rows)
            {
                products.Add(new Product
                {
                    ProductID = Convert.ToInt32(row["ID"]),
                    ProductName = row["Emri"].ToString(),
                    Description = row["Pershkrimi"].ToString(),
                    Price = Math.Round(Convert.ToDecimal(row["Price"]), 2),
                    ImageURL = row["Foto"].ToString(),
                    Category = row["Kategoria"].ToString(),
                    Business = row["Biznesi"].ToString()
                });
            }

            return products;
        }
    }
}