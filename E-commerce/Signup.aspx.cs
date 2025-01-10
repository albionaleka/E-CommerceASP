using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignUpBtn_Click(object sender, EventArgs e)
        {
            string emri = userName.Text;
            string mbiemri = userLastName.Text;
            string email = userEmail.Text;
            string password = userPassword.Text;
            string confirmPass = confirmPassword.Text;

            if (string.IsNullOrEmpty(emri) || string.IsNullOrEmpty(mbiemri) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPass))
            {
                Response.Write("<script type='text/javascript'>alert('Please fill out all the fields.');</script>");
                return;
            }

            if (password != confirmPass)
            {
                Response.Write("<script type='text/javascript'>alert('Passwords do not match!');</script>");
                return;
            }

            csUserSignUp.userSignup(emri, mbiemri, email, password);
            Response.Redirect("~/Default.aspx");
        }
    }
}