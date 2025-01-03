using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.Common;
using E_commerce.Models;

namespace E_commerce.Models
{
    public class csUserSignUp
    {
        public static int userSignup(string Emri, string Mbiemri, string Email, string Password)
        {
            int result = 0;

            csObject user = new csObject();
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@Emri", Emri),
                new SqlParameter("@Mbiemri", Mbiemri),
                new SqlParameter("@Email", Email),
                new SqlParameter("@Password", Password)
            };

            result = user.runProcedure("prSignUp", parameter);

            return result;
        }
    }
}