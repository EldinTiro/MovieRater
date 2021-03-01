using Movie_Rater.Model;
using Movie_Rater.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Service
{
    public interface IRating
    {
        RatingVM Insert(int articleId, int grade);
    }
}
