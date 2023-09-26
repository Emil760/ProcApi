using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.PurchaseRequestDocument.Base;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.PurchaseRequestDocument;

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