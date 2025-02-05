using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace E_commerce.Models
{
    public class csCart
    {
        public static List<CartItem> getCartItems(int UserID)
        {
            string query = "SELECT * FROM fnCartDetails(@UserID)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", UserID)
            };

            csObject item = new csObject();

            DataSet ds = item.RunQuery(query, "Cart", parameters);

            List<CartItem> items = new List<CartItem>();

            foreach (DataRow row in ds.Tables["Cart"].Rows)
            {
                items.Add(new CartItem()
                {
                    CartID = Convert.ToInt32(row["CartID"]),
                    ProductID = Convert.ToInt32(row["ProductID"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    ProductName = row["Name"].ToString(),
                    Image = row["Image"].ToString(),
                    Price = Math.Round(Convert.ToDecimal(row["Price"]), 2)
                });
            }

            return items;
        }

        public static List<PaymentDetails> getPaymentDetails(int UserID)
        {
            string query = "SELECT * FROM fnPaymentDetails(@UserID)";
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@UserID", UserID)
            };

            csObject payment = new csObject();

            DataSet ds = payment.RunQuery(query, "Payment", parameter);

            List<PaymentDetails> paymentDetails = new List<PaymentDetails>();

            foreach (DataRow row in ds.Tables["Payment"].Rows)
            {
                paymentDetails.Add(new PaymentDetails()
                {
                    ProductID = Convert.ToInt32(row["ProductID"]),
                    ProductName = row["Name"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Price = Math.Round(Convert.ToDecimal(row["Price"]), 2),
                    Total = Math.Round((Convert.ToDecimal(row["Price"]) * Convert.ToInt32(row["Quantity"])), 2)
                });
            }

            return paymentDetails;
        }

        public static int placeOrder(int UserID)
        {
            int result;

            try
            {
                csObject order = new csObject();

                SqlParameter[] parameter = new SqlParameter[]
                {
                new SqlParameter("@UserID", UserID)
                };

                result = order.runProcedure("prPlaceOrder", parameter);
            } catch
            {
                result = -1;
            }

            return result;
        }

    }
}