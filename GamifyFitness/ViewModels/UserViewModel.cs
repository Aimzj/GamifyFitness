using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamifyFitness.ViewModels
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        [Required] 
        public string name { get; set; }
        [Required]
        public int age { get; set; }
        public float lifetimeCalories { get; set; }
        public float currCaloriesStored { get; set; }
        public string Friends { get; set; }
    }
}