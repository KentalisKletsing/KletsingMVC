﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KletsingMVC.Models
{
    public class WordListWordTypeViewModel
    {
        [StringLength(50, ErrorMessage = "Word cannot be longer than 50 characters.")]
        public string Text { get; set; }

        public ICollection<WordType> WordTypes { get; set; }
    }
}