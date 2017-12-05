using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testnorm.Models
{
    public class BookReviewContext : IBookReviewContext
    {
        private static readonly BookReviewContext instance = new BookReviewContext();

        public static IBookReviewContext Instance
        {
            get { return instance; }
        }

        private readonly List<BookReview> _reviews = new List<BookReview>();

        public List<BookReview> GetAll()
        {
            return _reviews;
        }

        public void Report(int reviewId, string reason, bool isOffensive)
        {
            var review = _reviews.FirstOrDefault(x => x.Id == reviewId);
            if (review == null)
            {
                return;
            }

            review.ReportReason = reason;
        }

        public int IncrementAndGetLikes(int reviewId)
        {
            var review = _reviews.FirstOrDefault(x => x.Id == reviewId);
            if (review == null)
            {
                return -1;
            }

            return ++review.Likes;
        }
    }
}