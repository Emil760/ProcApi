using ProcApi.Application.DTOs.PurchaseRequestDocument.Response;

namespace ProcApi.Application.Services.Abstracts;

public interface IPurchaseRequestItemsService
{
    Task<IEnumerable<PRItemResponseDto>> GetAllItemsAsync(int docId);
}