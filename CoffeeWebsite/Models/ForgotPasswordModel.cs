﻿
using System.ComponentModel.DataAnnotations;

namespace CoffeeWebsite.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        public string Email { get; set; }
    }
}