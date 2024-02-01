using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IApprovalFlowTemplateRepository : IGenericRepository<ApprovalFlowTemplate>
{
    Task<IEnumerable<ApprovalFlowTemplate>> GetInitialWithUserByDocumentType(DocumentType type);

    Task<ApprovalFlowTemplate?> GetByRoleAndDocumentTypeAndMultiple(
        Roles role, DocumentType documentType, bool isMultiple);
}