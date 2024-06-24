using ProcApi.Application.DTOs.Comment.Requestes;
using ProcApi.Application.DTOs.Comment.Responses;

namespace ProcApi.Application.Services.Abstracts
{
    public interface ICommentService
    {
        Task<CommentResponseDto> AddDocumentCommentAsync(AddCommentRequestDto dto);
        Task DeleteDocumentCommentAsync(int id);
        Task<IEnumerable<CommentResponseDto>> GetDocumentCommentsAsync(int documentId);
        Task<CommentResponseDto> UpdateDocumentCommentAsync(int id);
    }
}
