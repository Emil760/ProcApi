using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.DTOs.Chat.Request;
using ProcApi.Resources;

namespace ProcApi.Validators.Chat;

public class CreateGroupValidator : AbstractValidator<CreateGroupRequestDto>
{
    public CreateGroupValidator(IStringLocalizer<SharedResource> _localizer)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(_localizer["GroupNameCantBeEmpty"]);
    }
}