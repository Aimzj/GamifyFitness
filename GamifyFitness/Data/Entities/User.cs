using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamifyFitness.Data.Entities
{
    public class User
    {
        public string UserId { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public float lifetimeCalories { get; set; }
        public float currCaloriesStored { get; set; }
        public string Friends { get; set; }
    }
}
