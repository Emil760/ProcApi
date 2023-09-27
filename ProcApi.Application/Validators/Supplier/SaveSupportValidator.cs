using FluentValidation;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Supplier.Base;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.Supplier;

public class SaveSupportValidator<T> : AbstractValidator<T> where T : SupplierDto
{
    public SaveSupportValidator(IStringLocalizer<SharedResource> localizer)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(localizer["NameCantBeEmpty"]);

        RuleFor(x => x.TaxId)
            .NotEmpty()
            .WithMessage(localizer["NameCantBeEmpty"])
            .Length(10)
            .WithMessage(localizer["TaxLenghtValidation"]);

        RuleFor(x => x.Mail)
            .NotEmpty()
            .WithMessage(localizer["MailCantBeEmpty"])
            .EmailAddress()
            .WithMessage(localizer["MailFormatValidation"]);
    }
}