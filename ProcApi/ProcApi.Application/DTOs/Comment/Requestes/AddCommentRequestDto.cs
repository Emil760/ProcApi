using ProcApi.Application.DTOs.Comment.Base;

namespace ProcApi.Application.DTOs.Comment.Requestes;

public class AddCommentRequestDto : CommentDto
{
    public int DocumentId { get; set; }
    public int ParentCommentId { get; set; }
}