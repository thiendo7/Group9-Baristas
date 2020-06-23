using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeWebsite.Models
{
    public class CartModel
    {
        public Account Account { get; set; }
        public List<CartItemModel> CartItems { get; set; }
        public List<Payment> Payments { get; set; }

        public string DiscountCode { get; set; }
        public int DiscountPercent { get; set; }
        public double TotalCart { get; set; }
        public double TotalFinal { get; set; }
        public double TotalDiscountByCode { get; set; }

        public bool IsSubmit { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }
        public string Note { get; set; }

        [Required]
        public int PaymentId { get; set; }
    }
}