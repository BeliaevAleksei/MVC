using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToDB;
using LinqToDB.Data;

namespace testnorm.Models
{
    public class DbBookReviewContext : IBookReviewContext
    {
        public int IncrementAndGetLikes(int reviewId)
        {
            using (var db = new Database())
            {
                var review =
                    db.Reviews.SingleOrDefault(x => x.Id == reviewId);

                if (review == null)
                    return -1;

                review.Likes += 1;

                db.Update(review);
                return review.Likes;
            }
        }

        public List<BookReview> GetAll()
        {
            using (var db = new Database())
            {
                var query = (from r in db.Reviews
                             select r);
                return query.ToList();
            }
        }

        public void Report(int reviewId, string reason, bool isOffensive)
        {
            using (var db = new Database())
            {
                var review =
                    db.Reviews.SingleOrDefault(x => x.Id == reviewId);

                if (review == null)
                    return;

                review.ReportReason = reason;
                review.IsOffensive = isOffensive;
                db.Update(review);
                return;
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