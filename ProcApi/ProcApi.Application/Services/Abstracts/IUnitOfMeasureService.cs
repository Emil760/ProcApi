using ProcApi.Application.DTOs;
using ProcApi.Application.DTOs.UnitOfMeasure.Requests;
using ProcApi.Application.DTOs.UnitOfMeasure.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Services.Abstracts;

public interface IUnitOfMeasureService
{
    Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllAsync();
    Task<IEnumerable<DropDownDto<int>>> GetActiveForDropDownAsync();
    Task<IEnumerable<DropDownDto<int>>> GetForDropDownAsync();
    Task<UnitOfMeasureResponseDto> CreateAsync(CreateUnitOfMeasureRequestDto dto);
    Task ActivateAsync(ActivateUnitOfMeasureRequestDto dto);
    Task CreateConversationRuleAsync(CreateUnitOfMeasureConversationRuleRequestDto dto);
    Task<IEnumerable<UnitOfMeasureConverterResponseDto>> GetRulesAsync(int id);
    void ValidateQuantity(UnitOfMeasure unitOfMeasure, decimal quantity);
}