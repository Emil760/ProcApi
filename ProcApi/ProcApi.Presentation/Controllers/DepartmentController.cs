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

    [HttpPost]
    [HasPermission(Permissions.CanCreateDepartment)]
    public async Task<IActionResult> CreateDepartmentAsync(CreateDepartmentRequest request)
    {
        return Ok(await _departmentService.CreateDepartmentAsync(request));
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationModel model)
    {
        return Ok(await _departmentService.GetAllAsync(model));
    }
}