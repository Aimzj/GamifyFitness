using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace GamifyFitness.Hubs
{
    public class GameHub: Hub
    {
        public async Task UpdateScore(string user, int score)
        {
            await  Clients.All.SendAsync("UpdateScore", user, score);
        }
        
    }
}