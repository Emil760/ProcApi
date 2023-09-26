using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Material.Base;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.Material;

public class SaveMaterialValidator<T> : AbstractValidator<T> where T : SaveMaterialDto
{
    private const int CodeLength = 6;

    public SaveMaterialValidator(IStringLocalizer<SharedResource> _localizer)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(_localizer["NameCantBeEmpty"]);

        RuleFor(x => x.Code)
            .Length(CodeLength)
            .WithMessage(_localizer["CodeMustBeInLenght"].Value.Replace("{length}", CodeLength.ToString()));
    }
}