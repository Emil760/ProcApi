using ProcApi.Application.DTOs.PurchaseRequest.Requests;
using ProcApi.Application.DTOs.PurchaseRequest.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class PurchaseRequestProfile : CommonProfile
{
    public PurchaseRequestProfile()
    {
        CreateMap<SavePRRequest, PurchaseRequest>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DocumentId))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DeliveryAddress, opt => opt.MapFrom(src => src.DeliveryAddress))
            .ForMember(dest => dest.RequestedForDepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
            .ForMember(dest => dest.Items, opt => opt.Ignore());

        CreateMap<PurchaseRequest, PRResponse>()
            .ForMember(dest => dest.BaseDocumentDto, opt => opt.MapFrom(src => src.Document))
            .ForMember(dest => dest.MembersDto, opt => opt.MapFrom(src => src.Document.Actions))
            .ForMember(dest => dest.ItemsDto, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.RequestedForDepartmentId))
            .ForMember(dest => dest.TotalItemsPrice, opt => opt.MapFrom(src => src.TotalItemsPrice));

        CreateMap<PurchaseRequest, SavePRResponse>()
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DeliveryAddress, opt => opt.MapFrom(src => src.DeliveryAddress))
            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.RequestedForDepartmentId))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.TotalItemsPrice, opt => opt.MapFrom(src => src.TotalItemsPrice));
    }
}