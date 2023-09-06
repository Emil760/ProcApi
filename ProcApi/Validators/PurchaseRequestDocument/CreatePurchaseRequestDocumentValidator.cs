using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.Resources;

namespace ProcApi.Validators.PurchaseRequestDocument;

public class CreatePurchaseRequestDocumentValidator : AbstractValidator<CreatePurchaseRequestDocumentRequestDto>
{
    public CreatePurchaseRequestDocumentValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(x => x.DeliveryAddress)
            .NotEmpty()
            .WithMessage(localizer["DeliveryAddressCantBeEmpty"]);

        RuleFor(x => x.DepartmentId)
            .GreaterThan(0)
            .WithMessage(localizer["DepartmentCantBeEmpty"]);

        RuleFor(x => x.Items)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage(localizer["ShouldHaveItem"])
            .Must(i => i.Any())
            .WithMessage(localizer["ShouldHaveItem"]);

        RuleForEach(x => x.Items)
            .ChildRules(item =>
                item.RuleFor(i => i.UnitOfMeasureId)
                    .GreaterThan(0))
            .WithMessage(localizer["UnitOfMeasureCantBeEmpty"]);
    }
}