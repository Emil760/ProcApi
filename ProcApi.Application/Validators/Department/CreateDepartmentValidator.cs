using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Department.Requests;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.Department;

public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentDto>
{
    public CreateDepartmentValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(d => d.Name)
            .MinimumLength(5)
            .WithMessage(localizer["DepartmentNameLenght"]);

        RuleFor(d => d.HeadUserId)
            .GreaterThan(0)
            .WithMessage(localizer["HeadUserCantBeEmpty"]);
    }
}