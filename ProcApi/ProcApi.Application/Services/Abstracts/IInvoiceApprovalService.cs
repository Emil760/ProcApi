using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface IInvoiceApprovalService
{
    Task PerformAction(ActionPerformRequest dto, UserInfoModel userInfo);
}