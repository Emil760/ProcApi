using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ProcApi.Services.Abstracts;
using ProcApi.Services.Concreates;

namespace ProcApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : BaseController
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IChatService _chatService;

        public ChatController(IHubContext<ChatHub> hubContext,
            IChatService chatService)
        {
            _hubContext = hubContext;
            _chatService = chatService;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send(string connectionId, string message, string name)
        {
            await _hubContext.Clients.All.SendAsync("Send", message, name);
            await _hubContext.Clients.AllExcept(connectionId).SendAsync("Send", message, "Me");
            return Ok();
        }

        [HttpPost("SendBulk")]
        public async Task<IActionResult> SendBulk(int userId, string message)
        {
            try
            {
                await _chatService.SendBulk(userId, message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + "\n" + ex.InnerException?.Message);
                throw;
            }

            return Ok();
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllClients()
        {
            return Ok(_hubContext.Clients);
        }
    }
}