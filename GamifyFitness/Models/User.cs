using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamifyFitness.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public float lifetimeCalories { get; set; }
        public float currCaloriesStored { get; set; }
        public string[] Friends { get; set; }


        public User()
        {
            this.UserId = CreateUserId();
        }

        public User(String Name, int age)
        {
            this.name = Name;
            this.age = age;
            this.UserId = CreateUserId();
        }

        public User(String Name, int age,String userId)
        {
            this.name = Name;
            this.age = age;
            this.UserId = userId;
        }

        private String CreateUserId()
        {
            String Id = "";
            Id += this.name[this.name.Length - 1];
            Id += this.name[0];
            Random rnd = new Random();
            Id += rnd.Next().ToString();

            return Id;
        }
    }


    
}
