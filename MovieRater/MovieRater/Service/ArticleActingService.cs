using AutoMapper;
using Movie_Rater.Model.Request;
using Movie_Rater.Model.Response;
using MovieRater.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Service
{
    public class ArticleActingService:IArticleActing
    {
        private readonly MovieRaterDBContext _context;
        private readonly IMapper _mapper;

        public ArticleActingService(MovieRaterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ArticleActingVM Insert(ArticleActingInsertRequest request)
        {
            ArticleActingVM viewModel = new ArticleActingVM();

            if (request == null)
                return viewModel;

            ArticleActorRelation relation = new ArticleActorRelation();

            relation.ActorId = request.ActorId;
            relation.ArticleId = request.ArticleId;

            _context.ArticleActorRelation.Add(relation);
            _context.SaveChanges();

            viewModel = _mapper.Map<ArticleActingVM>(relation);
            viewModel.ActorName = _context.Actors.Where(w => w.ActorId == relation.ActorId).Select(s => s.Name).FirstOrDefault();
            viewModel.ArticleTitle = _context.Articles.Where(w => w.ArticleId == relation.ArticleId).Select(s => s.Title).FirstOrDefault();

            return viewModel;
        }
    }
}
