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
        public string Text { get; set; }
        //public string 

        public virtual WordType Type { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}