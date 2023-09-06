using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts;

public interface IUserSettingRepository : IGenericRepository<UserSetting>
{
    Task<UserSetting> GetByUserId(int userId);
}