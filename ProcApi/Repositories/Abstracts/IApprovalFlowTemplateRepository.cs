using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts;

public interface IApprovalFlowTemplateRepository : IGenericRepository<ApprovalFlowTemplate>
{
    Task<IEnumerable<ApprovalFlowTemplate>> GetInitialByDocumentType(DocumentType type);
    Task<IEnumerable<ApprovalFlowTemplate>> GetInitialWithUserByDocumentType(DocumentType type);
}