using ProcApi.Application.DTOs.PurchaseRequest.Response;

namespace ProcApi.Application.Services.Abstracts;

public interface IPurchaseRequestItemsService
{
    Task<IEnumerable<PRItemResponseDto>> GetAllItemsAsync(int docId);
}