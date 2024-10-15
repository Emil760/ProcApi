using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Material.Base;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.Material;

public class SaveMaterialValidator<T> : AbstractValidator<T> where T : SaveMaterialDto
{
    private const int CODE_LENGTH = 6;

    public SaveMaterialValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(localizer["NameCantBeEmpty"]);

        RuleFor(x => x.Code)
            .Length(CODE_LENGTH)
            .WithMessage(localizer["CodeMustBeInLength"].Value.Replace("{length}", CODE_LENGTH.ToString()));
    }
}