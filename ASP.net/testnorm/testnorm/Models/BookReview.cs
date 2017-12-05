using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace testnorm.Models
{
    public class BookReview
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Автор\" отзыва обязательно для заполнения")]
        [Display(Name = "Автор отзыва"), Column]
        public String Name { get; set; }

        [Display(Name = "Название книги"), Column]
        public String BookName { get; set; }

        [Required(ErrorMessage = "Поле \"Отзыв\" обязательно для заполнения")]
        [Display(Name = "Отзыв"), Column]
        public String Review { get; set; }

        [Column]
        public int IdBook { get; set; }

        [Column]
        public int Likes { get; set; }

        [Column]
        public bool IsOffensive { get; set; }

        [Column]
        public string ReportReason { get; set; }
    }
}