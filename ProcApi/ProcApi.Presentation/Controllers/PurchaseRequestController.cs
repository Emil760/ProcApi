﻿using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Application.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Presentation.Attributes;
using ProcApi.Presentation.Filters;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchaseRequestController : BaseController
{
    private readonly IPurchaseRequestService _purchaseRequestService;
    private readonly IPurchaseRequestItemsService _purchaseRequestItemsService;
    private readonly IPurchaseRequestApprovalService _purchaseRequestApprovalService;

    public PurchaseRequestController(IPurchaseRequestService purchaseRequestService,
        IPurchaseRequestApprovalService purchaseRequestApprovalService,
        IPurchaseRequestItemsService purchaseRequestItemsService)
    {
        _purchaseRequestService = purchaseRequestService;
        _purchaseRequestApprovalService = purchaseRequestApprovalService;
        _purchaseRequestItemsService = purchaseRequestItemsService;
    }

    [DocumentAccessFilter(new[] { 
        Permissions.CanViewAll,
        Permissions.CanReturnPurchaseRequest,
        Permissions.CanRejectPurchaseRequest })]
    [HasPermission(Permissions.CanViewPurchaseRequest)]
    [HttpGet]
    public async Task<IActionResult> GetDocumentAsync([FromQuery] int docId)
    {
        return Ok(await _purchaseRequestService.GetDocumentAsync(docId));
    }

    [HasPermission(Permissions.CanCreatePurchaseRequest)]
    [HttpPost("Create")]
    public async Task<IActionResult> CreateDocumentAsync()
    {
        return Ok(await _purchaseRequestService.CreatePurchaseRequest(UserInfo));
    }

    [HasPermission(Permissions.CanCreatePurchaseRequest)]
    [HttpPost("Save")]
    public async Task<IActionResult> SaveAsync([FromBody] SavePRRequestDto dto)
    {
        return Ok(await _purchaseRequestService.SavePurchaseRequest(dto));
    }

    [HttpPost("PerformAction")]
    public async Task<IActionResult> PerformAction([FromBody] ActionPerformRequestDto requestDto)
    {
        await _purchaseRequestApprovalService.PerformAction(requestDto, UserInfo);
        return Ok();
    }

    [HasPermission(Permissions.CanViewPurchaseRequest)]
    [HttpGet("Items")]
    public async Task<IActionResult> GetItems([FromQuery] int docId)
    {
        return Ok(await _purchaseRequestItemsService.GetAllItemsAsync(docId));
    }
}