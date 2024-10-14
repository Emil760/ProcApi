using ProcApi.Application.DTOs.DocumentTypeStatus.Requests;
using ProcApi.Application.DTOs.DocumentTypeStatus.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class DocumentTypeStatusProfile : CommonProfile
{
    public DocumentTypeStatusProfile()
    {
        CreateMap<AddDocumentTypeStatusRequest, DocumentTypeStatus>();

        CreateMap<DocumentTypeStatus, DocumentTypeStatusResponse>();
    }
}