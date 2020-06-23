using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeWebsite.Models
{
    public class CartItemModel
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}