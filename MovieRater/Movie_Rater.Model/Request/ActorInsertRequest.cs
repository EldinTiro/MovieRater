using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Rater.Model.Request
{
    public class ActorInsertRequest
    {
        public string Name { get; set; }
        public int? Age { get; set; }
    }
}
