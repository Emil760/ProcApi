using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Application.Services.Abstracts;

public interface IApprovalsService
{
    Task<IEnumerable<DocumentAction>> InitApprovals(int userId, DocumentType documentType);
    Task CanPerformAction(ActionPerformRequestDto dto, int userId);
    Task ApproveDocumentAsync(ActionPerformRequestDto dto, int userId);
    Task ReturnDocumentAsync(ActionPerformRequestDto dto);
    Task RejectDocumentAsync(ActionPerformRequestDto dto);
}