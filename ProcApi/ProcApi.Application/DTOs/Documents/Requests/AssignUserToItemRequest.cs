namespace ProcApi.Application.DTOs.Documents.Requests;

public class AssignUserToItemRequest
{
    public int DocumentId { get; set; }
    public int UserId { get; set; }
    public int ItemId { get; set; }
}