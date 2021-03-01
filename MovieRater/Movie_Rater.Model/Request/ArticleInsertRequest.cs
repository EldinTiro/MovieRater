using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Rater.Model.Request
{
    public class ArticleInsertRequest
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
    }
}
