using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Chat.Request;
using ProcApi.Application.Services.Abstracts;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatGroupController : BaseController
{
    private readonly IChatGroupService _chatGroupService;

    public ChatGroupController(IChatGroupService chatGroupService)
    {
        _chatGroupService = chatGroupService;
    }

    [HttpPost("CreateGroup")]
    public async Task<IActionResult> CreateGroupAsync([FromBody] CreateGroupRequestDto dto)
    {
        return Ok(await _chatGroupService.CreateGroupAsync(UserInfo.UserId, dto));
    }

    [HttpPut("GiveAdmin")]
    public async Task<IActionResult> GiveAdminAsync(int groupId, int userId)
    {
        await _chatGroupService.GiveAdminAsync(UserInfo.UserId, userId, groupId);
        return Ok();
    }

    [HttpPut("RemoveAdmin")]
    public async Task<IActionResult> RemoveAdminAsync(int groupId, int userId)
    {
        await _chatGroupService.RemoveAdminAsync(UserInfo.UserId, userId, groupId);
        return Ok();
    }

    [HttpDelete("LeaveGroup")]
    public async Task<IActionResult> LeaveGroupAsync(int groupId)
    {
        await _chatGroupService.LeaveGroup(UserInfo.UserId, groupId);
        return Ok();
    }
}