using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GamifyFitness.Data.Entities
{
    public class FitnessUser
    {

        public string Username { get; set; }

        public string name { get; set; }

        public string surname { get; set; }

        public int age { get; set; }
        [Key]
        public string Email { get; set; }
       
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
    }
}
