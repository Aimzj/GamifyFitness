using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamifyFitness.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamifyFitness.Data
{
    public class GfContext : DbContext
    {
        public GfContext(DbContextOptions<GfContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> Logins { get; set; }
        public DbSet<FitnessUser> fitUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    UserId = "1",
                    name = "Ronan,",
                    age =22,
                    lifetimeCalories = 100,
                    currCaloriesStored = 10,
                    Friends = "Aimee,Riordan",
                    Email = "constantineronan@gmail.com",
                    Password = "Ronan123!"
                    
                });
                
        }
    }
}
