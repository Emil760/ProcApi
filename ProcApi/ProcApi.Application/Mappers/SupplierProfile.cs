using ProcApi.Application.DTOs.Supplier.Requests;
using ProcApi.Application.DTOs.Supplier.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class SupplierProfile : CommonProfile
{
    public SupplierProfile()
    {
        CreateMap<Supplier, SupplierResponse>();
        CreateMap<CreateSupplierRequest, Supplier>();
        CreateMap<UpdateSupplierRequest, Supplier>();
    }
}