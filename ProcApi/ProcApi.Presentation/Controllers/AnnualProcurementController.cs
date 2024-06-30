using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.AnnualProcurement.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Presentation.Attributes;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class AnnualProcurementController : BaseController
{
    private readonly IAnnualProcurementService _annualProcurementService;
    
    public AnnualProcurementController(IAnnualProcurementService annualProcurementService)
    {
        _annualProcurementService = annualProcurementService;
    }

    [HttpGet("All")]
    [HasPermission(Permissions.CanViewAnnualProcurement)]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _annualProcurementService.GetAllAsync());
    }
    
    [HttpGet("AllActive")]
    [HasPermission(Permissions.CanViewAnnualProcurement)]
    public async Task<IActionResult> GetAllActiveAsync()
    {
        return Ok(await _annualProcurementService.GetAllActiveAsync());
    }
    
    [HttpPost]
    [HasPermission(Permissions.CanAddAnnualProcurement)]
    public async Task<IActionResult> CreateAnnualProcurementAsync([FromBody] CreateAnnualProcurementRequestDto requestDto)
    {
        return Ok(await _annualProcurementService.CreateAnnualProcurementAsync(requestDto));
    }
    
    [HttpPut]
    [HasPermission(Permissions.CanAddAnnualProcurement)]
    public async Task<IActionResult> ChangeAnnualProcurementAsync(int id)
    {
        await _annualProcurementService.ChangeAnnualProcurementAsync(id);
        return Ok();
    }
    
    [HttpPut("Activate")]
    [HasPermission(Permissions.CanAddAnnualProcurement)]
    public async Task<IActionResult> ActivateAsync(int id)
    {
        await _annualProcurementService.ActivateAsync(id);
        return Ok();
    }
    
    [HttpPut("Deactivate")]
    [HasPermission(Permissions.CanAddAnnualProcurement)]
    public async Task<IActionResult> DeactivateAsynnc(int id)
    {
        await _annualProcurementService.DeactivateAsync(id);
        return Ok();
    }
    
    [HttpPost("Item")]
    [HasPermission(Permissions.CanAddAnnualProcurement)]
    public async Task<IActionResult> AddItemAsync(CreateAnnualProcurementItemsRequestDto dto)
    {
        return Ok(await _annualProcurementService.AddItemAsync(dto));
    }
}