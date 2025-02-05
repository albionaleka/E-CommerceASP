using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ID"] != null)
                {
                    if (Session["UserType"].ToString() != "Admin") 
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }

                List<productsInfo> products = getProducts();
                productRepeater.DataSource = products;
                productRepeater.DataBind();

                List<businessInfo> businesses = getBusinesses();
                businessRepeater.DataSource = businesses;
                businessRepeater.DataBind();

                List<userInfo> users = getUsers();
                userRepeater.DataSource = users;
                userRepeater.DataBind();

                List<ordersInfo> orders = getOrders();
                orderRepeater.DataSource = orders;
                orderRepeater.DataBind();
                lblTotal.Text = $"Total Orders: {orders.Count}";
            }
        }

        public class userInfo
        {
            public int UserID { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
        }

        public class productsInfo : ProductModel 
        {
            public int BusinessID { get; set; }
        }

        public class businessInfo
        {
            public int BusinessID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }

        public class ordersInfo
        {
            public int OrderID { get; set; }
            public int UserID { get; set; }
            public decimal Payment { get; set; }
            public string Date { get; set; }
            public int OrderCount { get; set; }
        }

        protected List<productsInfo> getProducts()
        {
            string query = "SELECT * FROM tblProduktet";
            csObject product = new csObject();

            DataSet ds = product.RunQuery(query, "Products");

            List<productsInfo> products = new List<productsInfo>();

            foreach (DataRow row in ds.Tables["Products"].Rows)
            {
                products.Add(new productsInfo()
                {
                    ProductID = Convert.ToInt32(row["ID_Produkti"]),
                    BusinessID = Convert.ToInt32(row["ID_Biznesi"]),
                    CategoryID = Convert.ToInt32(row["ID_Kategoria"]),
                    ProductName = row["Emri_Prod"].ToString(),
                    Description = row["Pershkrimi"].ToString(),
                    Price = Math.Round(Convert.ToDecimal(row["Cmimi"]), 2),
                    ImageURL = row["Foto"].ToString()
                });
            }

            return products;
        }

        protected List<businessInfo> getBusinesses()
        {
            string query = "SELECT * FROM tblBizneset";

            csObject business = new csObject();
            DataSet ds = business.RunQuery(query, "Businesses");

            List<businessInfo> businesses = new List<businessInfo>();

            foreach (DataRow row in ds.Tables["Businesses"].Rows)
            {
                businesses.Add(new businessInfo()
                {
                    BusinessID = Convert.ToInt32(row["ID_Biznesi"]),
                    Name = row["Emri"].ToString(),
                    Email = row["Email"].ToString()
                });
            }

            return businesses;
        }

        protected List<userInfo> getUsers()
        {
            string query = "SELECT * FROM tblPerdoruesit";

            csObject user = new csObject();

            DataSet ds = user.RunQuery(query, "Users");

            List<userInfo> users = new List<userInfo>();

            foreach (DataRow row in ds.Tables["Users"].Rows)
            {
                users.Add(new userInfo()
                {
                    UserID = Convert.ToInt32(row["ID_Perdoruesi"]),
                    Name = row["Emri"].ToString(),
                    LastName = row["Mbiemri"].ToString(),
                    Email = row["Email"].ToString(),
                    Role = row["UserType"].ToString()
                });
            }

            return users;
        }

        protected List<ordersInfo> getOrders()
        {
            string query = "SELECT *, (SELECT COUNT(*) FROM tblPorosite) AS Count FROM tblPorosite";

            csObject order = new csObject();
            DataSet ds = order.RunQuery(query, "Orders");

            List<ordersInfo> orders = new List<ordersInfo>();

            foreach (DataRow row in ds.Tables["Orders"].Rows)
            {
                orders.Add(new ordersInfo()
                {
                    OrderID = Convert.ToInt32(row["ID_Porosia"]),
                    UserID = Convert.ToInt32(row["ID_Perdoruesi"]),
                    Payment = Math.Round(Convert.ToDecimal(row["Pagesa"]), 2),
                    Date = row["DataKoha"].ToString(),
                    OrderCount = Convert.ToInt32(row["Count"])
                });
            }

            return orders;
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Default");
        }
    }
}