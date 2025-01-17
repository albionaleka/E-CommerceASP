using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_commerce.Models
{
    public class productModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public int Category { get; set; }
    }
}