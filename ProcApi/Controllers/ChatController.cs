using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ProcApi.Services.Concreates;

namespace ProcApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : Controller
    {
        IHubContext<ChatHub> hubContext;

        public ChatController(IHubContext<ChatHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send(string connectionId, string message, string name)
        {
            await hubContext.Clients.All.SendAsync("Send", message, name);
            await hubContext.Clients.AllExcept(connectionId).SendAsync("Send", message, "Me");
            return Ok();
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllClients()
        {
            return Ok(hubContext.Clients);
        }
    }
}
