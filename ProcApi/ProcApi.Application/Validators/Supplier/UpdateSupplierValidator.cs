using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Supplier.Requests;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.Supplier;

public class UpdateSupplierValidator : SaveSupportValidator<UpdateSupplierRequest>
{
    public UpdateSupplierValidator(IStringLocalizer<SharedResource> localizer) : base(localizer)
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage(localizer["SupplierNotFound"]);
    }
}