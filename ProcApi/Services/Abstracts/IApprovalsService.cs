using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Services.Abstracts
{
    public interface IApprovalsService
    {
        Task<IEnumerable<DocumentAction>> InitApprovals(int userId, DocumentType documentType);
    }
}