using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Data.ProcDatabase.ResultSets;
using ProcApi.DTOs.Category.Base;
using ProcApi.DTOs.Category.Requests;
using ProcApi.DTOs.Category.Responses;

namespace ProcApi.Mappers;

public class CategoryProfile : CommonProfile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<Category, CategoryResponseDto>();
        CreateMap<CategoryResultSet, CategoryDto>();
    }
}