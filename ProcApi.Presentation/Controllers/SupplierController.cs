using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Supplier.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Models;

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
    public async Task<IActionResult> GetAsync([FromQuery] int id)
    {
        return Ok(await _supplierService.GetSupplierAsync(id));
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationModel pagination)
    {
        return Ok(await _supplierService.GetAllSupplierAsync(pagination));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateSupplierRequestDto dto)
    {
        return Ok(await _supplierService.CreateSupplierAsync(dto));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateSupplierRequestDto dto)
    {
        return Ok(await _supplierService.UpdateSupplierAsync(dto));
    }

    [HttpPut("Activate")]
    public async Task<IActionResult> ActivateAsync(int id, bool isActivate)
    {
        return Ok(await _supplierService.ActivateSupplier(id, isActivate));
    }
}