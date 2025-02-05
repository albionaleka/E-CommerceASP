using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace E_commerce.Models
{
    public class userModel
    {
        public int UserID { get; set; }
        public string UserType { get; set; }
        public string Email { get; set; }
    }

    public class UserDetails
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public string Category { get; set; }
        public string Business { get; set; }
    }

    public class ProductModel : Product
    {
        public int CategoryID { get; set; }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

    public class CartItem
    {
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }

    public class PaymentDetails
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string OrderDate { get; set; }
        public decimal Total { get; set; }
        public List<OrderDetail> Details { get; set; }
    }

    public class OrderDetail
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class Edited
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }

    public class Hash
    {
        public static string HashPassword(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
    } 
}