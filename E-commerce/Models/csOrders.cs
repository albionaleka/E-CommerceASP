using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_commerce.Models
{
    public class csOrders
    {
        public static List<Order> getOrderDetails(int userID)
        {
            string query = "SELECT * FROM fnOrderInfo(@UserID) ORDER BY OrderDate DESC";
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@UserID", userID)
            };

            csObject order = new csObject();

            DataSet ds = order.RunQuery(query, "Orders", parameter);

            List<Order> orders = new List<Order>();

            foreach (DataRow row in ds.Tables["Orders"].Rows)
            {
                orders.Add(new Order()
                {
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    Total = Math.Round(Convert.ToDecimal(row["Payment"]), 2),
                    OrderDate = row["OrderDate"].ToString(),
                    Details = new List<OrderDetail>()
                });
            }

            getOrderDetails(orders);

            return orders;
        }

        public static void getOrderDetails(List<Order> orders)
        {
            foreach (Order order in orders)
            {
                string query = "SELECT * FROM fnOrderDetails(@OrderID)";
                SqlParameter[] param = new SqlParameter[]
                {
                new SqlParameter("@OrderID", order.OrderID)
                };

                csObject detail = new csObject();
                DataSet ds = detail.RunQuery(query, "OrderDetails", param);

                foreach (DataRow row in ds.Tables["OrderDetails"].Rows)
                {
                    order.Details.Add(new OrderDetail
                    {
                        ProductID = Convert.ToInt32(row["ProductID"]),
                        ProductName = row["Name"].ToString(),
                        Image = row["Image"].ToString(),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        Price = Math.Round(Convert.ToDecimal(row["Price"]), 2)
                    });
                }
            }          
        }
    }
}