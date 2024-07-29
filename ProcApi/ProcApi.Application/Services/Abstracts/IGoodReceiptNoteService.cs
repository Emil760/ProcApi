using ProcApi.Application.DTOs.PurchaseRequest.Requests;
using ProcApi.Application.DTOs.PurchaseRequest.Responses;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface IGoodReceiptNoteService
{
    Task<object?> GetDocumentAsync(int docId);
    Task<object?> CreateGoodReceiptNoteAsync(UserInfoModel userInfo);
    Task<SavePRResponse> SaveGoodReceiptNoteAsync(SavePRRequest dto);
    Task<object?> GetAllItemsAsync(int docId);
}