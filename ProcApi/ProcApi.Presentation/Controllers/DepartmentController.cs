using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Department.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;
using ProcApi.Presentation.Attributes;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : BaseController
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HasPermission(Permissions.CanCreateDepartment)]
    [HttpPost]
    public async Task<IActionResult> CreateDepartmentAsync(CreateDepartmentDto dto)
    {
        return Ok(await _departmentService.CreateDepartmentAsync(dto));
    }

    [HasPermission(Permissions.CanAssignUserDepartment)]
    [HttpPut("ChangeUserDepartment")]
    public async Task<IActionResult> ChangeUserDepartmentAsync([FromBody] AssignUserDepartmentDto dto)
    {
        await _departmentService.AssignUserToDepartment(UserInfo.UserId, dto);
        return Ok();
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationModel model)
    {
        return Ok(await _departmentService.GetAllAsync(model));
    }
}