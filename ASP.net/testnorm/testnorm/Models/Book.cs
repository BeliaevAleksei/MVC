using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testnorm.Models
{
    public class Book: IComparable<Book>
    {
        public int Id { get; set; }

        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Display(Name = "Название Книги")]
        public string Name { get; set; }
        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        public int CompareTo(Book book)
        {
            return string.Compare(this.Name, book.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}