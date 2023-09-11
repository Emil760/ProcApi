using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    public GroupRepository(ProcDbContext context) : base(context)
    {
    }
}