namespace ProcApi.Application.DTOs.AnnualProcurement.Requests;

public class CreateAnnualProcurementRequestDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public short Year { get; set; }
}