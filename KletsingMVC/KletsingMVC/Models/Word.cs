using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KletsingMVC.Models
{
    public class Word
    {
        [Key]
        [StringLength(50, ErrorMessage = "Word cannot be longer than 50 characters.")]
        [Required]
        public string Text { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

        [Required]
        public int Location { get; set; }

        [Required]
        public string Letter { get; set; }
    }
}