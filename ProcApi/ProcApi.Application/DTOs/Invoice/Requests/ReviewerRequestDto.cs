namespace ProcApi.Application.DTOs.Invoice.Requests;

public class ReviewerRequestDto
{
    public int DocumentId { get; set; }
    public int ReviewerId { get; set; }
}