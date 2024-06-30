using ProcApi.Application.DTOs.Comment.Requestes;
using ProcApi.Application.DTOs.Comment.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Application.Services.Concreates
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Task<CommentResponseDto> AddDocumentCommentAsync(AddCommentRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDocumentCommentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommentResponseDto>> GetDocumentCommentsAsync(int documentId)
        {
            throw new NotImplementedException();
        }

        public Task<CommentResponseDto> UpdateDocumentCommentAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
