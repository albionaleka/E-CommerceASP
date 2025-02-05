using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class EditProduct : System.Web.UI.Page
    {
        string productImageUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ID"] == null)
                {
                    Response.Redirect("~/Login");
                } else if (Request.QueryString["product"] == null || Session["UserType"].ToString() != "Business")
                {
                    Response.Redirect("~/Products");
                }

                List<Edited> product = csEditProduct.getInfo(Convert.ToInt32(Request.QueryString["product"]));
                txtProductName.Text = product[0].Name;
                txtProductDescription.Text = product[0].Description;
                txtProductPrice.Text = Math.Round(product[0].Price, 2).ToString();
            }
        }

        protected void btnEditProduct_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["product"]);

            if (fileProductImage.HasFile)
            {
                string fileName = Path.GetFileName(fileProductImage.PostedFile.FileName);
                string folderPath = Server.MapPath("uploadedProducts/");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(folderPath, fileName);

                fileProductImage.SaveAs(filePath);

                productImageUrl = "UploadedProducts/" + fileName;
            }
            else
            {
                productImageUrl = "images/products/no-image.jpg";
            }

            string productName = txtProductName.Text;
            decimal productPrice = Convert.ToDecimal(txtProductPrice.Text);
            string productDescription = txtProductDescription.Text;

            csObject obj = new csObject();

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@Email", Session["Email"].ToString())
            };

            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(productDescription))
            {
                Response.Write("<script type='text/javascript'>alert('Please fill out all the fields.');</script>");
                return;
            }

            int success = csEditProduct.editProduct(id, productName, productDescription, productPrice, productImageUrl);
            if (success == 1)
            {
                Response.Redirect($"~/Posted.aspx");
            }
            else
            {
                Response.Write($"<script type='text/javascript'>alert('Couldn't edit product. Please review the form!');</script>");
            }
        }
    }
}