using ProcApi.Application.DTOs.AnnualProcurement.Base;

namespace ProcApi.Application.DTOs.AnnualProcurement.Responses;

public class AnnualProcurementResponseDto : AnnualProcurementDto
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? LastUpdateDate { get; set; }
    public bool IsActive { get; set; }
}