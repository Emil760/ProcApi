using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Documents.Requests;

namespace ProcApi.Services.Abstracts
{
    public interface IApprovalsService
    {
        Task<IEnumerable<DocumentAction>> InitApprovals(int userId, DocumentType documentType);
        Task CanPerformAction(ActionPerformRequestDto dto, int userId);
    }
}