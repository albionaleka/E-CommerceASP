using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using E_commerce.Models;

namespace E_commerce.Models
{
    public class csEditProduct
    {
        public static int editProduct(int id, string name, string desc, decimal price, string image)
        {
            int result = 0;

            try
            {
                csObject edit = new csObject();
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@ProductID", id),
                new SqlParameter("@Name", name),
                new SqlParameter("@Description", desc),
                new SqlParameter("@Price", price),
                new SqlParameter("@Image", image)
                };

                result = edit.runProcedure("prEditProduct", parameters);
            } catch
            {
                result = -1;
            }
            
            return result;
        }

        public static List<Edited> getInfo(int id)
        {
            List<Edited> edit = new List<Edited>();

            string query = "SELECT Emri_Prod, Pershkrimi, Cmimi, Foto FROM tblProduktet WHERE ID_Produkti = @ID";
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@ID", id)
            };

            csObject obj = new csObject();
            DataSet ds = obj.RunQuery(query, "Product", parameter);

            foreach (DataRow row in ds.Tables["Product"].Rows)
            {
                edit.Add(new Edited {
                    Name = row["Emri_Prod"].ToString(),
                    Description = row["Pershkrimi"].ToString(),
                    Price = Convert.ToDecimal(row["Cmimi"]),
                    Image = row["Foto"].ToString()
                });
            }

            return edit;
        }
    }
}