using Microsoft.AspNetCore.Mvc;
using ProcApi.DTOs.Chat.Request;
using ProcApi.Services.Abstracts;

namespace ProcApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatMessageController : BaseController
{
    private readonly IChatMessageService _chatMessageService;

    public ChatMessageController(IChatMessageService chatMessageService)
    {
        _chatMessageService = chatMessageService;
    }

    [HttpPost("SendUserChatMessage")]
    public async Task<IActionResult> SendAsync([FromBody] SendChatUserMessageRequestDto dto)
    {
        await _chatMessageService.SendMessageToUserAsync(UserInfo.UserId, dto);
        return Ok();
    }

    [HttpPut("MarkAsRead")]
    public async Task<IActionResult> MarkAsReadAsync(int messageId)
    {
        await _chatMessageService.MarkAsReadAsync(messageId, UserInfo.UserId);
        return Ok();
    }
}