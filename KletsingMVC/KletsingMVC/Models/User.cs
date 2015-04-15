using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KletsingMVC.Models
{
    public class User
    {
        [Key]
        [StringLength(64, ErrorMessage = "Email cannot be longer than 65 characters.")]
        public string Email { get; set; }
        [StringLength(255, ErrorMessage = "Password cannot be longer than 255 characters.")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}