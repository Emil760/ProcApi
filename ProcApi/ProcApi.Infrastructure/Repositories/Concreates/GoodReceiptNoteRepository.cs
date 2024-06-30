using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class GoodReceiptNoteRepository : GenericRepository<GoodReceiptNote>, IGoodReceiptNoteRepository
{
    public GoodReceiptNoteRepository(ProcDbContext context) : base(context)
    {
    }
}