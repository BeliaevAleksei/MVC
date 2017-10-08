using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testnorm.Models;


namespace testnorm.Models
{
    public class BaseTest
    {
        public static readonly BaseTest instance = new BaseTest();

        public static BaseTest Instance
        {
            get { return instance; }
        }


        public IEnumerable<Book> Book
        {
            get { return Books; }
        }

        public IEnumerable<BookReview> Reviews
        {
            get { return Rewiews; }
        }

        public List<Book> Books = new List<Book>();

        public List<BookReview> Rewiews = new List<BookReview>();


        public void AddBook(Book newBook)
        {
            _bookId++;
            newBook.Id = _bookId;
            Books.Add(newBook);
        }

        public void AddReview(BookReview newReview)
        {
            _reviewId++;
            newReview.Id = _reviewId;
            Rewiews.Add(newReview);
        }

        private static int _bookId;

        private static int _reviewId;

        private BaseTest()
        {
            Book book = new Book()
            {
                Id = 1,
                Author = "SomeOne1",
                Genre = "Fen",
                Name = "hz"
            };

            Book book1 = new Book()
            {
                Id = 2,
                Author = "SomeOne2",
                Genre = "ThusRoDuh",
                Name = "hz2"
            };

            Books.AddRange(new List<Book>() { book, book1 });

            BookReview review = new BookReview()
            {
                Id = 1,
                BookName = "ono",
                Name = "ononos",
                Review = "tak se",
                IdBook = 1
            };

            Rewiews.Add(review);
            _bookId = 2;
            _reviewId = 1;

        }
    }
}