﻿using ProcApi.Application.DTOs;
using ProcApi.Application.DTOs.Material.Request;
using ProcApi.Application.DTOs.Material.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class MaterialProfile : CommonProfile
{
    public MaterialProfile()
    {
        CreateMap<Material, MaterialResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        
        CreateMap<CreateMaterialRequest, Material>();
        CreateMap<EditMaterialRequest, Material>();
        
        CreateMap<Material, DropDownDto<int>>()
            .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Name));
    }
}