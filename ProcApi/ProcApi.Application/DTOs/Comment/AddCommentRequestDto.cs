namespace ProcApi.Application.DTOs.Comment;

public class AddCommentRequestDto
{
    public int DocumentId { get; set; }
    public int ParentCommentId { get; set; }
}