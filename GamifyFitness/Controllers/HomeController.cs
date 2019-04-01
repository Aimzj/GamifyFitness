using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamifyFitness.Models;
using System.Data.SQLite;

namespace GamifyFitness.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            //DatabaseSuite ds = new DatabaseSuite();
            //ds.CreateDatabase();
            //ds.OpenConnection();
            //ds.CreateTable();
            //ds.AddUser("1", "Ronan", 22, 123, 10, new List<string>() { "Aimee", "Riordan" });
            //ds.AddUser("2", "Aimee", 21, 1230, 100, new List<string>() { "Ronan", "Riordan" });
            //ds.ReadTable();
            //Console.WriteLine("");
            //ds.UpdateUserCalories("1", 10000, 2300);
            //ds.UpdateUserFriends("2", new List<string>() { "Ronan", "Riordan", "MaryAnn", "Josh" });
            //ds.ReadTable();
            //SQLiteDataReader reader = ds.GetUserData("1");
            //while(reader.Read())
            //    Console.WriteLine(reader["name"] + "--------------------------------------------------------------------------------------------------");

            //User user = new User("Ronan", 22);
            //Console.WriteLine(user.UserId);
            //ds.CloseConnection();

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                //login the user

            }
            ModelState.Clear();
            return View();
        }

        public IActionResult CreateUser(CreateUser model)
        {
            if (ModelState.IsValid)
            {
                //create new user

            }
            ModelState.Clear();
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
