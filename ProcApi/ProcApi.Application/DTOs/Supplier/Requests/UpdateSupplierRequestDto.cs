using ProcApi.Application.DTOs.Supplier.Base;

namespace ProcApi.Application.DTOs.Supplier.Requests;

public class UpdateSupplierRequestDto : SupplierDto
{
    public int Id { get; set; }
}