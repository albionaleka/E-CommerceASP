using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_commerce.Models;

namespace E_commerce
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ID"] != null)
                {
                    btnLogout.Visible = true;
                    lnkLogin.Visible = false;

                    if (Session["UserType"].ToString() == "Business")
                    {
                        lnkAddProduct.Visible = true;
                    }

                    if (Session["UserType"].ToString() == "User")
                    {
                        lnkCart.Visible = true;
                        lnkOrders.Visible = true;
                    }

                    if (Session["UserType"].ToString() == "Admin")
                    {
                        lnkAdmin.Visible = true;
                    }

                    lnkContact.Visible = true;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;

            if (!string.IsNullOrEmpty(search))
            {
                Response.Redirect($"~/Products.aspx?search={search}");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Clear();
            Response.Redirect("~/Default");
        }
    }
}