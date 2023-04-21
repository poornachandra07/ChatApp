using Microsoft.AspNetCore.SignalR;

namespace ChatApp.HubContext
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients?.All.SendAsync("ReceiveMessage", user, message);
        }
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? ex)
        {
            await base.OnDisconnectedAsync(ex);
        }
    }
}
