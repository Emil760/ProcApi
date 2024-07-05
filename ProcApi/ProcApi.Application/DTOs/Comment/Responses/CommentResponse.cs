using ProcApi.Application.DTOs.Comment.Base;

namespace ProcApi.Application.DTOs.Comment.Responses
{
    public class CommentResponse : CommentDto
    {
        public string UserName { get; set; }
        public DateTime DateTime { get; set; }
        public int ParentCommentId { get; set; }
    }
}
