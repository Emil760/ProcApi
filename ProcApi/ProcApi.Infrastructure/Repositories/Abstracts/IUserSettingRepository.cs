using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IUserSettingRepository : IGenericRepository<UserSetting, int>
{
    Task<UserSetting> GetByUserId(int userId);
}