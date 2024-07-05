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

    [HttpPost]
    [HasPermission(Permissions.CanViewMaterial)]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
    {
        return Ok(await _categoryService.CreateCategory(request));
    }

    [HttpGet("GetByLevel")]
    [HasPermission(Permissions.CanViewMaterial)]
    public async Task<IActionResult> GetByLevelAsync([FromQuery] int level)
    {
        return Ok(await _categoryService.GetByLevelAsync(level));
    }
}