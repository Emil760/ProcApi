using ProcApi.Application.DTOs.Comment.Base;

namespace ProcApi.Application.DTOs.Comment.Requests;

public class AddCommentRequest : CommentDto
{
    public int DocumentId { get; set; }
    public int ParentCommentId { get; set; }
}