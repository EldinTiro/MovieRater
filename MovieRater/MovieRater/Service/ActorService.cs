using AutoMapper;
using Movie_Rater.Model;
using Movie_Rater.Model.Request;
using MovieRater.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Service
{
    public class ActorService:IActor
    {
        private readonly MovieRaterDBContext _context;
        private readonly IMapper _mapper;

        public ActorService(MovieRaterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActorVM Insert(ActorInsertRequest request)
        {
            ActorVM viewModel = new ActorVM();

            if (request == null)
                return viewModel;

            Actors actor = new Actors();

            actor.Name = request.Name;
            actor.Age = request.Age;

            _context.Actors.Add(actor);
            _context.SaveChanges();

            return _mapper.Map<ActorVM>(actor);
        }
    }
}
