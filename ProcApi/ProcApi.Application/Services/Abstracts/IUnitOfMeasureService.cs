using ProcApi.Application.DTOs;
using ProcApi.Application.DTOs.UnitOfMeasure.Requests;
using ProcApi.Application.DTOs.UnitOfMeasure.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Services.Abstracts;

public interface IUnitOfMeasureService
{
    Task<IEnumerable<UnitOfMeasureResponse>> GetAllAsync();
    Task<IEnumerable<DropDownDto<int>>> GetActiveForDropDownAsync();
    Task<IEnumerable<DropDownDto<int>>> GetForDropDownAsync();
    Task<UnitOfMeasureResponse> CreateAsync(CreateUnitOfMeasureRequest dto);
    Task ActivateAsync(ActivateUnitOfMeasureRequest dto);
    Task CreateConversationRuleAsync(CreateUnitOfMeasureConversationRuleRequest dto);
    Task<IEnumerable<UnitOfMeasureConverterResponse>> GetRulesAsync(int id);
    void ValidateQuantity(UnitOfMeasure unitOfMeasure, decimal quantity);
}