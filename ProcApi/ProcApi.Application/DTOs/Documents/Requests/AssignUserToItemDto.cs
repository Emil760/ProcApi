namespace ProcApi.Application.DTOs.Documents.Requests;

public class AssignUserToItemDto
{
    public int DocumentId { get; set; }
    public int UserId { get; set; }
    public int ItemId { get; set; }
}