namespace ProcApi.Application.DTOs.AnnualProcurement.Requests;

public class CreateAnnualProcurementItemsRequestDto
{
    public int AnnualProcurementId { get; set; }
    public IEnumerable<CreateAnnualProcurementItemRequestDto> Items { get; set; }
}