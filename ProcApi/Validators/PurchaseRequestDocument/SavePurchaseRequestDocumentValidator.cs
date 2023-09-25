using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.DTOs.PurchaseRequestDocument.Base;
using ProcApi.Resources;

namespace ProcApi.Validators.PurchaseRequestDocument;

public class SavePurchaseRequestDocumentValidator<T> : AbstractValidator<T> where T : PRDto
{
    public SavePurchaseRequestDocumentValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(x => x.DeliveryAddress)
            .NotEmpty()
            .WithMessage(localizer["DeliveryAddressCantBeEmpty"]);

        RuleFor(x => x.DepartmentId)
            .GreaterThan(0)
            .WithMessage(localizer["DepartmentCantBeEmpty"]);
    }
}