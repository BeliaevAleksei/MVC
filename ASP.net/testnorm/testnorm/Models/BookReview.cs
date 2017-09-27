using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testnorm.Models
{
    public class BookReview
    {
        public int Id { get; set; }
        [Display(Name = "Автор")]
        public String Name { get; set; }

        public String BookName { get; set; }
        [Display(Name = "Отзыв")]
        public String Review { get; set; }
        public int IdBook { get; set; }
    }
}