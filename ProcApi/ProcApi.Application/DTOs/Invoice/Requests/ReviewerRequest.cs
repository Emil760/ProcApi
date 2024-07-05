namespace ProcApi.Application.DTOs.Invoice.Requests;

public class ReviewerRequest
{
    public int DocumentId { get; set; }
    public int ReviewerId { get; set; }
}