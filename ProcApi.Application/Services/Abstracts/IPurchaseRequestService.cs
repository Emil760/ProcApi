using ProcApi.Application.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.Application.DTOs.PurchaseRequestDocument.Response;

namespace ProcApi.Application.Services.Abstracts;

public interface IPurchaseRequestService
{
    Task<PRResponseDto> GetDocumentAsync(int docId);
    Task<SavePRResponseDto> SavePurchaseRequest(SavePRRequestDto dto);
}