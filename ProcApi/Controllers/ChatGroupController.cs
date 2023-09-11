using Microsoft.AspNetCore.Mvc;
using ProcApi.DTOs.Chat.Request;
using ProcApi.Services.Abstracts;

namespace ProcApi.Controllers;

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
        return Ok();
    }

    [HttpPut("RemoveAdmin")]
    public async Task<IActionResult> RemoveAdminAsync(int groupId, int userId)
    {
        return Ok();
    }

    [HttpDelete("LeaveGroup")]
    public async Task<IActionResult> LeaveGroupAsync(int groupId)
    {
        return Ok();
    }
}