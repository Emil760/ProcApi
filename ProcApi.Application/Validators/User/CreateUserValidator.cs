using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.User.Requests;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.User;

public class CreateUserValidator : AbstractValidator<AddUserDto>
{
    public CreateUserValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(u => u.FirstName)
            .NotEmpty()
            .WithMessage(localizer["FirstNameCantBeEmpty"])
            .WithErrorCode("001")
            .WithSeverity(Severity.Error);
        RuleFor(u => u.LastName)
            .NotEmpty()
            .WithMessage("last name cant be empty")
            .WithErrorCode("002")
            .WithSeverity(Severity.Error);
        RuleFor(u => u.Age)
            .GreaterThan(17)
            .WithMessage("Age should be greater than 18")
            .WithErrorCode("003")
            .WithSeverity(Severity.Error);

        //this.RaiseValidationException();
    }
}