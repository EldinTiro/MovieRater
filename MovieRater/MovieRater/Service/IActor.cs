﻿using Movie_Rater.Model;
using Movie_Rater.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Service
{
    public interface IActor
    {
        ActorVM Insert(ActorInsertRequest request);
    }
}
