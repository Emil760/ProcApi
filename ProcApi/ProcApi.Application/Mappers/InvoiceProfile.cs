using ProcApi.Application.DTOs.Invoice.Requests;
using ProcApi.Application.DTOs.Invoice.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class InvoiceProfile : CommonProfile
{
    public InvoiceProfile()
    {
        CreateMap<SaveInvoiceRequest, Invoice>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DocumentId))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.SupplierId))
            .ForMember(dest => dest.Items, opt => opt.Ignore());

        CreateMap<Invoice, InvoiceResponse>()
            .ForMember(dest => dest.BaseDocumentDto, opt => opt.MapFrom(src => src.Document))
            .ForMember(dest => dest.MembersDto, opt => opt.MapFrom(src => src.Document.Actions))
            .ForMember(dest => dest.ItemsDto, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.TotalItemsPrice, opt => opt.MapFrom(src => src.TotalItemsPrice));

        CreateMap<Invoice, SaveInvoiceResponse>()
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.TotalItemsPrice, opt => opt.MapFrom(src => src.TotalItemsPrice));
    }
}