using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_commerce.Models
{
    public class csAddToCart
    {
        public static int addToCart(int productID, int userID)
        {
            int result;

            try
            {
                csObject addProduct = new csObject();
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID_Perdoruesi", userID),
                    new SqlParameter("@ProductID", productID)
                };

                result = addProduct.runProcedure("prAddToCart", parameters);
            }
            catch
            {
                result = -1;
            }

            return result;
        }
    }
}