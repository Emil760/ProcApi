﻿using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Application.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;

namespace ProcApi.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseRequestDocumentController : BaseController
    {
        private readonly IDocumentService _documentService;
        private readonly IPurchaseRequestDocumentService _purchaseRequestDocumentService;
        private readonly IPurchaseRequestDocumentItemsService _purchaseRequestDocumentItemsService;
        private readonly IPurchaseRequestDocumentApprovalService _purchaseRequestDocumentApprovalService;

        public PurchaseRequestDocumentController(IPurchaseRequestDocumentService purchaseRequestDocumentService,
            IPurchaseRequestDocumentApprovalService purchaseRequestDocumentApprovalService,
            IPurchaseRequestDocumentItemsService purchaseRequestDocumentItemsService,
            IDocumentService documentService)
        {
            _purchaseRequestDocumentService = purchaseRequestDocumentService;
            _purchaseRequestDocumentApprovalService = purchaseRequestDocumentApprovalService;
            _purchaseRequestDocumentItemsService = purchaseRequestDocumentItemsService;
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDocumentAsync([FromQuery] int docId)
        {
            return Ok(await _purchaseRequestDocumentService.GetDocument(docId));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateDocumentAsync()
        {
            return Ok(await _documentService.CreateDocumentWithApprovalsAsync(UserInfo,
                DocumentType.PurchaseRequest,
                DocumentStatus.PurchaseRequestDraft));
        }

        [HttpPost("Save")]
        public async Task<IActionResult> SaveAsync([FromBody] CreatePRRequestDto dto)
        {
            return Ok(await _purchaseRequestDocumentService.CreateDocument(dto));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdatePRRequestDto dto)
        {
            return Ok(await _purchaseRequestDocumentService.UpdateDocument(dto));
        }

        [HttpPost("PerformAction")]
        public async Task<IActionResult> PerformAction([FromBody] ActionPerformRequestDto requestDto)
        {
            await _purchaseRequestDocumentApprovalService.PerformAction(requestDto, UserInfo);
            return Ok();
        }

        [HttpGet("Items")]
        public async Task<IActionResult> GetItems([FromQuery] int docId)
        {
            return Ok(await _purchaseRequestDocumentItemsService.GetAllItemsAsync(docId));
        }
    }
}