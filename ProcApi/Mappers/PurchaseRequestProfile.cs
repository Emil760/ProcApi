using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.PurchaseRequestDocument;
using ProcApi.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.DTOs.PurchaseRequestDocument.Response;

namespace ProcApi.Mappers;

public class PurchaseRequestProfile : CommonProfile
{
    public PurchaseRequestProfile()
    {
        CreateMap<CreatePurchaseRequestDocumentItemRequestDto, PurchaseRequestDocumentItem>();
        
        CreateMap<CreatePurchaseRequestDocumentRequestDto, PurchaseRequestDocument>();

        CreateMap<PurchaseRequestDocument, PurchaseRequestDocumentResponseDto>()
            .ForMember(dest => dest.BaseDocumentDto,
                opt => opt.MapFrom(src => src.Document))
            .ForMember(dest => dest.MemberDtos,
                opt => opt.MapFrom(src => src.Document.DocumentActions));
    }
}