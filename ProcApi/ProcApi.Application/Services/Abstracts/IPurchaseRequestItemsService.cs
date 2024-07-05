using ProcApi.Application.DTOs.PurchaseRequest.Responses;

namespace ProcApi.Application.Services.Abstracts;

public interface IPurchaseRequestItemsService
{
    Task<IEnumerable<PRItemResponse>> GetAllItemsAsync(int docId);
}