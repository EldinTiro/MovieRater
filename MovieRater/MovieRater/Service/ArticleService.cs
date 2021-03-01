using AutoMapper;
using Movie_Rater.Model;
using Movie_Rater.Model.Request;
using MovieRater.Database;
using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieRater.Service
{
    public class ArticleService : IArticle
    {
        private readonly MovieRaterDBContext _context;
        private readonly IMapper _mapper;

        public ArticleService(MovieRaterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ArticleVM>> GetTop10Movies()
        {
            List<ArticleVM> viewModels = new List<ArticleVM>();
            List<Articles> articles = new List<Articles>();

            viewModels = await GetAverageRating("Movie", 0, true);

            return viewModels;

        }

        public async Task<List<ArticleVM>> GetTop10TvShows()
        {
            List<ArticleVM> viewModels = new List<ArticleVM>();
            List<Articles> articles = new List<Articles>();

            viewModels = await GetAverageRating("TV Show", 0, true);

            return viewModels;
        }

        public async Task<List<ArticleVM>> GetMovies(string filter)
        {
            List<ArticleVM> viewModels = new List<ArticleVM>();

            if (filter != null)
                viewModels = await SearchArticle("Movie", filter);
            else
            foreach (var item in _context.Articles.Where(w => w.Type=="Movie").ToList())
            {
                    viewModels.Add(_mapper.Map<ArticleVM>(item));
            }

            return viewModels;
        }

        public async Task<List<ArticleVM>> GetTVShows(string filter)
        {
            List<ArticleVM> viewModels = new List<ArticleVM>();

            if (filter != null)
                viewModels = await SearchArticle("TV Show", filter);
            else
                foreach (var item in _context.Articles.Where(w => w.Type == "TV Show").ToList())
                {
                    viewModels.Add(_mapper.Map<ArticleVM>(item));
                }

            return viewModels;
        }

        public ArticleVM Insert(ArticleInsertRequest request)
        {
            ArticleVM viewModel = new ArticleVM();

            if (request == null)
                return viewModel;

            Articles article = new Articles();

             article.Title = request.Title;
             article.Type = request.Type;
             article.ReleaseDate = request.ReleaseDate;
             article.Image = request.Image;
             article.Description = request.Description;

             _context.Articles.Add(article);
             _context.SaveChanges();

             return _mapper.Map<ArticleVM>(article);
        }

        public async Task<List<ArticleVM>> GetAverageRating(string type, int stars, bool top10)
        {
            List<ArticleVM> viewModels = new List<ArticleVM>();
            List<Articles> articles = new List<Articles>();

            var result = _context.Rating.Where(w => w.Article.Type == type).GroupBy(g => g.ArticleId, s => s.Grade).Select(g => new
            {
                ArticleId = g.Key,
                AvgScore = g.Average()
            }).OrderByDescending(o => o.AvgScore).ToList();

            if(result.Count == 0)
            {
                return viewModels;
            }

            foreach (var s in result)
            {
                Articles item = _context.Articles.Where(w => w.ArticleId == s.ArticleId).FirstOrDefault();

                if (item != null)
                {
                    articles.Add(item);

                    ArticleVM vm = new ArticleVM();

                    vm.Title = item.Title;
                    vm.ReleaseDate = item.ReleaseDate;
                    vm.Type = item.Type;
                    vm.ArticleId = item.ArticleId;
                    vm.Grade = s.AvgScore;
                    vm.Actors = _context.ArticleActorRelation.Where(w => w.ArticleId == item.ArticleId).Select(s => s.Actor.Name).ToList();
                    vm.Image = item.Image;
                    vm.Description = item.Description;

                    if (stars != 0)
                    {
                        if (vm.Grade >= stars)
                        {
                            viewModels.Add(vm);
                        }
                    }
                    else
                        viewModels.Add(vm);
                }
            }

            if (top10)
            {
                List<ArticleVM> top10ViewModels = viewModels.GetRange(0, 10);
                return top10ViewModels;
            }

            return viewModels;
        }

        public async Task<List<ArticleVM>> SearchArticle(string type, string filter)
        {
            List<ArticleVM> viewModels = new List<ArticleVM>();
            List<Articles> articles = new List<Articles>();

            int bar;
            char charValue;
            //"5 stars", "at least 3 stars", "after 2015","older than 5 years"
            if (filter.Contains("at") == true && filter.Contains("least") == true && filter.Contains("stars") == true)
            {
                charValue = filter[9];
                if (int.TryParse(charValue.ToString(), out bar))
                {
                    viewModels = await GetAverageRating(type, bar, false);
                    return viewModels;
                }
            }
            else if (filter.Contains("at") == false && filter.Contains("least") == false && filter.Contains("stars") == true)
            {
                charValue = filter[0];
                if (int.TryParse(charValue.ToString(), out bar))
                {
                    viewModels = await GetAverageRating(type, bar, false);
                    return viewModels;
                }
            }
            else if (filter.Contains("after") == true)
            {
                string substring = filter.Substring(6, 4);

                if (int.TryParse(substring, out bar))
                {
                    articles =  _context.Articles.Where(w => w.ReleaseDate.Year > bar && w.Type == type).ToList();
                    if(articles !=null)
                        foreach (var item in articles)
                        {
                            viewModels.Add(_mapper.Map<ArticleVM>(item));
                        }
                    return viewModels;
                }
            }
            else if (filter.Contains("older") == true && filter.Contains("than") == true && filter.Contains("years") == true)
            {

                string[] parts = filter.Split(" ");

                int currentYear = DateTime.Now.Year;

                if (int.TryParse(parts[2], out bar))
                {
                    int targetYear = currentYear - bar;
                    articles = _context.Articles.Where(w => w.ReleaseDate.Year < targetYear && w.Type == type).ToList();
                    if (articles != null)
                        foreach (var item in articles)
                        {
                            viewModels.Add(_mapper.Map<ArticleVM>(item));
                        }
                    return viewModels;
                }
            }
            else
            {
                articles = _context.Articles.Where(w => w.Title.StartsWith(filter) && w.Type == type).ToList();
                if (articles != null)
                    foreach (var item in articles)
                    {
                        viewModels.Add(_mapper.Map<ArticleVM>(item));
                    }
                return viewModels;
            }

            return viewModels;
        }

    }
}
