using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamifyFitness.Data;
using GamifyFitness.Data.Entities;
using GamifyFitness.ViewModels;

namespace GamifyFitness.Controllers
{
    [Route("api/test")]
    public class UserWebController : Controller
    {
        private IGfRepository _repo { get; }
        public UserWebController(IGfRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.getAllUsers());
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                return BadRequest("Failed to find users");
            }
            
        }

        [HttpGet("{userId}")]
        public IActionResult Get(string userId)
        {
            try
            {
                var user = _repo.getUser(userId);
                if (user != null)
                {
                    return Ok(user);
                }
                else return NotFound();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                return BadRequest("Failed to find users");
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody]UserViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var newOrder = new User()
                    {
                        UserId = model.UserId,
                        name = model.name,
                        age = model.age,
                        lifetimeCalories = model.lifetimeCalories,
                        currCaloriesStored = model.currCaloriesStored,
                        Friends = model.Friends
                    };
                     
                    if(newOrder.Friends == null || newOrder.Friends == "")
                    {
                        newOrder.Friends = "HAHA you have no friends";
                    }

                    _repo.AddUser(newOrder);
                    if (_repo.SaveAll())
                    {
                        var vm = new UserViewModel()
                        {
                            UserId = newOrder.UserId,
                            name = newOrder.name,
                            age = newOrder.age,
                            lifetimeCalories = newOrder.lifetimeCalories,
                            currCaloriesStored = newOrder.currCaloriesStored,
                            Friends = newOrder.Friends
                        }; 

                        return Created($"/api/test/{vm.UserId}", vm);
                    }
                }
                else
                {
                    return BadRequest(ModelState);   
                }
                

                
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occurred: " + e.ToString()  );
            }

            return BadRequest("Couldn't make user");
        }
    }
}
