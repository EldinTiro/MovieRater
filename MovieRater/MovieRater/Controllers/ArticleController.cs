using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Rater.Model.Request;
using MovieRater.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movie_Rater.Model;

namespace MovieRater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticle _service;

        public ArticleController(IArticle service)
        {
            this._service = service;
        }

        [HttpGet("GetMovies")]
        public Task<List<ArticleVM>> GetMovies(string filter)
        {
            var list = _service.GetMovies(filter);

            return list;
        }

        [HttpGet("GetTVShows")]
        public Task<List<ArticleVM>> GetTVShows(string filter)
        {
            var list = _service.GetTVShows(filter);

            return list;
        }

        [HttpGet("Top10Movies")]
        public Task<List<ArticleVM>> GetTop10Movies()
        {
            var list = _service.GetTop10Movies();

            return list;
        }

        [HttpGet("Top10TvShows")]
        public Task<List<ArticleVM>> GetTop10TvShows()
        {
            var list = _service.GetTop10TvShows();

            return list;
        }

        [HttpPost]
        public ArticleVM Insert(ArticleInsertRequest request)
        {
            return _service.Insert(request);
        }

    }
}
