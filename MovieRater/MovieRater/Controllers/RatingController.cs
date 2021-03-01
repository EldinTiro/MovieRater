using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Rater.Model;
using Movie_Rater.Model.Request;
using MovieRater.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRating _service;

        public RatingController(IRating service)
        {
            this._service = service;
        }

        [HttpPost]
        public RatingVM Insert(int articleId, int grade)
        {
            return _service.Insert(articleId, grade);
        }
    }
}
