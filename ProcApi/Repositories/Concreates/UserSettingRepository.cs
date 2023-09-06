using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates;

public class UserSettingRepository : GenericRepository<UserSetting>, IUserSettingRepository
{
    public UserSettingRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<UserSetting> GetByUserId(int userId)
    {
        return await _context.UserSettings
            .SingleAsync(us => us.UserId == userId);
    }
}