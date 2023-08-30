using FluentValidation;
using ProcApi.DTOs.Documents.PurchaseRequestDocument;

namespace ProcApi.Validators.PurchaseRequestDocument;

public class CreatePurchaseRequestDocumentValidator : AbstractValidator<CreatePurchaseRequestDocumentDto>
{
    public CreatePurchaseRequestDocumentValidator()
    {
        RuleFor(x => x.DeliveryAddress)
            .NotEmpty()
            .WithMessage("Delivery address cant be empty");

        RuleFor(x => x.DepartmentId)
            .GreaterThan(0)
            .WithMessage("Department cant be empty");
    }
}