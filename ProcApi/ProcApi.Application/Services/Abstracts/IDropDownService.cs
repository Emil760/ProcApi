using ProcApi.Application.DTOs.DropDown.Requests;
using ProcApi.Application.DTOs.DropDown.Responses;

namespace ProcApi.Application.Services.Abstracts;

public interface IDropDownService
{
    Task<DropDownSourceResponse> CreateSourceAsync(CreateDropDownSourceRequest dto);
    Task<DropDownItemResponse> CreateItemAsync(CreateDropDownItemRequest dto);
    Task ChangeSourceAsync(ChangeDropDownSourceRequest dto);
    Task ChangeItemAsync(ChangeDropDownItemRequest dto);
    Task<IEnumerable<DropDownSourceResponse>> GetAllSources();
    Task<IEnumerable<DropDownItemResponse>> GetAllItems(int sourceId);
}