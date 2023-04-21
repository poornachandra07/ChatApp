using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Chat : ControllerBase
    {

        /// <summary>
        /// End point for posting data
        /// </summary>
        /// <param name="value"></param>
        [HttpPost("PostChat")]
        public IActionResult Post([FromBody] string message)
        {
            return Ok(1);
        }
    }
}
