using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Department.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Models;

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

    [HttpPost]
    public async Task<IActionResult> CreateDepartmentAsync(CreateDepartmentDto dto)
    {
        return Ok(await _departmentService.CreateDepartmentAsync(dto));
    }

    [HttpPut("ChangeUserDepartment")]
    public async Task<IActionResult> ChangeUserDepartmentAsync([FromBody] AssignUserDepartmentDto dto)
    {
        await _departmentService.AssignUserToDepartment(dto);
        return Ok();
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationModel model)
    {
        return Ok(await _departmentService.GetAllAsync(model));
    }
}