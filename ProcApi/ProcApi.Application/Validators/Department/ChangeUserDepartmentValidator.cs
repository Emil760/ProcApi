using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Department.Requests;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.Department;

public class ChangeUserDepartmentValidator : AbstractValidator<AssignUserDepartmentDto>
{
    public ChangeUserDepartmentValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(x => x.DepartmentId)
            .GreaterThan(0)
            .WithMessage(localizer["DepartmentCantBeEmpty"]);

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage(localizer["UserCantBeEmpty"]);
    }
}