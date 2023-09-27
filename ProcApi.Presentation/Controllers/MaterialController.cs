using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Material.Request;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Models;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class MaterialController : BaseController
{
    private readonly IMaterialService _materialService;

    public MaterialController(IMaterialService materialService)
    {
        _materialService = materialService;
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationModel pagination)
    {
        return Ok(await _materialService.GetAllAsync(pagination));
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] int id)
    {
        return Ok(await _materialService.GetAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateMaterialRequestDto dto)
    {
        return Ok(await _materialService.CreateMaterial(dto));
    }

    [HttpPut]
    public async Task<IActionResult> EditAsync([FromQuery] int id, [FromBody] EditMaterialRequestDto dto)
    {
        return Ok(await _materialService.EditMaterial(id, dto));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromQuery] int id)
    {
        await _materialService.DeleteMaterial(id);
        return Ok();
    }
}