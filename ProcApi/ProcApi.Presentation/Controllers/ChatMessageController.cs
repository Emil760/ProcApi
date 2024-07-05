using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Chat.Requests;
using ProcApi.Application.Services.Abstracts;

namespace ProcApi.Presentation.Controllers;

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
    public async Task<IActionResult> SendUserAsync([FromBody] SendChatUserMessageRequest dto)
    {
        await _chatMessageService.SendMessageToUserAsync(UserInfo.UserId, dto);
        return Ok();
    }
    
    [HttpPost("SendGroupMessage")]
    public async Task<IActionResult> SendGroupAsync([FromBody] SendGroupMessageRequest dto)
    {
        await _chatMessageService.SendMessageToGroupAsync(UserInfo.UserId, dto);
        return Ok();
    }

    [HttpPut("MarkAsRead")]
    public async Task<IActionResult> MarkAsReadAsync(int messageId)
    {
        await _chatMessageService.MarkAsReadAsync(messageId, UserInfo.UserId);
        return Ok();
    }
}