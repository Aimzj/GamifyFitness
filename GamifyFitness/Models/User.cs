using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GamifyFitness.Models
{
    public class User
    {
        public string UserId { get; set; }
        [Display(Name = "Name: ")]
        public string name { get; set; }
        [Display(Name = "Age: ")]
        public int age { get; set; }
        public float lifetimeCalories { get; set; }
        public float currCaloriesStored { get; set; }
        public List<String> Friends { get; set; }


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

        public User(String Name, int age, String userId, int lifetimeCalories, int currCalories, List<String> friends)
        {
            this.name = Name;
            this.age = age;
            this.UserId = userId;
            this.lifetimeCalories = lifetimeCalories;
            this.currCaloriesStored = currCalories;
            foreach(String friend in friends)
            {
                this.Friends.Add(friend);
            }
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
