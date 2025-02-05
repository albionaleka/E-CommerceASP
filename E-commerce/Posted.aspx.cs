using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_commerce.Models;

namespace E_commerce
{
    public partial class Posted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ID"] == null || Session["UserType"].ToString() != "Business")
                {
                    Response.Redirect("Default.aspx");
                }

                bindData();
            }
        }

        protected void postedRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "EditListing")
            {
                Response.Redirect($"~/EditProduct.aspx?product={e.CommandArgument}");
            }

            if (e.CommandName == "DeleteListing")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                string query = "DELETE FROM tblProduktet WHERE ID_Produkti = @ID";

                SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@ID", id)
                };

                csObject obj = new csObject();
                obj.RunQuery(query, "Produktet", parameter);

                bindData();
            }
        }

        private void bindData()
        {
            string email = Session["Email"].ToString();
            List<Models.Product> listings = csPosted.getListings(email);

            if (listings.Count > 0)
            {
                postedRepeater.DataSource = listings;
                postedRepeater.DataBind();
            }
            else
            {
                postedRepeater.Visible = false;
                noListings.Visible = true;
                addProduct.Visible = true;
            }
        }
    }
}