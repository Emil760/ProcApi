using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.PurchaseRequest.Requests;
using ProcApi.Application.Enums;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.PurchaseRequest;

public class SavePurchaseRequestValidator : AbstractValidator<SavePRRequestDto>
{
    public SavePurchaseRequestValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(x => x.DeliveryAddress)
            .NotEmpty()
            .WithMessage(localizer["DeliveryAddressCantBeEmpty"]);

        RuleFor(x => x.DepartmentId)
            .GreaterThan(0)
            .WithMessage(localizer["DepartmentCantBeEmpty"]);

        RuleForEach(x => x.Items)
            .ChildRules(item =>
                item.RuleFor(i => i.UnitOfMeasureId)
                    .GreaterThan(0))
            .WithMessage(localizer["UnitOfMeasureCantBeEmpty"]);

        RuleForEach(x => x.Items)
            .ChildRules(item =>
                item.RuleFor(i => i.Quantity)
                    .GreaterThan(0))
            .WithMessage(localizer["QuantityCantBeEmpty"]);
        
        RuleForEach(x => x.Items)
            .ChildRules(item =>
                item.RuleFor(i => i.MaterialId)
                    .GreaterThan(0))
            .WithMessage(localizer["MaterialCantBeEmpty"]);

        RuleFor(x => x.Items)
            .Cascade(CascadeMode.Stop)
            .Must(x => !(x.Count() == x.Count(i => i.State == ActionState.Deleted)
                         && !x.Any(i => i.State == ActionState.Added)))
            .WithMessage(localizer["ShouldHaveItem"]);
    }
}