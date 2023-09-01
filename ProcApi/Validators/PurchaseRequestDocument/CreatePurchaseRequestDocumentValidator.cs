using FluentValidation;
using ProcApi.DTOs.PurchaseRequestDocument.Requests;

namespace ProcApi.Validators.PurchaseRequestDocument;

public class CreatePurchaseRequestDocumentValidator : AbstractValidator<CreatePurchaseRequestDocumentRequestDto>
{
    public CreatePurchaseRequestDocumentValidator()
    {
        RuleFor(x => x.DeliveryAddress)
            .NotEmpty()
            .WithMessage("Delivery address cant be empty");

        RuleFor(x => x.DepartmentId)
            .GreaterThan(0)
            .WithMessage("Department cant be empty");

        RuleFor(x => x.Items)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("Items cant be empty")
            .Must(i => i.Any())
            .WithMessage("Items cant be empty");

        RuleForEach(x => x.Items)
            .ChildRules(item =>
                item.RuleFor(i => i.UnitOfMeasureId)
                    .GreaterThan(0));
    }
}