using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class EdtProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Session["ID"]);
                List<UserDetails> user = csEditProfile.getDetails(id);

                userName.Text = user[0].Name.ToString();

                if (Session["UserType"].ToString() != "Business")
                {
                    userLastName.Text = user[0].LastName.ToString();
                } else {
                    userLastName.Enabled = false;
                    userLastName.Visible = false;
                    lblLastName.Visible = false;
                }
                
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["ID"]);
            List<UserDetails> user = csEditProfile.getDetails(id);

            string oldPassword = user[0].Password;

            string name = userName.Text;
            string lastName = userLastName.Text;

            string currentPassword = txtPassword.Text;

            string password = newPassword.Text;
            string confirm = confirmPassword.Text;

            if (oldPassword == Hash.HashPassword(currentPassword) && password == confirm)
            {
                int result = csEditProfile.EditUser(id, name, lastName, password);

                if (result == 1)
                {
                    Response.Redirect("~/Default");
                } else
                {
                    Response.Write("<script>alert(Something went wrong when editing your profile.)</script>");
                }
            } else
            {
                Response.Write("<script>alert(Passwords do not match!)</script>");
            }
        }
    }
}