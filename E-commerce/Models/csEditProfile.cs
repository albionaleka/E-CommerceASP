using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_commerce.Models
{
    public class csEditProfile
    {
        public static List<UserDetails> getDetails(int id)
        {
            List<UserDetails> user = new List<UserDetails>();
            string query = "SELECT Emri, Mbiemri, Password FROM tblPerdoruesit WHERE ID_Perdoruesi = @ID";

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@ID", id)
            };

            csObject details = new csObject();
            DataSet ds = details.RunQuery(query, "User", parameter);

            foreach (DataRow row in ds.Tables["User"].Rows)
            {
                user.Add(new UserDetails
                {
                    Name = row["Emri"].ToString(),
                    LastName = row["Mbiemri"].ToString(),
                    Password = row["Password"].ToString()
                });
            }

            return user;
        }

        public static int EditUser(int id, string name, string lastName, string password)
        {
            int result;

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserID", id),
                    new SqlParameter("@Name", name),
                    new SqlParameter("@LastName", lastName),
                    new SqlParameter("@Password", Hash.HashPassword(password))
                };

                csObject obj = new csObject();
                result = obj.runProcedure("prEditUser", parameters);
            } catch
            {
                result = -1;
            }    

            return result;
        }
    }
}