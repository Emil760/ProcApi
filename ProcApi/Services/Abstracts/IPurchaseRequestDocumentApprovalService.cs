using ProcApi.DTOs.Documents;
using ProcApi.DTOs.Documents.PurchaseRequestDocument;
using ProcApi.DTOs.User;

namespace ProcApi.Services.Abstracts;

public interface IPurchaseRequestDocumentApprovalService
{
    Task<PurchaseRequestDocumentDto> CreateDocument(UserInfoDro userInfoDro, CreatePurchaseRequestDocumentDto dto);
    Task PerformAction(ActionPerformDto dto);
}