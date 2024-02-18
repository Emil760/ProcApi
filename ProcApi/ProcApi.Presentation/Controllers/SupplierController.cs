using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Supplier.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;
using ProcApi.Presentation.Attributes;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class SupplierController : BaseController
{
    private readonly ISupplierService _supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpGet]
    [HasPermission(Permissions.CanViewSupplier)]
    public async Task<IActionResult> GetAsync([FromQuery] int id)
    {
        return Ok(await _supplierService.GetSupplierAsync(id));
    }

    [HttpGet("All")]
    [HasPermission(Permissions.CanViewSupplier)]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationModel pagination)
    {
        return Ok(await _supplierService.GetAllSupplierAsync(pagination));
    }

    [HttpPost]
    [HasPermission(Permissions.CanCreateSupplier)]
    public async Task<IActionResult> CreateAsync(CreateSupplierRequestDto dto)
    {
        return Ok(await _supplierService.CreateSupplierAsync(dto));
    }

    [HttpPut]
    [HasPermission(Permissions.CanCreateSupplier)]
    public async Task<IActionResult> UpdateAsync(UpdateSupplierRequestDto dto)
    {
        return Ok(await _supplierService.UpdateSupplierAsync(dto));
    }

    [HttpPut("Activate")]
    [HasPermission(Permissions.CanCreateSupplier)]
    public async Task<IActionResult> ActivateAsync(int id, bool isActivate)
    {
        return Ok(await _supplierService.ActivateSupplier(id, isActivate));
    }
}