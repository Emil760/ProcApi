namespace ProcApi.Application.DTOs.AnnualProcurement.Responses;

public class AnnualProcurementResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public short Year { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
}