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
    public class UserController : Controller
    {
        public IActionResult Details(String userid)
        {
            if(userid == "")
            {
                Console.WriteLine("EmptyString");
                return NotFound();
            }
            Console.WriteLine("-----------------------------------+"+userid+"+---------------------------------------------------------------------");
            DatabaseSuite ds = new DatabaseSuite();
            ds.OpenConnection();
            try
            {
                SQLiteDataReader reader = ds.GetUserData(userid);
                String name = "";
                string userId = "";
                int age = 0;
                while (reader.Read())
                {
                    name = reader["name"].ToString();
                    age = (int)reader["age"];
                    userId = reader["userId"].ToString();
                }

                var user = new User(name, age, userId);

                return View(user);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
                return NotFound();
            }
            
        }
        /*public IActionResult Index()
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
        }*/

    }
}
