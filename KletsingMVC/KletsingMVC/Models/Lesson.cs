using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KletsingMVC.Models
{
    public class Lesson
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50, ErrorMessage = "Lesson name cannot be longer than 50 characters.")]
        public string Name { get; set; }
    }
}