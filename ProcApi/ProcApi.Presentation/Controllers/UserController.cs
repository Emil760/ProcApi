using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.Caches.Abstracts;
using ProcApi.Application.DTOs.User.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Presentation.Attributes;

namespace ProcApi.Presentation.Controllers;

[Route("api/[controller]")]
public class UserController : BaseController
{
    private readonly IUserService _userService;
    private readonly IUserCachedService _userCachedService;

    public UserController(IUserService userService,
        IUserCachedService userCachedService)
    {
        _userService = userService;
        _userCachedService = userCachedService;
    }

    [HasPermission(Permissions.CanViewUser)]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _userService.GetUsersAsync());
    }

    [HasPermission(Permissions.CanViewUser)]
    [HttpGet("GetAllWithRoles")]
    public async Task<IActionResult> GetAllWithRolesAsync(string? search)
    {
        return Ok(await _userService.GetUsersWithRolesAsync(search));
    }

    [HasPermission(Permissions.CanViewUser)]
    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetAllAsync([FromRoute] int id)
    {
        return Ok(await _userService.GetByIdAsync(id));
    }

    [HasPermission(Permissions.CanViewUser)]
    [HttpGet("GetCached")]
    public async Task<IActionResult> GetCachedAsync(int userId)
    {
        return Ok(await _userCachedService.GetByIdAsync(userId));
    }

    [HasPermission(Permissions.CanCreateUser)]
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] AddUserDto dto)
    {
        return Ok(await _userService.AddUserAsync(dto));
    }

    [HasPermission(Permissions.CanGrantRole)]
    [HttpPost("GrantRole")]
    public async Task<IActionResult> GrantRoleAsync([FromBody] GrantRoleRequestDto dto)
    {
        await _userService.GrantRoleAsync(dto);
        return Ok();
    }

    [HasPermission(Permissions.CanRemoveRole)]
    [HttpDelete("RemoveRole")]
    public async Task<IActionResult> RemoveRoleAsync([FromBody] RemoveRoleRequestDto dto)
    {
        await _userService.RemoveRoleAsync(dto);
        return Ok();
    }

    [HttpGet("MyRoleName")]
    public async Task<IActionResult> GetRoleNamesAsync()
    {
        return Ok(await _userService.GetAllRoleNames(UserInfo.UserId));
    }

    [HttpGet("MyPermissionNames")]
    public async Task<IActionResult> GetRolePermissionsAsync()
    {
        return Ok(await _userService.GetPermissionNames(UserInfo.UserId));
    }

    [HasPermission(Permissions.CanViewUser)]
    [HttpGet("GetAllByRole")]
    public async Task<IActionResult> GetAllByRoleAsync(int roleId)
    {
        return Ok(await _userService.GetAllByRoleAsync(roleId));
    }

    [HasPermission(Permissions.CanViewUser)]
    [HttpGet("GetAllByRoleName")]
    public async Task<IActionResult> GetAllByRoleNameAsync(string name)
    {
        return Ok(await _userService.GetAllByRoleNameAsync(name));
    }
}