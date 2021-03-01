using System;
using System.Collections.Generic;

namespace MovieRater.Database
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int Grade { get; set; }
        public int ArticleId { get; set; }

        public virtual Articles Article { get; set; }
    }
}
