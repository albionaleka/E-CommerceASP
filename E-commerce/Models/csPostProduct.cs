using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace E_commerce.Models
{
    public class csPostProduct
    {
        // int Biznesi
        public static int postProduct(int Kategoria, string Emri, string Pershkrimi, string Image, string Price)
        {
            int result;

            try
            {
                csObject product = new csObject();
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@Biznesi", 20000),
                    new SqlParameter("@Kategoria", Kategoria),
                    new SqlParameter("@Emri", Emri),
                    new SqlParameter("@Pershkrimi", Pershkrimi),
                    new SqlParameter("@Image", Image),
                    new SqlParameter("@Price", Convert.ToDecimal(Price))
                };

                result = product.runProcedure("prPostProduct", parameter);
            }
            catch
            {
                result = -1;
            }

            return result;
        }
    }
}