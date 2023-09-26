using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.Application.Enums;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.PurchaseRequestDocument;

public class UpdatePurchaseRequestDocumentValidator : SavePurchaseRequestDocumentValidator<UpdatePRRequestDto>
{
    public UpdatePurchaseRequestDocumentValidator(IStringLocalizer<SharedResource> localizer) : base(localizer)
    {
        RuleFor(x => x.Items)
            .Cascade(CascadeMode.Stop)
            .Must(x => !(x.Count() == x.Count(i => i.State == ActionState.Deleted)
                        && !x.Any(i => i.State == ActionState.Added)))
            .WithMessage(localizer["ShouldHaveItem"]);

        RuleForEach(x => x.Items)
            .ChildRules(item =>
                item.RuleFor(i => i.UnitOfMeasureId)
                    .GreaterThan(0))
            .WithMessage(localizer["UnitOfMeasureCantBeEmpty"]);
    }
}