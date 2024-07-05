using ProcApi.Application.DTOs.Supplier.Base;

namespace ProcApi.Application.DTOs.Supplier.Requests;

public class UpdateSupplierRequest : SupplierDto
{
    public int Id { get; set; }
}