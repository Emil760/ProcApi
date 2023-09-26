using Microsoft.Extensions.Localization;
using ProcApi.DTOs.Material.Request;
using ProcApi.Resources;

namespace ProcApi.Application.Validators.Material;

public class CreateMaterialValidator : SaveMaterialValidator<CreateMaterialRequestDto>
{
    public CreateMaterialValidator(IStringLocalizer<SharedResource> _localizer) : base(_localizer)
    {
    }
}