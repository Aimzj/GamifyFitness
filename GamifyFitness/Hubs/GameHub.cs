using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace GamifyFitness.Hubs
{
    public class GameHub: Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await  Clients.All.SendAsync("Message", user, message);
        }
        
    }
}