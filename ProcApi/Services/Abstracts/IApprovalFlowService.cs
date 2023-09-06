using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.User;
using ProcApi.DTOs.User.Base;

namespace ProcApi.Services.Abstracts
{
    public interface IApprovalFlowService
    {
        Task<IEnumerable<DocumentAction>> CreateApprovals(UserInfo? userInfo, Document document, DocumentType documentType);
    }
}