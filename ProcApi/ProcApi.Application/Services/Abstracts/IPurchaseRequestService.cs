using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Application.DTOs.Documents.Responses;
using ProcApi.Application.DTOs.PurchaseRequest.Requests;
using ProcApi.Application.DTOs.PurchaseRequest.Response;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface IPurchaseRequestService
{
    Task<PRResponseDto> GetDocumentAsync(int docId);
    Task<SavePRResponseDto> SavePurchaseRequest(SavePRRequestDto dto);
    Task<DocumentResponseDto> CreatePurchaseRequest(UserInfoModel userInfo);
    Task AssignBuyerToItemAsync(AssignUserToItemDto dto);
}