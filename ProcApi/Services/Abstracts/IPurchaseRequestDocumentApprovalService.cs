using ProcApi.DTOs.Documents.Requests;
using ProcApi.DTOs.User.Base;

namespace ProcApi.Services.Abstracts;

public interface IPurchaseRequestDocumentApprovalService
{
    Task PerformAction(ActionPerformRequestDto dto, UserInfo userInfo);
}