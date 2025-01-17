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
        public static int postProduct(int Kategoria, string Emri, string Pershkrimi, decimal Price, string Image)
        {
            int result;

            try
            {
                csObject product = new csObject();
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@ID_Biznesi", 20000),
                    new SqlParameter("@ID_Kategoria", Kategoria),
                    new SqlParameter("@Emri", Emri),
                    new SqlParameter("@Pershkrimi", Pershkrimi),
                    new SqlParameter("@Image", Image),
                    new SqlParameter("@Price", Price)
                };

                result = product.runProcedure("prPostProducts", parameter);
            }
            catch
            {
                result = -1;
            }

            return result;
        }
    }
}