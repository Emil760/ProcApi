using ProcApi.Application.DTOs.Material.Request;
using ProcApi.Application.DTOs.Material.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class MaterialProfile : CommonProfile
{
    public MaterialProfile()
    {
        CreateMap<Material, MaterialResponseDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.UnitOfMeasureName, opt => opt.MapFrom(src => src.UnitOfMeasure.Name));
        
        CreateMap<CreateMaterialRequestDto, Material>();
        CreateMap<EditMaterialRequestDto, Material>();
    }
}