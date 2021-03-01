using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Database
{
    public class Seed
    {
        public static void Seeding(MovieRaterDBContext context)
        {
            context.Database.Migrate();
        }
    }
}
