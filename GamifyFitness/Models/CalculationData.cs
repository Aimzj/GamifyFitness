using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamifyFitness.Models
{
    public class CalculationData
    {
        public static IDictionary<string, double> Activities = new Dictionary<string, double>()
        {
            {"swimming", 2.93},
            {"running", 0.79},
            {"cycling", 0.28},
            {"walking", 0.653}
        };


        [Required] public int age { get; }

        [Required] public double heartrate { get; }

        [Required] public int time { get; }

        [Required] public string activity { get; }
    }
}