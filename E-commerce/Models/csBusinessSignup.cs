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
    public class csBusinessSignup
    {
        public static int businessSignup(string Emri, string Email, string Password)
        {
            int result;

            try
            {
                csObject business = new csObject();
                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@Emri", Emri),
                    new SqlParameter("@Email", Email),
                    new SqlParameter("@Password", Password)
                };

                result = business.runProcedure("prSignupBizneset", parameter);
            }
            catch
            {
                result = -1;
            }

            return result;
        }
    }
}