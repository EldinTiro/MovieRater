using Movie_Rater.Model.Request;
using Movie_Rater.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Service
{
    public interface IArticleActing
    {
        ArticleActingVM Insert(ArticleActingInsertRequest request);
    }
}
