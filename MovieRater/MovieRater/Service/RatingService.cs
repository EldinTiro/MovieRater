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
    public class RatingService:IRating
    {
        private readonly MovieRaterDBContext _context;
        private readonly IMapper _mapper;

        public RatingService(MovieRaterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public RatingVM Insert(int articleId, int grade)
        {
            RatingVM viewModel = new RatingVM();

            if (articleId == 0 || grade ==0)
                return viewModel;

            Rating rating = new Rating();

            rating.ArticleId = articleId;
            rating.Grade = grade;

            try
            {
                _context.Rating.Add(rating);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }


            return _mapper.Map<RatingVM>(rating);
        }
    }
}
