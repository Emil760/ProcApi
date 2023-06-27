using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private ProcDbContext context;

        public UserRepository(ProcDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
