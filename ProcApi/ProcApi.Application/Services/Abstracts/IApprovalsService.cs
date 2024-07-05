using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Application.Services.Abstracts;

public interface IApprovalsService
{
    Task<IEnumerable<DocumentAction>> InitApprovals(int documentId, int userId, DocumentType documentType);
    Task CanPerformAction(ActionPerformRequest dto, int userId);
    Task ApproveDocumentAsync(ActionPerformRequest dto, int userId);
    Task ReturnDocumentAsync(ActionPerformRequest dto);
    Task RejectDocumentAsync(ActionPerformRequest dto);
    Task AddApprovalToDocument(int documentId, int userId, Roles role, DocumentType documentType);
    Task RemoveApprovalFromDocument(int documentId, int userId, Roles role, DocumentType documentType);
    Task AddMultipleApprovalToDocument(int documentId, int userId, Roles role, DocumentType documentType);
}