using ProcApi.Application.DTOs.Documents.Responses;
using ProcApi.Application.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.Application.DTOs.PurchaseRequestDocument.Response;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface IPurchaseRequestService
{
    Task<PRResponseDto> GetDocumentAsync(int docId);
    Task<SavePRResponseDto> SavePurchaseRequest(SavePRRequestDto dto);
    Task<DocumentResponseDto> CreatePurchaseRequest(UserInfoModel userInfo);
}