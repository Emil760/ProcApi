using Microsoft.AspNetCore.Mvc;
using ProcApi.DTOs.Category.Requests;
using ProcApi.Services.Abstracts;

namespace ProcApi.Controllers;

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
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto dto)
    {
        return Ok(await _categoryService.CreateCategory(dto));
    }

    [HttpGet("get-by-level")]
    public async Task<IActionResult> GetByLevelAsync([FromQuery] int level)
    {
        return Ok(await _categoryService.GetByLevelAsync(level));
    }
}