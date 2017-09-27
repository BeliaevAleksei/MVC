using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testnorm.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Display(Name = "Автор")]
        public string Author { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }
    }
}