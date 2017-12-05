using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testnorm.Models
{
    public interface IBookReviewContext
    {
        int IncrementAndGetLikes(int reviewId);
        List<BookReview> GetAll();
        void Report(int reviewId, string reason, bool isOffensive);
    }
}
