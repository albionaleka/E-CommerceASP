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
            bool saveCookies = checkRemember.Checked;

            string hashed = Hash.HashPassword(password);

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Response.Write("<script type='text/javascript'>alert('Please fill out all the fields.');</script>");
                return;
            }

            if (saveCookies)
            {
                Response.Cookies["email"].Value = email;
                Response.Cookies["email"].Expires = DateTime.Now.AddDays(10);
            }

            userModel user = csUserLogin.userLogin(email, hashed);
            if (user == null)
            {
                Response.Write("<script type='text/javascript'>alert('Invalid login credentials.');</script>");
                return;
            }

            Session.RemoveAll();

            Session["ID"] = user.UserID;
            Session["UserType"] = user.UserType;
            Session["Email"] = user.Email;
            Response.Redirect($"~/Default");
            
        }
    }
}