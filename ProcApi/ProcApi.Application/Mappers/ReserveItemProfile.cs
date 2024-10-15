using ProcApi.Application.DTOs.ReservedItem.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class ReserveItemProfile : CommonProfile
{
    public ReserveItemProfile()
    {
        CreateMap<ReservedItem, ReserveItemResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.GoodReceiptNoteItemId, opt => opt.MapFrom(src => src.GoodReceiptNoteItemId))
            .ForMember(dest => dest.GoodReceiptNoteNumber,
                opt => opt.MapFrom(src => src.GoodReceiptNoteItem.GoodReceiptNote.Document.Number))
            .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(src => src.GoodReceiptNoteItem.Material.Name))
            .ForMember(dest => dest.UnitOfMeasureName,
                opt => opt.MapFrom(src => src.GoodReceiptNoteItem.UnitOfMeasure.Name))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));

        CreateMap<GoodReceiptNoteItem, ItemForReservationResponse>()
            .ForMember(dest => dest.GoodReceiptNoteItemId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.GoodReceiptNoteNumber,
                opt => opt.MapFrom(src => src.GoodReceiptNote.Document.Number))
            .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(src => src.Material.Name))
            .ForMember(dest => dest.UnitOfMeasureName, opt => opt.MapFrom(src => src.UnitOfMeasure.Name))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.UsedQuantity, opt => opt.MapFrom(src => src.UsedQuantity));
    }
}