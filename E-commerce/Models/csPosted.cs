using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static E_commerce._Default;

namespace E_commerce.Models
{
    public class csPosted
    {
        public static List<Product> getListings(string email)
        {
            List<Product> products = new List<Product>();
            string query = "SELECT prod.ID_Produkti AS ID, prod.Emri_Prod AS Emri, prod.Foto AS Foto, prod.ID_Kategoria AS ID_Kategoria, prod.Cmimi AS Price, prod.Pershkrimi AS Pershkrimi, business.Emri AS Biznesi, cat.Kategoria AS Kategoria FROM tblProduktet prod \r\n\tINNER JOIN tblBizneset business ON business.ID_Biznesi = prod.ID_Biznesi INNER JOIN tblKategorite cat ON prod.ID_Kategoria = cat.ID_Kategoria WHERE prod.ID_Biznesi = @BusinessID";

            int businessID = findBusiness(email);

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@BusinessID", businessID)
            };

            csObject display = new csObject();
            DataSet ds = display.RunQuery(query, "Products", parameter);

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

        protected static int findBusiness(string email)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@Email", email),
            };

            csObject obj = new csObject();
            DataSet ds = obj.RunQuery("SELECT ID_Biznesi FROM tblBizneset WHERE Email = @Email", "Biznesi", parameter);

            return Convert.ToInt32(ds.Tables["Biznesi"].Rows[0]["ID_Biznesi"]);
        }
    }
}