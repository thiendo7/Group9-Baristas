using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeWebsite.Models
{
    public class BookingTableModel
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int NumberCustomer { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public TimeSpan BookingTime { get; set; }
    }
}