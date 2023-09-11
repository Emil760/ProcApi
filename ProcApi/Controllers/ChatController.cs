using Microsoft.AspNetCore.Mvc;
using ProcApi.DTOs.Base;
using ProcApi.Services.Abstracts;

namespace ProcApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : BaseController
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("Connect")]
        public async Task<IActionResult> ConnectAsync(string connectionId)
        {
            await _chatService.ConnectAsync(UserInfo.UserId, connectionId);
            return Ok();
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllClientsAsync([FromQuery] PaginationRequestDto dto)
        {
            return Ok(await _chatService.GetUsersAsync(dto));
        }

        [HttpGet("GetChats")]
        public async Task<IActionResult> GetChatsAsync()
        {
            return Ok();
        }
    }
}