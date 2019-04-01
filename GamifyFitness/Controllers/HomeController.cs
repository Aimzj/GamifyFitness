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
        private UserLogin loggedInUser;
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
               var user =_repo.getUserByEmail(model.Email);
                loggedInUser = _repo.GetLoggedInUser();
                if (user != null && user.Password == model.Password)
                {
                    var loginUser = new UserLogin()
                    {
                        Email = user.Email,
                        Password = model.Password,

                        
                    };
                    if(loggedInUser != null)
                    {
                        _repo.RemoveLoginUser(loggedInUser);
                    }
                   
                    _repo.AddUser(loginUser);
                    _repo.SaveAll();
                    return RedirectToAction("Index");

                    // return Created($"/Home", loginUser);
                }
                else if(user == null)
                {
                    Console.WriteLine("You need to login ------------------------------------------------");
                    return RedirectToAction("CreateUser");
                }
                else if(user.Password != model.Password)
                {
                    ModelState.Clear();
                    return View();
                }
                    
                //return NotFound();
                
            }
            ModelState.Clear();
            return View();
        }

        public IActionResult Logout()
        {
           loggedInUser = _repo.GetLoggedInUser();
            _repo.RemoveLoginUser(loggedInUser);
            _repo.SaveAll();

            return RedirectToAction("Login");
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUser model)
        {
            if (ModelState.IsValid)
            {
                var user = new FitnessUser()
                {
                    Username = model.Username,
                    name = model.name,
                    surname = model.surname,
                    age = model.age,
                    Email = model.Email,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword
                };
                _repo.AddUser(user);
                _repo.SaveAll();

            }
            ModelState.Clear();
            return View();
        }

        public IActionResult Index()
        {
            loggedInUser = _repo.GetLoggedInUser();
            
            if (loggedInUser == null)
                return RedirectToAction("Login");
            else
            {
                var user = _repo.getUserByEmail(loggedInUser.Email);

                return View(user);
            }
        }
        public IActionResult DisplayFriends()
        {
            loggedInUser = _repo.GetLoggedInUser();
            if (loggedInUser == null)
                return RedirectToAction("Login");
            else
                return View();
        }

        public IActionResult Profile()
        {
            loggedInUser = _repo.GetLoggedInUser();
            if (loggedInUser == null)
                return RedirectToAction("Login");
            else
                return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
