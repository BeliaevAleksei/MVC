using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testnorm.Models;


namespace testnorm.Models
{
    public class BookContext : IBookContext
    {
        public static readonly BookContext instance = new BookContext();

        public static BookContext Instance
        {
            get { return instance; }
        }

        public List<Book> Books = new List<Book>();

        public List<BookReview> Rewiews = new List<BookReview>();

        public Book GetBook(int bookId)
        {
            var book = Books.SingleOrDefault(x => x.Id == bookId);
            if (book == null)
                return null;   
            book.Reviews.Clear();
            book.Reviews.AddRange(BookReviewContext.Instance.GetAll().Where(x => x.IdBook == bookId));
            return book;
        }

        public Book Update(Book newBookData)
        {
            if (newBookData == null) throw new ArgumentNullException(nameof(newBookData));
            var book = Books.Single(x => x.Id == newBookData.Id);

            book.Update(newBookData);
            return book;
        }

        public List<Book> GetRange(int from, int to)
        {
            return Books.Skip(from).Take(to - from).ToList();
        }

        public List<Book> GetAll()
        {
            return Books;
        }

        public int Count()
        {
            return Books.Count;
        }

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

        private BookContext()
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