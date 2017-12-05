using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testnorm.Models;

namespace testnorm.Controllers
{
    public class BookController : Controller
    {
        private IBookContext _bookContext;

        public BookController() : this(new DbBookContext())
        {
        }

        public BookController(IBookContext bookContext)
        {
            if (bookContext == null)
                throw new ArgumentNullException();
            _bookContext = bookContext;
        }

        public ActionResult CreateBook()
        {
            var book = new Book();
            return View(book);
        }

        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookContext.AddBook(book);
            }
            else
            {
                ModelState.AddModelError("CreateBook", "Something wrong!");
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
