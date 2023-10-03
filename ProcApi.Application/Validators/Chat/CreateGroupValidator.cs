using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Chat.Request;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.Chat;

public class CreateGroupValidator : AbstractValidator<CreateGroupRequestDto>
{
    public CreateGroupValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(localizer["GroupNameCantBeEmpty"]);
    }
}