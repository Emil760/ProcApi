using ProcApi.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.DTOs.PurchaseRequestDocument.Response;

namespace ProcApi.Services.Abstracts
{
    public interface IPurchaseRequestDocumentService
    {
        Task<PRResponseDto> GetDocument(int docId);
        Task<SavePRResponseDto> CreateDocument(CreatePRRequestDto dto);
        Task<SavePRResponseDto> UpdateDocument(UpdatePRRequestDto dto);
    }
}