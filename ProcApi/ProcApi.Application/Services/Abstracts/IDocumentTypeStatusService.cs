using ProcApi.Application.DTOs.DocumentTypeStatus.Requests;
using ProcApi.Application.DTOs.DocumentTypeStatus.Responses;
using ProcApi.Domain.Enums;

namespace ProcApi.Application.Services.Abstracts;

public interface IDocumentTypeStatusService
{
    Task<IEnumerable<DocumentTypeStatusResponse>> GetAllAsync();
    Task<IEnumerable<DocumentTypeStatusResponse>> GetAllByDocumentTypeAsync(DocumentType documentType);
    Task<int> AddAsync(AddDocumentTypeStatusRequest dto);
}