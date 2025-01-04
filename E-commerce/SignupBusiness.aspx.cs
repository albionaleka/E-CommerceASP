using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class signupBusiness : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignUpBtn_Click(object sender, EventArgs e)
        {
            string emri = businessName.Text;
            string email = businessEmail.Text;
            string password = businessPassword.Text;
            string confirmPass = confirmPassword.Text;

            if (string.IsNullOrEmpty(emri) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPass))
            {
                Response.Write("<script type='text/javascript'>alert('Please fill out all the fields.');</script>");
                return;
            }

            if (password != confirmPass)
            {
                Response.Write("<script type='text/javascript'>alert('Passwords do not match!');</script>");
                return;
            }

            int result = csBusinessSignup.businessSignup(emri, email, password);
            Response.Write($"<p>{result}</p>");

            //if (result == 0)
            //{
            //    Response.Clear();
            //    Response.Redirect("~/Default.aspx");
            //}
            //else
            //{
            //    Response.Write("<script type='text/javascript'>alert('Signup Failed! Email address already in use.');</script>");
            //}
        }
    }
}