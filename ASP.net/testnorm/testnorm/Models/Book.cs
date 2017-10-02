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
        [Display(Name = "Название Книги")]
        public string Name { get; set; }
        [Display(Name = "Жанр")]
        public string Genre { get; set; }
    }

    //class Book : IComparer<Book>
    //{
    //    public int Compare(string[] o1, string[] o2)
    //    {
    //        if (o1[1].Length > o2[1].Length)
    //        {
    //            return 1;
    //        }
    //        else if (o1[1].Length < o2[1].Length)
    //        {
    //            return -1;
    //        }
    //        return 0;
    //    }
    //}
}