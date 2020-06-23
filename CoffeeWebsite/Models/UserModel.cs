using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeWebsite.Models
{
    public class UserModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string RePassword { get; set; }

        public bool IsMatchPassword
        {
            get
            {
                return string.Equals(Password, RePassword);
            }
        }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string CustomerName { get; set; }
    }
}