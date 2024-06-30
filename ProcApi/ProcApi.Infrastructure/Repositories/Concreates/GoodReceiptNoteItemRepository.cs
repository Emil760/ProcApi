using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class GoodReceiptNoteItemRepository : GenericRepository<GoodReceiptNoteItem>, IGoodReceiptNoteItemRepository
{
    public GoodReceiptNoteItemRepository(ProcDbContext context) : base(context)
    {
    }
}