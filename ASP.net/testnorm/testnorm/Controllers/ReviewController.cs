using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testnorm.Models;

namespace testnorm.Controllers
{
    public class ReviewController : Controller
    {
        //
        // GET: /Review/

        public ActionResult Create(int BookId, string BookName)
        {
            if(BaseTest.instance.Books.All(x => x.Id != BookId))
                return HttpNotFound();
            var reviews = new BookReview() { IdBook = BookId, BookName = BookName };
            return View(reviews);
        }

        [HttpPost]
        public ActionResult Create(BookReview reviews)
        {
            if (ModelState.IsValid)
            {
                BaseTest.instance.AddReview(reviews);
            }
            else
            {
                ModelState.AddModelError("Create", "Something wrong!");
            }
            return RedirectToAction("Details", "Home", new { id = reviews.IdBook });
        }

    }
}
