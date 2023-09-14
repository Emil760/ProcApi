using ProcApi.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.DTOs.PurchaseRequestDocument.Response;
using ProcApi.DTOs.User.Base;

namespace ProcApi.Services.Abstracts
{
    public interface IPurchaseRequestDocumentService
    {
        Task<PurchaseRequestDocumentResponseDto> CreateDocument(UserInfo userInfo,
            CreatePurchaseRequestDocumentRequestDto requestDto);
    }
}
