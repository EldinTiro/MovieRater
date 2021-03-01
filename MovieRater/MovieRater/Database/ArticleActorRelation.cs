using System;
using System.Collections.Generic;

namespace MovieRater.Database
{
    public partial class ArticleActorRelation
    {
        public int RelationId { get; set; }
        public int ArticleId { get; set; }
        public int ActorId { get; set; }

        public virtual Actors Actor { get; set; }
        public virtual Articles Article { get; set; }
    }
}
