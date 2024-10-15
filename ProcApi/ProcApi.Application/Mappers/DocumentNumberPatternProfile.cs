using ProcApi.Application.DTOs.DocumentPattern.Requests;
using ProcApi.Application.DTOs.DocumentPattern.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class DocumentNumberPatternProfile : CommonProfile
{
    public DocumentNumberPatternProfile()
    {
        CreateMap<CreateDocumentNumberPatternRequest, DocumentNumberPattern>();
        CreateMap<DocumentNumberPattern, DocumentNumberPatternReponse>();

        CreateMap<CreateDocumentNumberSectionRequest, DocumentNumberSection>();
        CreateMap<DocumentNumberSection, DocumentNumberSectionReponse>();
    }
}