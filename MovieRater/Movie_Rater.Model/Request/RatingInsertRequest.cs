using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Rater.Model.Request
{
    public class RatingInsertRequest
    {
        public int Grade { get; set; }
        public int ArticleId { get; set; }
    }
}
