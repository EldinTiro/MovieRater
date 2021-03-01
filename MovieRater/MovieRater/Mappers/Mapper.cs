using AutoMapper;
using Movie_Rater.Model;
using Movie_Rater.Model.Request;
using Movie_Rater.Model.Response;
using MovieRater.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Mappers
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Articles, ArticleVM>();
            CreateMap<List<Articles>, List<ArticleVM>>();
            CreateMap<Actors, ActorVM>();
            CreateMap<Rating, RatingVM>();
            CreateMap<ArticleActorRelation, ArticleActingVM>();
            CreateMap<Korisnici, KorisniciVM>();
            CreateMap<Korisnici, KorisniciInsertRequest>().ReverseMap();
        }

    }
}
