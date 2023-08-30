using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Documents.PurchaseRequestDocument;

namespace ProcApi.Mappers;

public class PurchaseRequestProfile : CommonProfile
{
    public PurchaseRequestProfile()
    {
        CreateMap<CreatePurchaseRequestDocumentDto, PurchaseRequestDocument>();

        CreateMap<PurchaseRequestDocument, PurchaseRequestDocumentDto>()
            .ForMember(dest => dest.DocumentDto,
                opt => opt.MapFrom(src => src.Document))
            .ForMember(dest => dest.MemberDtos,
                opt => opt.MapFrom(src => src.Document.DocumentActions));
    }
}