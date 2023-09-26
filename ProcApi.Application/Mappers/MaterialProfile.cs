using ProcApi.Domain.Entities;
using ProcApi.DTOs.Material.Request;
using ProcApi.DTOs.Material.Responses;

namespace ProcApi.Application.Mappers;

public class MaterialProfile : CommonProfile
{
    public MaterialProfile()
    {
        CreateMap<Material, MaterialResponseDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<CreateMaterialRequestDto, Material>();
        CreateMap<EditMaterialRequestDto, Material>();
    }
}