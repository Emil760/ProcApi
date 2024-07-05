using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Delegation.Requests;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.Delegation;

public class CreateDelegationValidator : AbstractValidator<CreateDelegationRequest>
{
    public CreateDelegationValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(x => x.FromUserId)
            .GreaterThan(0)
            .WithMessage(localizer["UserCantBeEmpty"]);

        RuleFor(x => x.ToUserId)
            .GreaterThan(0)
            .WithMessage(localizer["UserCantBeEmpty"]);

        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(DateTime.Now.Date)
            .WithMessage(localizer["StartDateGreaterThanCurrentDate"]);

        RuleFor(x => x.EndDate)
            .GreaterThanOrEqualTo(DateTime.Now.Date)
            .WithMessage(localizer["EndDateGreaterThanCurrentDate"]);
    }
}