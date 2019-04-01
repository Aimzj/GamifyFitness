using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GamifyFitness.Data;
using Microsoft.AspNetCore.Mvc;
using GamifyFitness.Models;

namespace GamifyFitness.Controllers
{
    public class GameController : Controller
    {
        public IGfRepository _repo { get; }

        public GameController(IGfRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var loggedInUser = _repo.GetLoggedInUser();
            if (loggedInUser == null)
                return RedirectToAction("Login");
            else
            {
                return View();
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel{RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}