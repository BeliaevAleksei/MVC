using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testnorm.Models
{
    public interface IBookContext
    {
        void AddBook(Book newBook);
        void AddReview(BookReview newReview);
        List<Book> GetAll();
        int Count();
        List<Book> GetRange(int from, int to);
        Book GetBook(int bookId);
        Book Update(Book newBookData);
    }
}
