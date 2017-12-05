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
        private IBookContext _bookContext;
        private IBookReviewContext _reviewContext;

        public ReviewController() : this(new DbBookContext(), new DbBookReviewContext())
        {
        }

        public ReviewController(IBookContext bookContext, IBookReviewContext reviewContext)
        {
            if (bookContext == null)
                throw new ArgumentNullException();
            if (reviewContext == null)
                throw new ArgumentNullException();
            _bookContext = bookContext;
            _reviewContext = reviewContext;
        }

        public ActionResult Create(int BookId, string BookName)
        {
            if(_bookContext.GetBook(BookId) == null)
                return HttpNotFound();
            var reviews = new BookReview() { IdBook = BookId, BookName = BookName };
            return View(reviews);
        }

        [HttpPost]
        public ActionResult Create(BookReview reviews)
        {
            if (ModelState.IsValid)
            {
                _bookContext.AddReview(reviews);
            }
            else
            {
                ModelState.AddModelError("Create", "Something wrong!");
            }
            return RedirectToAction("Details", "Home", new { id = reviews.IdBook });
        }

        [HttpPost]
        public void ReportOffensiveReview(int reviewId, string reason)
        {
            _reviewContext.Report(reviewId, reason, true);
        }

        [HttpPost]
        public int IncrementAndGetLikes(int reviewId)
        {
            var likesCount = _reviewContext.IncrementAndGetLikes(reviewId);
            return likesCount;
        }

    }
}
