using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Data;

namespace E_commerce.Models
{
    public class csDefault
    {
        public static List<Category> getCategories()
        {
            string query = "SELECT * FROM tblKategorite";

            csObject kategoria = new csObject();
            DataSet ds = kategoria.RunQuery(query, "Kategorite");

            List<Category> categories = new List<Category>();

            foreach(DataRow row in ds.Tables["Kategorite"].Rows)
            {
                categories.Add(new Category
                {
                    CategoryID = Convert.ToInt32(row["ID_Kategoria"]),
                    CategoryName = row["Kategoria"].ToString()
                });
            }

            return categories;
        }
    }
}