using ProcApi.Application.DTOs.Comment.Requests;
using ProcApi.Application.DTOs.Comment.Responses;

namespace ProcApi.Application.Services.Abstracts
{
    public interface ICommentService
    {
        Task<CommentResponse> AddDocumentCommentAsync(AddCommentRequest dto);
        Task DeleteDocumentCommentAsync(int id);
        Task<IEnumerable<CommentResponse>> GetDocumentCommentsAsync(int documentId);
        Task<CommentResponse> UpdateDocumentCommentAsync(int id);
    }
}
