using System;
using System.Collections.Generic;

namespace MovieRater.Database
{
    public partial class Actors
    {
        public Actors()
        {
            ArticleActorRelation = new HashSet<ArticleActorRelation>();
        }

        public int ActorId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }

        public virtual ICollection<ArticleActorRelation> ArticleActorRelation { get; set; }
    }
}
