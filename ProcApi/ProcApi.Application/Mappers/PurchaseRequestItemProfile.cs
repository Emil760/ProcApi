using ProcApi.Application.DTOs.PurchaseRequest.Base;
using ProcApi.Application.DTOs.PurchaseRequest.Requests;
using ProcApi.Application.DTOs.PurchaseRequest.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class PurchaseRequestItemProfile : CommonProfile
{
    public PurchaseRequestItemProfile()
    {
        CreateMap<PurchaseRequestItem, PRItemResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.MaterialId, opt => opt.MapFrom(src => src.MaterialId))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.BuyerId, opt => opt.MapFrom(src => src.Buyer.Id))
            .ForMember(dest => dest.BuyerName, opt => opt.MapFrom(src => src.Buyer.FirstName));

        CreateMap<CreatePRItemRequest, PurchaseRequestItem>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.MaterialId, opt => opt.MapFrom(src => src.MaterialId))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.UnitOfMeasureId, opt => opt.MapFrom(src => src.UnitOfMeasureId));

        CreateMap<PRItemDto, PurchaseRequestItem>().ReverseMap()
            .ForMember(dest => dest.MaterialId, opt => opt.MapFrom(src => src.MaterialId))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.UnitOfMeasureId, opt => opt.MapFrom(src => src.UnitOfMeasureId));
    }
}