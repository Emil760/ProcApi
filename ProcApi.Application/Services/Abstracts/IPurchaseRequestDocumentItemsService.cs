using ProcApi.Application.DTOs.PurchaseRequestDocument.Response;

namespace ProcApi.Application.Services.Abstracts;

public interface IPurchaseRequestDocumentItemsService
{
    Task<IEnumerable<PRItemResponseDto>> GetAllItemsAsync(int docId);
}