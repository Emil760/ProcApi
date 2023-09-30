using ProcApi.Application.DTOs.Documents.Responses;
using ProcApi.Application.DTOs.Invoice.Responses;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface IDocumentService
{
    Task<DocumentResponseDto> CreateDocumentWithApprovalsAsync(UserInfoModel userInfo, DocumentType type, DocumentStatus status);
}