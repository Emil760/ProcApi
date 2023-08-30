using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.User;

namespace ProcApi.Services.Abstracts
{
    public interface IApprovalFlowService
    {
        Task<IEnumerable<DocumentAction>> CreateApprovals(UserInfoDro userInfoDro, Document document, DocumentType documentType);
    }
}