using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Category.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Presentation.Attributes;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : BaseController
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HasPermission(Permissions.CanViewMaterial)]
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto dto)
    {
        return Ok(await _categoryService.CreateCategory(dto));
    }

    [HasPermission(Permissions.CanViewMaterial)]
    [HttpGet("GetByLevel")]
    public async Task<IActionResult> GetByLevelAsync([FromQuery] int level)
    {
        return Ok(await _categoryService.GetByLevelAsync(level));
    }
}