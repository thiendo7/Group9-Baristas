using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeWebsite.Models
{
    public class ChangePasswordModel
    {
        [Required]
        public string PasswordOld { get; set; }
        [Required]
        public string PasswordNew { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        public bool IsMatchPassword
        {
            get
            {
                return string.Equals(PasswordNew, ConfirmPassword);
            }
        }
    }
}