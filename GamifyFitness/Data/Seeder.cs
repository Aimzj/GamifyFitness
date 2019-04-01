using GamifyFitness.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamifyFitness.Data
{
    public class Seeder
    {
        public GfContext _ctx { get; }
        public Seeder(GfContext ctx)
        {
            _ctx = ctx;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if(!_ctx.Users.Any())
            {

            }
        }

        
    }
}
