using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testnorm.Models;

namespace testnorm.Controllers
{
    public class HomeController : Controller
    {
        private const int _PAGE_SIZE = 5;
        private IBookContext _bookContext;

        public HomeController() : this(new DbBookContext())
        {
        }

        public HomeController(IBookContext bookContext)
        {
            if (bookContext == null)
                throw new ArgumentNullException();
            _bookContext = bookContext;
        }

        public ActionResult Index(int currentPage = 1)
        {
            if (currentPage < 1)
            {
                currentPage = 1;
            }
            var paginatorNum = currentPage - 2;
            if (paginatorNum < 1)
            {
                paginatorNum = 1;
            }
            var indexListView = new IndexListView()
            {
                books = _bookContext.GetRange((currentPage - 1) * _PAGE_SIZE, _PAGE_SIZE),
                currentPage = paginatorNum,
                totalPage = (int)(_bookContext.Count() / _PAGE_SIZE + 0.5)
            };
            return View(indexListView);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Details(int Id = 0)
        {
            var book = _bookContext.GetBook(Id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult EditBook(int Id)
        {
            var book = _bookContext.GetBook(Id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            Book first = _bookContext.GetBook(book.Id);

            if (first == null)
                return HttpNotFound();

            _bookContext.Update(book);
            return RedirectToAction("Details", "Home", new { id = book.Id });
        }

    }
}
