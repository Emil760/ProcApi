using ProcApi.DTOs.PurchaseRequestDocument.Response;

namespace ProcApi.Services.Abstracts
{
    public interface IPurchaseRequestDocumentService
    {
        Task<PurchaseRequestDocumentResponseDto> GetDocument(int docId);
    }
}
