using ProcApi.DTOs.Documents;
using ProcApi.DTOs.Documents.Requests;
using ProcApi.DTOs.PurchaseRequestDocument;
using ProcApi.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.DTOs.PurchaseRequestDocument.Response;
using ProcApi.DTOs.User;
using ProcApi.DTOs.User.Base;

namespace ProcApi.Services.Abstracts;

public interface IPurchaseRequestDocumentApprovalService
{
    Task<PurchaseRequestDocumentResponseDto> CreateDocument(UserInfo userInfo, CreatePurchaseRequestDocumentRequestDto requestDto);
    Task PerformAction(ActionPerformRequestDto requestDto);
}