using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.UnitOfMeasure.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Presentation.Attributes;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class UnitOfMeasureController : BaseController
{
    private readonly IUnitOfMeasureService _unitOfMeasureService;

    public UnitOfMeasureController(IUnitOfMeasureService unitOfMeasureService)
    {
        _unitOfMeasureService = unitOfMeasureService;
    }

    [HttpGet("All")]
    [HasPermission(Permissions.CanViewUnitOfMeasure)]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _unitOfMeasureService.GetAllAsync());
    }

    [HttpGet("ActiveForDropDown")]
    public async Task<IActionResult> GetActiveForDropDownAsync()
    {
        return Ok(await _unitOfMeasureService.GetActiveForDropDownAsync());
    }

    [HttpGet("ForDropDown")]
    public async Task<IActionResult> GetForDropDownAsync()
    {
        return Ok(await _unitOfMeasureService.GetForDropDownAsync());
    }

    [HttpPost]
    [HasPermission(Permissions.CanCreateUnitOfMeasure)]
    public async Task<IActionResult> CreateAsync(CreateUnitOfMeasureRequestDto dto)
    {
        return Ok(await _unitOfMeasureService.CreateAsync(dto));
    }

    [HttpPut("Activate")]
    [HasPermission(Permissions.CanCreateUnitOfMeasure)]
    public async Task<IActionResult> ActivateAsync(ActivateUnitOfMeasureRequestDto dto)
    {
        await _unitOfMeasureService.ActivateAsync(dto);
        return Ok();
    }

    [HttpPost("Rule")]
    [HasPermission(Permissions.CanCreateUnitOfMeasure)]
    public async Task<IActionResult> CreateRuleAsync(CreateUnitOfMeasureConversationRuleRequestDto dto)
    {
        await _unitOfMeasureService.CreateConversationRuleAsync(dto);
        return Ok();
    }

    [HttpGet("Rule")]
    public async Task<IActionResult> GetRulesAsync(int id)
    {
        return Ok(await _unitOfMeasureService.GetRulesAsync(id));
    }
    
}