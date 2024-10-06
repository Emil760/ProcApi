using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class UserSettingRepository : GenericRepository<UserSetting, int>, IUserSettingRepository
{
    public UserSettingRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<UserSetting> GetByUserId(int userId)
    {
        return await _context.UserSettings
            .SingleAsync(us => us.Id == userId);
    }
}