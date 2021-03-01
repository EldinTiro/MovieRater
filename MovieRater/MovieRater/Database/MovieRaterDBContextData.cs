using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieRater.Encryption;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MovieRater.Database
{
    public partial class MovieRaterDBContext
    {

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

            var webClient = new WebClient();

            var korisnikLozinkaSalt = HashGenSalt.GenerateSalt();
            var korisnikLozinkaHash = HashGenSalt.GenerateHash(korisnikLozinkaSalt, "test");

            var kupacLozinkaSalt = HashGenSalt.GenerateSalt();
            var kupacLozinkaHash = HashGenSalt.GenerateHash(kupacLozinkaSalt, "test");

            //KORISNICI
            modelBuilder.Entity<Korisnici>().HasData(new Korisnici()
            {
                KorisnikId = 5,
                Email = "mist@edu.com",
                Ime = "test",
                Prezime = "test",
                DatumRodjenja = DateTime.Now,
                KorisnickoIme = "mist@edu.com",
                LozinkaSalt = korisnikLozinkaSalt,
                LozinkaHash = korisnikLozinkaHash
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 1,
                Title = "The Shawshank Redemption",
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                ReleaseDate = DateTime.Parse("1994-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BNjQ2NDA3MDcxMF5BMl5BanBnXkFtZTgwMjE5NTU0NzE@._V1_CR0,60,640,360_AL_UX477_CR0,0,477,268_AL_.jpg"),
                Type = "Movie"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 2,
                Title = "The Godfather",
                Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.",
                ReleaseDate = DateTime.Parse("1972-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY268_CR3,0,182,268_AL_.jpg"),
                Type = "Movie"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 3,
                Title = "The Godfather: Part II",
                Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                ReleaseDate = DateTime.Parse("1974-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BMWMwMGQzZTItY2JlNC00OWZiLWIyMDctNDk2ZDQ2YjRjMWQ0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY268_CR3,0,182,268_AL_.jpg"),
                Type = "Movie"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 4,
                Title = "The Dark Knight",
                Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                ReleaseDate = DateTime.Parse("2008-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "Movie"
            });


            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 5,
                Title = "12 Angry Men",
                Description = "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.",
                ReleaseDate = DateTime.Parse("1957-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BMWU4N2FjNzYtNTVkNC00NzQ0LTg0MjAtYTJlMjFhNGUxZDFmXkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "Movie"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 6,
                Title = "The Lord of the Rings: The Return of the King",
                Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                ReleaseDate = DateTime.Parse("2003-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "Movie"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 7,
                Title = "Schindler's List",
                Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                ReleaseDate = DateTime.Parse("1993-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "Movie"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 8,
                Title = "Pulp Fiction",
                Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                ReleaseDate = DateTime.Parse("1994-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY268_CR1,0,182,268_AL_.jpg"),
                Type = "Movie"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 9,
                Title = "The Good, the Bad and the Ugly",
                Description = "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.",
                ReleaseDate = DateTime.Parse("1966-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BOTQ5NDI3MTI4MF5BMl5BanBnXkFtZTgwNDQ4ODE5MDE@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "Movie"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 10,
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                ReleaseDate = DateTime.Parse("2001-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "Movie"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 11,
                Title = "Fight Club",
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                ReleaseDate = DateTime.Parse("1999-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BMmEzNTkxYjQtZTc0MC00YTVjLTg5ZTEtZWMwOWVlYzY0NWIwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "Movie"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 12,
                Title = "Forrest Gump",
                Description = "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate and other historical events unfold through the perspective of an Alabama man with an IQ of 75",
                ReleaseDate = DateTime.Parse("1994-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UY268_CR1,0,182,268_AL_.jpg"),
                Type = "Movie"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 13,
                Title = "Inception",
                Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                ReleaseDate = DateTime.Parse("2010-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "Movie"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 14,
                Title = "The Lord of the Rings: The Two Towers",
                Description = "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.",
                ReleaseDate = DateTime.Parse("2002-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BZGMxZTdjZmYtMmE2Ni00ZTdkLWI5NTgtNjlmMjBiNzU2MmI5XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "Movie"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 15,
                Title = "Planet",
                Description = "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.",
                ReleaseDate = DateTime.Parse("2019-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BYWZjMjk3ZTItODQ2ZC00NTY5LWE0ZDYtZTI3MjcwN2Q5NTVkXkEyXkFqcGdeQXVyODk4OTc3MTY@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "TV Show"
            });



            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 16,
                Title = "Planet 2",
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                ReleaseDate = DateTime.Parse("1999-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BMmEzNTkxYjQtZTc0MC00YTVjLTg5ZTEtZWMwOWVlYzY0NWIwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "TV Show"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 17,
                Title = "Dexter",
                Description = "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate and other historical events unfold through the perspective of an Alabama man with an IQ of 75",
                ReleaseDate = DateTime.Parse("1994-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UY268_CR1,0,182,268_AL_.jpg"),
                Type = "TV Show"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 18,
                Title = "Friends",
                Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                ReleaseDate = DateTime.Parse("2010-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "TV Show"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 19,
                Title = "Two and a half man",
                Description = "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.",
                ReleaseDate = DateTime.Parse("2002-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BZGMxZTdjZmYtMmE2Ni00ZTdkLWI5NTgtNjlmMjBiNzU2MmI5XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "TV Show"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 20,
                Title = "Bing bang teory",
                Description = "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.",
                ReleaseDate = DateTime.Parse("2019-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BYWZjMjk3ZTItODQ2ZC00NTY5LWE0ZDYtZTI3MjcwN2Q5NTVkXkEyXkFqcGdeQXVyODk4OTc3MTY@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "TV Show"
            });


            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 21,
                Title = "Planet 3",
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                ReleaseDate = DateTime.Parse("1999-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BMmEzNTkxYjQtZTc0MC00YTVjLTg5ZTEtZWMwOWVlYzY0NWIwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "TV Show"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 22,
                Title = "Dexter 2",
                Description = "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate and other historical events unfold through the perspective of an Alabama man with an IQ of 75",
                ReleaseDate = DateTime.Parse("1994-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UY268_CR1,0,182,268_AL_.jpg"),
                Type = "TV Show"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 23,
                Title = "Friends 3",
                Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                ReleaseDate = DateTime.Parse("2010-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "TV Show"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 24,
                Title = "Two and a half man 2",
                Description = "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.",
                ReleaseDate = DateTime.Parse("2002-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BZGMxZTdjZmYtMmE2Ni00ZTdkLWI5NTgtNjlmMjBiNzU2MmI5XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "TV Show"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 25,
                Title = "Bing bang teory 5",
                Description = "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.",
                ReleaseDate = DateTime.Parse("2019-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BYWZjMjk3ZTItODQ2ZC00NTY5LWE0ZDYtZTI3MjcwN2Q5NTVkXkEyXkFqcGdeQXVyODk4OTc3MTY@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "TV Show"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 26,
                Title = "Friends 4",
                Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                ReleaseDate = DateTime.Parse("2010-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "TV Show"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 27,
                Title = "Two and a half man 3",
                Description = "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.",
                ReleaseDate = DateTime.Parse("2002-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BZGMxZTdjZmYtMmE2Ni00ZTdkLWI5NTgtNjlmMjBiNzU2MmI5XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "TV Show"
            });

            modelBuilder.Entity<Articles>().HasData(new Articles()
            {
                ArticleId = 28,
                Title = "Bing bang teory 4",
                Description = "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.",
                ReleaseDate = DateTime.Parse("2019-06-24"),
                Image = webClient.DownloadData("https://m.media-amazon.com/images/M/MV5BYWZjMjk3ZTItODQ2ZC00NTY5LWE0ZDYtZTI3MjcwN2Q5NTVkXkEyXkFqcGdeQXVyODk4OTc3MTY@._V1_UX182_CR0,0,182,268_AL_.jpg"),
                Type = "TV Show"
            });

            //ACTORS
            modelBuilder.Entity<Actors>().HasData(new Actors()
            {
                ActorId = 1,
                Name = "Kang-ho Song",
                Age = 44
            });

            modelBuilder.Entity<Actors>().HasData(new Actors()
            {
                ActorId = 2,
                Name = "Morgan Freeman",
                Age = 82
            });

            modelBuilder.Entity<Actors>().HasData(new Actors()
            {
                ActorId = 3,
                Name = "Tim Robbins",
                Age = 44
            });

            modelBuilder.Entity<Actors>().HasData(new Actors()
            {
                ActorId = 4,
                Name = "Al Pacino",
                Age = 44
            });

            modelBuilder.Entity<Actors>().HasData(new Actors()
            {
                ActorId = 5,
                Name = "John Travolta",
                Age = 44
            });

            modelBuilder.Entity<Actors>().HasData(new Actors()
            {
                ActorId = 6,
                Name = "Samuel L. Jackson",
                Age = 44
            });

            modelBuilder.Entity<Actors>().HasData(new Actors()
            {
                ActorId = 7,
                Name = "Henry Fonda",
                Age = 44
            });

            modelBuilder.Entity<Actors>().HasData(new Actors()
            {
                ActorId = 8,
                Name = "Leonardo DiCaprio",
                Age = 44
            });

            modelBuilder.Entity<Actors>().HasData(new Actors()
            {
                ActorId = 9,
                Name = "Joseph Gordon-Levitt",
                Age = 44
            });

            modelBuilder.Entity<Actors>().HasData(new Actors()
            {
                ActorId = 10,
                Name = "Elliot Page",
                Age = 44
            });


            modelBuilder.Entity<ArticleActorRelation>().HasData(new ArticleActorRelation()
            {
                RelationId =1,
                ActorId = 1,
                ArticleId =1
            });

            modelBuilder.Entity<ArticleActorRelation>().HasData(new ArticleActorRelation()
            {
                RelationId = 2,
                ActorId = 2,
                ArticleId = 2,
            });

            modelBuilder.Entity<ArticleActorRelation>().HasData(new ArticleActorRelation()
            {
                RelationId = 3,
                ActorId = 3,
                ArticleId = 3,
            });

            modelBuilder.Entity<ArticleActorRelation>().HasData(new ArticleActorRelation()
            {
                RelationId = 4,
                ActorId = 4,
                ArticleId = 4,
            });

            modelBuilder.Entity<ArticleActorRelation>().HasData(new ArticleActorRelation()
            {
                RelationId = 5,
                ActorId = 5,
                ArticleId = 5,
            });

            modelBuilder.Entity<ArticleActorRelation>().HasData(new ArticleActorRelation()
            {
                RelationId = 6,
                ActorId = 6,
                ArticleId = 6,
            });

            modelBuilder.Entity<ArticleActorRelation>().HasData(new ArticleActorRelation()
            {
                RelationId = 7,
                ActorId = 7,
                ArticleId = 7,
            });

            modelBuilder.Entity<ArticleActorRelation>().HasData(new ArticleActorRelation()
            {
                RelationId = 8,
                ActorId = 8,
                ArticleId = 8,
            });

            modelBuilder.Entity<ArticleActorRelation>().HasData(new ArticleActorRelation()
            {
                RelationId = 9,
                ActorId = 9,
                ArticleId = 9,
            });

            modelBuilder.Entity<ArticleActorRelation>().HasData(new ArticleActorRelation()
            {
                RelationId = 10,
                ActorId = 10,
                ArticleId = 10,
            });

            modelBuilder.Entity<ArticleActorRelation>().HasData(new ArticleActorRelation()
            {
                RelationId = 11,
                ActorId = 6,
                ArticleId = 11,
            });
            
            modelBuilder.Entity<ArticleActorRelation>().HasData(new ArticleActorRelation()
            {
                RelationId = 12,
                ActorId = 5,
                ArticleId = 12,
            });
            modelBuilder.Entity<ArticleActorRelation>().HasData(new ArticleActorRelation()
            {
                RelationId = 13,
                ActorId = 2,
                ArticleId = 1,
            });

            modelBuilder.Entity<ArticleActorRelation>().HasData(new ArticleActorRelation()
            {
                RelationId = 14,
                ActorId = 5,
                ArticleId = 15,
            });


            //RATING
            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 1,
                ArticleId = 1,
                Grade = 5,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 2,
                ArticleId = 2,
                Grade = 5,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 3,
                ArticleId = 3,
                Grade = 5,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 4,
                ArticleId = 4,
                Grade = 4,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 5,
                ArticleId = 5,
                Grade = 4,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 6,
                ArticleId = 6,
                Grade = 5,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 7,
                ArticleId = 7,
                Grade = 3,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 8,
                ArticleId = 8,
                Grade = 3,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 9,
                ArticleId = 9,
                Grade = 2,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 10,
                ArticleId = 10,
                Grade = 5,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 11,
                ArticleId = 11,
                Grade = 3,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 12,
                ArticleId = 12,
                Grade = 3,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 13,
                ArticleId = 13,
                Grade = 3,
            });
            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 14,
                ArticleId = 14,
                Grade = 5,
            });
            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 15,
                ArticleId = 15,
                Grade = 2,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 16,
                ArticleId = 16,
                Grade = 5,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 17,
                ArticleId = 17,
                Grade = 5,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 18,
                ArticleId = 18,
                Grade = 5,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 19,
                ArticleId = 19,
                Grade = 4,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 20,
                ArticleId = 20,
                Grade = 4,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 21,
                ArticleId = 21,
                Grade = 5,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 22,
                ArticleId = 22,
                Grade = 3,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 23,
                ArticleId = 23,
                Grade = 2,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 24,
                ArticleId = 24,
                Grade = 5,
            });
            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 25,
                ArticleId = 25,
                Grade = 4,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 26,
                ArticleId = 26,
                Grade = 5,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 27,
                ArticleId = 27,
                Grade = 3,
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
            {
                RatingId = 28,
                ArticleId = 28,
                Grade = 3,
            });

        }
    }
}
