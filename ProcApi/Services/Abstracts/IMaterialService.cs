using ProcApi.DTOs.Base;
using ProcApi.DTOs.Material.Request;
using ProcApi.DTOs.Material.Responses;

namespace ProcApi.Services.Abstracts;

public interface IMaterialService
{
    Task<IEnumerable<MaterialResponseDto>> GetAllAsync(PaginationRequestDto dto);
    Task<TreeMaterialResponseDto> GetAsync(int id);
    Task<MaterialResponseDto> CreateMaterial(CreateMaterialRequestDto dto);
    Task<MaterialResponseDto> EditMaterial(int id, EditMaterialRequestDto dto);
}