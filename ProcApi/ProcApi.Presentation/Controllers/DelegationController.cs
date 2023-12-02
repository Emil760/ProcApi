﻿using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Delegation.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;
using ProcApi.Presentation.Attributes;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class DelegationController : BaseController
{
    private readonly IDelegationService _delegationService;

    public DelegationController(IDelegationService delegationService)
    {
        _delegationService = delegationService;
    }

    [HasPermission(Permissions.CanCreateDelegation)]
    [HttpPost]
    public async Task<IActionResult> CreateDelegationAsync(CreateDelegationRequestDto dto)
    {
        await _delegationService.CreateDelegationAsync(dto);
        return Ok();
    }

    [HasPermission(Permissions.CanViewDelegation)]
    [HttpGet("all")]
    public async Task<IActionResult> GetDelegationAsync([FromQuery] PaginationModel dto)
    {
        return Ok(await _delegationService.GetDelegations(dto));
    }
}