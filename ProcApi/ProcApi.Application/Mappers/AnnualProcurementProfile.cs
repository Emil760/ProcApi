using ProcApi.Application.DTOs.AnnualProcurement.Requests;
using ProcApi.Application.DTOs.AnnualProcurement.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class AnnualProcurementProfile : CommonProfile
{
    public AnnualProcurementProfile()
    {
        CreateMap<AnnualProcurement, AnnualProcurementResponseDto>();
        CreateMap<CreateAnnualProcurementRequestDto, AnnualProcurement>();
    }
}