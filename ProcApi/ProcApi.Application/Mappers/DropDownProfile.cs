using ProcApi.Application.DTOs.DropDown.Requests;
using ProcApi.Application.DTOs.DropDown.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class DropDownProfile : CommonProfile
{
    public DropDownProfile()
    {
        CreateMap<CreateDropDownSourceRequest, DropDownSource>();
        CreateMap<DropDownSource, DropDownSourceResponse>();
        CreateMap<ChangeDropDownSourceRequest, DropDownSource>();
        CreateMap<ChangeDropDownItemRequest, DropDownItem>();
    }
}