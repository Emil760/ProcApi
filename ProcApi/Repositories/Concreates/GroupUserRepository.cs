using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates;

public class GroupUserRepository : GenericRepository<GroupUser>, IGroupUserRepository
{
    public GroupUserRepository(ProcDbContext context) : base(context)
    {
    }
}