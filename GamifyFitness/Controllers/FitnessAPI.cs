using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GamifyFitness.Controllers
{
    public class FitnessAPI : Controller
    {
        public IActionResult Calories(int age, int time, float heartrate, string activity)
        {
            IDictionary<string, double> Activities = new Dictionary<string, double>()
            {
                {"swimming", 2.93},
                {"running", 0.79},
                {"cycling", 0.28},
                {"walking", 0.653}
            };

            if (activity == null || !Activities.Keys.Contains(activity.ToLower()))
            {
                return BadRequest("Invalid activity");
            }

            return Ok(((age * time) + heartrate) * Activities[activity.ToLower()]);

        }
    }
}