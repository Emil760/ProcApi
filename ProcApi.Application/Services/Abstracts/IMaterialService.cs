using ProcApi.Domain.Models;
using ProcApi.DTOs.Material.Request;
using ProcApi.DTOs.Material.Responses;

namespace ProcApi.Application.Services.Abstracts;

public interface IMaterialService
{
    Task<IEnumerable<MaterialResponseDto>> GetAllAsync(PaginationModel pagination);
    Task<TreeMaterialResponseDto> GetAsync(int id);
    Task<MaterialResponseDto> CreateMaterial(CreateMaterialRequestDto dto);
    Task<MaterialResponseDto> EditMaterial(int id, EditMaterialRequestDto dto);
    Task DeleteMaterial(int id);
}