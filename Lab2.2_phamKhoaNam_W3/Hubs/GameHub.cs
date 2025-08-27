using Microsoft.AspNetCore.SignalR;

namespace Lab2._2_phamKhoaNam_W3.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
