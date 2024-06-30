using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class GoodIssueNoteItemRepository : GenericRepository<GoodIssueNoteItem>, IGoodIssueNoteItemRepository
{
    public GoodIssueNoteItemRepository(ProcDbContext context) : base(context)
    {
    }
}