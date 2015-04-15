using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KletsingMVC.Models
{
    public class WordType
    {
        [Key]
        [StringLength(1, ErrorMessage = "Has to be 1 character.")]
        public string Text { get; set; }
        [Range(-1, 1)]
        public int Location { get; set; }
    }
}