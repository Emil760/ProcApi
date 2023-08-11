using ProcApi.DTOs.Documents;

namespace ProcApi.Services.Abstracts;

public interface IPurchaseRequestDocumentApprovalService
{
    Task PerformAction(ActionPerformDto dto);
}