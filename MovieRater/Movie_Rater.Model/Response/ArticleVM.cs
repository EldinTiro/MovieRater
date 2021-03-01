using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Rater.Model
{
    public class ArticleVM
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public double Grade { get; set; }
        public List<string> Actors { get; set; }
    }
}
