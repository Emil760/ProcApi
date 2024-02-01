using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Application.Services.Abstracts;

public interface IApprovalsService
{
    Task<IEnumerable<DocumentAction>> InitApprovals(int documentId, int userId, DocumentType documentType);
    Task CanPerformAction(ActionPerformRequestDto dto, int userId);
    Task ApproveDocumentAsync(ActionPerformRequestDto dto, int userId);
    Task ReturnDocumentAsync(ActionPerformRequestDto dto);
    Task RejectDocumentAsync(ActionPerformRequestDto dto);
    Task AddApprovalToDocument(int documentId, int userId, Roles role, DocumentType documentType);
    Task RemoveApprovalFromDocument(int documentId, int userId, Roles role, DocumentType documentType);
    Task AddMultipleApprovalToDocument(int documentId, int userId, Roles role, DocumentType documentType);
}