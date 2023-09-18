using Microsoft.AspNetCore.Mvc;
using ProcApi.DTOs.Base;
using ProcApi.DTOs.Material.Request;
using ProcApi.Services.Abstracts;

namespace ProcApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MaterialController : BaseController
{
    private readonly IMaterialService _materialService;

    public MaterialController(IMaterialService materialService)
    {
        _materialService = materialService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationRequestDto dto)
    {
        return Ok(await _materialService.GetAllAsync(dto));
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] int id)
    {
        return Ok();
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
        return Ok();
    }
}