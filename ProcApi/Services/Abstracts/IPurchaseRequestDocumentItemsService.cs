using ProcApi.DTOs.PurchaseRequestDocument.Response;

namespace ProcApi.Services.Abstracts;

public interface IPurchaseRequestDocumentItemsService
{
    Task<IEnumerable<PurchaseRequestDocumentItemResponseDto>> GetAllItemsAsync(int docId);
}