using ChatApp.HubContext;
using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Chat : ControllerBase
    {
        private readonly ILogger<Chat> _log;
        private readonly ChatHub _chatHub;

        public Chat(ILogger<Chat> log, ChatHub chathub)
        {
            _log = log;
            _chatHub = chathub;
        }

        /// <summary>
        /// End point for posting data
        /// </summary>
        /// <param name="value"></param>
        [HttpPost("PostChat")]
        public IActionResult Post([FromBody] MessageDto message)
        {
            _log.LogInformation($"Post: {message}");
            _chatHub.SendMessage(message.user, message.msgText);
            return Ok(1);
        }
    }
}
