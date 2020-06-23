using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeWebsite.Models
{
    public class FeedBackModel
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Age { get; set; }
        public string Job { get; set; }
        public string Another { get; set; }
    }
}