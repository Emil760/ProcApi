﻿using ProcApi.Application.DTOs.Category.Base;
using ProcApi.Application.DTOs.Category.Requests;
using ProcApi.Application.DTOs.Category.Responses;
using ProcApi.Domain.Entities;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Application.Mappers;

public class CategoryProfile : CommonProfile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<Category, CategoryResponse>();
        CreateMap<CategoryResultSet, CategoryDto>();
    }
}