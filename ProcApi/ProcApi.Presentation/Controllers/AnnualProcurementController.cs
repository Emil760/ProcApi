using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcApi.Application.DTOs.AnnualProcurement.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Infrastructure.Data;
using ProcApi.Presentation.Attributes;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class AnnualProcurementController : BaseController
{
    private readonly IAnnualProcurementService _annualProcurementService;
    private readonly ProcDbContext _dbContext;
    
    public AnnualProcurementController(IAnnualProcurementService annualProcurementService)
    {
        _annualProcurementService = annualProcurementService;
    }
    
    [HttpPost]
    [HasPermission(Permissions.CanAddAnnualProcurement)]
    public async Task<IActionResult> CreateAnnualProcurementAsync([FromBody] CreateAnnualProcurementRequestDto requestDto)
    {
        _dbContext.AnnualProcurements.ExecuteDelete();
        return Ok(await _annualProcurementService.CreateAnnualProcurementAsync(requestDto));
    }
}