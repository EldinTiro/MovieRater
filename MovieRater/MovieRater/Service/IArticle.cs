using Movie_Rater.Model;
using Movie_Rater.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Service
{
    public interface IArticle
    {
        Task<List<ArticleVM>> GetTop10Movies();
        Task<List<ArticleVM>> GetTop10TvShows();
        ArticleVM Insert(ArticleInsertRequest request);
        Task<List<ArticleVM>> GetMovies(string filter);
        Task<List<ArticleVM>> GetTVShows(string filter);
    }
}
