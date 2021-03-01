using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Rater.Model.Request;
using Movie_Rater.Model.Response;
using MovieRater.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleActingController : ControllerBase
    {
        private readonly IArticleActing _service;

        public ArticleActingController(IArticleActing service)
        {
            _service = service;
        }

        [HttpPost]
        public ArticleActingVM Insert(ArticleActingInsertRequest request)
        {
            return _service.Insert(request);
        }
    }
}
