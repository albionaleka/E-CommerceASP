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
        public static int userLogin(string email, string password)
        {
            try
            {
                csObject user = new csObject();

                string query = $"SELECT ID_Perdoruesi FROM fnKerkoPerdoruesin('{email}', '{password}')";

                DataSet ds = user.RunQuery(query, "User");

                if (ds.Tables["User"].Rows.Count > 0)
                {
                    int userID = Convert.ToInt32(ds.Tables["User"].Rows[0]["ID_Perdoruesi"]);
                    return userID;
                }
                else
                {
                    return -1;
                }

            } catch
            {
                return -1;
            }
        }
    }
}