using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Handlers;

public interface IApprovalCoordinator
{
    Task PerformAction(ActionPerformRequest dto, UserInfoModel userInfo);
}