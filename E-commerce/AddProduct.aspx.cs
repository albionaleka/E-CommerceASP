using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using E_commerce.Models;
using System.IO;

namespace E_commerce
{
    public partial class AddProduct : System.Web.UI.Page
    {
        string productImageUrl;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
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
            int productCategory = Convert.ToInt32(CategoryList.SelectedItem.Value);
            

            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(productDescription))
            {
                Response.Write("<script type='text/javascript'>alert('Please fill out all the fields.');</script>");
                return;
            }

            int success = csPostProduct.postProduct(productCategory, productName, productDescription, productPrice, productImageUrl);
            if (success == 1)
            {
                Response.Redirect($"~/Default.aspx?success={success}");
            }
            else
            {
                Response.Write($"<script type='text/javascript'>alert('{productName}, {productCategory}, {productDescription}, {productPrice}');</script>");
            }

        }
    }
}