using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_commerce.Models;

namespace E_commerce
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void userLogin_Click(object sender, EventArgs e)
        {
            string email = userEmail.Text.Trim();
            string password = userPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Response.Write("<script type='text/javascript'>alert('Please fill out all the fields.');</script>");
                return;
            }

            int userID = csUserLogin.userLogin(email, password);
            Session["ID"] = userID;
            Response.Redirect($"~/Default");
        }
    }
}