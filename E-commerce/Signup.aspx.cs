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

            Console.WriteLine(emri, mbiemri, email, password, confirmPass);

            if (confirmPass == password)
            {
                int result = csUserSignUp.userSignup(emri, mbiemri, email, password);

                if (result > 0)
                {
                    Response.Redirect("~/Default");
                }
                else
                {
                    Response.Write("<p>Signup Failed.</p>");
                }
            }
        }
    }
}