using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeWebsite.Models
{
    public class ProductModel
    {
        [Required]
        public int ProductSizeId { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int ProductCateID { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string UserName { get; set; }
    }
}