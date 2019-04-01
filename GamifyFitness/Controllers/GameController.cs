using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamifyFitness.Models;
using GamifyFitness.Game;

namespace GamifyFitness.Controllers
{
    public class GameController : Controller
    {
        public GameInstance gameInstance {get; set;}
        public IActionResult Index()
        {
            InitializeGame();
            return View();
        }

        public void InitializeGame()
        {
            gameInstance = new GameInstance();
            gameInstance.Restart();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel{RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}