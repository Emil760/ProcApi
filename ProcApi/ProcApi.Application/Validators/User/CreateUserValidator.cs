using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.User.Requests;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.User;

public class CreateUserValidator : AbstractValidator<AddUserRequest>
{
    public CreateUserValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(u => u.FirstName)
            .NotEmpty()
            .WithMessage(localizer["FirstNameCantBeEmpty"]);

        RuleFor(u => u.Age)
            .GreaterThan(17)
            .WithMessage("Age should be greater than 18");
    }
}