using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamifyFitness.Models;
using System.Data.SQLite;
using GamifyFitness.Data;
using GamifyFitness.Data.Entities;

namespace GamifyFitness.Controllers
{
    public class HomeController : Controller
    {
        public IGfRepository _repo { get; }

        public HomeController(IGfRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUser model)
        {
            if (ModelState.IsValid)
            {
               Data.Entities.User user =_repo.getUserByEmail(model.Email);
                var loggedInUser = _repo.GetLoggedInUser();
                if (user != null && loggedInUser == null)
                {
                    var loginUser = new UserLogin()
                    {
                        Email = user.Email,
                        Password = model.Password,
                        UserName = user.UserId

                        
                    };
                    _repo.AddUser(loginUser);
                    _repo.SaveAll();
                   // return Created($"/Home", loginUser);
                }
                else
                {
                    Console.WriteLine("ALREADY LOGGED IN ------------------------------------------------");
                    return View();
                }
                    
                //return NotFound();
                
            }
            ModelState.Clear();
            return View();
        }

        public void LogOut()
        {
            var user = _repo.GetLoggedInUser();
            _repo.RemoveLoginUser(user);

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
