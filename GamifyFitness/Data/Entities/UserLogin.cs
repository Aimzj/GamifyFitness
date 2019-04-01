using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GamifyFitness.Data.Entities
{
    public class UserLogin : IdentityUser
    {
        [Key]
        [Required]
        public string emailExample { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
