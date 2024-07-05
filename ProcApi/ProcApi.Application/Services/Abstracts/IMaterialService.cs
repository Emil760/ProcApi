using ProcApi.Application.DTOs;
using ProcApi.Application.DTOs.Material.Request;
using ProcApi.Application.DTOs.Material.Responses;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface IMaterialService
{
    Task<IEnumerable<MaterialResponse>> GetAllAsync(PaginationModel pagination);
    Task<TreeMaterialResponse> GetAsync(int id);
    Task<MaterialResponse> CreateMaterial(CreateMaterialRequest dto);
    Task<MaterialResponse> EditMaterial(int id, EditMaterialRequest dto);
    Task DeleteMaterial(int id);
    Task<IEnumerable<DropDownDto<int>>> GetAllForDropDownAsync();
}