using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Application.DTOs.Documents.Responses;
using ProcApi.Application.DTOs.PurchaseRequest.Requests;
using ProcApi.Application.DTOs.PurchaseRequest.Responses;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface IPurchaseRequestService
{
    Task<PRResponse> GetDocumentAsync(int docId);
    Task<SavePRResponse> SavePurchaseRequest(SavePRRequest dto);
    Task<DocumentResponseDto> CreatePurchaseRequest(UserInfoModel userInfo);
    Task AssignBuyerToItemAsync(AssignUserToItemRequest request);
}