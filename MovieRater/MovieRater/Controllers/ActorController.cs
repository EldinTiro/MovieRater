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
    public class ActorController : ControllerBase
    {
        private readonly IActor _service;

        public ActorController(IActor service)
        {
            this._service = service;
        }

        [HttpPost]
        public ActorVM Insert(ActorInsertRequest request)
        {
            return _service.Insert(request);
        }
    }
}
