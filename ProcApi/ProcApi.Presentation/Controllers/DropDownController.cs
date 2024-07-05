using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.DropDown.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Presentation.Attributes;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class DropDownController : BaseController
{
    private readonly IDropDownService _dropDownService;
    
    public DropDownController(IDropDownService dropDownService)
    {
        _dropDownService = dropDownService;
    }
    
    [HttpPost("source")]
    [HasPermission(Permissions.CanCreateDropDown)]
    public async Task<IActionResult> CreateSourceAsync(CreateDropDownSourceRequest dto)
    {
        return Ok(await _dropDownService.CreateSourceAsync(dto));
    }
    
    [HttpPost("item")]
    [HasPermission(Permissions.CanCreateDropDown)]
    public async Task<IActionResult> CreateItemAsync(CreateDropDownItemRequest dto)
    {
        return Ok(await _dropDownService.CreateItemAsync(dto));
    }
    
    [HttpPut("source")]
    [HasPermission(Permissions.CanCreateDropDown)]
    public async Task<IActionResult> ChangeSourceAsync(ChangeDropDownSourceRequest dto)
    {
        await _dropDownService.ChangeSourceAsync(dto);
        return Ok();
    }
    
    [HttpPut("item")]
    [HasPermission(Permissions.CanCreateDropDown)]
    public async Task<IActionResult> ChangeItemAsync(ChangeDropDownItemRequest dto)
    {
        await _dropDownService.ChangeItemAsync(dto);
        return Ok();
    }

    [HttpGet("sources")]
    [HasPermission(Permissions.CanGetDropDown)]
    public async Task<IActionResult> GetDelegationAsync()
    {
        return Ok(await _dropDownService.GetAllSources());
    }
    
    [HttpGet("items")]
    [HasPermission(Permissions.CanGetDropDown)]
    public async Task<IActionResult> GetDelegationAsync([FromQuery] int sourceId)
    {
        return Ok(await _dropDownService.GetAllItems(sourceId));
    }
}