using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IApprovalFlowTemplateRepository : IGenericRepository<ApprovalFlowTemplate>
{
    Task<IEnumerable<ApprovalFlowTemplate>> GetInitialByDocumentType(DocumentType type);
    Task<IEnumerable<ApprovalFlowTemplate>> GetInitialWithUserByDocumentType(DocumentType type);
}