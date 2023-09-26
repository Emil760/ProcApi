using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.PurchaseRequestDocument;

public class CreatePurchaseRequestDocumentValidator : SavePurchaseRequestDocumentValidator<CreatePRRequestDto>
{
    public CreatePurchaseRequestDocumentValidator(IStringLocalizer<SharedResource> localizer) : base(localizer)
    {
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