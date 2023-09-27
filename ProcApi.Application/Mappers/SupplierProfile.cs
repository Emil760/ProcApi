using ProcApi.Application.DTOs.Supplier.Requests;
using ProcApi.Application.DTOs.Supplier.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class SupplierProfile : CommonProfile
{
    public SupplierProfile()
    {
        CreateMap<Supplier, SupplierResponseDto>();
        CreateMap<CreateSupplierRequestDto, Supplier>();
        CreateMap<UpdateSupplierRequestDto, Supplier>();
    }
}