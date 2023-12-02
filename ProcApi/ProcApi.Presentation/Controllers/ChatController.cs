using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Models;

namespace ProcApi.Presentation.Controllers;

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
    public async Task<IActionResult> GetAllClientsAsync([FromQuery] PaginationModel pagination)
    {
        return Ok(await _chatService.GetUsersAsync(pagination));
    }

    [HttpGet("GetChats")]
    public async Task<IActionResult> GetChatsAsync()
    {
        return Ok(await _chatService.GetChatsAsync(UserInfo.UserId));
    }
}