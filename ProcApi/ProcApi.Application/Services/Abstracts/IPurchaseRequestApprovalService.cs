using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface IPurchaseRequestApprovalService
{
    Task PerformAction(ActionPerformRequestDto dto, UserInfoModel userInfo);
}