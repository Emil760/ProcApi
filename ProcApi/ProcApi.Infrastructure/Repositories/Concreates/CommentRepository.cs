using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates
{
    public class CommentRepository : GenericRepository<Comment, int>, ICommentRepository
    {
        public CommentRepository(ProcDbContext context) : base(context)
        {
        }
    }
}
