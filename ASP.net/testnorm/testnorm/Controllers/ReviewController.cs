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

        public ActionResult Create(int BookId)
        {
            if(BaseTest.instance.Books.All(x => x.Id != BookId))
                return HttpNotFound();
            var review = new BookReview() { IdBook = BookId };
            return View(review);
        }

        [HttpPost]
        public ActionResult Create(BookReview review)
        {
            if (ModelState.IsValid)
            {
                BaseTest.instance.AddReview(review);
            }
            else
            {
                ModelState.AddModelError("Create", "Something wrong!");
            }
            return RedirectToAction("Details", "Book", new { id = review.IdBook });
        }

    }
}
