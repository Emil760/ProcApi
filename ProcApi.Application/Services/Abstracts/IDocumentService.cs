using ProcApi.Application.DTOs.Documents.Responses;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface IDocumentService
{
    Task<DocumentResponseDto> CreateDocumentWithApprovals(UserInfoModel userInfo, DocumentType type, DocumentStatus status);
}