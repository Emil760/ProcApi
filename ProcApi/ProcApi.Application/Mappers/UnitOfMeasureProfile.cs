using ProcApi.Application.DTOs;
using ProcApi.Application.DTOs.UnitOfMeasure.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class UnitOfMeasureProfile : CommonProfile
{
    public UnitOfMeasureProfile()
    {
        CreateMap<UnitOfMeasure, UnitOfMeasureResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.CanBeDecimal, opt => opt.MapFrom(src => src.CanBeDecimal))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));

        CreateMap<UnitOfMeasure, DropDownDto<int>>()
            .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Name));

        CreateMap<UnitOfMeasureConverter, UnitOfMeasureConverterResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TargetUnitOfMeasure.Name))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.CanBeDecimal, opt => opt.MapFrom(src => src.TargetUnitOfMeasure.CanBeDecimal))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
    }
}