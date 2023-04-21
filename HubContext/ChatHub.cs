using Microsoft.AspNetCore.SignalR;

namespace ChatApp.HubContext
{
    public class ChatHub : Hub
    {
        private ILogger<ChatHub> _log;
        public ChatHub(ILogger<ChatHub> log)
        {
            _log = log;
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public override async Task OnConnectedAsync()
        {
            _log.LogInformation($"OnConnectedAsync");
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? ex)
        {
            _log.LogInformation($"OnDisconnectedAsync");
            await base.OnDisconnectedAsync(ex);
        }
    }
}
