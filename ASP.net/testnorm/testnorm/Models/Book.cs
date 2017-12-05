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
    [LinqToDB.Mapping.Table]
    public class Book
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Автор\" обязательно для заполнения")]
        [Display(Name = "Автор"), Column]
        public string Author { get; set; }

        [Required(ErrorMessage = "Поле \"Название Книги\" обязательно для заполнения")]
        [Display(Name = "Название Книги"), Column]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле \"Жанр\" обязательно для заполнения")]
        [Display(Name = "Жанр"), Column]
        public string Genre { get; set; }

        public void Update(Book newBookData)
        {
            Name = newBookData.Name;
            Author = newBookData.Author;
            Genre = newBookData.Genre;
        }

        public List<BookReview> Reviews
        {
            get
            {
                using (var db = new Database())
                    return (from r in db.Reviews
                            where r.IdBook == Id
                            select r).Take(10).ToList();
            }
        }

        private class Database : DataConnection
        {
            public Database() : base("Main")
            {

            }

            public ITable<BookReview> Reviews { get { return GetTable<BookReview>(); } }
        }
    }
}