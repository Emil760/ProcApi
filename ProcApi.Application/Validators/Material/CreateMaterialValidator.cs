using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Material.Request;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.Material;

public class CreateMaterialValidator : SaveMaterialValidator<CreateMaterialRequestDto>
{
    public CreateMaterialValidator(IStringLocalizer<SharedResource> _localizer) : base(_localizer)
    {
    }
}