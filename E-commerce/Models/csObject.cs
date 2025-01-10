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
    public class csObject
    {
        protected SqlConnection Connection;

        string error;

        public csObject() 
        {
            string con = ConfigurationManager.ConnectionStrings["connectionEcommerce"].ToString();
            Connection = new SqlConnection(con);
        }

        public void fnConnection() { }

        public int runProcedure (string storedProcedure, IDataParameter[] parameters)
        {
            int res = -1;

            try
            {
                Connection.Open();

                SqlCommand cmd = new SqlCommand(storedProcedure, Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (IDataParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }

                res = cmd.ExecuteNonQuery();

                Connection.Close();
            } catch (Exception)
            {
                error = "There was an error calling the procedures";
            }

            return res;
        }

        public DataSet RunQuery(string query, string tableName, SqlParameter[] parameters = null)
        {
            DataSet ds = new DataSet();

            Connection.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.CommandType = CommandType.Text;

            if (parameters != null)
            {
                foreach (IDataParameter param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
            }

            sqlda.SelectCommand = cmd;
            sqlda.Fill(ds, tableName);

            Connection.Close();

            return ds;
        }
    }
}