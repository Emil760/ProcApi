using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.DTOs.Documents.Responses;
using ProcApi.DTOs.User.Base;

namespace ProcApi.Services.Abstracts;

public interface IDocumentService
{
    Task<DocumentResponseDto> CreateDocumentWithApprovals(UserInfo userInfo, DocumentType type, DocumentStatus status);
}