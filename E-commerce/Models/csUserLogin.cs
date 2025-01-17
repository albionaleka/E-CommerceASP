using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Data;

namespace E_commerce.Models
{
    public class csUserLogin
    {
        public static userModel userLogin(string email, string password)
        {
            try
            {
                csObject user = new csObject();

                string query = "SELECT * FROM fnKerkoPerdoruesin(@Email, @Password)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Password", password)
                };

                DataSet ds = user.RunQuery(query, "User", parameters);

                if (ds.Tables["User"].Rows.Count == 1)
                {
                    int userID = Convert.ToInt32(ds.Tables["User"].Rows[0]["ID_Perdoruesi"]);
                    string userType = ds.Tables["User"].Rows[0]["UserType"].ToString();
                    string userEmail = ds.Tables["User"].Rows[0]["Email"].ToString();

                    return new userModel 
                    {
                        UserID = userID,
                        UserType = userType,
                        Email = userEmail
                    };
                }
                else
                {
                    return null;
                }

            } catch
            {
                return null;
            }
        }
    }
}