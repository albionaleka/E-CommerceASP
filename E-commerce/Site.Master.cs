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

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;

            if (!string.IsNullOrEmpty(search))
            {
                Response.Redirect($"~/Products.aspx?search={search}");
            }
        }
    }
}