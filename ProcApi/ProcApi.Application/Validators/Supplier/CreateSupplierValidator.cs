using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Supplier.Requests;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Validators.Supplier;

public class CreateSupplierValidator : SaveSupportValidator<CreateSupplierRequestDto>
{
    public CreateSupplierValidator(IStringLocalizer<SharedResource> localizer) : base(localizer)
    {
        
    }
}