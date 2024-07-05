using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.Caches.Abstracts;
using ProcApi.Application.DTOs.Department.Requests;
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

    [HttpGet("GetAll")]
    [HasPermission(Permissions.CanViewUser)]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _userService.GetAllInfosAsync());
    }

    [HttpGet("GetAllWithRoles")]
    [HasPermission(Permissions.CanViewUser)]
    public async Task<IActionResult> GetAllWithRolesAsync(string? search)
    {
        return Ok(await _userService.GetUsersWithRolesAsync(search));
    }

    [HttpGet("GetById/{id}")]
    [HasPermission(Permissions.CanViewUser)]
    public async Task<IActionResult> GetAllAsync([FromRoute] int id)
    {
        return Ok(await _userService.GetByIdAsync(id));
    }

    [HttpGet("GetCached")]
    [HasPermission(Permissions.CanViewUser)]
    public async Task<IActionResult> GetCachedAsync(int userId)
    {
        return Ok(await _userCachedService.GetByIdAsync(userId));
    }

    [HttpPost]
    [HasPermission(Permissions.CanCreateUser)]
    public async Task<IActionResult> CreateUser([FromBody] AddUserRequest request)
    {
        return Ok(await _userService.AddUserAsync(request));
    }

    [HttpPost("GrantRole")]
    [HasPermission(Permissions.CanGrantRole)]
    public async Task<IActionResult> GrantRoleAsync([FromBody] GrantRoleRequest dto)
    {
        await _userService.GrantRoleAsync(dto);
        return Ok();
    }

    [HttpDelete("RemoveRole")]
    [HasPermission(Permissions.CanRemoveRole)]
    public async Task<IActionResult> RemoveRoleAsync([FromBody] RemoveRoleRequest dto)
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

    [HttpGet("GetAllByRole")]
    [HasPermission(Permissions.CanViewUser)]
    public async Task<IActionResult> GetAllByRoleAsync(int roleId)
    {
        return Ok(await _userService.GetAllByRoleAsync(roleId));
    }

    [HttpGet("GetAllByRoleName")]
    [HasPermission(Permissions.CanViewUser)]
    public async Task<IActionResult> GetAllByRoleNameAsync(string name)
    {
        return Ok(await _userService.GetAllByRoleNameAsync(name));
    }

    [HttpPut("AssignDashboard")]
    [HasPermission(Permissions.CanChangeDashboard)]
    public async Task<IActionResult> AssignDashboardAsync(AssignDashboardRequest dto)
    {
        await _userService.AssignDashboardAsync(dto);
        return Ok();
    }
    
    [HttpPut("AssignDepartment")]
    [HasPermission(Permissions.CanChangeDashboard)]
    public async Task<IActionResult> AssignDepartmentAsync(AssignDepartmentRequest request)
    {
        await _userService.AssignDepartmentAsync(request);
        return Ok();
    }
}