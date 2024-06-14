using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface IDocumentService
{
    Task<Document> CreateDocumentWithApprovalsAsync(UserInfoModel userInfo, DocumentType type, DocumentStatus status);
    Task<string> CreateDocumentNumber(DocumentType documentType);
}