using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KletsingMVC.Models
{
    public class Song
    {
        [Key]
        [StringLength(50, ErrorMessage = "Song name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        public virtual ICollection<Word> Words { get; set; }
    }
}