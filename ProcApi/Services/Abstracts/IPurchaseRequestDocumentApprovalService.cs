using ProcApi.DTOs.Documents.Requests;

namespace ProcApi.Services.Abstracts;

public interface IPurchaseRequestDocumentApprovalService
{
    Task PerformAction(ActionPerformRequestDto requestDto);
}