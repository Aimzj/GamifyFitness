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
        [Required]
        [Display(Name = "Username: ")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Name: ")]
        public string name { get; set; }
        [Required]
        [Display(Name= "Surname: ")]
        public string surname{ get; set; }
        [Required]
        [Display(Name = "Age: ")]
        public int age { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public float lifetimeCalories { get; set; }
        public float currCaloriesStored { get; set; }
        public List<String> Friends { get; set; }


        public User()
        {
            //this.UserId = CreateUserId();
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

    public class LoginUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email: ")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password: ")]
        public string Password { get; set; }
    }
    public class CreateUser
    {
        [Required]
        [Display(Name = "Username: ")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Name: ")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Surname: ")]
        public string surname { get; set; }
        [Required]
        [Display(Name = "Age: ")]
        public int age { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
