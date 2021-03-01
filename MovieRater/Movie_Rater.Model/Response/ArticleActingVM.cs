using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Rater.Model.Response
{
    public class ArticleActingVM
    {
        public int ActorId { get; set; }
        public int ArticleId { get; set; }
        public string ActorName { get; set; }
        public string ArticleTitle { get; set; }
    }
}
