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
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _service;

        public KorisniciController(IKorisniciService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("Authenticiraj/{username}/{password}")]
        public KorisniciVM Authenticiraj(string username, string password)
        {
            return _service.Authenticiraj(username, password);
        }
        [HttpPost]
        public KorisniciVM Insert(KorisniciInsertRequest request)
        {
            return _service.Insert(request);
        }

    }
}
