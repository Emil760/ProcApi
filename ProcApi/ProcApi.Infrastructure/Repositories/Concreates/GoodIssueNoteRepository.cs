using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class GoodIssueNoteRepository : GenericRepository<GoodIssueNote>, IGoodIssueNoteRepository
{
    public GoodIssueNoteRepository(ProcDbContext context) : base(context)
    {
    }
}