using System;
using System.Collections.Generic;

namespace MovieRater.Database
{
    public partial class Articles
    {
        public Articles()
        {
            ArticleActorRelation = new HashSet<ArticleActorRelation>();
            Rating = new HashSet<Rating>();
        }

        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ArticleActorRelation> ArticleActorRelation { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
